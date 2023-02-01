using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Client.Json;
using Net.Leksi.Pocota.Common;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Leksi.Pocota.Client.Context;

internal class PocoContext : IPocoContext
{
    public event EventHandler<EventArgs>? TracedPocosChanged;
    public event EventHandler<EventArgs>? ModifiedPocosChanged;

    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;
    private readonly Dictionary<Type, int> _tracedPocos = new();
    private readonly Dictionary<Type, Dictionary<object?[], WeakReference>> _cachedObjects = new();
    private readonly object _getSourceLock = new();
    private readonly ConcurrentDictionary<IPoco, string> _changedPocos = new(ReferenceEqualityComparer.Instance);

    private bool _tracePocos = false;
    private int _freezeTracingPocosReenters = 0;

    internal WeakEventManager PocoChangedEventManager { get; init; } = new();
    internal WeakEventManager PocoStateChangedEventManager { get; init; } = new();
    internal WeakEventManager DeletionRequestedEventManager { get; init; } = new();

    public bool TracePocos {
        get => _tracePocos;
        set
        {
            if (value != _tracePocos)
            {
                if (_tracePocos)
                {
                    _tracedPocos.Clear();
                }
                _tracePocos = value;
            }
        }
    }

    public IDictionary<Type, int> TracedPocos => _tracedPocos;

    public ICollection<IPoco> ModifiedPocos => _changedPocos.Keys;

    public PocoContext(IServiceProvider services)
    {
        _services = services;
        _core = (_services.GetRequiredService<IPocota>() as PocotaCore)!;
    }


    public JsonSerializerOptions BindJsonSerializerOptions(
        JsonSerializerOptions? options = null,
        JsonSerializerOptionsKind optionsKind = JsonSerializerOptionsKind.Ordinary
    )
    {
        if (options is null)
        {
            options = new JsonSerializerOptions();
        }
        options.AllowTrailingCommas = true;
        options.ReferenceHandler = ReferenceHandler.Preserve;
        options.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
        options.Converters.Add(_services.GetRequiredService<PocoJsonConverterFactory>());
        PocoTraversalContext context = (_services.GetRequiredService<IPocoTraversalContext>() as PocoTraversalContext)!;
        context.JsonSerializerOptionsKind = optionsKind;
        context.JsonSerializerOptions = options;
        _core.AddPocoJsonContext(options, context);
        return options;
    }

    public IPocoTraversalContext? GetTraversalContext(JsonSerializerOptions options)
    {
        if (_core.TryGetPocoJsonContext(options, out PocoTraversalContext? context))
        {
            return context;
        }
        return null;
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

    public bool TryGetSource(Type type, object[] primaryKey, out object? value)
    {
        lock (_getSourceLock)
        {
            value = null;
            bool res = true;
            Type? actualType = _core.GetActualType(type);
            if (
                actualType is { }
                && primaryKey is { }
                && primaryKey.All(v => v is { })
            )
            {
                if (_cachedObjects!.TryGetValue(actualType, out var dict))
                {
                    if (dict.TryGetValue(primaryKey, out WeakReference? wr))
                    {
                        if (!wr.IsAlive)
                        {
                            dict.Remove(primaryKey);
                            res = false;
                        }
                        else
                        {
                            value = ((IProjection)wr.Target!).As(type);
                        }
                    }
                }
                else
                {
                    _cachedObjects.Add(actualType, new Dictionary<object?[], WeakReference>(ObjectArrayEqualityComparer.Instance));
                }
                if (value is null)
                {
                    value = _services.GetRequiredService(type);
                    _cachedObjects[actualType].Add(primaryKey, new WeakReference(((IProjection)value).As(actualType), false));
                    ((IProjection)value).As<EntityBase>()!.PrimaryKey = primaryKey;
                }
            }
            if (value is null)
            {
                throw new InvalidOperationException();
            }
            return res;
        }
    }

    internal void OnPocoStateChanged(object? sender, NotifyPocoStateChangedEventArgs args)
    {
        if (args.NewState is PocoState.Created || args.NewState is PocoState.Modified || args.NewState is PocoState.Deleted)
        {
            _changedPocos.TryAdd((sender as PocoBase)!, string.Empty);
            ModifiedPocosChanged?.Invoke(this, new EventArgs());
        }
        else
        {
            if(_changedPocos.TryRemove((sender as PocoBase)!, out string _))
            {
                ModifiedPocosChanged?.Invoke(this, new EventArgs());
            }
        }
    }

    internal void PocoInstantiated(PocoBase poco)
    {
        poco.PocoStateChanged += OnPocoStateChanged;
        if (_tracePocos)
        {
            lock (_tracedPocos)
            {
                if (!_tracedPocos.ContainsKey(poco.GetType()))
                {
                    _tracedPocos.Add(poco.GetType(), 1);
                }
                else
                {
                    ++_tracedPocos[poco.GetType()];
                }
            }
            if (_freezeTracingPocosReenters == 0)
            {
                TracedPocosChanged?.Invoke(this, new EventArgs());
            }
        }
    }

    internal void PocoFinalized(PocoBase poco)
    {
        poco.PocoStateChanged -= OnPocoStateChanged;
        if (_tracePocos)
        {
            --_tracedPocos[poco.GetType()];
            if(_freezeTracingPocosReenters == 0)
            {
                TracedPocosChanged?.Invoke(this, new EventArgs());
            }
        }
    }

    internal void FreezeTracingPocos()
    {
        Interlocked.Increment(ref _freezeTracingPocosReenters);
    }

    internal void UnfreezeTracingPocos()
    {
        if(Interlocked.Decrement(ref _freezeTracingPocosReenters) == 0)
        {
            TracedPocosChanged?.Invoke(this, new EventArgs());
        }
    }
}
