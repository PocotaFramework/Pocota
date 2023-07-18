
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Contract.CatContractConfigurator                   //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-18T19:12:59                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Pocota.Demo.Cats.Contract;

public class CatContractConfigurator : IContractConfigurator
{
    public void Configure(IServiceCollection services)
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
        services.AddTransient<IFindCatsDataProviderFactory, DataProviderStub>();
        services.AddTransient<IGetCatDataProviderFactory, DataProviderStub>();
        services.AddTransient<IFindBreedsDataProviderFactory, DataProviderStub>();
        services.AddTransient<IFindCatteriesDataProviderFactory, DataProviderStub>();
        services.AddTransient<IFindLittersWithCatsDataProviderFactory, DataProviderStub>();
        services.AddTransient<IFindExteriorsDataProviderFactory, DataProviderStub>();
        services.AddTransient<IFindTitlesDataProviderFactory, DataProviderStub>();
    }
}