using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Core;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Client.Json;

internal class PocoJsonConverterFactory : JsonConverterFactory
{
    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;

    public PocoJsonConverterFactory(IServiceProvider services)
    {
        _services = services;
        _core = (_services.GetRequiredService<IPocota>() as PocotaCore)!;
    }

    public override bool CanConvert(Type typeToConvert)
    {
        if (IsIList(typeToConvert))
        {
            return _core.GetActualType(typeToConvert.GetGenericArguments()[0]) is Type;
        }
        return _core.GetActualType(typeToConvert) is Type;
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (IsIList(typeToConvert))
        {
            return (JsonConverter?)Activator.CreateInstance(
                typeof(ListJsonConverter<>).MakeGenericType(new Type[] { typeToConvert }),
                new object[] { _services }
            );
        }
        return (JsonConverter?)Activator.CreateInstance(
            typeof(PocoJsonConverter<>).MakeGenericType(new Type[] { typeToConvert }),
            new object[] { _services }
        );
    }

    private bool IsIList(Type type)
    {
        return type.IsGenericType && typeof(IList<>).MakeGenericType(type.GetGenericArguments()[0]).IsAssignableFrom(type);
    }
}
