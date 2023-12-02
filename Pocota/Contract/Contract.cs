
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

    }

    public sealed override object Mandatory(object obj)
    {
        return obj;
    }

    internal void AccessSelector<T>(Func<T, object[]> config) where T : class
    {
        if (_serviceProvider is { })
        {
            ContractProcessing?.Invoke(new ContractEventArgs { PocoType = typeof(T), EventKind = ContractEventKind.AccessSelector });
            T obj = _serviceProvider.GetRequiredService<T>();
            Console.WriteLine(config);
            config?.Invoke(obj);
        }
    }

    internal void PrimaryKey<T>(Func<T, object[]> config) where T : class
    {
        if (_serviceProvider is { })
        {
            ContractProcessing?.Invoke(new ContractEventArgs { PocoType = typeof(T), EventKind = ContractEventKind.PrimaryKey });
            T obj = _serviceProvider.GetRequiredService<T>();
            config?.Invoke(obj);
        }
    }

}
