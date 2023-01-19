using CatsContract;
using CatsServerDebug.Converters;
using CatsServerEngineDebug;
using CatsServerEngineDebug.ControllersImpl;
using CatsServerEngineDebug.Converters;
using Microsoft.AspNetCore.Http.Features;
using Net.Leksi.Pocota.Asp;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System.Security.Cryptography;
using System.Web;

namespace CatsServerEngine;

public static class CatsServerExtensions
{
    public static IServiceCollection AddCatsServer(this IServiceCollection services, string connectionString)
    {
        services.AddPocota(
            configureServices: ServicesConfigurator.Configure,
            configureJson: JsonConfigurator.Configure
        );

        services.AddScoped<IStorage>(serviceProvider => new Storage(
            serviceProvider,
            connectionString)
        );

        services.AddScoped<RequestStartTime>();

        services.AddTransient<ICatsController, CatsController>();
        services.AddTransient<IBuilder, Builder>();

        services.AddSingleton<GenderConverter>();
        services.AddSingleton<DateOnlyConverter>();

        services.AddControllers();


        return services;
    }

    public static WebApplication UseCatsServer(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            if (context.Request.Headers.ContainsKey(Constants.RequestStartTimeHeaderName))
            {
                RequestStartTime rst = context.RequestServices.GetRequiredService<RequestStartTime>();
                rst.StartTime = DateTime.Now;
                Console.WriteLine($"Request {HttpUtility.UrlDecode(context.Request.Path)} started: {rst.StartTime:O}");
            }
            var syncIOFeature = context.Features.Get<IHttpBodyControlFeature>();
            if (syncIOFeature != null)
            {
                syncIOFeature.AllowSynchronousIO = true;
            }
            await next?.Invoke()!;
            if (context.Request.Headers.ContainsKey(Constants.RequestStartTimeHeaderName))
            {
                DateTime stop = DateTime.Now;
                Console.WriteLine($"Request {HttpUtility.UrlDecode(context.Request.Path)} done: {stop:o}, elapsed: {stop - context.RequestServices.GetRequiredService<RequestStartTime>().StartTime}");
            }
        });

        app.MapControllers();
        app.UsePocotaExceptionsHandler();

        return app;
    }
}
