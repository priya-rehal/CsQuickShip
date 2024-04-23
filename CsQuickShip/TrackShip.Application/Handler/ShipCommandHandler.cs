
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrackShip.Application.Command;
using TrackShip.Application.DTOs;


namespace TrackShip.Application.Handler;
public class ShipCommandHandler : IRequestHandler<ShipCommand, CsShipResponseDTO>
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient = new HttpClient();
    public ShipCommandHandler(IConfiguration configuration)
    {
        _configuration = configuration;

    }
    public async Task<CsShipResponseDTO> Handle(ShipCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request == null || request._ShipRequest == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            string accessToken = await GetAccessToken(cancellationToken);
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("Access token is null or empty.");
            }
            FedexRequest fedexRequest = MapToFedexRequest(request);

            string serializeData = JsonConvert.SerializeObject(fedexRequest, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            using HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_configuration["FedexBaseUrl"]}/ship/v1/shipments");
            requestMessage.Content = new StringContent(serializeData, Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await _httpClient.SendAsync(requestMessage, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                FedexResponse fedExShipResponse = JsonConvert.DeserializeObject<FedexResponse>(responseBody);
                CsShipResponseDTO responseDTO = new CsShipResponseDTO();
                {
                    responseDTO.TransactionId = fedExShipResponse?.TransactionId;
                    responseDTO.Address = new ResponseAddressDto
                    {
                        FromAddress = new CsAddressDto()
                        {
                            Address1 = request?._ShipRequest?.RequestedShipment?.ToAddress?.Address?.StreetLines?.FirstOrDefault(),
                            Address2 = request?._ShipRequest?.RequestedShipment?.ToAddress?.Address?.StreetLines?.ElementAtOrDefault(1),
                            City = request._ShipRequest.RequestedShipment.FromAddress.Address.City,
                            PostalCode = request._ShipRequest.RequestedShipment.FromAddress.Address.PostalCode,
                            CountryCode = request._ShipRequest.RequestedShipment.FromAddress.Address.CountryCode,
                            PersonName = request._ShipRequest.RequestedShipment.FromAddress.Contact.PersonName,
                            PhoneNumber = request._ShipRequest.RequestedShipment.FromAddress.Contact.PhoneNumber,
                            CompanyName = request._ShipRequest.RequestedShipment.FromAddress.Contact.CompanyName,
                        },
                        ToAddress = new CsAddressDto()
                        {
                            Address1 = request?._ShipRequest?.RequestedShipment?.ToAddress?.Address?.StreetLines?.FirstOrDefault(),
                            Address2 = request?._ShipRequest?.RequestedShipment?.ToAddress?.Address?.StreetLines?.ElementAtOrDefault(1),
                            City = request._ShipRequest.RequestedShipment.ToAddress.Address.City,
                            PostalCode = request._ShipRequest.RequestedShipment.ToAddress.Address.PostalCode,
                            CountryCode = request._ShipRequest.RequestedShipment.ToAddress.Address.CountryCode,
                            PersonName = request._ShipRequest.RequestedShipment.ToAddress.Contact.PersonName,
                            PhoneNumber = request._ShipRequest.RequestedShipment.ToAddress.Contact.PhoneNumber,
                            CompanyName = request._ShipRequest.RequestedShipment.ToAddress.Contact.CompanyName,
                        },

                    };
                    responseDTO.Packages = new List<CsResponsePackages>();

                    foreach (var ts in fedExShipResponse?.Output?.TransactionShipments ?? Enumerable.Empty<TransactionShipments>())
                    {
                        foreach (var packingId in ts.CompletedShipmentDetail?.CompletedPackageDetails ?? Enumerable.Empty<CompletedPackageDetails>())
                        {
                            var csResponsePackage = new CsResponsePackages
                            {
                                PackageId = packingId.SequenceNumber,
                                Labels = new List<Label>()
                            };
                            List<ShipmentRateDetails>? shipmentRateDetails = ts?.CompletedShipmentDetail?.ShipmentRating?.ShipmentRateDetails;
                            if (shipmentRateDetails != null && shipmentRateDetails.Any())
                            {
                                var firstShipmentRateDetail = shipmentRateDetails.First();
                                csResponsePackage.TotalBillingWeight = new ResponseWeight
                                {
                                    Units = firstShipmentRateDetail?.TotalBillingWeight?.Units,
                                    Value = firstShipmentRateDetail?.TotalBillingWeight?.Value
                                };
                            }

                            foreach (var pr in ts?.PieceResponses ?? Enumerable.Empty<PieceResponses>())
                            {
                                foreach (var package in pr?.PackageDocuments ?? Enumerable.Empty<ShipmentDocuments>())
                                {
                                    if (package != null)
                                    {
                                        csResponsePackage.Labels.Add(new Label
                                        {
                                            DocType = package.DocType,
                                            Url = package.Url,
                                            EncodedLabel = package.EncodedLabel
                                        });
                                    }
                                }
                            }

                            responseDTO.Packages.Add(csResponsePackage);
                        }
                    }

                }

                return responseDTO;
            }
            else
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to create shipment. Status code: {response.StatusCode}. Response: {responseBody}");
            }

        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            throw new Exception("Failed to create shipment.", ex);
        }
    }

    private FedexRequest MapToFedexRequest(ShipCommand request)
    {
        FedexRequest fedexRequest = new FedexRequest
        {
            AccountNumber = new AccountNumber
            {
                Value = request?._ShipRequest?.AccountNumber?.Value,
            },
            LabelResponseOptions = request?._ShipRequest?.LabelResponseOptions,
            RequestedShipment = new RequestedShipment
            {
                Shipper = new Shipper
                {
                    Address = new Address
                    {
                        City = request._ShipRequest.RequestedShipment.FromAddress.Address.City,
                        StreetLines = request._ShipRequest.RequestedShipment.FromAddress.Address.StreetLines,
                        CountryCode = request._ShipRequest.RequestedShipment.FromAddress.Address.CountryCode,
                        PostalCode = request._ShipRequest.RequestedShipment.FromAddress.Address.PostalCode,
                        StateOrProvinceCode = request._ShipRequest.RequestedShipment.FromAddress.Address.StateOrProvinceCode,
                    },
                    Contact = new Contact
                    {
                        PersonName = request._ShipRequest.RequestedShipment.FromAddress.Contact.PersonName,
                        PhoneNumber = request._ShipRequest.RequestedShipment.FromAddress.Contact.PhoneNumber,
                        CompanyName = request._ShipRequest.RequestedShipment.FromAddress.Contact.CompanyName,
                    }
                },
                Recipients = new List<Recipient>
                {
                    new Recipient()
                    {
                    Address = new Address
                    {
                        City = request._ShipRequest.RequestedShipment.ToAddress.Address.City,
                        StreetLines = request._ShipRequest.RequestedShipment.ToAddress.Address.StreetLines,
                        CountryCode = request._ShipRequest.RequestedShipment.ToAddress.Address.CountryCode,
                        PostalCode = request._ShipRequest.RequestedShipment.ToAddress.Address.PostalCode,
                        StateOrProvinceCode = request._ShipRequest.RequestedShipment.ToAddress.Address.StateOrProvinceCode,
                    },
                    Contact = new Contact
                    {
                        PersonName = request._ShipRequest.RequestedShipment.ToAddress.Contact.PersonName,
                        PhoneNumber = request._ShipRequest.RequestedShipment.ToAddress.Contact.PhoneNumber,
                        CompanyName = request._ShipRequest.RequestedShipment.ToAddress.Contact.CompanyName
                    }
                 }

                },
                PickupType = request._ShipRequest.RequestedShipment.PickupType,
                ServiceType = request._ShipRequest.RequestedShipment.ServiceType,
                PackagingType = request._ShipRequest.RequestedShipment.PackagingType,
                ShipDatestamp = request._ShipRequest.RequestedShipment.ShipDatestamp,
                ShippingChargesPayment = new ShippingChargesPayment
                {
                    PaymentType = request._ShipRequest.RequestedShipment.ShippingChargesPayment.PaymentType,
                },
                RequestedPackageLineItems = request._ShipRequest.RequestedShipment.RequestedPackageLineItems.Select(rp => new RequestedPackageLineItem
                {
                    Weight = new Weight
                    {
                        Units = rp.Weight.Units,
                        Value = rp.Weight.Value
                    }
                }).ToList(),
                LabelSpecification = new LabelSpecification
                {
                    LabelStockType = request._ShipRequest.RequestedShipment.LabelSpecification.LabelStockType,
                    ImageType = request._ShipRequest.RequestedShipment.LabelSpecification.ImageType,
                },
                /*ShipmentSpecialServices = new ShipmentSpecialServices
                {

                },*/

            }
        };
        return fedexRequest;
    }

    private async Task<string> GetAccessToken(CancellationToken cancellationToken)
    {
        try
        {
            // Check if the configuration keys are present
            Dictionary<string, string> requestBody = new Dictionary<string, string>
            {
              { "grant_type", "client_credentials" },
              { "client_id", _configuration["client_id"] ?? throw new Exception("Client ID configuration is null.")},
              { "client_secret", _configuration["client_secret"] ?? throw new Exception("Client secret configuration is null.")}
            };
            // Send a POST request to the FedEx authentication API
            FormUrlEncodedContent requestContent = new FormUrlEncodedContent(requestBody);
            HttpResponseMessage response = await _httpClient.PostAsync(_configuration["FedexAuthUrl"], requestContent, cancellationToken);
            // Ensure the response is successful
            if (response.IsSuccessStatusCode)
            {
                string tokenResponse = await response.Content.ReadAsStringAsync();
                // Deserialize the response content to an AuthResponseDto object and return the access token
                AuthResponseDto tokenObj = JsonConvert.DeserializeObject<AuthResponseDto>(tokenResponse);
                return tokenObj?.access_token ?? throw new Exception("Failed to the get accesstoken.");
            }
            else
            {
                throw new Exception("Failed to the get accesstoken.");
            }
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Failed to get access token: {ex.Message}");
        }
    }
}




