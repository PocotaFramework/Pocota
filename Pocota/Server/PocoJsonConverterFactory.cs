using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Server;

public class PocoJsonConverterFactory : JsonConverterFactory
{
    private readonly IServiceProvider _services;

    public PocoJsonConverterFactory(IServiceProvider services)
    {
        _services = services;
    }

    public override bool CanConvert(Type typeToConvert)
    {
        return false;
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
