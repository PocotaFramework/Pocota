using CatsCommon.Filters;
using CatsCommon.Model;

namespace CatsServerEngine;

internal class ServicesConfigurator
{
    internal static void Configure(IServiceCollection services)
    {
        services.AddTransient<BreedPoco>();
        services.AddTransient<Cat>();
        services.AddTransient<CatteryPoco>();
        services.AddTransient<LitterPoco>();
        services.AddTransient<BreedFilterPoco>();
        services.AddTransient<CatteryFilterPoco>();
        services.AddTransient<CatFilterPoco>();
        services.AddTransient<LitterFilterPoco>();
    }
}