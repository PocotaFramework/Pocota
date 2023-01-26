using System.Text.Json;

namespace Net.Leksi.Pocota.Client;

public interface IPocoContext
{
    event EventHandler<EventArgs> TracedPocosChanged;
    event NotifyModifiedPocosChangedEventHandler ModifiedPocosChanged;

    bool TracePocos { get; set; }
    IDictionary<Type, int> TracedPocos { get; }
    ICollection<IEntity> ModifiedPocos { get; }

    JsonSerializerOptions BindJsonSerializerOptions(
        JsonSerializerOptions? options = null, 
        JsonSerializerOptionsKind optionsKind = JsonSerializerOptionsKind.Ordinary
    );
    IPocoTraversalContext? GetTraversalContext(JsonSerializerOptions options);

    void AddJsonConverters(Type targetType, JsonSerializerOptions jsonSerializerOptions);
    void AddJsonConverters<TTarget>(JsonSerializerOptions jsonSerializerOptions);

    bool TryGetSource(Type type, object[] primaryKey, out object? value);
}
