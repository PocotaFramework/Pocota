using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Context;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Net.Leksi.Pocota.Client;

public abstract class EntityBase : PocoBase, IEntity, IReferencersCountable
{
    private bool _isDeleting = false;

    internal ConcurrentDictionary<Tuple<PocoBase, IProperty>, byte> Referencers { get; init; } = new(ReferencerEqualityComparer.Instance);

    internal object[]? PrimaryKey { get; set; } = null;

    internal override bool IsEnvelope => false;

    ImmutableArray<object>? IEntity.PrimaryKey => PrimaryKey?.ToImmutableArray();

    public EntityBase(IServiceProvider services) : base(services) 
    {
        _pocoState = PocoState.Uncertain;
    }

    void IPoco.AcceptChanges()
    {
        throw new InvalidOperationException($"Accepting changes is forbidden for {nameof(IEntity)}!");
    }

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
        if (!_isDeleting)
        {
            lock (_lock)
            {
                if (!_isDeleting)
                {
                    _isDeleting = true;
                    try
                    {
                        if (_pocoState is PocoState.Deleted)
                        {
                            throw new InvalidOperationException($"{((IPoco)this).PocoState} Poco cannot be deleted!");
                        }

                        if(_pocoState is PocoState.Created)
                        {
                            ImmutableList<IProperty>? properties = _services.GetRequiredService<PocotaCore>().GetPropertiesList(GetType());
                            if(properties is { })
                            {
                                foreach(Property prop in properties)
                                {
                                    prop.CancelChange(this);
                                }
                            }
                        }

                        Deleting();

                        List<Tuple<PocoBase, IProperty>>? envelopesReferencers = null;
                        foreach(Tuple<PocoBase, IProperty>? referencer in Referencers.Select(v => v.Key))
                        {
                            if (referencer.Item1.IsEnvelope)
                            {
                                if(envelopesReferencers is null)
                                {
                                    envelopesReferencers = new List<Tuple<PocoBase, IProperty>>();
                                }
                                envelopesReferencers.Add(referencer);
                            }
                            else if(referencer.Item1 is EntityBase entity && entity._pocoState is not PocoState.Deleted)
                            {
                                throw new InvalidOperationException($"Referenced Poco cannot be deleted!");
                            }
                        }
                        if(envelopesReferencers is { })
                        {
                            foreach (Tuple<PocoBase, IProperty>? referencer in envelopesReferencers)
                            {
                                if (referencer.Item2.IsCollection)
                                {
                                    ((IList)referencer.Item2.Get(referencer.Item1)!).Remove(this);
                                }
                                else
                                {
                                    referencer.Item2.Set(referencer.Item1, default);
                                }
                            }
                        }
                        Referencers.Clear();

                        PocoState oldPocoState = ((IPoco)this).PocoState;
                        _pocoState = _pocoState is PocoState.Created ? PocoState.Uncertain : PocoState.Deleted;
                        OnPocoStateChanged(new NotifyPocoStateChangedEventArgs(oldPocoState, _pocoState));
                    }
                    finally
                    {
                        _isDeleting = false;
                    }
                }
            }
        }
    }

    void IEntity.Undelete()
    {
        if (!_isDeleting)
        {
            lock (_lock)
            {
                if (!_isDeleting)
                {
                    _isDeleting = true;
                    try
                    {
                        if (_pocoState is not PocoState.Deleted)
                        {
                            throw new InvalidOperationException($"{((IPoco)this).PocoState} Poco cannot be undeleted!");
                        }
                        if (_isCreated)
                        {
                            throw new InvalidOperationException($"{PocoState.Created} and {((IPoco)this).PocoState} Poco cannot be undeleted!");
                        }
                        else
                        {
                            _pocoState = PocoState.Unchanged;
                        }

                        Undeleting();

                        PocoState newPocoState = ((IPoco)this).PocoState;
                        OnPocoStateChanged(new NotifyPocoStateChangedEventArgs(PocoState.Deleted, newPocoState));
                    }
                    finally
                    {
                        _isDeleting = false;
                    }
                }
            }
        }
    }

    void IReferencersCountable.AddReferencer(PocoBase obj, IProperty prop)
    {
        Referencers.TryAdd(new Tuple<PocoBase, IProperty>(obj, prop), 0);
    }

    void IReferencersCountable.RemoveReferencer(PocoBase obj, IProperty prop)
    {
        Referencers.TryRemove(new Tuple<PocoBase, IProperty>(obj, prop), out byte _);
    }

    void IReferencersCountable.RemoveReferencer(Tuple<PocoBase, IProperty> referencer)
    {
        Referencers.TryRemove(referencer, out byte _);
    }

    protected virtual void Deleting() { }

    protected virtual void Undeleting() { }
}
