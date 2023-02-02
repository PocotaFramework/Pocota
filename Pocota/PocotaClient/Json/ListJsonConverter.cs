using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Context;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using System.Text.Json;

namespace Net.Leksi.Pocota.Client.Json;

internal class ListJsonConverter<T> : ListJsonConverterBase<T> where T : class
{
    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;
    private readonly Type _itemType;
    private readonly PocoContext _pocoContext;

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

        if(result is { })
        {
            ListMembersHolder membersHolder = GetListMembersHolder(result.GetType());

            object?[] value = new object[1];
            object?[] index = new object[1];

            if (membersHolder.Clear is { })
            {
                if (context.CallContext?.DispatcherWrapper is { })
                {
                    context.CallContext.DispatcherWrapper.Invoke(() => membersHolder.Clear!.Invoke(result, null));
                }
                else
                {
                    membersHolder.Clear!.Invoke(result, null);
                }
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
                    context.CallContext.DispatcherWrapper.Invoke(() => membersHolder.Add!.Invoke(result, value));
                }
                else
                {
                    membersHolder.Add!.Invoke(result, value);
                }
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
            ListMembersHolder membersHolder = GetListMembersHolder(value.GetType());

            object[] index = new object[1];
            writer.WriteStartArray();

            int count = (int)membersHolder.Count!.GetValue(value)!;
            for (int i = 0; i < count; ++i)
            {
                index[0] = i;
                object? item = membersHolder.Item!.GetValue(value, index);
                JsonSerializer.Serialize(writer, item, options);
            }
            writer.WriteEndArray();
        }
    }


}