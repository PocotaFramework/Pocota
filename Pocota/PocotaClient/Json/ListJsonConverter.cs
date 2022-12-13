using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Context;
using Net.Leksi.Pocota.Client.Core;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Client.Json;

internal class ListJsonConverter<T> : JsonConverter<T> where T : class
{
    private static readonly MethodInfo? _clear;
    private static readonly MethodInfo? _add;
    private static readonly MethodInfo? _removeAt;
    private static readonly PropertyInfo? _count;
    private static readonly PropertyInfo? _items;

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
                else if ("RemoveAt".Equals(m.Name) && _removeAt is null)
                {
                    _removeAt = m;
                }
                else if ("Clear".Equals(m.Name) && _removeAt is null)
                {
                    _clear = m;
                }
            }
            foreach (var p in now.GetProperties())
            {
                if ("Count".Equals(p.Name) && _count is null)
                {
                    _count = p;
                }
                else if ("Items".Equals(p.Name) && _count is null)
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
        _core = (_services.GetRequiredService<IPocota>() as PocotaCore)!;
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
            result = (T?)Activator.CreateInstance(typeof(T));
        }

        object?[] value = new object[1];
        object?[] index = new object[1];

        if (context.CallContext?.DispatcherWrapper is { })
        {
            context.CallContext.DispatcherWrapper.Invoke(() => _clear!.Invoke(result, null));
        }
        else
        {
            _clear!.Invoke(result, null);
        }

        while (reader.Read())
        {
            if (reader.TokenType is JsonTokenType.EndArray)
            {
                break;
            }
            value[0] = JsonSerializer.Deserialize(ref reader, itemType, options);
            if (context.CallContext?.DispatcherWrapper is { })
            {
                context.CallContext.DispatcherWrapper.Invoke(() => _add!.Invoke(result, value));
            }
            else
            {
                _add!.Invoke(result, value);
            }
        }
        return result;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            object[] index = new object[1];
            writer.WriteStartArray();

            int count = (int)_count!.GetValue(value)!;
            for (int i = 0; i < count; ++i)
            {
                index[0] = i;
                object? item = _items!.GetValue(value, index);
                JsonSerializer.Serialize(writer, item, options);
            }
            writer.WriteEndArray();
        }
    }
}