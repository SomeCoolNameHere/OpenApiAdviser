using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestTaksOpenApi.Models;

[JsonConverter(typeof(StringEnumConverter))]  
public enum Role
{
    system,user,assistant
}