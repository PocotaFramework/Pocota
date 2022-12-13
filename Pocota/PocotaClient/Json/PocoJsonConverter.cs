using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Context;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using System.Collections;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Client.Json;

internal class PocoJsonConverter<T> : JsonConverter<T>
{
    internal const string Key = "$key";
    internal const string Id = "$id";
    internal const string Ref = "$ref";

    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;
    private readonly PocoContext _pocoContext;

    public PocoJsonConverter(IServiceProvider services)
    {
        _services = services;
        _core = (_services.GetRequiredService<IPocota>() as PocotaCore)!;
        _pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (!_core.TryGetPocoJsonContext(options, out PocoTraversalContext? context))
        {
            throw new InvalidOperationException("Unproper using!");
        }

        if (reader.TokenType is JsonTokenType.Null)
        {
            return default(T);
        }

        if (!(reader.TokenType is JsonTokenType.StartObject))
        {
            throw new JsonException();
        }

        T? result = (T?)context!.Target;

        try
        {
            context!.Target = null;

            string? reference = null;

            while (reader.Read())
            {
                if (reader.TokenType is JsonTokenType.EndObject)
                {
                    break;
                }
                if (!(reader.TokenType is JsonTokenType.PropertyName))
                {
                    throw new JsonException();
                }
                string propertyName = reader.GetString()!;
                bool done = false;
                if (!done && propertyName[0] == '$')
                {
                    if (propertyName.Equals(Id) || propertyName.Equals(Ref))
                    {
                        if (!reader.Read())
                        {
                            throw new JsonException();
                        }
                        reference = reader.GetString();
                        if (reference is { })
                        {
                            result = (T?)context!.ResolveReference(reference);
                            if (result is PocoBase poco)
                            {
                                poco.StartPopulate(context);
                            }
                        }
                        else
                        {
                            throw new JsonException("Invalid reference");
                        }
                        done = true;
                    }
                    else if (propertyName.Equals(Key))
                    {
                        string[] selector = null!;
                        object[]? parts = JsonSerializer.Deserialize<object[]>(ref reader);
                        if (parts is { } && parts.Length > 0)
                        {
                            if (parts.Length > 1)
                            {
                                string selectorReference = ((JsonElement)parts[1]).ToString();
                                if (parts.Length > 2)
                                {
                                    selector = new string[2];
                                    for (int i = 0; i < 2; ++i)
                                    {
                                        selector[i] = ((JsonElement)parts[2])[i].ToString();
                                    }
                                    context!.AddReference(selectorReference, selector);
                                    _core.MapType(selector[0], typeof(T));
                                }
                                else
                                {
                                    selector = (context.ResolveReference(selectorReference) as string[])!;
                                }
                            }
                            if (
                                ((JsonElement)parts[0]).ValueKind is JsonValueKind.Array
                            )
                            {
                                object[] items = new object[((JsonElement)parts[0]).GetArrayLength()];
                                for (int i = 0; i < ((JsonElement)parts[0]).GetArrayLength(); ++i)
                                {
                                    items[i] = ((JsonElement)parts[0])[i].ToString();
                                }

                                _pocoContext.TryGetSource(typeof(T), items, out object? obj);

                                result = (T?)obj;
                                if(result is PocoBase poco)
                                {
                                    poco!.StartPopulate(context);
                                }

                                if (reference is { })
                                {
                                    context!.AddReference(reference, result!);
                                }
                                done = true;
                            }
                        }
                        if (!done)
                        {
                            throw new JsonException("Invalid key");
                        }
                    }
                    else
                    {
                        JsonSerializer.Deserialize<object>(ref reader);
                        done = true;
                    }
                }
                if (!done)
                {
                    PocoBase poco = (result as PocoBase)!;
                    Property<PocoBase>? property = poco.GetProperties()[propertyName];

                    if (property is { })
                    {

                        if (!property.IsReadOnly || property.IsCollection)
                        {

                            object? oldValue = property.GetValue(poco);

                            Type typeForDeserialization;
                            if (property.IsCollection)
                            {
                                typeForDeserialization = property.Type;
                                context!.ItemType = property.ItemType(typeof(T));
                            }
                            else
                            {
                                typeForDeserialization = property.PropertyType(typeof(T))!;
                                context!.ItemType = null;
                            }

                            bool isUnchanged = true;
                            bool isModified = false;
                            IEntity? entity = poco as IEntity;
                            if (entity is { })
                            {
                                isUnchanged = entity.PocoState is PocoState.Unchanged;
                                isModified = entity.IsModified(propertyName);
                            }
                            bool canChangeValue = (
                                    poco.IsEnvelope
                                    || isUnchanged
                                    || !isModified
                                );

                            context!.Target = property.IsCollection 
                                ? (
                                    canChangeValue 
                                    ? oldValue 
                                    : (
                                        _pocoContext.ExternalUpdateProcessing is ExternalUpdateProcessing.Never
                                        ? Activator.CreateInstance(typeof(List<>).MakeGenericType(context.ItemType!))
                                        : ((EntityBase?)entity)!.DeferredOverwriting(context, propertyName, Activator.CreateInstance(typeof(List<>).MakeGenericType(context.ItemType!)))
                                    )
                                )
                                : null;
                            object? value = JsonSerializer.Deserialize(ref reader, typeForDeserialization, options);
                            context!.Target = null;

                            if(
                                (
                                    oldValue is null && value is null
                                )
                                || (
                                    oldValue is { } && value is { } && oldValue!.Equals(value)
                                )
                            )
                            {
                                property.TouchValue(poco);

                            }
                            else 
                            {
                                if (canChangeValue)
                                {
                                    property.SetValue(poco, value);
                                }
                                else if (_pocoContext.ExternalUpdateProcessing is not ExternalUpdateProcessing.Never)
                                {
                                    ((EntityBase?)entity)!.DeferredOverwriting(context, propertyName, value);
                                }
                            }
                            done = true;
                        }

                    }
                    if (!done)
                    {
                        JsonSerializer.Deserialize<object>(ref reader);
                    }
                }
            }
            return result;
        }
        finally
        {
            if(result is PocoBase poco)
            {
                poco.StopPopulate(context);
            }
        }

    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (!_core.TryGetPocoJsonContext(options, out PocoTraversalContext? context))
        {
            throw new InvalidOperationException("Unproper using!");
        }

        if (value is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStartObject();

            string? reference = context!.GetReference(value, out bool alreadyExists);

            if (alreadyExists)
            {

                writer.WritePropertyName(Ref);
                writer.WriteStringValue(reference);
            }
            else
            {
                object[]? primaryKey = _core.GetPrimaryKey(value);
                writer.WritePropertyName(Id);
                writer.WriteStringValue(reference);
                if (primaryKey is { })
                {
                    writer.WritePropertyName(Key);
                    JsonSerializer.Serialize<object[]?>(writer, new object[] { primaryKey });
                }
                if(context.JsonSerializerOptionsKind is JsonSerializerOptionsKind.Ordinary || _core.IsEnvelope<T>())
                {
                    Type actualType = value.GetType();
                    foreach(PropertyInfo pi in typeof(T).GetProperties())
                    {
                        PropertyInfo? actualPropertyInfo = actualType.GetProperty(pi.Name);
                        if(actualPropertyInfo is { })
                        {
                            object? propertytValue = actualPropertyInfo.GetValue(value);
                            if(propertytValue is { })
                            {
                                writer.WritePropertyName(pi.Name);
                                JsonSerializer.Serialize(writer, propertytValue, pi.PropertyType, options);
                            }
                        }
                    }
                }
            }



            writer.WriteEndObject();
        }
    }
}