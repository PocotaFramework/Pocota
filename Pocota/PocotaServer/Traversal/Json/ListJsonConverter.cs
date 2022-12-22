using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Server;

internal class ListJsonConverter<T> : JsonConverter<T> where T : class
{
    private static readonly MethodInfo? _add;
    private static readonly PropertyInfo? _items;
    private static readonly PropertyInfo? _count;

    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;
    private readonly Type _itemType;
    private readonly PocoContext _pocoContext;


    static ListJsonConverter()
    {
        Queue<Type> types = new();
        types.Enqueue(typeof(T));
        while (types.Count > 0)
        {
            Type now = types.Dequeue();
            foreach (var m in now.GetMethods())
            {
                if ("Add".Equals(m.Name) && _add is null)
                {
                    _add = m;
                }
            }
            foreach (var p in now.GetProperties())
            {
                if ("Count".Equals(p.Name) && _count is null)
                {
                    _count = p;
                }
                else if ("Items".Equals(p.Name) && _items is null)
                {
                    _items = p;
                }
            }
            foreach (var intf in now.GetInterfaces())
            {
                types.Enqueue(intf);
            }
            if (now != typeof(object) && now.BaseType is { })
            {
                types.Enqueue(now.BaseType);
            }
        }
    }

    public ListJsonConverter(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
        _itemType = typeof(T).GetGenericArguments()[0];
        _pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is JsonTokenType.Null)
        {
            return null;
        }
        if (!(reader.TokenType is JsonTokenType.StartArray))
        {
            throw new JsonException();
        }

        if (!_core.TryGetPocoJsonContext(options, out PocoTraversalContext? context))
        {
            throw new InvalidOperationException("Unproper using!");
        }

        T? result = (T?)context!.Target;
        context!.Target = null;

        Type itemType = context.ItemType is { } ? context.ItemType : _itemType;
        context.ItemType = null;

        if (result is null)
        {
            result = (T?)Activator.CreateInstance(typeof(List<>).MakeGenericType(new Type[] { _itemType }));
        }

        object?[] index = new object[1];

        while (reader.Read())
        {
            if (reader.TokenType is JsonTokenType.EndArray)
            {
                break;
            }
            index[0] = JsonSerializer.Deserialize(ref reader, itemType, options);
            _add!.Invoke(result, index);
        }
        return result;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (!(_pocoContext.GetTraversalContext(options) is PocoTraversalContext context))
        {
            throw new InvalidOperationException("Unproper using!");
        }

        object[] index = new object[1];
        writer.WriteStartArray();
        bool isHighLevel = context.IsHighLevel;
        context.IsHighLevel = false;

        for (int i = 0; ; ++i)
        {
            context.IsHighLevel = isHighLevel;
            index[0] = i;
            try
            {
                object? item = _items!.GetValue(value, index);
                JsonSerializer.Serialize(writer, item, options);
            }
            catch (TargetInvocationException tiex)
            {
                if(tiex.InnerException is ArgumentOutOfRangeException)
                {
                    break;
                }
                throw;
            }
        }
        writer.WriteEndArray();

    }
}