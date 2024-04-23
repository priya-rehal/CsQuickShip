using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TrackShip.Application.DTOs;
using TrackShip.Application.Queries;

namespace TrackShip.Application.Handler;
public class TrackShipmentQueryHandler : IRequestHandler<TrackShipmentQuery, TrackShipmentResponseDto>
{
    HttpClient _httpClient = new HttpClient();
    private readonly IConfiguration _configuration;
    public TrackShipmentQueryHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<TrackShipmentResponseDto> Handle(TrackShipmentQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Asynchronously retrieve the access token using the GetAccessToken method
            string accessToken = await GetAccessToken(cancellationToken);
            // Check if the access token is null or empty
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                // Throw an exception if the access token is null or empty
                throw new Exception("accessToken is null.");
            }
            // Initialize a new HttpRequestMessage object with the POST method and the TrackShipmentUrl from the configuration
            using HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _configuration["TrackShipmentUrl"]);
            // Add the Bearer authentication header with the access token
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            // Serialize the TrackRequest object from the TrackShipmentQuery request to JSON and set it as the content of the request message
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(request._trackRequest), Encoding.UTF8, "application/json");
            // Send the HTTP request asynchronously using the HttpClient and the request message
            using HttpResponseMessage response = await _httpClient.SendAsync(requestMessage, cancellationToken);

            // Check if the HTTP response was successful
            if (response.IsSuccessStatusCode)
            {
                // Deserialize the HTTP response content to a TrackShipmentResponseDto object and return it
                return JsonConvert.DeserializeObject<TrackShipmentResponseDto>(await response.Content.ReadAsStringAsync()) ?? throw new Exception("Failed to get the response");
            }
            // Throw an exception if the HTTP response was not successful
            throw new($"Failed to track shipment: {response.ReasonPhrase}");
        }
        catch (Exception ex)
        {
            // Throw a new exception with the message from the caught exception
            throw new Exception(ex.Message);
        }
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
                AuthResponseDto? tokenObj = JsonConvert.DeserializeObject<AuthResponseDto>(tokenResponse);
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


