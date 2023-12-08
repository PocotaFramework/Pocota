
using Microsoft.Extensions.DependencyInjection;

namespace Net.Leksi.Pocota;

public abstract class Contract: ContractBase
{
    public event ContractEventHandler? ContractProcessing;

    protected IServiceProvider? _serviceProvider = null;
    public sealed override EntityInfo<T> Entity<T>()
    {
        EntityInfo<T> info = new(this);
        ContractProcessing?.Invoke(new ContractEventArgs { PocoType = typeof(T), EventKind = ContractEventKind.Poco, PocoKind = PocoKind.Entity });
        return info;
    }

    public sealed override PocoInfo<T> Envelope<T>()
    {
        PocoInfo<T> info = new(this);
        ContractProcessing?.Invoke(new ContractEventArgs { PocoType = typeof(T), EventKind = ContractEventKind.Poco, PocoKind = PocoKind.Envelope });
        return info;
    }

    public sealed override void Output<T>(Func<T, object[]> config)
    {
        if (_serviceProvider is { })
        {
            T obj = _serviceProvider.GetRequiredService<T>();
            ContractProcessing?.Invoke(new ContractEventArgs { Poco = obj, PocoType = typeof(T), EventKind = ContractEventKind.Output });
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
    public sealed override void Property(object obj, string propertyName, object? propertyValue)
    {
        ContractProcessing?.Invoke(new ContractEventArgs { Poco = obj, EventKind = ContractEventKind.Property, Property = propertyName, Value = propertyValue });
    }
    internal void AccessSelector<T>(Func<T, object[]> config) where T : class
    {
        if (_serviceProvider is { })
        {
            T obj = _serviceProvider.GetRequiredService<T>();
            ContractProcessing?.Invoke(new ContractEventArgs { PocoType = typeof(T), Poco = obj, EventKind = ContractEventKind.AccessSelector });
            config?.Invoke(obj);
            ContractProcessing?.Invoke(new ContractEventArgs { EventKind = ContractEventKind.Done });
        }
    }

    internal void PrimaryKey<T>(Func<T, object[]> config) where T : class
    {
        if (_serviceProvider is { })
        {
            T obj = _serviceProvider.GetRequiredService<T>();
            ContractProcessing?.Invoke(new ContractEventArgs { PocoType = typeof(T), Poco = obj, EventKind = ContractEventKind.PrimaryKey });
            config?.Invoke(obj);
            ContractProcessing?.Invoke(new ContractEventArgs { EventKind = ContractEventKind.Done });
        }
    }

}
