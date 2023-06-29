using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.Server;

public class Core: Common.Core
{
    public static void UseContractConfigurator<TConfigurator, TController>(IServiceCollection services)
        where TConfigurator : IContractConfigurator, new()
        where TController : Controller, IPocotaController
    {
        if (services is Core core)
        {
            core.IsConfiguringContract = true;
            new TConfigurator().Configure<TController>(services);
            core.IsConfiguringContract = false;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

}
