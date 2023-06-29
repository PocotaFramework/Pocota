using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Demo.Cats.Contract;
using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Pocota.Demo.Cats.Server;

public static class CatsServerExtensions
{
    public static IServiceCollection AddCatsServer(this IServiceCollection services, string connectionString)
    {
        services.AddPocota(serv =>
        {
            serv.AddContract<CatContractConfigurator, CatsController>();
            serv.AddTransient<ICat, Cat>();
        });

        services.AddScoped<IStorage>(serviceProvider => new Storage(
            serviceProvider,
            connectionString)
        );

        return services;
    }

    public static WebApplication UseCatServer(this WebApplication app)
    {
        app.UsePocota();
        return app;
    }

}
