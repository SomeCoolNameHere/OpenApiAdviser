using Microsoft.AspNetCore.Mvc;
using TestTaksOpenApi.Models;
using TestTaksOpenApi.Services.Abstractions;

namespace TestTaksOpenApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CodeImprovementController : ControllerBase
{
    private readonly ICodeIssuesService _codeIssuesService;

    public CodeImprovementController(ICodeIssuesService codeIssuesService)
    {
        _codeIssuesService = codeIssuesService;
    }

    [HttpPost]
    public async Task<List<GeneratedTextInfo>> PossibleIssues(CodeIssueRequest code)
    {
        return await _codeIssuesService.GetCodeIssues(OpenApiConsts.CodeIssuesQuestion + code.CodeExample);
    }

    [HttpPost]
    public async Task<List<GeneratedTextInfo>> RefactorCodeIssues(CodeIssueRequest code)
    {
        return await _codeIssuesService.GetCodeIssues(OpenApiConsts.RefactorCodeQuestion + code.CodeExample);
    }
}