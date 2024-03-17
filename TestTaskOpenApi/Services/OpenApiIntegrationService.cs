using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TestTaksOpenApi.Models;
using TestTaksOpenApi.Services.Abstractions;

namespace TestTaksOpenApi.Services;

public class OpenApiIntegrationService : IOpenApiIntegrationService
{
    private readonly HttpClient _httpClient;

    public OpenApiIntegrationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<OpenApiResponse> GetAnswer(OpenApiRequest question)
    {
        var json = JsonConvert.SerializeObject(question, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/v1/chat/completions", httpContent);
        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new Exception("Error from OpenApi: " + result);

        return JsonConvert.DeserializeObject<OpenApiResponse>(result);
    }
}