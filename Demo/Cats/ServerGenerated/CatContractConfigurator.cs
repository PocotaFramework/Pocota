
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Contract.CatContractConfigurator                   //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-29T10:49:35                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Server;
using Net.Leksi.Pocota.Server.Generic;

namespace Net.Leksi.Pocota.Demo.Cats.Contract;

public class CatContractConfigurator : Pocota.Server.IContractConfigurator
{
    public void Configure<TController>(IServiceCollection services) where TController : Controller, IPocotaController
    {
        services.AddTransient<ICat, CatPoco>();
        services.AddTransient<CatPoco>();
        services.AddTransient<IPrimaryKey<ICat>, CatPrimaryKey>();
        services.AddTransient<CatPrimaryKey>();
        services.AddTransient<IBreed, BreedPoco>();
        services.AddTransient<BreedPoco>();
        services.AddTransient<IPrimaryKey<IBreed>, BreedPrimaryKey>();
        services.AddTransient<BreedPrimaryKey>();
        services.AddTransient<ICattery, CatteryPoco>();
        services.AddTransient<CatteryPoco>();
        services.AddTransient<IPrimaryKey<ICattery>, CatteryPrimaryKey>();
        services.AddTransient<CatteryPrimaryKey>();
        services.AddTransient<ILitter, LitterPoco>();
        services.AddTransient<LitterPoco>();
        services.AddTransient<IPrimaryKey<ILitter>, LitterPrimaryKey>();
        services.AddTransient<LitterPrimaryKey>();
        services.AddTransient<ICatFilter, CatFilterPoco>();
        services.AddTransient<CatFilterPoco>();
        services.AddTransient<IBreedFilter, BreedFilterPoco>();
        services.AddTransient<BreedFilterPoco>();
        services.AddTransient<ICatteryFilter, CatteryFilterPoco>();
        services.AddTransient<CatteryFilterPoco>();
        services.AddTransient<ILitterFilter, LitterFilterPoco>();
        services.AddTransient<LitterFilterPoco>();
        services.AddTransient<ILitterWithCats, LitterWithCatsPoco>();
        services.AddTransient<LitterWithCatsPoco>();
        services.Add(new ServiceDescriptor(typeof(ICatsController), typeof(TController), ServiceLifetime.Transient));
    }
}