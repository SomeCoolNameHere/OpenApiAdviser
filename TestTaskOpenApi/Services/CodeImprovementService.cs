using TestTaksOpenApi.Models;
using TestTaksOpenApi.Services.Abstractions;

namespace TestTaksOpenApi.Services;

public class CodeImprovementService : ICodeIssuesService
{
    private readonly IOpenApiIntegrationService _integrationService;

    public CodeImprovementService(IOpenApiIntegrationService integrationService)
    {
        _integrationService = integrationService;
    }

    public async Task<List<GeneratedTextInfo>> GetCodeIssues(string question)
    {
        var request = new OpenApiRequest
        {
            Model = OpenApiConsts.ModelType,
            Messages = new List<Message>
            {
                new()
                {
                    Content = OpenApiConsts.SystemRole,
                    Role = Role.System
                },
                new()
                {
                    Content = question,
                    Role = Role.User
                }
            }
        };
        var answer = await _integrationService.GetAnswer(request);

        return answer.Choices;
    }
}