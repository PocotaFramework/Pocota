using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Context;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Client.Json;
using Net.Leksi.Pocota.Common;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Net.Leksi.Pocota.Client;

public abstract class PocoBase : IPoco
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public event PocoChangedEventHandler? PocoChanged
    {
        add
        {
            _pocoContext.PocoChangedEventManager.AddHandler(this, value);
        }
        remove
        {
            _pocoContext.PocoChangedEventManager.RemoveHandler(this, value);
        }
    }

    public event PocoStateChangedEventHandler? PocoStateChanged
    {
        add
        {
            _pocoContext.PocoStateChangedEventManager.AddHandler(this, value);
        }
        remove
        {
            _pocoContext.PocoStateChangedEventManager.RemoveHandler(this, value);
        }
    }

    public static new bool ReferenceEquals(object? obj1, object? obj2)
    {
        if (obj1 is IProjection proj1 && obj2 is IProjection proj2)
        {
            return object.ReferenceEquals(proj1.As<IPoco>(), proj2.As<IPoco>());
        }
        return object.ReferenceEquals(obj1, obj2);
    }

    private readonly Dictionary<PocoTraversalContext, int> _populaters = new(ReferenceEqualityComparer.Instance);
    private readonly PocoContext _pocoContext;
    protected readonly PocotaCore _pocota;

    private readonly ConditionalWeakTable<NotifyPocoChangedEventArgs, HashSet<string>> _notifiers = new();
    private ConditionalWeakTable<object, string>? _antiCycleTokens = null;

    private readonly HashSet<string> _populatedProperties = new();

    protected bool _isCreated = false;

    protected bool _cancellingChanges = false;

    protected Dictionary<string, object?>? _modified = null;
    protected PocoState _pocoState = PocoState.Uncertain;
    protected readonly object _lock = new();

    protected readonly IServiceProvider _services;

    internal abstract bool IsEnvelope { get; }

    protected bool IsBeingPopulated
    {
        get
        {
            lock (_lock)
            {
                return _populaters.Count > 0;
            }
        }
    }

    PocoState IPoco.PocoState
    {
        get
        {
            lock (_lock)
            {
                if (_pocoState is PocoState.Unchanged && _modified is { } && _modified.Count > 0)
                {
                    return PocoState.Modified;
                }
                return _pocoState;
            }
        }
    }

    public PocoBase(IServiceProvider services)
    {
        _services = services;
        _pocota = _services.GetRequiredService<PocotaCore>();
        _pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
        _pocoContext.PocoInstantiated(this);
    }

    ~PocoBase()
    {
        _pocoContext.PocoFinalized(this);
    }

    void IPoco.CancelChanges()
    {
        lock (_lock)
        {
            PocoState oldPocoState = ((IPoco)this).PocoState;
            if (_pocoState is PocoState.Created)
            {
                _pocoState = PocoState.Uncertain;
            }
            else if (_pocoState is PocoState.Deleted)
            {
                if (_isCreated)
                {
                    _pocoState = PocoState.Uncertain;
                }
                else
                {
                    _pocoState = PocoState.Unchanged;
                }
            }
            else if (_pocoState is PocoState.Unchanged && _modified is { } && _modified.Count > 0)
            {
                try
                {
                    _cancellingChanges = true;
                    foreach (var entry in _modified)
                    {
                        if (_pocota.GetProperties(GetType())?[entry.Key] is Property property && !property.IsCollection)
                        {
                            property.SetValue(this, entry.Value);
                        }
                    }
                    _modified.Clear();
                    CancelCollectionsChanges();
                    _cancellingChanges = false;
                }
                finally
                {
                    _cancellingChanges = false;
                }
            }
            PocoState newPocoState = ((IPoco)this).PocoState;
            if (oldPocoState != newPocoState)
            {
                OnPocoStateChanged(new NotifyPocoStateChangedEventArgs(oldPocoState, newPocoState));
            }
        }
    }

    void IPoco.AcceptChanges()
    {
        if (!IsEnvelope && (_pocoState is PocoState.Uncertain || _pocoState is PocoState.Deleted))
        {
            throw new InvalidOperationException($"{((IPoco)this).PocoState} Poco cannot be processed!");
        }
        lock (_lock)
        {
            PocoState oldPocoState = ((IPoco)this).PocoState;
            if (_modified is { })
            {
                _modified.Clear();
            }
            AcceptCollectionsChanges();
            _pocoState = PocoState.Unchanged;
            PocoState newPocoState = ((IPoco)this).PocoState;
            if (oldPocoState != newPocoState)
            {
                OnPocoStateChanged(new NotifyPocoStateChangedEventArgs(oldPocoState, newPocoState));
            }
        }
    }

    bool IPoco.IsModified(string property)
    {
        return _modified?.ContainsKey(property) ?? false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        return IsLoaded(@interface, new object());
    }

    bool IPoco.IsLoaded<T>()
    {
        return IsLoaded(typeof(T), new object());
    }

    void IPoco.TouchProperty(string property)
    {
        lock (_lock)
        {
            if (_populaters.Count > 0)
            {
                _populatedProperties.Add(property!);
            }
        }
    }

    void IPoco.Invalidate()
    {
        lock (_lock)
        {
            if (_populaters.Count == 0)
            {
                _populatedProperties.Clear();
            }
        }
    }

    internal bool StopPopulate(object? sender)
    {
        bool result = true;
        if (sender is PocoTraversalContext context)
        {
            lock (_lock)
            {
                if (_populaters.TryGetValue(context, out int count))
                {
                    if (--count == 0)
                    {
                        _populaters.Remove(context);
                    }
                    else
                    {
                        result = false;
                        --_populaters[context];
                    }
                }
                if (_populaters.Count == 0)
                {
                    AcceptCollectionsChanges();
                }
            }
        }
        return result;
    }

    internal bool StartPopulate(object? sender)
    {
        bool result = false;
        if (sender is PocoTraversalContext context)
        {
            lock (_lock)
            {
                if (_pocoState is PocoState.Uncertain)
                {
                    _pocoState = PocoState.Unchanged;
                }
                result = _populaters.TryAdd(context, 1);
                if (!result)
                {
                    ++_populaters[context];
                }
            }
        }
        return result;
    }

    protected void PropagateChangeEvent(NotifyPocoChangedEventArgs args, string property)
    {
        lock (_lock)
        {
            if (!_notifiers.TryGetValue(args, out HashSet<string>? properties))
            {
                properties = new();
                _notifiers.Add(args, properties);
                OnPocoChanged(args);
            }
            if (properties.Add(property))
            {
                OnPropertyChanged(property);
            }
        }
    }

    protected abstract bool IsCollectionChanged(string property);

    protected abstract void AcceptCollectionsChanges();

    protected abstract void CancelCollectionsChanges();

    protected virtual void OnPocoChanged(object? oldValue, object? newValue, [CallerMemberName] string? property = null)
    {
        lock (_lock)
        {
            if (_populaters.Count == 0)
            {
                if (!_cancellingChanges)
                {
                    if (_pocoState is not PocoState.Created)
                    {
                        if (!IsEnvelope && (_pocoState is PocoState.Deleted || _pocoState is PocoState.Uncertain))
                        {
                            throw new InvalidOperationException($"{((IPoco)this).PocoState} Poco cannot be modified!");
                        }
                        PocoState oldPocoState = ((IPoco)this).PocoState;
                        if (_modified is null)
                        {
                            _modified = new Dictionary<string, object?>();
                        }
                        if (_pocota.GetProperties(GetType())![property!].IsCollection)
                        {
                            if (IsCollectionChanged(property!))
                            {
                                _modified.TryAdd(property!, oldValue);
                            }
                            else
                            {
                                _modified.Remove(property!);
                            }
                        }
                        else if (
                            (oldValue is { } && !oldValue.Equals(newValue) || newValue is { } && !newValue.Equals(oldValue))
                            && !(_modified.TryAdd(property!, oldValue))
                            && (
                                _modified[property!] is null && newValue is null
                                || (
                                    _modified[property!] is { } && newValue is { } && _modified[property!]!.Equals(newValue)
                                )
                            )
                        )
                        {
                            _modified.Remove(property!);
                        }

                        PocoState newPocoState = ((IPoco)this).PocoState;

                        if (oldPocoState != newPocoState)
                        {
                            OnPocoStateChanged(new NotifyPocoStateChangedEventArgs(oldPocoState, newPocoState));
                        }
                        else
                        {
                            OnPocoChanged(new NotifyPocoChangedEventArgs());
                        }
                    }
                    else
                    {
                        OnPocoChanged(new NotifyPocoChangedEventArgs());
                    }
                }
            }
            else
            {
                _populatedProperties.Add(property!);
            }
        }
    }

    protected virtual void OnPocoChanged(NotifyPocoChangedEventArgs args)
    {
        lock (_lock)
        {
            _pocoContext.PocoChangedEventManager.InvokeHandlers(this, new object[] { this, args });
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? prop = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    protected virtual void OnProjectionCreated(Type @interface, IProjection projection) { }

    protected void OnPocoStateChanged(NotifyPocoStateChangedEventArgs args)
    {
        lock (_lock)
        {
            _pocoContext.PocoStateChangedEventManager.InvokeHandlers(this, new object[] { this, args });
            OnPocoChanged(new NotifyPocoChangedEventArgs());
        }
    }

    private bool IsLoaded(Type @interface, object antiCycleToken)
    {
        if (_antiCycleTokens is null)
        {
            lock (_lock)
            {
                if (_antiCycleTokens is null)
                {
                    _antiCycleTokens = new ConditionalWeakTable<object, string>();
                }
            }
        }
        if (!_antiCycleTokens.TryGetValue(antiCycleToken, out var _))
        {
            _antiCycleTokens.Add(antiCycleToken, string.Empty);
            if(_pocota.GetProperties(@interface) is IDictionary<string, Property> properties)
            {
                return properties.Values.All(p =>
                {
                    if (_populatedProperties.Contains(p.Name))
                    {
                        if (typeof(IPoco).IsAssignableFrom(p.Type))
                        {

                            return ((PocoBase)p.GetValue(this)!)?.IsLoaded(p.Type, antiCycleToken) ?? true;
                        }
                        else if (p.IsCollection)
                        {
                            IEnumerable en = (IEnumerable)p.GetValue(this)!;
                            foreach (PocoBase item in en)
                            {
                                if (!item.IsLoaded(p.ItemType!, antiCycleToken))
                                {
                                    return false;
                                }
                            }
                        }
                        return true;
                    }
                    return false;
                });
            }
            return true;
        }
        return true;
    }
}
