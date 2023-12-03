﻿
using Microsoft.Extensions.DependencyInjection;

namespace Net.Leksi.Pocota;

public abstract class Contract: ContractBase
{
    public event ContractEventHandler? ContractProcessing;

    protected IServiceProvider? _serviceProvider = null;
    public sealed override EntityInfo<T> Entity<T>()
    {
        EntityInfo<T> info = new(this);
        ContractProcessing?.Invoke(new ContractEventArgs { PocoType = typeof(T), EventKind = ContractEventKind.Poco });
        return info;
    }

    public sealed override PocoInfo<T> Envelope<T>()
    {
        PocoInfo<T> info = new(this);
        ContractProcessing?.Invoke(new ContractEventArgs { PocoType = typeof(T), EventKind = ContractEventKind.Poco });
        return info;
    }

    public sealed override void Output<T>(Func<T, object[]> config)
    {
        if (_serviceProvider is { })
        {
            ContractProcessing?.Invoke(new ContractEventArgs { PocoType = typeof(T), EventKind = ContractEventKind.Output });
            T obj = _serviceProvider.GetRequiredService<T>();
            config?.Invoke(obj);
        }
    }

    public sealed override object Mandatory(object obj)
    {
        if (_serviceProvider is { })
        {
            ContractProcessing?.Invoke(new ContractEventArgs { EventKind = ContractEventKind.Mandatory });
        }
        return obj;
    }
    public sealed override void Property(object obj, string propertyName)
    {
        ContractProcessing?.Invoke(new ContractEventArgs { Poco = obj, EventKind = ContractEventKind.Property, Property = propertyName });
    }
    internal void AccessSelector<T>(Func<T, object[]> config) where T : class
    {
        if (_serviceProvider is { })
        {
            T obj = _serviceProvider.GetRequiredService<T>();
            ContractProcessing?.Invoke(new ContractEventArgs { PocoType = typeof(T), Poco = obj, EventKind = ContractEventKind.AccessSelector });
            config?.Invoke(obj);
        }
    }

    internal void PrimaryKey<T>(Func<T, object[]> config) where T : class
    {
        if (_serviceProvider is { })
        {
            T obj = _serviceProvider.GetRequiredService<T>();
            ContractProcessing?.Invoke(new ContractEventArgs { PocoType = typeof(T), Poco = obj, EventKind = ContractEventKind.PrimaryKey });
            config?.Invoke(obj);
        }
    }

}
