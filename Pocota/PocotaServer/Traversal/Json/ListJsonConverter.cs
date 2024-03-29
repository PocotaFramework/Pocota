﻿using Net.Leksi.Pocota.Common;
using System;
using System.Collections;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Server;

internal class ListJsonConverter<T> : ListJsonConverterBase<T> where T : class
{
    private static readonly Type _itemType = typeof(T).GetGenericArguments()[0];

    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;
    private readonly PocoContext _pocoContext;


    public ListJsonConverter(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
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

        if (result is null)
        {
            result = (T?)Activator.CreateInstance(typeof(List<>).MakeGenericType(new Type[] { _itemType }));
        }

        if(result is { })
        {
            ListMembersHolder membersHolder = GetListMembersHolder(result.GetType());
            object?[] index = new object[1];

            while (reader.Read())
            {
                if (reader.TokenType is JsonTokenType.EndArray)
                {
                    break;
                }
                index[0] = JsonSerializer.Deserialize(ref reader, _itemType, options);
                membersHolder.Add!.Invoke(result, index);
            }
            return result;
        }

        return null;

    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (!(_pocoContext.GetTraversalContext(options) is PocoTraversalContext context))
        {
            throw new InvalidOperationException("Unproper using!");
        }

        writer.WriteStartArray();
        bool isHighLevel = context.IsHighLevel;
        context.IsHighLevel = false;

        if (value is IEnumerable values)
        {
            IEnumerator en = values.GetEnumerator();
            while (en.MoveNext())
            {
                context.IsHighLevel = isHighLevel;
                JsonSerializer.Serialize(writer, en.Current, _itemType, options);
            }
        }
        writer.WriteEndArray();

    }
}