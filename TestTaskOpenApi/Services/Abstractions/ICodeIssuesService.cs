using TestTaksOpenApi.Models;

namespace TestTaksOpenApi.Services.Abstractions;

public interface ICodeIssuesService
{
    Task<List<GeneratedTextInfo>> GetCodeIssues(string code);
}