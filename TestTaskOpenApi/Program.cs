using System.Net.Http.Headers;
using TestTaksOpenApi.Models;
using TestTaksOpenApi.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TestTaksOpenApi.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
builder.Services.AddSwaggerGen();

services.AddControllers();
services.AddControllers().AddNewtonsoftJson(o =>
{
    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    o.SerializerSettings.Formatting = Formatting.Indented;
});
services.AddSingleton<ITypedClientConfig, TypedClientConfig>();
services.AddScoped<ICodeIssuesService, CodeImprovementService>();
services.AddScoped<IOpenApiIntegrationService, OpenApiIntegrationService>();
services.AddHttpClient<IOpenApiIntegrationService, OpenApiIntegrationService>().ConfigureHttpClient(
    (serviceProvider, httpClient) =>
    {
        httpClient.BaseAddress = new Uri(configuration["OpenApiUrl"]);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration["OpenApiToken"]);
    });
var app = builder.Build();
app.UseSwagger();
app.UseRouting();
app.MapControllers();
app.UseSwaggerUI();
app.Run();