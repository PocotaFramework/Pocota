using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.Server;

public class Core: Common.Core
{
    public static void UseContractConfigurator<TConfigurator>(IServiceCollection services)
        where TConfigurator : IContractConfigurator, new()
    {
        if (services is Core core)
        {
            core.IsConfiguringContract = true;
            new TConfigurator().Configure(services);
            core.IsConfiguringContract = false;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

}
