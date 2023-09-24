using System.Runtime.CompilerServices;

namespace Net.Leksi.Pocota.Common;

public abstract class Contract: ContractBase
{
    public event ContractEventHandler? ContractEvent;

    public Func<Type, object?> GetObject { get; set; } = null!;

    internal void PrimaryKey<T>(Func<T, object> name)
    {
        if(GetObject(typeof(T)) is T target)
        {
            try
            {
                ContractEvent?.Invoke(this, new ContractEventArgs { PocoType = typeof(T), 
                    EventKind = ContractEventKind.PrimaryKey, IsStarting = true });
                name?.Invoke(target);
            }
            finally
            {
                ContractEvent?.Invoke(this, new ContractEventArgs { PocoType = typeof(T), 
                    EventKind = ContractEventKind.PrimaryKey, });
            }
        }
    }

    internal void AccessSelector<T>(Func<T, object> name)
    {
        if (GetObject(typeof(T)) is T target)
        {
            try
            {
                ContractEvent?.Invoke(this, new ContractEventArgs { PocoType = typeof(T),
                    EventKind = ContractEventKind.AccessSelector, IsStarting = true });
                name?.Invoke(target);
            }
            finally
            {
                ContractEvent?.Invoke(this, new ContractEventArgs { PocoType = typeof(T), 
                    EventKind = ContractEventKind.AccessSelector, });
            }
        }
    }

    public abstract void AddPocos();

    protected override sealed PocoEntityInfo<T> Entity<T>() where T : class
    {
        try
        {
            PocoEntityInfo<T> result = new PocoEntityInfo<T>(this);
            ContractEvent?.Invoke(this, new AddPocoEventArgs { PocoType = typeof(T), IsEntity = true, IsStarting = true, });
            return result;
        }
        finally
        {
            ContractEvent?.Invoke(this, new AddPocoEventArgs { PocoType = typeof(T), });
        }
   }

    protected override sealed PocoInfo<T> Envelope<T>() where T : class
    {
        try
        {
            PocoInfo<T> result = new PocoInfo<T>(this);
            ContractEvent?.Invoke(this, new AddPocoEventArgs { PocoType = typeof(T), IsStarting = true, });
            return result;
        }
        finally
        {
            ContractEvent?.Invoke(this, new AddPocoEventArgs { });
        }
    }

    protected override sealed void UseProperty<T>(Func<T, object> paths, [CallerMemberName]string? methodName = null) where T: class
    {
        if(GetObject.Invoke(typeof(T)) is T target)
        {
            try
            {
                ContractEvent?.Invoke(this, new ContractEventArgs { EventKind = ContractEventKind.UseProperty, IsStarting = true });
                paths.Invoke(target);
            }
            finally
            {
                ContractEvent?.Invoke(this, new ContractEventArgs { EventKind = ContractEventKind.UseProperty, });
            }
        }
    }

    protected override sealed object Mandatory(object value) 
    {
        try
        {
            ContractEvent?.Invoke(this, new ContractEventArgs { EventKind = ContractEventKind.Mandatory, IsStarting = true });
            return value;
        }
        finally
        {
            ContractEvent?.Invoke(this, new ContractEventArgs { EventKind = ContractEventKind.Mandatory });
        }
    }
}
