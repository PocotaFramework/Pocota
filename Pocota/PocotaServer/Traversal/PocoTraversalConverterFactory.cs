using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Server;

internal class PocoTraversalConverterFactory : JsonConverterFactory
{
    internal const string Key = "$key";
    internal const string Id = "$id";
    internal const string Ref = "$ref";
    internal const string Class = "$cl";
    internal const string Interface = "$in";

    protected readonly IServiceProvider _services;
    protected readonly PocotaCore _core;
    protected readonly IPocoContext _pocoContext;

    public PocoTraversalConverterFactory(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
        _pocoContext = _services.GetRequiredService<IPocoContext>();
    }

    public override bool CanConvert(Type typeToConvert)
    {
        if (typeof(IEnumerable).IsAssignableFrom(typeToConvert) && typeToConvert.IsGenericType)
        {
            return CanConvert(typeToConvert.GetGenericArguments()[0]);
        }
        return _core.GetActualType(typeToConvert) is Type;
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        bool building = (_pocoContext.GetTraversalContext(options) as PocoTraversalContext)!.IsBuilding;
        if (typeof(IEnumerable).IsAssignableFrom(typeToConvert) && typeToConvert.IsGenericType)
        {
            if (building)
            {
                return (JsonConverter?)Activator.CreateInstance(
                    typeof(ListBuildingJsonConverter<>).MakeGenericType(new Type[] { typeToConvert }),
                    new object[] { _services }
                );
            }
            return (JsonConverter?)Activator.CreateInstance(
                typeof(ListJsonConverter<>).MakeGenericType(new Type[] { typeToConvert }),
                new object[] { _services }
            );
        }
        if (building)
        {
            return (JsonConverter?)Activator.CreateInstance(
                typeof(PocoBuildingJsonConverter<>).MakeGenericType(new Type[] { typeToConvert }),
                new object[] { _services }
            );
        }
        return (JsonConverter?)Activator.CreateInstance(
            typeof(PocoJsonConverter<>).MakeGenericType(new Type[] { typeToConvert }),
            new object[] { _services }
        );
    }
}
