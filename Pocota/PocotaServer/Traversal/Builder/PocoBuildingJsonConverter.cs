using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server.Generic;
using System.Data.Common;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Server;

internal class PocoBuildingJsonConverter<T> : JsonConverter<T> where T : class
{
    private readonly IServiceProvider _services;
    private readonly object? _probe;
    private readonly object? _skip;
    private readonly PocotaCore _core;
    private readonly PocoContext _pocoContext;
    private readonly bool _isEntity;
    private readonly Type _actualType;
    private readonly IEnumerable<Property> _properties;


    public PocoBuildingJsonConverter(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
        _actualType = _core.GetActualType(typeof(T))!;
        _isEntity = _core.IsEntity(typeof(T));
        _pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
        _probe = _pocoContext.GetProbePlaceholder<T>();
        _skip = _pocoContext.GetSkipPlaceholder<T>();
        if (typeof(T).Name.Contains("Litter"))
        {
            var props = _core.GetProperties(typeof(T))!;
            _properties = new string[] { "Order", "Date", "Female", "Male", "Cats", "Strings" }.Where(s => props.ContainsKey(s)).Select(s => props[s]);
        }
        else
        {
            _properties = _core.GetProperties(typeof(T))!.Values;
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
        bool isNew = false;
        string? reference = null;
        bool isHighLevel = context.IsHighLevel;
        context.IsHighLevel = false;
        bool isListItem = context.IsListItem;
        context.IsListItem = false;

        writer.Flush();

        if (isHighLevel)
        {
            context.BuildingContext.Log?.Reset();
        }

        try
        {
            while (context.BuildingContext.Spinners.Peek().Level > context.BuildingContext.Level)
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
                foreach (string name in context.BuildingContext.Presets.Keys)
                {
                    primaryKey![name] = context.BuildingContext.Presets[name];
                }
                context.BuildingContext.Presets.Clear();

            }

            context.BuildingContext.BuildingEventArgs.InternalValue = _probe;

            List<object> path = context.BuildingContext.BufferWriter!.Path
                .Skip(context.BuildingContext.Spinners.Peek().PathPrefixLength)
                .Select<Node, object>((Node v) => v.NodeKind is Node.Kind.Array ? v.Count : v.Name!)
                .Where(v => v is { })
                .ToList();
            if (path.Count > 0 && context.BuildingContext.BufferWriter!.Path.Last().IsIncompleteNumber)
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

            context.BuildingContext.Log?.AddEntry(
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
                    if (!context.BuildingContext.BuildingEventArgs.IsNullable && !isListItem)
                    {
                        context.BuildingContext.Log?.UpdateEntry(null, BuildingEventResult.NotNullableSetNull);
                    }
                    context.Target = context.BuildingContext.BuildingEventArgs.InternalValue;

                    if (!isListItem)
                    {
                        if (context.BuildingContext.Name is { })
                        {
                            writer.WriteNull(context.BuildingContext.Name);
                            context.BuildingContext.Name = null;
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
                context.BuildingContext.Log?.UpdateEntry(ex, BuildingEventResult.Exception);
            }

            if (
                !object.ReferenceEquals(context.BuildingContext.BuildingEventArgs.InternalValue, _skip)
                && (_isEntity && !primaryKey!.IsAssigned)
            )
            {
                context.BuildingContext.Log?.UpdateEntry(
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
                value = _pocoContext.FindOrCreateEntity(primaryKey!, out isNew);
            }
            else
            {
                value = _services.GetRequiredService<T>();
            }

            reference = context.GetReference(((IProjection)value).As<IPoco>()!, out alreadyExists);
            if (context.BuildingContext.Name is { })
            {
                writer.WritePropertyName(context.BuildingContext.Name);
                context.BuildingContext.Name = null;
            }

            writer.WriteStartObject();
            writer.Flush();

            context.BuildingContext.BufferWriter!.Path.Last().Value = value;

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
            if ((_isEntity || !alreadyExists) && !poco.IsLoaded<T>() && !context.BuildingContext.BuildingEventArgs.KeyOnly)
            {
                string? prevPropertyName = null;

                foreach (Property property in _properties)
                {
                    context.Target = null;

                    Type propertyType = property.Type;

                    object? propertyValue = property.GetValue(value);

                    bool isPropertySet = poco.IsPropertySet(property.Name);

                    if (isNew || !isPropertySet)
                    {
                        if (isNew && isPropertySet)
                        {
                            prevPropertyName = property.Name;
                            writer.WritePropertyName(property.Name);
                            JsonSerializer.Serialize(writer, propertyValue, propertyType, options);
                            writer.Flush();
                        }
                        else
                        {
                            context.BuildingContext.BuildingEventArgs.IsNullable = property.IsNullable;
                            bool isPoco = _core.GetActualType(propertyType) is { };
                            bool isPocoWithKey = _core.IsEntity(propertyType);
                            bool isNewPocoList = false;
                            Type typeForSerialization = propertyType;
                            if (isPocoWithKey)
                            {
                                primaryKey!.TryGetPresets(property.Name, context.BuildingContext.Presets);
                                propertyValue = _pocoContext.GetProbePlaceholder(propertyType);
                            }
                            else
                            {
                                if (!isPoco || propertyValue is null || !context.TestReference(propertyValue))
                                {
                                    if (
                                        property.IsCollection
                                    )
                                    {
                                        //context.ItemType = property.ItemType;
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

                                    context.BuildingContext.Log?.AddEntry(
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
                                                context.BuildingContext.Log?.UpdateEntry(null, BuildingEventResult.Missed);
                                            }
                                            if (
                                                context.BuildingContext.BuildingEventArgs.Value == default
                                                && !context.BuildingContext.BuildingEventArgs.IsNullable
                                            )
                                            {
                                                context.BuildingContext.Log?.UpdateEntry(null, BuildingEventResult.NotNullableSetNull);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            context.BuildingContext.Log?.UpdateEntry(ex, BuildingEventResult.Exception);
                                        }
                                        propertyValue = context.BuildingContext.BuildingEventArgs.Value;
                                        if (
                                            (propertyValue is null && value is { })
                                            || (propertyValue is { } && !propertyValue.Equals(value))
                                        )
                                        {
                                            property.SetValue(value, propertyValue);
                                        }
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
                                                context.BuildingContext.Log?.UpdateEntry(null, BuildingEventResult.NotNullableSetNull);
                                            }
                                            else
                                            {
                                                context.BuildingContext.Log?.UpdateEntry(null, BuildingEventResult.Matched);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            context.BuildingContext.Log?.UpdateEntry(ex, BuildingEventResult.Exception);
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
                                        property.SetValue(value, context.Target);
                                    }
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
            if (isHighLevel && (context.BuildingContext.Log?.Failed ?? false))
            {
                context.BuildingContext.Log?.Throw();
            }
            --context.BuildingContext!.Level;
        }

    }
}
