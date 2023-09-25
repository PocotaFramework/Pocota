namespace Net.Leksi.Pocota.Common;

public abstract class Contract : ContractBase
{
    public event ParseContractEventHandler? ParseContractEvent;

    public Func<Type, object?> GetObject { get; set; } = null!;
    public abstract string Version { get; }
    public virtual string RoutePrefix { get; private init; } = string.Empty;

    public abstract void AddPocos();

    internal void PrimaryKey<T>(Func<T, object> name)
    {
        if (GetObject(typeof(T)) is T target)
        {
            try
            {
                ParseContractEvent?.Invoke(this, new ParseContractEventArgs
                {
                    PocoType = typeof(T),
                    EventKind = ParseContractEventKind.PrimaryKey,
                    IsStarting = true
                });
                name?.Invoke(target);
            }
            finally
            {
                ParseContractEvent?.Invoke(this, new ParseContractEventArgs
                {
                    PocoType = typeof(T),
                    EventKind = ParseContractEventKind.PrimaryKey,
                });
            }
        }
    }

    internal void AccessSelector<T>(Func<T, object> name)
    {
        if (GetObject(typeof(T)) is T target)
        {
            try
            {
                ParseContractEvent?.Invoke(this, new ParseContractEventArgs
                {
                    PocoType = typeof(T),
                    EventKind = ParseContractEventKind.AccessSelector,
                    IsStarting = true
                });
                name?.Invoke(target);
            }
            finally
            {
                ParseContractEvent?.Invoke(this, new ParseContractEventArgs
                {
                    PocoType = typeof(T),
                    EventKind = ParseContractEventKind.AccessSelector,
                });
            }
        }
    }

    internal void Calculated<T>(Func<T, object> name)
    {
        if (GetObject(typeof(T)) is T target)
        {
            try
            {
                ParseContractEvent?.Invoke(this, new ParseContractEventArgs
                {
                    PocoType = typeof(T),
                    EventKind = ParseContractEventKind.Calculated,
                    IsStarting = true
                });
                name?.Invoke(target);
            }
            finally
            {
                ParseContractEvent?.Invoke(this, new ParseContractEventArgs
                {
                    PocoType = typeof(T),
                    EventKind = ParseContractEventKind.Calculated,
                });
            }
        }
    }

    internal void Link<TFrom, TTo>(Func<TFrom, object> from, Func<TTo, object> to)
    {
    }
    protected override sealed PocoEntityInfo<T> Entity<T>() where T : class
    {
        try
        {
            PocoEntityInfo<T> result = new PocoEntityInfo<T>(this);
            ParseContractEvent?.Invoke(this, new AddPocoEventArgs { PocoType = typeof(T), IsEntity = true, IsStarting = true, });
            return result;
        }
        finally
        {
            ParseContractEvent?.Invoke(this, new AddPocoEventArgs { PocoType = typeof(T), });
        }
    }

    protected override sealed PocoInfo<T> Envelope<T>() where T : class
    {
        try
        {
            PocoInfo<T> result = new PocoInfo<T>(this);
            ParseContractEvent?.Invoke(this, new AddPocoEventArgs { PocoType = typeof(T), IsStarting = true, });
            return result;
        }
        finally
        {
            ParseContractEvent?.Invoke(this, new AddPocoEventArgs { });
        }
    }

    protected override sealed void UseProperty<T>(Func<T, object> paths) where T : class
    {
        if (GetObject.Invoke(typeof(T)) is T target)
        {
            try
            {
                ParseContractEvent?.Invoke(this, new ParseContractEventArgs { PocoType = typeof(T), EventKind = ParseContractEventKind.PropertyUse, IsStarting = true });
                paths.Invoke(target);
            }
            finally
            {
                ParseContractEvent?.Invoke(this, new ParseContractEventArgs { PocoType = typeof(T), EventKind = ParseContractEventKind.PropertyUse, });
            }
        }
    }

    protected override sealed object Mandatory(object value)
    {
        ParseContractEvent?.Invoke(this, new ParseContractEventArgs { EventKind = ParseContractEventKind.Mandatory });
        return value;
    }
}
