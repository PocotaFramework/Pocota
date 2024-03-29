﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Net.Leksi.Pocota.Client.Context;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Constants = Net.Leksi.Pocota.Common.Constants;

namespace Net.Leksi.Pocota.Client.Json;

internal class PocoJsonConverter<T> : JsonConverter<T> where T : class
{
    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;
    private readonly PocoContext _pocoContext;
    private readonly ImmutableDictionary<string, IProperty>? _properties;
    private readonly bool _isEntity;

    public PocoJsonConverter(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
        _pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
        _properties = _core.GetPropertiesDictionary(typeof(T));
        _isEntity = typeof(IProjection<IEntity>).IsAssignableFrom(_core.GetActualType(typeof(T)));
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

        IProjection<T>? result = (IProjection<T>?)context!.Target;

        try
        {
            context!.Target = null;

            string? reference = null;

            string? @class = null;
            string? @interface = null;
            string? key = null;

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
                    if (propertyName.Equals(Constants.Id) || propertyName.Equals(Constants.Ref))
                    {
                        if (!reader.Read())
                        {
                            throw new JsonException();
                        }
                        reference = reader.GetString();
                        if (reference is { })
                        {
                            result = (IProjection<T>?)((IProjection<T>?)context!.ResolveReference(reference))?.As<T>();
                            result?.As<PocoBase>()?.StartPopulate(context);
                        }
                        else
                        {
                            throw new JsonException("Invalid reference");
                        }
                        done = true;
                    }
                    else if (propertyName.Equals(Constants.Class))
                    {
                        string? val = JsonSerializer.Deserialize<string>(ref reader);
                        if (string.IsNullOrEmpty(val) || !val.StartsWith(Constants.ReferencePrefix))
                        {
                            throw new JsonException("Invalid class reference");
                        }
                        string[] parts = val.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                        if (parts.Length > 1)
                        {
                            @class = parts[1];
                            context.AddReference(parts[0], @class);
                        }
                        else
                        {
                            @class = (string?)context.ResolveReference(parts[0]);
                            if (@class is null)
                            {
                                throw new JsonException("Invalid class reference");
                            }
                        }
                        done = true;
                    }
                    else if (propertyName.Equals(Constants.Interface))
                    {
                        string? val = JsonSerializer.Deserialize<string>(ref reader);
                        if (string.IsNullOrEmpty(val) || !val.StartsWith(Constants.ReferencePrefix))
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
                    else if (propertyName.Equals(Constants.Key) && _isEntity)
                    {
                        object[]? parts = JsonSerializer.Deserialize<object[]>(ref reader);
                        if (parts is { } && parts.Length > 0)
                        {
                            if (@class is null)
                            {
                                @class = typeof(object).ToString();
                            }
                            key = string.Join(',', parts.Select(v => v.ToString()!));
                            _pocoContext.TryGetSource(typeof(T), parts.Select(v => v.ToString()!).ToArray(), out object? obj);
                            result = (IProjection<T>)obj!;
                            result.As<PocoBase>()?.StartPopulate(context);

                            if (result is { } && reference is { })
                            {
                                context.AddReference(reference, ((object?)((IProjection?)result)?.As<PocoBase>() ?? result)!);
                            }

                            if(result is null)
                            {
                                throw new InvalidOperationException();
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
                        if (_isEntity)
                        {
                            throw new InvalidOperationException($"{typeof(T)}, {reference}, {key}");
                        }
                        result = (IProjection<T>)_services.GetRequiredService<T>();
                        result.As<PocoBase>()?.StartPopulate(context);
                    }
                    PocoBase? poco = result!.As<PocoBase>();
                    Property? property = _properties![propertyName] as Property;

                    if (property is { })
                    {

                        Type typeForDeserialization = property.Type;

                        if (property.IsCollection)
                        {
                            property.Touch(result);
                            context!.ItemType = property.ItemType;
                        }
                        else
                        {
                            typeForDeserialization = property.Type;
                            context!.ItemType = null;
                        }

                        object? oldValue = property.Get(result);

                        bool isUnchanged = true;
                        bool isModified = false;
                        IEntity? entity = poco as IEntity;
                        if (entity is { })
                        {
                            isUnchanged = entity.PocoState is PocoState.Unchanged;
                            isModified = property.IsModified(result);
                        }
                        bool canChangeValue = (
                                poco!.IsEnvelope
                                || isUnchanged
                                || !isModified
                            );

                        context!.Target = property.IsCollection
                            ? (
                                canChangeValue
                                ? oldValue
                                : property.GetInitial(result)
                                
                            )
                            : null;
                        object? value = JsonSerializer.Deserialize(ref reader, typeForDeserialization, options);
                        context!.Target = null;

                        if (!property.IsCollection)
                        {
                            if (
                                (
                                    oldValue is null && value is null
                                )
                                || (
                                    oldValue is { } && value is { } && oldValue!.Equals(value)
                                )
                            )
                            {
                                if (!property.IsCollection)
                                {
                                    property.Touch(result);
                                }
                            }
                            else
                            {
                                if (!property.IsCollection)
                                {
                                    property.Set(result, value);
                                }
                            }
                        }
                        done = true;

                    }
                    if (!done)
                    {
                        JsonSerializer.Deserialize<object>(ref reader);
                    }
                }
            }
            return (T?)result;
        }
        finally
        {
            result?.As<PocoBase>()?.StopPopulate(context);
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

                writer.WritePropertyName(Constants.Ref);
                writer.WriteStringValue(reference);
            }
            else
            {
                IProjection<T> projection = (IProjection<T>)value;
                object[]? primaryKey = projection.As<EntityBase>()?.PrimaryKey;
                writer.WritePropertyName(Constants.Id);
                writer.WriteStringValue(reference);
                if (primaryKey is { })
                {
                    writer.WritePropertyName(Constants.Key);
                    JsonSerializer.Serialize<object[]?>(writer, primaryKey);
                }
                if (context.JsonSerializerOptionsKind is JsonSerializerOptionsKind.Ordinary || projection.As<EnvelopeBase>() is { })
                {
                    foreach (IProperty property in _properties!.Values)
                    {
                        object? propertytValue = property.Get(projection);
                        if (propertytValue is { })
                        {
                            writer.WritePropertyName(property.Name);
                            JsonSerializer.Serialize(writer, propertytValue, property.Type, options);
                        }
                    }
                }
            }



            writer.WriteEndObject();
        }
    }
}