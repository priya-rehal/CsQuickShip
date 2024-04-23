using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using Registration.Application.Commands.FedEx;
using Registration.Application.DTOs;
using Registration.Application.ErrorDto;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public class RegisterFedExCredentialsCommandHandler : IRequestHandler<FedexRegisterCredentialCommand, RegisterCredentialResponse>
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly IConfiguration _configuration;

    public RegisterFedExCredentialsCommandHandler(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<RegisterCredentialResponse> Handle(FedexRegisterCredentialCommand request, CancellationToken cancellationToken)
    {
        try
        {
            string accessToken = await GetAccessToken(cancellationToken);
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                /* _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {await GetAccessToken(cancellationToken)}");*/
                // Set authorization header with the access token
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                // Serialize the request object to JSON
                var content = new StringContent(JsonSerializer.Serialize(request._register), Encoding.UTF8, "application/json");
                // Send a POST request to the FedEx API with the serialized content
                HttpResponseMessage response = await _httpClient.PostAsync($"{_configuration["FedexBaseUrl"]}/irc/v1/customerkeys", content, cancellationToken);
                // Ensure the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content to a RegisterCredentialResponse object
                    using var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);
                    return await JsonSerializer.DeserializeAsync<RegisterCredentialResponse>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, cancellationToken)
                        ?? throw new Exception("Deserialization failed: RegisterCredentialResponse was null.");
                }
                else
                {
                    throw new Exception("Failed to Create the customer credentials.");
                }

            }
            else
            {
                throw new Exception("Failed to get the accesstoken token is null");
            }
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Failed to register FedEx credentials: {ex.Message}");
        }
    }

    // Method to get the access token from FedEx authentication API
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
                // Deserialize the response content to an AuthResponseDto object and return the access token
                var oAuthResponse = JsonSerializer.Deserialize<AuthResponseDto>(await response.Content.ReadAsStringAsync(cancellationToken));
                return oAuthResponse?.access_token ?? throw new Exception("Failed to get access token");
            }
            else
            {
                throw new Exception($"Failed to get the token: {response.ReasonPhrase}");
            }

        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Failed to get access token: {ex.Message}");
        }
    }
}

public class AuthResponseDto
{
    public string? access_token { get; set; }
}
public class ErrorResponseDto
{
    public string? Message { get; set; }
}
