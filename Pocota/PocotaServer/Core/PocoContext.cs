using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server.Generic;
using System.Data.Common;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Server;

public class PocoContext : IPocoContext
{
    private readonly PocotaCore _core;
    private readonly IServiceProvider _services;
    private readonly HashSet<IPrimaryKey> _cache = new();

    public IServiceProvider Services => _services;

    public PocoContext(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
    }

    public void AddJsonConverters(Type targetType, JsonSerializerOptions jsonSerializerOptions)
    {
        if (_core.GetJsonConverters(targetType) is HashSet<Type> types)
        {
            foreach (Type type in types)
            {
                if (!jsonSerializerOptions.Converters.Any(v => v.GetType() == type))
                {
                    jsonSerializerOptions.Converters.Add((JsonConverter)_services.GetRequiredService(type));
                }
            }
        }
    }

    public void AddJsonConverters<TTarget>(JsonSerializerOptions jsonSerializerOptions)
    {
        AddJsonConverters(typeof(TTarget), jsonSerializerOptions);
    }

    public JsonSerializerOptions BindJsonSerializerOptions(JsonSerializerOptions? options = null)
    {
        if (options is null)
        {
            options = new JsonSerializerOptions();
        }
        if (!_core.TryGetPocoJsonContext(options, out PocoTraversalContext? context))
        {
            options.ReferenceHandler = ReferenceHandler.Preserve;
            options.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
            options.Converters.Add(_services.GetRequiredService<PocoTraversalConverterFactory>());
            context = (_services.GetRequiredService<IPocoTraversalContext>() as PocoTraversalContext)!;
            context.JsonSerializerOptions = options;
        }
        _core.AddPocoJsonContext(options, context!);
        return options;
    }

    public void Build(Type type, BuildingOptions options)
    {
        BuildingContext context = null!;
        try
        {
            context = CreateBuildingContext(options);
            AddJsonConverters(type, context.TraversalContext!.JsonSerializerOptions!);
            Utf8JsonWriter jsonWriter = new Utf8JsonWriter(context.BufferWriter!);
            context.TraversalContext!.IsHighLevel = true;
            context.StackTrace = Environment.StackTrace;
            JsonSerializer.Serialize(
                    jsonWriter,
                    options.Target is { } ? options.Target : GetProbePlaceholder(type),
                    type,
                    context.TraversalContext!.JsonSerializerOptions
                );
            object? result = context.TraversalContext.Target;
            context.TraversalContext.Target = null;
            options.Target = object.ReferenceEquals(result, GetSkipPlaceholder(type)) ? null : result;
        }
        finally
        {
            if (context is { })
            {
                while (context.Spinners.Count > 0)
                {
                    DbDataReader? reader = context.Spinners.Pop().Spinner.Current;
                    if (reader is { } && !reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
            }
        }
    }

    public void Build<T>(BuildingOptions options)
    {
        Build(typeof(T), options);
    }

    public IPocoTraversalContext? GetTraversalContext(JsonSerializerOptions options)
    {
        if (_core.TryGetPocoJsonContext(options, out PocoTraversalContext? context))
        {
            return context;
        }
        return null;
    }

    internal T FindOrCreateEntity<T>(IPrimaryKey<T> key, out bool isNew) where T : class
    {
        if (!key.IsAssigned)
        {
            throw new ArgumentException($"{nameof(key)} must be assigned!");
        }
        isNew = true;
        if (_cache.TryGetValue(key, out IPrimaryKey? cachedKey))
        {
            if (cachedKey.Source is { })
            {
                isNew = false;
                return ((IProjection)cachedKey.Source).As<T>()!;
            }
            _cache.Remove(key);

        }
        IProjection result = (IProjection)_services.GetRequiredService(typeof(T));
        IPrimaryKey newKey = ((IEntity)(result).Projector).PrimaryKey;
        newKey.Assign(key);
        _cache.Add(newKey);
        return result.As<T>()!;
    }

    internal object? GetProbePlaceholder(Type type)
    {
        return _core.GetProbePlaceholder(type, () => _services.GetRequiredService(type));
    }


    internal object? GetProbePlaceholder<T>() where T : class
    {
        return GetProbePlaceholder(typeof(T));
    }

    internal object? GetSkipPlaceholder(Type type)
    {
        return _core.GetSkipPlaceholder(type, () => _services.GetRequiredService(type));
    }


    internal object? GetSkipPlaceholder<T>() where T : class
    {
        return GetSkipPlaceholder(typeof(T));
    }

    private BuildingContext CreateBuildingContext(BuildingOptions options)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }
        options.JsonSerializerOptions = BindJsonSerializerOptions(options.JsonSerializerOptions);
        PocoTraversalContext context = (GetTraversalContext(BindJsonSerializerOptions(options.JsonSerializerOptions)) as PocoTraversalContext)!;
        context.IsBuilding = true;
        context.BuildingContext!.BufferWriter = new TreeWalkerBufferWriter(options.Output);
        context.HighLevelListUniqueness = options.HighLevelListUniqueness;
        context.BuildingContext!.Spinners.Push(new SpinnerHolder
        {
            Level = 1,
            Spinner = options.Spinner.GetEnumerator(),
            Script = options.Script ?? _services.GetRequiredService<BuildingScript>()
        }); ;
        return context.BuildingContext!;
    }

}
