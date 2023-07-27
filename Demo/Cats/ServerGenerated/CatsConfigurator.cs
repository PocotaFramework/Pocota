
///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Contract.CatsConfigurator                              //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-27T18:03:12.                                                           //
// Modifying this file will break the program!                                       //
///////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Pocota.Demo.Cats.Contract;

public class CatsConfigurator : IContractConfigurator
{
    public void Configure(Core core)
    {
        core.StartAddContract<ICatContract>();
        core.AddTransient<ICat, CatPoco>();
        core.AddScoped<ICatAccessManager, CatAllowAccessManager>();
        core.AddTransient<IBreed, BreedPoco>();
        core.AddScoped<IBreedAccessManager, BreedAllowAccessManager>();
        core.AddTransient<ICattery, CatteryPoco>();
        core.AddScoped<ICatteryAccessManager, CatteryAllowAccessManager>();
        core.AddTransient<ILitter, LitterPoco>();
        core.AddScoped<ILitterAccessManager, LitterAllowAccessManager>();
        core.AddTransient<ICatFilter, CatFilterPoco>();
        core.AddTransient<IBreedFilter, BreedFilterPoco>();
        core.AddTransient<ICatteryFilter, CatteryFilterPoco>();
        core.AddTransient<ILitterFilter, LitterFilterPoco>();
        core.AddTransient<IPedigree, PedigreePoco>();
        core.AddScoped<IPedigreeAccessManager, PedigreeAllowAccessManager>();
        core.AddSingleton<IFindCatsDataProviderFactory, FindCatsDefaultDataProviderFactory>();
        core.AddSingleton<IFindCatsProcessorFactory, FindCatsDefaultProcessorFactory>();
        core.AddSingleton<IGetCatDataProviderFactory, GetCatDefaultDataProviderFactory>();
        core.AddSingleton<IGetCatProcessorFactory, GetCatDefaultProcessorFactory>();
        core.AddSingleton<IFindBreedsDataProviderFactory, FindBreedsDefaultDataProviderFactory>();
        core.AddSingleton<IFindBreedsProcessorFactory, FindBreedsDefaultProcessorFactory>();
        core.AddSingleton<IFindCatteriesDataProviderFactory, FindCatteriesDefaultDataProviderFactory>();
        core.AddSingleton<IFindCatteriesProcessorFactory, FindCatteriesDefaultProcessorFactory>();
        core.AddSingleton<IFindLittersDataProviderFactory, FindLittersDefaultDataProviderFactory>();
        core.AddSingleton<IFindLittersProcessorFactory, FindLittersDefaultProcessorFactory>();
        core.AddSingleton<IFindExteriorsDataProviderFactory, FindExteriorsDefaultDataProviderFactory>();
        core.AddSingleton<IFindExteriorsProcessorFactory, FindExteriorsDefaultProcessorFactory>();
        core.AddSingleton<IFindTitlesDataProviderFactory, FindTitlesDefaultDataProviderFactory>();
        core.AddSingleton<IFindTitlesProcessorFactory, FindTitlesDefaultProcessorFactory>();
        core.MapPrimaryKeyType(typeof(ICat), typeof(CatPrimaryKey));
        core.MapPrimaryKeyType(typeof(CatPoco), typeof(CatPrimaryKey));
        core.MapPrimaryKeyType(typeof(IBreed), typeof(BreedPrimaryKey));
        core.MapPrimaryKeyType(typeof(BreedPoco), typeof(BreedPrimaryKey));
        core.MapPrimaryKeyType(typeof(ICattery), typeof(CatteryPrimaryKey));
        core.MapPrimaryKeyType(typeof(CatteryPoco), typeof(CatteryPrimaryKey));
        core.MapPrimaryKeyType(typeof(ILitter), typeof(LitterPrimaryKey));
        core.MapPrimaryKeyType(typeof(LitterPoco), typeof(LitterPrimaryKey));
        core.MapPrimaryKeyType(typeof(IPedigree), typeof(CatPrimaryKey));
        core.MapPrimaryKeyType(typeof(PedigreePoco), typeof(CatPrimaryKey));
        core.MapAccessManagerType(typeof(ICat), typeof(ICatAccessManager));
        core.MapAccessManagerType(typeof(CatPoco), typeof(ICatAccessManager));
        core.MapAccessManagerType(typeof(IBreed), typeof(IBreedAccessManager));
        core.MapAccessManagerType(typeof(BreedPoco), typeof(IBreedAccessManager));
        core.MapAccessManagerType(typeof(ICattery), typeof(ICatteryAccessManager));
        core.MapAccessManagerType(typeof(CatteryPoco), typeof(ICatteryAccessManager));
        core.MapAccessManagerType(typeof(ILitter), typeof(ILitterAccessManager));
        core.MapAccessManagerType(typeof(LitterPoco), typeof(ILitterAccessManager));
        core.MapAccessManagerType(typeof(IPedigree), typeof(IPedigreeAccessManager));
        core.MapAccessManagerType(typeof(PedigreePoco), typeof(IPedigreeAccessManager));
    }
}