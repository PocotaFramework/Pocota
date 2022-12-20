using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public interface IPocoContext
{
    void Build(Type type, BuildingOptions options);
    void Build<T>(BuildingOptions options);

    IPocoTraversalContext? GetTraversalContext(JsonSerializerOptions options);

    JsonSerializerOptions BindJsonSerializerOptions(JsonSerializerOptions? options = null);

    void AddJsonConverters(Type targetType, JsonSerializerOptions jsonSerializerOptions);
    void AddJsonConverters<TTarget>(JsonSerializerOptions jsonSerializerOptions);

}
