
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Contract.CatContractConfigurator                   //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-13T10:14:27                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Pocota.Demo.Cats.Contract;

public class CatContractConfigurator : IContractConfigurator
{
    public void Configure<TController>(IServiceCollection services) where TController : IPocotaController
    {
        services.StartAddContract<ICatContract>();
        services.AddTransient<ICat, CatPoco>();
        services.AddTransient<IPrimaryKey<ICat>, CatPrimaryKey>();
        services.AddTransient<IBreed, BreedPoco>();
        services.AddTransient<IPrimaryKey<IBreed>, BreedPrimaryKey>();
        services.AddTransient<ICattery, CatteryPoco>();
        services.AddTransient<IPrimaryKey<ICattery>, CatteryPrimaryKey>();
        services.AddTransient<ILitter, LitterPoco>();
        services.AddTransient<IPrimaryKey<ILitter>, LitterPrimaryKey>();
        services.AddTransient<ICatFilter, CatFilterPoco>();
        services.AddTransient<IBreedFilter, BreedFilterPoco>();
        services.AddTransient<ICatteryFilter, CatteryFilterPoco>();
        services.AddTransient<ILitterFilter, LitterFilterPoco>();
        services.AddTransient<ILitterWithCats, LitterWithCatsPoco>();
        services.Add(new ServiceDescriptor(typeof(ICatsController), typeof(TController), ServiceLifetime.Transient));
    }
}