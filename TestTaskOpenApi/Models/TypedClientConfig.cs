namespace TestTaksOpenApi.Models;

public class TypedClientConfig : ITypedClientConfig
{
    public TypedClientConfig(IConfiguration configuration)
    {
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));
        configuration.Bind("TypedClient", this);
    }

    public Uri BaseUrl { get; set; }

    public int Timeout { get; set; }
}

public interface ITypedClientConfig
{
}