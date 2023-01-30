﻿using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Context;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Client.Json;
using Net.Leksi.Pocota.Common;
using System.Collections.Specialized;
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

    private readonly ConditionalWeakTable<NotifyPocoChangedEventArgs, HashSet<string>> _notifiers = new();
    private HashSet<IProperty>? _modified = null;
    protected bool _isCreated = false;

    protected bool _cancellingChanges = false;

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
        _pocoContext = (_services.GetRequiredService<IPocoContext>() as PocoContext)!;
        _pocoContext.PocoInstantiated(this);
        _pocoState = PocoState.Unchanged;
    }

    ~PocoBase()
    {
        _pocoContext.PocoFinalized(this);
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
            if (_modified is { } && _modified.Count > 0)
            {
                foreach (Property property in _modified)
                {
                    property.AcceptChange(this);
                }
                _modified.Clear();
            }
            _pocoState = PocoState.Unchanged;
            PocoState newPocoState = ((IPoco)this).PocoState;
            if (oldPocoState != newPocoState)
            {
                OnPocoStateChanged(new NotifyPocoStateChangedEventArgs(oldPocoState, newPocoState));
            }
        }
    }

    void IPoco.CancelChanges()
    {
        lock (_lock)
        {
            PocoState oldPocoState = ((IPoco)this).PocoState;
            if (_pocoState is PocoState.Unchanged && _modified is { } && _modified.Count > 0)
            {
                try
                {
                    _cancellingChanges = true;

                    foreach (Property property in _modified)
                    {
                        property.CancelChange(this);
                        if(property.Get(this) is EntityBase entity1 && entity1._pocoState is PocoState.Deleted)
                        {
                            if (IsEnvelope)
                            {
                                property.Set(this, default);
                            }
                            else
                            {
                                throw new InvalidOperationException($"Unchanged property {property.Name} refers to a deleted entity!");
                            }
                        }
                    }

                    _modified.Clear();

                    _cancellingChanges = false;
                }
                finally
                {
                    _cancellingChanges = false;
                }
            }
            if(this is IEntity entity)
            {
                if(entity.PocoState is PocoState.Created)
                {
                    entity.Delete();
                    return;
                }
                if (_pocoState is PocoState.Deleted)
                {
                    entity.Undelete();
                    return;
                }
            }
            PocoState newPocoState = ((IPoco)this).PocoState;
            if (oldPocoState != newPocoState)
            {
                OnPocoStateChanged(new NotifyPocoStateChangedEventArgs(oldPocoState, newPocoState));
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

    protected virtual void OnPocoChanged(Property property)
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
                        if (!property.IsInitial(this))
                        {
                            (_modified ?? (_modified = new HashSet<IProperty>())).Add(property);
                        }
                        else
                        {
                            _modified?.Remove(property);
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

    protected void OnPocoStateChanged(NotifyPocoStateChangedEventArgs args)
    {
        lock (_lock)
        {
            _pocoContext.PocoStateChangedEventManager.InvokeHandlers(this, new object[] { this, args });
            OnPocoChanged(new NotifyPocoChangedEventArgs());
        }
    }

}
