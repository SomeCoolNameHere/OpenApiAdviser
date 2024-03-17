using TestTaksOpenApi.Models;

namespace TestTaksOpenApi.Services.Abstractions;

public interface IOpenApiIntegrationService
{
    Task<OpenApiResponse> GetAnswer(OpenApiRequest question);
}