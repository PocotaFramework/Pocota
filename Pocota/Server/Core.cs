using Microsoft.Extensions.DependencyInjection.Extensions;
using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public class Core: Common.Core
{
    private readonly Dictionary<Type, Type> _accessManagerTypesByType = new();

    public static void UseContractConfigurator<TConfigurator>(IServiceCollection services)
        where TConfigurator : IContractConfigurator, new()
    {
        if (services is Core core)
        {
            core.IsConfiguringContract = true;
            new TConfigurator().Configure(core);
            core.IsConfiguringContract = false;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void MapAccessManagerType(Type entityType, Type accessManagerType)
    {
        if (!IsConfiguringContract)
        {
            throw new InvalidOperationException($"Calling of the method MapPrimaryKeyType is forbidden!");
        }
        _accessManagerTypesByType.Add(entityType, accessManagerType);
    }

    protected override ServiceDescriptor? AddServiceDescriptor(ServiceDescriptor item)
    {
        if (!IsConfiguringContract)
        {
            if (typeof(IDataProviderFactory).IsAssignableFrom(item.ServiceType))
            {
                _serviceCollection!.RemoveAll(item.ServiceType);
            }
            else if (
                typeof(IPoco).IsAssignableFrom(item.ServiceType)
                || typeof(IPoco).IsAssignableFrom(item.ImplementationType)
                || typeof(IPrimaryKey).IsAssignableFrom(item.ServiceType)
            )
            {
                if (_accessManagerTypesByType[item.ServiceType] is { })
                {
                    _accessManagerTypesByType.Add(item.ImplementationType!, _accessManagerTypesByType[item.ServiceType]);
                }
            }
        }
        return base.AddServiceDescriptor(item);
    }

    public override void ReceiveTelemetry()
    {
        Services?.GetService<ICoreTelemetry>()?.Receive(new Dictionary<string, object>()
        {
            { "_actualTypes", _actualTypes },
            { "_primaryKeyTypesByType", _primaryKeyTypesByType },
            { "_accessManagerTypesByType", _accessManagerTypesByType },
        });
    }

}
