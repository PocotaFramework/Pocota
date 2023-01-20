using Net.Leksi.Pocota.Client.Json;
using Net.Leksi.Pocota.Common;
using System.Collections;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Net.Leksi.Pocota.Client;

public abstract class EntityBase : PocoBase, IEntity
{
    internal object[]? PrimaryKey { get; set; } = null;

    internal override bool IsEnvelope => false;

    ImmutableArray<object>? IEntity.PrimaryKey => PrimaryKey?.ToImmutableArray();

    public EntityBase(IServiceProvider services) : base(services) { }

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
}
