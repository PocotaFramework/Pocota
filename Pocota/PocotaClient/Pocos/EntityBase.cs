using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Context;
using Net.Leksi.Pocota.Client.Json;
using Net.Leksi.Pocota.Common;
using System.Collections;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Net.Leksi.Pocota.Client;

public abstract class EntityBase : PocoBase, IEntity
{
    private ConditionalWeakTable<PocoTraversalContext, object>? _overwriters = null;
    private Dictionary<string, Tuple<int, object?>> _deferredOverwritings = null;
    private int _overwritersGenId = 0;

    internal object[]? PrimaryKey { get; set; } = null;

    internal override bool IsEnvelope => false;

    ImmutableArray<object>? IEntity.PrimaryKey => PrimaryKey?.ToImmutableArray();

    public EntityBase(IServiceProvider services) : base(services) { }

    void IEntity.Create()
    {
        lock (_lock)
        {
            if (_pocoState is not PocoState.Uncertain)
            {
                throw new InvalidOperationException($"{((IPoco)this).PocoState} Poco cannot be created!");
            }
            _isCreated = true;
            PocoState oldPocoState = ((IPoco)this).PocoState;
            _pocoState = PocoState.Created;
            PocoState newPocoState = ((IPoco)this).PocoState;
            OnPocoStateChanged(new NotifyPocoStateChangedEventArgs(oldPocoState, newPocoState));
        }
    }

    void IEntity.Delete()
    {
        lock (_lock)
        {
            PocoState oldPocoState = ((IPoco)this).PocoState;
            if (_pocoState is PocoState.Created)
            {
                _pocoState = PocoState.Uncertain;
            }
            else if (_pocoState is not PocoState.Deleted)
            {
                _pocoState = PocoState.Deleted;
            }
            else
            {
                throw new InvalidOperationException($"{((IPoco)this).PocoState} Poco cannot be deleted!");
            }
            PocoState newPocoState = ((IPoco)this).PocoState;
            OnPocoStateChanged(new NotifyPocoStateChangedEventArgs(oldPocoState, newPocoState));
        }
    }

    internal object? DeferredOverwriting(PocoTraversalContext context, string property, object? value)
    {
        lock (_lock)
        {
            if (_overwriters is null)
            {
                _overwriters = new ConditionalWeakTable<PocoTraversalContext, object>();
                _deferredOverwritings = new Dictionary<string, Tuple<int, object?>>();
            }
            if (!_overwriters.TryGetValue(context, out object? id))
            {
                id = ++_overwritersGenId;
                _overwriters.Add(context, id);
            }
            if(!_deferredOverwritings.TryGetValue(property, out Tuple<int, object?>? pair))
            {
                _deferredOverwritings.Add(property, new Tuple<int, object?>((int)id, value));
            }
            else if((int)id >= pair.Item1)
            {
                _deferredOverwritings[property] = new Tuple<int, object?>((int)id, value);
            }
        }
        return value;
    }

    internal void OverwriteExternalUpdates()
    {
        if(_deferredOverwritings is { })
        {
            lock (_lock)
            {
                if (_deferredOverwritings is { } && _deferredOverwritings.Count > 0)
                {
                    if((_services.GetRequiredService<IPocoContext>() as PocoContext)!.ExternalUpdateProcessing is ExternalUpdateProcessing.Always)
                    {
                        ((IPoco)this).CancelChanges();
                        foreach(var pair in _deferredOverwritings)
                        {
                            if(_pocota.GetProperties(GetType())?[pair.Key] is Property property)
                            {
                                if (!property.IsCollection)
                                {
                                    property.SetValue(this, pair.Value.Item2);
                                }
                                else if (pair.Value.Item2 is IList src && property.GetValue(this) is IList dst)
                                {
                                    dst.Clear();
                                    foreach (var item in src)
                                    {
                                        dst.Add(item);
                                    }
                                }
                            }
                        }
                        ((IPoco)this).AcceptChanges();
                        _deferredOverwritings.Clear();
                    }
                    Console.WriteLine($"ovewrite {GetType()}:{GetHashCode()}: {{{string.Join(',', _deferredOverwritings.Select(e => $"{e.Key}={e.Value.Item2}({e.Value.Item1})"))}}}");
                }
            }
        }
    }

}
