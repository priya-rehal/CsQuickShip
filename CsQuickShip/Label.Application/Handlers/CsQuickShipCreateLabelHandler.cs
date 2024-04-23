using AutoMapper;
using Label.Application.Commands;
using Label.Application.DTOs.AccessTokenDTOs;
using Label.Application.DTOs.CsQuickShipDTOs;
using Label.Application.DTOs.LabelDTOs;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
namespace Label.Application.Handlers;
public class CsQuickShipCreateLabelHandler : IRequestHandler<CsQuickShipCreateLabelCommand, CsQuickShipResponse>
{
    private HttpClient _httpClient = new HttpClient();
    private readonly IConfiguration _configuration;
    public string FedexCreateLabelBaseUrl { get; set; } = "";

    public CsQuickShipCreateLabelHandler()
    {
        _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build().GetSection("FedexCredentials");
        FedexCreateLabelBaseUrl = _configuration.GetSection("fedexCreateLableUrl").Value ?? "";
    }
    /// <summary>
    /// Handler to handle create label request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CsQuickShipResponse> Handle(CsQuickShipCreateLabelCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.CsQuickShipRequest == null)
            {
                throw new Exception("CsQuickShipRequest can't be null.");
            }
            #region Parsing request with fedex create label api
            FedexCreateLabelRequest fedexCreateLabelRequest = new FedexCreateLabelRequest()
            {
                LabelResponseOptions = request?.CsQuickShipRequest?.LabelResponseOptions,
                AccountNumber = new AccountNumber
                {
                    Value = request?.CsQuickShipRequest?.AccountNumber?.Value
                },
                RequestedShipment = new RequestedShipment()
                {
                    Shipper = new Shipper()
                    {
                        Address = new Address()
                        {
                            StreetLines = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Address?.StreetLines,
                            City = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Address?.City,
                            StateOrProvinceCode = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Address?.StateOrProvinceCode,
                            PostalCode = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Address?.PostalCode,
                            CountryCode = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Address?.CountryCode,
                            Residential = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Address?.Residential,
                        },
                        Contact = new Contact()
                        {
                            EmailAddress = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Contact?.EmailAddress,
                            PersonName = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Contact?.PersonName,
                            PhoneExtension = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Contact?.PhoneExtension,
                            PhoneNumber = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Contact?.PhoneNumber,
                            CompanyName = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Contact?.CompanyName
                        }
                    },
                    Recipients = new List<Recipient>()
                            {
                                new Recipient()
                                {
                                    Address= new Address(){
                                        StateOrProvinceCode=request?.CsQuickShipRequest?.Shipment?.ToAddress?.Address?.StateOrProvinceCode,
                                        PostalCode=request?.CsQuickShipRequest?.Shipment?.ToAddress?.Address?.PostalCode,
                                        CountryCode=request ?.CsQuickShipRequest ?.Shipment ?.ToAddress ?.Address ?.CountryCode,
                                        Residential=request ?.CsQuickShipRequest ?.Shipment ?.ToAddress ?.Address ?.Residential,
                                        StreetLines=request ?.CsQuickShipRequest ?.Shipment ?.ToAddress ?.Address ?.StreetLines,
                                        City=request ?.CsQuickShipRequest ?.Shipment ?.ToAddress ?.Address ?.City,
                                    },
                                    Contact=new Contact(){
                                        PersonName=request?.CsQuickShipRequest?.Shipment?.ToAddress?.Contact?.PersonName,
                                        EmailAddress=request ?.CsQuickShipRequest ?.Shipment ?.ToAddress ?.Contact ?.EmailAddress,
                                        PhoneExtension=request ?.CsQuickShipRequest ?.Shipment ?.ToAddress ?.Contact ?.PhoneExtension,
                                        PhoneNumber=request ?.CsQuickShipRequest ?.Shipment ?.ToAddress ?.Contact ?.PhoneNumber,
                                        CompanyName=request ?.CsQuickShipRequest ?.Shipment ?.ToAddress ?.Contact ?.CompanyName,
                                    }
                                }
                            },
                    PickupType = request?.CsQuickShipRequest?.Shipment?.PickupType,
                    ServiceType = request?.CsQuickShipRequest?.Shipment?.ServiceLevelType,
                    PackagingType = request?.CsQuickShipRequest?.Shipment?.PackagingType,
                    ShippingChargesPayment = new ShippingChargesPaymentDto()
                    {
                        PaymentType = request?.CsQuickShipRequest?.Shipment?.ShippingChargesPayment?.PaymentType
                    },
                    LabelSpecification = new LabelSpecificationDto()
                    {
                        LabelStockType = request?.CsQuickShipRequest?.Shipment?.LabelSpecification?.LabelStockType,
                        ImageType = request?.CsQuickShipRequest?.Shipment?.LabelSpecification?.ImageType,
                    },
                }
            };
            foreach (var package in request?.CsQuickShipRequest?.Shipment?.Packages ?? new List<CsQuickShipPackagesRequest>())
            {
                if (fedexCreateLabelRequest.RequestedShipment.RequestedPackageLineItems == null)
                {
                    fedexCreateLabelRequest.RequestedShipment.RequestedPackageLineItems = new List<RequestedPackageLineItemDto>();
                }

                fedexCreateLabelRequest.RequestedShipment.RequestedPackageLineItems?.Add(new RequestedPackageLineItemDto()
                {
                    Weight = new Weight()
                    {
                        Units = package?.Weight?.Units,
                        Value = package?.Weight?.Value
                    },
                    PackageSpecialServices = new PackageSpecialServices()
                    {
                        SpecialServiceTypes = package?.PackageSpecialServices?.SpecialServiceTypes,
                        AlcoholDetail = new AlcoholDetail()
                        {
                            AlcoholRecipientType = package?.PackageSpecialServices?.AlcoholDetail?.AlcoholRecipientType
                        },
                    }
                });
            }
            #endregion
            var accessToken = await GetAccessToken();
            if (string.IsNullOrEmpty(accessToken) && fedexCreateLabelRequest == null)
            {
                throw new Exception("No access token is provided");
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonPayload = JsonConvert.SerializeObject(fedexCreateLabelRequest, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                if (jsonPayload != null)
                {
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                    if (content.Headers.ContentType != null)
                    {
                        var response = await client.PostAsync(FedexCreateLabelBaseUrl, content);
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            if (responseContent == null)
                            {
                                throw new Exception("Content is null");
                            }
                            var fedexDeserializedObject = JsonConvert.DeserializeObject<FedexCreateLabelResponse>(responseContent);
                            if (fedexDeserializedObject == null)
                            {
                                throw new Exception("Failed to parse response as FedExSuccessResponse");
                            }

                            #region Parsing the fedex response with cs quick ship response
                            CsQuickShipResponse csQuickShipResponse = new CsQuickShipResponse
                            {
                                AddressFrom = new CsQuickShipAddressResponse()
                                {
                                    City = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Address?.City,
                                    CountryCode = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Address?.CountryCode,
                                    PostalCode = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Address?.PostalCode,
                                    StateOrProvinceCode = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Address?.StateOrProvinceCode,
                                    Residential = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Address?.Residential,
                                    StreetLines = request?.CsQuickShipRequest?.Shipment?.FromAddress?.Address?.StreetLines,
                                },
                                AddressTo = new CsQuickShipAddressResponse()
                                {
                                    City = request?.CsQuickShipRequest?.Shipment?.ToAddress?.Address?.City,
                                    CountryCode = request?.CsQuickShipRequest?.Shipment?.ToAddress?.Address?.CountryCode,
                                    PostalCode = request?.CsQuickShipRequest?.Shipment?.ToAddress?.Address?.PostalCode,
                                    Residential = request?.CsQuickShipRequest?.Shipment?.ToAddress?.Address?.Residential,
                                    StreetLines = request?.CsQuickShipRequest?.Shipment?.ToAddress?.Address?.StreetLines,
                                },
                                Packages = new List<CsQuickShipPackagesResponse>() { }
                            };
                            foreach (var transactionShipments in fedexDeserializedObject?.Output?.TransactionShipments ?? new List<TransactionShipments>())
                            {
                                foreach (var package in transactionShipments?.ShipmentDocuments ?? new List<ShipmentDocuments>())
                                {
                                    csQuickShipResponse.Packages?.Add(new CsQuickShipPackagesResponse()
                                    {
                                        TrackingNumber = package?.TrackingNumber,
                                        EncodedLabel = package?.EncodedLabel,
                                    });
                                }
                            }
                            #endregion

                            return csQuickShipResponse;
                        }
                        else
                        {
                            var errorMessage = $"API call failed with status code: {response.StatusCode}";
                            if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync()))
                            {
                                errorMessage += $"\nResponse: {await response.Content.ReadAsStringAsync()}";
                            }
                            throw new Exception(errorMessage);
                        }
                    }
                    else
                    {
                        throw new Exception("ContentType is null");
                    }
                }
                else
                {
                    throw new Exception("Payload is null");
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    /// <summary>
    /// Method to create access token
    /// </summary>
    /// <returns></returns>
    private async Task<string> GetAccessToken()
    {
        var requestBody = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("client_id", "l771755ff8b6f3411881218cf243677492"),
            new KeyValuePair<string, string>("client_secret", "1d169f69c0b3490c9d336bb33ac14c93")
        });
        var response = await _httpClient.PostAsync("https://apis-sandbox.fedex.com/oauth/token", requestBody);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var deserializedObject = JsonConvert.DeserializeObject<FedexAccessTokenResponse>(content ?? "");
        return deserializedObject?.Access_Token;
    }
}
