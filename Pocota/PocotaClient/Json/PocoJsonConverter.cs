using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Context;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using System.Collections.Immutable;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Client.Json;

internal class PocoJsonConverter<T> : JsonConverter<T> where T : class
{
    internal const string Key = "$key";
    internal const string Id = "$id";
    internal const string Ref = "$ref";
    internal const string Class = "$cl";
    internal const string Interface = "$in";

    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;
    private readonly PocoContext _pocoContext;
    private readonly ImmutableDictionary<string, Property>? _properties;

    public PocoJsonConverter(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
        _pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
        _properties = _core.GetProperties(typeof(T));
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

            List<string>? key = null;
            string? @class = null;
            string? @interface = null;

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
                    else if (propertyName.Equals(Class))
                    {
                        string? val = JsonSerializer.Deserialize<string>(ref reader);
                        if(string.IsNullOrEmpty(val) || !val.StartsWith("#"))
                        {
                            throw new JsonException("Invalid class reference");
                        }
                        string[] parts = val.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                        if(parts.Length > 1)
                        {
                            @class = parts[1];
                            context.AddReference(parts[0], @class);
                        }
                        else
                        {
                            @class = (string?)context.ResolveReference(parts[0]);
                            if(@class is null)
                            {
                                throw new JsonException("Invalid class reference");
                            }
                        }
                        done = true;
                    }
                    else if (propertyName.Equals(Interface))
                    {
                        string? val = JsonSerializer.Deserialize<string>(ref reader);
                        if (string.IsNullOrEmpty(val) || !val.StartsWith("#"))
                        {
                            throw new JsonException("Invalid interface reference");
                        }
                        string[] parts = val.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                        if (parts.Length > 1)
                        {
                            @interface = parts[1];
                            context.AddReference(parts[0], @interface);
                        }
                        else
                        {
                            @interface = (string?)context.ResolveReference(parts[0]);
                            if (@interface is null)
                            {
                                throw new JsonException("Invalid interface reference");
                            }
                        }
                        done = true;
                    }
                    else if (propertyName.Equals(Key))
                    {
                        object[]? parts = JsonSerializer.Deserialize<object[]>(ref reader);
                        if (parts is { } && parts.Length > 0)
                        {
                            key = new List<string>();
                            key.AddRange(parts.Select(v => v.ToString()));
                            done = true;
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
                    if(key is { })
                    {
                        if(@class is null)
                        {
                            @class = typeof(object).ToString();
                        }
                        key.Insert(0, @class);

                        if(_pocoContext.TryGetSource(typeof(T), key.ToArray(), out object? obj))
                        {
                            result = (T)obj!;
                            ((PocoBase?)((IProjection?)result)?.Projector)?.StartPopulate(context);
                        }

                        key = null;
                    }

                    PocoBase? poco = (((IProjection?)result)?.Projector as PocoBase)!;
                    Property? property = _properties![propertyName];

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
            ((PocoBase?)((IProjection?)result)?.Projector)?.StopPopulate(context);
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
                if(context.JsonSerializerOptionsKind is JsonSerializerOptionsKind.Ordinary || typeof(EnvelopeBase).IsAssignableFrom(typeof(T)))
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