using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client.Core;
using Net.Leksi.Pocota.Common;
using System.Collections.Immutable;

namespace Net.Leksi.Pocota.Client;

public abstract class EntityBase : PocoBase, IEntity
{
    private bool _isDeleting = false;

    internal object[]? PrimaryKey { get; set; } = null;

    internal override bool IsEnvelope => false;

    protected abstract IEnumerable<string> KeyNames { get; }

    IEnumerable<string> IEntity.KeyNames => KeyNames;

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
            OnPocoStateChanged(new PocoStateChangedEventArgs(oldPocoState, newPocoState));
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

                            DebugAccess("1");

                            if (properties is { })
                            {
                                foreach(Property prop in properties)
                                {
                                    prop.CancelChange(this);
                                }
                            }
                            DebugAccess("2");
                        }

                        DeletionEventArgs preRequest = new(true);
                        OnDeletionRequested(preRequest);

                        Deleting();

                        if (preRequest.IsReferencedByEnvelope)
                        {
                            OnDeletionRequested(new DeletionEventArgs(false));
                        }

                        PocoState oldPocoState = ((IPoco)this).PocoState;
                        _pocoState = _pocoState is PocoState.Created ? PocoState.Uncertain : PocoState.Deleted;
                        OnPocoStateChanged(new PocoStateChangedEventArgs(oldPocoState, _pocoState));
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
                        OnPocoStateChanged(new PocoStateChangedEventArgs(PocoState.Deleted, newPocoState));
                    }
                    finally
                    {
                        _isDeleting = false;
                    }
                }
            }
        }
    }

    protected virtual void Deleting() { }

    protected virtual void Undeleting() { }

    protected virtual void DebugAccess(string selector) { }
}
