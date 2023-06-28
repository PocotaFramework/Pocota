using Microsoft.AspNetCore.Http.Features;
using Net.Leksi.Pocota.Demo.Cats.Contract;
using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Pocota.Demo.Cats.Server;

public static class CatsServerExtensions
{
    public static IServiceCollection AddCatsServer(this IServiceCollection services, string connectionString)
    {
        services.AddPocota(new CatContractConfigurator().Configure);

        services.AddScoped<IStorage>(serviceProvider => new Storage(
            serviceProvider,
            connectionString)
        );

        services.AddScoped<IPocoContext, PocoContext>();
        services.AddScoped<ICatsController, CatsController>();

        services.AddControllers();

        return services;
    }

    public static WebApplication UseCatsServer(this WebApplication app)
    {

        app.Use(async (context, next) =>
        {
            var syncIOFeature = context.Features.Get<IHttpBodyControlFeature>();
            if (syncIOFeature != null)
            {
                syncIOFeature.AllowSynchronousIO = true;
            }
            await next?.Invoke()!;
        });

        app.MapControllers();
        app.UsePocotaExceptionsHandler();

        return app;
    }

    public static WebApplication UsePocotaExceptionsHandler(this WebApplication app)
    {
        Middleware.UsePocotaExceptionsHandler(app);
        return app;
    }

}
