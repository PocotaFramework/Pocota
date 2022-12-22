using Net.Leksi.Pocota.Server.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Server;

internal class PocoJsonConverter<T> : JsonConverter<T> where T : class
{
    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;
    private readonly bool _hasKey;
    private readonly PocoContext _pocoContext;
    private readonly Type _actualType;

    public PocoJsonConverter(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
        _hasKey = typeof(IEntity).IsAssignableFrom(typeof(T));
        _pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
        _actualType = _core.GetActualType(typeof(T))!;
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
                    object[]? parts = JsonSerializer.Deserialize<object[]>(ref reader);
                    if (parts is { } && parts.Length > 0)
                    {
                        primaryKey = _services.GetRequiredService<IPrimaryKey<T>>();
                        
                        if (
                            ((JsonElement)parts[0]).ValueKind is JsonValueKind.Array 
                            && ((JsonElement)parts[0]).GetArrayLength() == primaryKey!.Items.Count()
                        )
                        {
                            for (int i = 0; i < ((JsonElement)parts[0]).GetArrayLength(); ++i)
                            {
                                primaryKey![i] = ((JsonElement)parts[0])[i].ToString();
                            }
                            if (context.IsUpdating)
                            {
                                //primaryKey.TryGetSource<T>(out object? obj);
                                //result = (T?)obj;
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
                PropertyInfo? pi = typeof(T).GetProperty(propertyName);

                if(pi is { })
                {
                    PropertyInfo? actualPropertyInfo = _actualType.GetProperty(propertyName);

                    if(actualPropertyInfo is { } && actualPropertyInfo.CanWrite)
                    {
                        object? oldValue = actualPropertyInfo!.GetValue(result);

                        Type typeForDeserialization = pi.PropertyType;
                        if (PocotaCore.IsIList(pi.PropertyType))
                        {
                            typeForDeserialization = actualPropertyInfo.PropertyType;
                            context!.ItemType = pi.PropertyType.GetGenericArguments()[0];
                        }
                        context!.Target = oldValue;
                        object? value = JsonSerializer.Deserialize(ref reader, typeForDeserialization, options);
                        if (!object.ReferenceEquals(oldValue, value))
                        {
                            actualPropertyInfo.SetValue(result, value);
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


        if (_hasKey)
        {
            primaryKey = _services.GetRequiredService<IPrimaryKey<T>>();
            if (primaryKey is { })
            {
                if (isHighLevel &&!context.IsHighLevelListUnique(primaryKey))
                {
                    return;
                }
            }
        }

        writer.WriteStartObject();

        if (alreadyExists)
        {

            writer.WritePropertyName(PocoTraversalConverterFactory.Ref);
            writer.WriteStringValue(reference);
        }
        else
        {
            writer.WritePropertyName(PocoTraversalConverterFactory.Id);
            writer.WriteStringValue(reference);
            if (_hasKey && primaryKey is { })
            {
                writer.WritePropertyName(PocoTraversalConverterFactory.Key);
                JsonSerializer.Serialize<object[]?>(writer, context.EncodePrimaryKey<T>(primaryKey!));
            }
        }
        foreach (PropertyInfo pi in typeof(T).GetProperties())
        {
            PropertyInfo actualPropertyInfo = value!.GetType().GetProperty(pi.Name)!;
            if(!context.IsPropertySerialized(reference, actualPropertyInfo))
            {
                object? propertyValue = pi.GetValue(value);
                if(propertyValue is { })
                {
                    writer.WritePropertyName(pi.Name);
                    try
                    {
                        JsonSerializer.Serialize(writer, propertyValue, pi.PropertyType, options);
                    }
                    catch(Exception ex)
                    {
                        throw new JsonException($"Exception occured while serializing the property {pi} of {typeof(T)} object!", ex);
                    }
                }
            }
        }
        writer.WriteEndObject();
    }
}
