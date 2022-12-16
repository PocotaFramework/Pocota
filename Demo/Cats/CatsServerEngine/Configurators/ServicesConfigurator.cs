using CatsCommon.Filters;
using CatsCommon.Model;

namespace CatsServerEngine;

internal class ServicesConfigurator
{
    internal static void Configure(IServiceCollection services)
    {
        services.AddTransient<BreedBase>();
        services.AddTransient<Cat>();
        services.AddTransient<CatteryBase>();
        services.AddTransient<LitterBase>();
        services.AddTransient<BreedFilterBase>();
        services.AddTransient<CatteryFilterBase>();
        services.AddTransient<CatFilterBase>();
        services.AddTransient<LitterFilterBase>();
    }
}