using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public interface IPocoContext
{
    JsonSerializerOptions BindJsonSerializerOptions(JsonSerializerOptions? options = null);

    void AddJsonConverters(Type targetType, JsonSerializerOptions jsonSerializerOptions);
    void AddJsonConverters<TTarget>(JsonSerializerOptions jsonSerializerOptions);

}
