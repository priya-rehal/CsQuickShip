using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Registration.Application.DTOs;
using Registration.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Handler.FedExCommandHandler;
public class GetAccessTokenHandler : IRequestHandler<GetAccessTokenQuery, string>
{
    private static readonly HttpClient client = new HttpClient();
    private readonly IConfiguration _configuration;
    public GetAccessTokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<string> Handle(GetAccessTokenQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Clear any existing default request headers
            client.DefaultRequestHeaders.Clear();
            // Add the Accept header to specify that the response should be in JSON format
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            // Define the request body as a FormUrlEncodedContent object containing the grant_type, client_id, and client_secret parameters
            var requestBody = new FormUrlEncodedContent(new[]
            {
    new KeyValuePair<string, string>("grant_type", "client_credentials"),
    new KeyValuePair<string, string>("client_id", request.clientId),
    new KeyValuePair<string, string>("client_secret", request.clientSecret)
});

            // Send a POST request to the OAuth token endpoint to obtain an access token
            var response = await client.PostAsync(_configuration["FedexAuthUrl"], requestBody);

            // Read the response content as a string
            var responseContent = await response.Content.ReadAsStringAsync();

            // If the response was successful (i.e., had a status code of 2xx), deserialize the JSON response content into an AuthResponseDto object
            if (response.IsSuccessStatusCode)
            {
                var oAuthResponse = JsonConvert.DeserializeObject<AuthResponseDto>(responseContent);

                // Return the access token from the AuthResponseDto object
                return oAuthResponse.access_token;
            }
            // If the response was not successful, throw an exception with the error message from the response content
            else
            {
                throw new Exception("Failed to get access token: " + responseContent);
            }
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

