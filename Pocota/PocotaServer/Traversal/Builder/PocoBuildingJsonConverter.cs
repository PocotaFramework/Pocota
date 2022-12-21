using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using Net.Leksi.Pocota.Server.Generic;
using Net.Leksi.Pocota.Traversal;
using System.Data.Common;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Builder;

internal class PocoBuildingJsonConverter<T> : JsonConverter<T> where T : class
{
    private static Type? s_actualType = null;
    private static readonly object s_lock = new();

    private readonly IServiceProvider _services;
    private readonly object? _probe;
    private readonly object? _skip;
    private readonly PocotaCore _core;
    private readonly PocoContext _pocoContext;
    private readonly bool _isEntity;

    public PocoBuildingJsonConverter(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
        _isEntity = _core.IsEntity(typeof(T));
        _pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
        _probe = _pocoContext.GetProbePlaceholder<T>();
        _skip = _pocoContext.GetSkipPlaceholder<T>();
        if(s_actualType is null)
        {
            lock (s_lock)
            {
                if (s_actualType is null)
                {
                    s_actualType = _core.GetActualType(typeof(T))!;
                }
            }
        }
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    /*TODO Возможность запрещения доступа к полям по какой-либо причине, например по роли */
    /*TODO Передача в JSON через имена можно ли этому пользователю редактировать свойство */
    /*TODO null в лист не пишем, для конца специальный объект end<T> */
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        //Console.WriteLine(GetType() + " " + string.Join('\n', Environment.StackTrace.Split(new[] { '\n'}).Where(v => v.Contains(":line")).Skip(1).Take(1)));
        if (!(_pocoContext.GetTraversalContext(options) is PocoTraversalContext context))
        {
            throw new InvalidOperationException("Unproper using!");
        }
        ++context.BuildingContext!.Level;

        IPrimaryKey<T>? primaryKey = null;
        bool alreadyExists = false;
        string? reference = null;
        bool isHighLevel = context.IsHighLevel;
        context.IsHighLevel = false;
        bool isListItem = context.IsListItem;
        context.IsListItem = false; 

        writer.Flush();

        if (isHighLevel)
        {
            context.BuildingContext.ResetBuildingLog();
        }

        try
        {
            while(context.BuildingContext.Spinners.Peek().Level > context.BuildingContext.Level)
            {
                DbDataReader? reader = context.BuildingContext.Spinners.Pop().Spinner.Current;
                if (reader is { } && !reader.IsClosed)
                {
                    reader.Close();
                }
            }
            if (context.BuildingContext.Spinners.Peek().Level == context.BuildingContext.Level)
            {
                if (!context.BuildingContext.Spinners.Peek().Spinner.MoveNext())
                {
                    DbDataReader? reader = context.BuildingContext.Spinners.Pop().Spinner.Current;
                    if (reader is { } && !reader.IsClosed)
                    {
                        reader.Close();
                    }
                    context.Target = null;
                    writer.Flush();

                    return;
                }
            }
            if (_isEntity)
            {
                primaryKey = _services.GetRequiredService<IPrimaryKey<T>>();
                foreach (string name in context.BuildingContext.PresetKeys.Keys)
                {
                    primaryKey![name] = context.BuildingContext.PresetKeys[name];
                }
                context.BuildingContext.PresetKeys.Clear();

            }

            context.BuildingContext.BuildingEventArgs.InternalValue = _probe;

            List<object> path = context.BuildingContext.BufferWriter!.Path
                .Skip(context.BuildingContext.Spinners.Peek().PathPrefixLength)
                .Select<Node, object>((Node v) => v.NodeKind is Node.Kind.Array ? v.Count : v.Name!)
                .Where(v => v is { })
                .ToList();
            if(path.Count > 0 && context.BuildingContext.BufferWriter!.Path.Last().IsIncompleteNumber)
            {
                //Console.WriteLine(String.Join('/', path));
                path.RemoveAt(path.Count - 1);
            }

            context.BuildingContext.BuildingEventArgs.IsKeyRequest = true;
            context.BuildingContext.BuildingEventArgs.IsMissed = true;
            if (context.BuildingContext.Name is { })
            {
                path.Add(context.BuildingContext.Name);
            }
            context.BuildingContext.BuildingEventArgs.InternalPath = path;
            context.BuildingContext.BuildingEventArgs.PropertyType = typeof(T);

            context.BuildingContext.AddLogEntry(
                context.BuildingContext.BuildingEventArgs.IsKeyRequest,
                context.BuildingContext.BuildingEventArgs.PropertyType,
                context.BuildingContext.BuildingEventArgs.PathSelector
            );

            context.BuildingContext.BuildingEventArgs.PrimaryKey = primaryKey!;
            context.BuildingContext.BuildingEventArgs.DataReader = context.BuildingContext.Spinners.Peek().Spinner.Current;

            try
            {
                context.BuildingContext!.Spinners.Peek().Script!.Run(context.BuildingContext.BuildingEventArgs);

                if (
                    context.BuildingContext.BuildingEventArgs.InternalValue == default
                    || object.ReferenceEquals(context.BuildingContext.BuildingEventArgs.InternalValue, _skip)
                )
                {
                    if (!context.BuildingContext.BuildingEventArgs.IsNullable)
                    {
                        context.BuildingContext.UpdateLogEntry(null, BuildingEventResult.NotNullableSetNull);
                    }
                    context.Target = context.BuildingContext.BuildingEventArgs.InternalValue;

                    if (!isListItem)
                    {
                        if (context.BuildingContext.Name is { })
                        {
                            writer.WritePropertyName(context.BuildingContext.Name);
                            context.BuildingContext.Name = null;
                            writer.WriteNullValue();
                        }

                    }
                    writer.Flush();

                    if (context.BuildingContext.Name is { })
                    {
                        context.BuildingContext.Name = null;
                    }

                    return;
                }

            }
            catch (Exception ex)
            {
                context.BuildingContext.UpdateLogEntry(ex, BuildingEventResult.Exception);
            }

            if (
                !object.ReferenceEquals(context.BuildingContext.BuildingEventArgs.InternalValue, _skip)
                && (_isEntity && (primaryKey is null || primaryKey.Items.Any(v => v == default)))
            )
            {
                context.BuildingContext.UpdateLogEntry(
                    primaryKey?.Names.Where(v => primaryKey[v] == default).ToArray(),
                    BuildingEventResult.KeyNotSet
                );
                if (context.BuildingContext.Name is { })
                {
                    context.BuildingContext.Name = null;
                }
                context.Target = null;
                writer.Flush();

                return;
            }

            if (isHighLevel && !context.IsHighLevelListUnique(primaryKey!))
            {
                if (context.BuildingContext.Name is { })
                {
                    context.BuildingContext.Name = null;
                }
                context.Target = _skip;
                writer.Flush();

                return;
            }
            if (!object.ReferenceEquals(context.BuildingContext.BuildingEventArgs.InternalValue, _probe))
            {
                context.Target = context.BuildingContext.BuildingEventArgs.InternalValue;
                writer.Flush();

                return;
            }
            if (_isEntity)
            {
                value = _pocoContext.FindOrCreateEntity(primaryKey!);
            }
            else
            {
                value = _services.GetRequiredService<T>();
            }

            reference = context.GetReference(value!, out alreadyExists);
            if (context.BuildingContext.Name is { })
            {
                writer.WritePropertyName(context.BuildingContext.Name);
                context.BuildingContext.Name = null;
            }

            writer.WriteStartObject();
            writer.Flush();

            context.BuildingContext.BufferWriter!.Path.Last().Value = value;

            if (alreadyExists)
            {

                writer.WritePropertyName(PocoTraversalConverterFactory.Ref);
                writer.WriteStringValue(reference);
            }
            else
            {
                writer.WritePropertyName(PocoTraversalConverterFactory.Id);
                writer.WriteStringValue(reference);
                if (_isEntity)
                {
                    writer.WritePropertyName(PocoTraversalConverterFactory.Key);
                    JsonSerializer.Serialize<object[]?>(writer, context.EncodeKeyRing<T>(primaryKey!));
                }
            }
            if ((_isEntity || !alreadyExists) && !((IPoco)value).IsLoaded<T>() && !context.BuildingContext.BuildingEventArgs.KeyOnly)
            {
                PocoBase poco = (value as PocoBase)!;
                string? prevPropertyName = null;

                foreach (Property property in _core.GetProperties(typeof(T))!.Values)
                {
                    context.Target = null;

                    //PropertyInfo actualPropertyInfo = s_actualType.GetProperty(property.Name);

                    Type propertyType = property.PropertyType(typeof(T))!;

                    object? propertyValue = property.GetValue(poco);

                    if (!((IPoco)value).IsPropertySet(property.Name))
                    {
                        context.BuildingContext.BuildingEventArgs.IsNullable = property.IsNullable;
                        bool isPoco = _core.GetActualType(propertyType) is { };
                        bool isPocoWithKey = _core.IsEntity(propertyType);
                        bool isNewPocoList = false;
                        Type typeForSerialization = propertyType;
                        primaryKey!.TryGetPresets(property.Name, context.BuildingContext.PresetKeys);
                        if (!isPocoWithKey)
                        {
                            bool isSetFromKey = context.BuildingContext.PresetKeys.TryGetValue(string.Empty, out propertyValue);
                            property.SetValue(poco, propertyValue);
                            context.BuildingContext.PresetKeys.Clear();
                            if (!isSetFromKey)
                            {
                                if (!isPoco || propertyValue is null || !context.TestReference(propertyValue))
                                {
                                    if (
                                        property.IsCollection
                                    )
                                    {
                                        context.ItemType = property.ItemType(typeof(T));
                                        typeForSerialization = property.Type;
                                        if (propertyValue == default)
                                        {
                                            propertyValue = _pocoContext.GetProbePlaceholder(typeForSerialization);
                                            isNewPocoList = true;
                                        }
                                    }
                                    else
                                    {
                                        context.ItemType = null;
                                    }

                                    context.BuildingContext.BuildingEventArgs.IsKeyRequest = false;

                                    path = context.BuildingContext.BufferWriter!.Path
                                        .Skip(context.BuildingContext.Spinners.Peek().PathPrefixLength)
                                        .Select<Node, object>((Node v) => v.NodeKind is Node.Kind.Array ? v.Count - 1 : v.Name!)
                                        .Where(v => v is { })
                                        .ToList();

                                    if (path.Count > 0 && path.Last().Equals(prevPropertyName))
                                    {
                                        path.RemoveAt(path.Count - 1);
                                    }
                                    path.Add(property.Name);
                                    context.BuildingContext.BuildingEventArgs.InternalPath = path;
                                    context.BuildingContext.BuildingEventArgs.PropertyType = typeForSerialization;

                                    context.BuildingContext.AddLogEntry(
                                        context.BuildingContext.BuildingEventArgs.IsKeyRequest,
                                        context.BuildingContext.BuildingEventArgs.PropertyType,
                                        context.BuildingContext.BuildingEventArgs.PathSelector
                                    );

                                    context.BuildingContext.BuildingEventArgs.InternalValue = propertyValue;
                                    context.BuildingContext.BuildingEventArgs.PrimaryKey = primaryKey!;
                                    context.BuildingContext.BuildingEventArgs.IsMissed = true;
                                    context.BuildingContext.BuildingEventArgs.DataReader = context.BuildingContext.Spinners.Peek().Spinner.Current;

                                    if (!isNewPocoList)
                                    {
                                        try
                                        {
                                            context.BuildingContext!.Spinners.Peek().Script!.Run(context.BuildingContext.BuildingEventArgs);
                                            if (context.BuildingContext.BuildingEventArgs.IsMissed)
                                            {
                                                context.BuildingContext.UpdateLogEntry(null, BuildingEventResult.Missed);
                                            }
                                            if (
                                                context.BuildingContext.BuildingEventArgs.Value == default
                                                && !context.BuildingContext.BuildingEventArgs.IsNullable
                                            )
                                            {
                                                context.BuildingContext.UpdateLogEntry(null, BuildingEventResult.NotNullableSetNull);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            context.BuildingContext.UpdateLogEntry(ex, BuildingEventResult.Exception);
                                        }
                                        propertyValue = context.BuildingContext.BuildingEventArgs.Value;
                                        property.SetValue(poco, propertyValue);
                                    }
                                    else
                                    {
                                        try
                                        {
                                            context.BuildingContext!.Spinners.Peek().Script!.Run(context.BuildingContext.BuildingEventArgs);
                                            if (
                                                context.BuildingContext.BuildingEventArgs.Value == default
                                                && !context.BuildingContext.BuildingEventArgs.IsNullable
                                            )
                                            {
                                                context.BuildingContext.UpdateLogEntry(null, BuildingEventResult.NotNullableSetNull);
                                            }
                                            else
                                            {
                                                context.BuildingContext.UpdateLogEntry(null, BuildingEventResult.Matched);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            context.BuildingContext.UpdateLogEntry(ex, BuildingEventResult.Exception);
                                        }
                                    }

                                }
                            }
                        }
                        if (isPoco)
                        {
                            context.BuildingContext.Name = property.Name;
                        }
                        else
                        {
                            prevPropertyName = property.Name;
                            writer.WritePropertyName(property.Name);
                            writer.Flush();
                        }
                        if (propertyValue is { })
                        {
                            //Console.WriteLine($"reflecion: typeForSerialization: {typeForSerialization}, itemType: {context.ItemType}");
                            //Console.WriteLine($"property: typeForSerialization: {(property.IsCollection ? property.Type : property.PropertyType(typeof(T)))}, itemType: {property.ItemType(typeof(T))}");
                            JsonSerializer.Serialize(writer, propertyValue, typeForSerialization, options);
                            if (isPoco)
                            {
                                if (object.ReferenceEquals(context.Target, _pocoContext.GetSkipPlaceholder(typeForSerialization)))
                                {
                                    context.Target = null;
                                }
                            }

                            if (isPocoWithKey || isNewPocoList)
                            {
                                if (
                                    (
                                        context.Target is null
                                        && propertyValue is { }
                                    )
                                    || (
                                        context.Target is { }
                                        && !context.Target.Equals(propertyValue)
                                    )
                                )
                                {
                                    property.SetValue(poco, context.Target);
                                }
                            }
                        }
                    }
                }
            }
            writer.WriteEndObject();
            writer.Flush();
            context.Target = value;

        }
        finally
        {
            if (isHighLevel && context.BuildingContext.Failed)
            {
                context.BuildingContext.Throw();
            }
            --context.BuildingContext!.Level;
        }

    }
}
