
using Fedex.Domain.ConfigurationModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Fedex.Application.ClientFactory;
public class BaseClientFactory<TRequest, TResponse> : IBaseClientFactory<TRequest, TResponse>
         where TRequest : class 
         where TResponse : class
{
    private readonly HttpClient _client;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JwtTokenConfiguration _jwtToken;


    public BaseClientFactory(IHttpClientFactory httpClientFactory, IOptions<JwtTokenConfiguration> options) 
        => (_httpClientFactory, _jwtToken, _client) = (httpClientFactory, options.Value, httpClientFactory.CreateClient());
    

    private async Task<TResponse?> CreateClientAsync(string urlPath, TRequest requestBody,
                  HttpMethod httpMethod,
                  CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(urlPath))
        {
            throw new ArgumentNullException(nameof(urlPath));
        }
        if (requestBody == null)
        {
            throw new ArgumentNullException(nameof(requestBody));
        }

        HttpRequestMessage request = new HttpRequestMessage(httpMethod, urlPath);
        // Add required headers
        AddHeader(requestBody, ref request);

        try
        {
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonDeserializeObject(response);
            }
            else
            {
                Task<string> errorContent = response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code: {response.StatusCode}. Error: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating client: {ex.Message}", ex);
        }
    }

    private TResponse? CreateClient(string urlPath, TRequest requestBody,
                       HttpMethod httpMethod, CancellationToken cancellationToken )
    {
        if (string.IsNullOrEmpty(urlPath)) 
        {
            throw new ArgumentNullException(nameof(urlPath)); 
        }
        if (requestBody == null)
        {
            throw new ArgumentNullException(nameof(requestBody));
        }
    
        HttpRequestMessage request = new HttpRequestMessage(httpMethod, urlPath);
        // Add required headers
        AddHeader(requestBody, ref request);

        try
        {
            HttpResponseMessage response = _client.Send(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonDeserializeObject(response);
            }
            else
            {
                Task<string> errorContent = response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code: {response.StatusCode}. Error: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating client: {ex.Message}", ex);
        }

    }

    private void AddHeader(TRequest requestBody, ref HttpRequestMessage request)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _jwtToken.Token);
        request.Headers.Add("x-customer-transaction-id", Guid.NewGuid().ToString()); // Generate unique transaction ID
        request.Headers.Add("X-locale", "en_US");
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        };
        request.Content = new StringContent(JsonConvert.SerializeObject(requestBody, settings), Encoding.UTF8, "application/json");
    }

    private TResponse? JsonDeserializeObject(HttpResponseMessage httpResponse)
    {
        if (httpResponse.StatusCode==System.Net.HttpStatusCode.OK)
        {
            Task<string> jsonString = httpResponse.Content.ReadAsStringAsync();
            if (jsonString != null)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                return JsonConvert.DeserializeObject<TResponse>(jsonString.Result, settings);
            }
        }
        return null;
    }

    
    public async Task<TResponse?> SendAsync(string urlPath,
        TRequest requestbody, HttpMethod httpMethod,
        CancellationToken cancellationToken) => await CreateClientAsync(urlPath, requestbody, httpMethod, cancellationToken);
    

    public TResponse? Send(string urlPath,
        TRequest requestbody, HttpMethod httpMethod,
        CancellationToken cancellationToken) =>  CreateClient(urlPath, requestbody, httpMethod, cancellationToken);
    
}

