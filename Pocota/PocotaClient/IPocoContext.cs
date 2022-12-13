using System.Text.Json;

namespace Net.Leksi.Pocota.Client;

public interface IPocoContext
{
    event EventHandler<EventArgs> TracedPocosChanged;

    ExternalUpdateProcessing ExternalUpdateProcessing { get; set; }
    bool TracePocos { get; set; }
    IDictionary<Type, int> TracedPocos { get; }

    JsonSerializerOptions BindJsonSerializerOptions(
        JsonSerializerOptions? options = null, 
        JsonSerializerOptionsKind optionsKind = JsonSerializerOptionsKind.Ordinary
    );
    IPocoTraversalContext? GetTraversalContext(JsonSerializerOptions options);

    void AddJsonConverters(Type targetType, JsonSerializerOptions jsonSerializerOptions);
    void AddJsonConverters<TTarget>(JsonSerializerOptions jsonSerializerOptions);

}
