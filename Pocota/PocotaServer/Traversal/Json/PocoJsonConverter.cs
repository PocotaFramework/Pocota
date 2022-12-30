using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Server;

internal class PocoJsonConverter<T> : JsonConverter<T> where T : class
{
    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;
    private readonly bool _isEntity;
    private readonly PocoContext _pocoContext;
    private readonly Type _actualType;
    private readonly ImmutableDictionary<string, Property> _propertiesByName;
    private readonly ImmutableList<Property> _propertiesByOrder;

    public PocoJsonConverter(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
        _isEntity = _core.IsEntity(typeof(T));
        _pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
        _actualType = _core.GetActualType(typeof(T))!;
        _propertiesByName = _core.GetPropertiesDictionary(typeof(T))!;
        _propertiesByOrder = _core.GetPropertiesList(typeof(T))!;
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (!_core.TryGetPocoJsonContext(options, out PocoTraversalContext? context))
        {
            throw new InvalidOperationException("Unproper using!");
        }

        if (reader.TokenType is JsonTokenType.Null)
        {
            return null;
        }

        if (!(reader.TokenType is JsonTokenType.StartObject))
        {
            throw new JsonException();
        }

        IPrimaryKey<T>? primaryKey = null;
        T? result = (T?)context!.Target;
        context!.Target = null;

        bool isHighLevel = context.IsHighLevel;
        context.IsHighLevel = false;

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
                if (propertyName.Equals(PocoTraversalConverterFactory.Id)
                    || propertyName.Equals(PocoTraversalConverterFactory.Ref))
                {
                    if (!reader.Read())
                    {
                        throw new JsonException();
                    }
                    reference = reader.GetString();
                    if (reference is { })
                    {
                        result = context!.ResolveReference(reference) as T;
                    }
                    else
                    {
                        throw new JsonException("Invalid reference");
                    }
                    done = true;
                }
                else if (propertyName.Equals(PocoTraversalConverterFactory.Key))
                {
                    primaryKey = _services.GetRequiredService<IPrimaryKey<T>>();

                    JsonElement element = JsonSerializer.Deserialize<JsonElement>(ref reader);

                    if(element.ValueKind is JsonValueKind.Array && element.GetArrayLength() == primaryKey.Names.Count())
                    {
                        for (int i = 0; i < element.GetArrayLength(); ++i)
                        {
                            primaryKey![i] = element[i].ToString();
                        }
                        if (context.IsUpdating)
                        {
                            result = _pocoContext.FindOrCreateEntity(primaryKey, out bool _);
                        }
                        else
                        {
                            result = _services.GetRequiredService<T>();
                        }
                        if (reference is { } && result is { })
                        {
                            context!.AddReference(reference, result);
                        }
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
                if(result is null)
                {
                    result = _services.GetRequiredService<T>();
                }


                if(_propertiesByName.TryGetValue(propertyName, out Property? property))
                {
                    object? oldValue = property.GetValue(result);

                    context!.Target = oldValue;
                    object? value = JsonSerializer.Deserialize(ref reader, property.Type, options);
                    if (!PocoBase.ReferenceEquals(oldValue, value))
                    {
                        property.SetValue(result, value);
                    }
                    done = true;

                }
                if (!done)
                {
                    JsonSerializer.Deserialize<object>(ref reader);
                }
            }
        }
        return result;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            return;
        }
        if (!_core.TryGetPocoJsonContext(options, out PocoTraversalContext? context))
        {
            throw new InvalidOperationException("Unproper using!");
        }

        IPrimaryKey<T>? primaryKey = null;
        string? reference = context!.GetReference(value, out bool alreadyExists);
        bool isHighLevel = context.IsHighLevel;
        context.IsHighLevel = false;


        if (_isEntity)
        {
            primaryKey = (IPrimaryKey<T>?)((IProjection)value).As<IEntity>()!.PrimaryKey;
            if (primaryKey is { })
            {
                if (isHighLevel &&!context.IsHighLevelListUnique(primaryKey))
                {
                    return;
                }
            }
        }

        writer.WriteStartObject();

        string interfaceReference = context.GetReference(typeof(T), out bool isInterfaceFound);
        writer.WriteString(PocoTraversalConverterFactory.Interface, $"{interfaceReference}{(isInterfaceFound ? string.Empty : $":{typeof(T)}")}");

        if (alreadyExists)
        {

            writer.WriteString(PocoTraversalConverterFactory.Ref, reference);
        }
        else
        {
            writer.WriteString(PocoTraversalConverterFactory.Id, reference);
            string classReference = context.GetReference(_actualType, out bool isClassFound);
            writer.WriteString(PocoTraversalConverterFactory.Class, $"{classReference}{(isClassFound ? string.Empty : $":{_actualType}")}");
            if (_isEntity)
            {
                writer.WritePropertyName(PocoTraversalConverterFactory.Key);
                JsonSerializer.Serialize<object[]?>(writer, primaryKey!.Items.ToArray()!);
            }
        }
        IPoco poco = ((IProjection)value).As<IPoco>()!;

        foreach (Property property in _propertiesByOrder)
        {
            if(poco.IsPropertySet(property.Name) && !context.IsPropertySerialized(reference, property.Name))
            {
                object? propertyValue = property.GetValue(value);
                if(propertyValue is { })
                {
                    writer.WritePropertyName(property.Name);
                    try
                    {
                        JsonSerializer.Serialize(writer, propertyValue, property.Type, options);
                    }
                    catch(Exception ex)
                    {
                        throw new JsonException($"Exception occured while serializing the property {property.Name} of {typeof(T)} object!", ex);
                    }
                }
                else
                {
                    writer.WriteNull(property.Name);
                }
            }
        }
        writer.WriteEndObject();
    }
}
