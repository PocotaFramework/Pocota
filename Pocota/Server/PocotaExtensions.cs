using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.Server;

public static class PocotaExtensions
{
    public static IServiceCollection AddPocota(
        this IServiceCollection services,
        Action<IServiceCollection>? configureServices
    )
    {
        services.AddScoped<IPocoContext, PocoContext>();
        Core core = new();
        core.Configure(services, configureServices);
        services.AddControllers();

        return services;
    }

    public static IServiceCollection AddContract<TConfigurator, TController> (this IServiceCollection services) 
        where TConfigurator : IContractConfigurator, new()
        where TController : Controller, IPocotaController
    {
        Core.UseContractConfigurator<TConfigurator, TController>(services);
        return services;
    }

    public static IServiceCollection StartAddContract<TContract>(this IServiceCollection services)
    {
        Core.StartAddContract<TContract>(services);
        return services;
    }

    public static WebApplication UsePocota(this WebApplication app)
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
        Middleware.UsePocotaExceptionsHandler(app);

        return app;
    }



}
