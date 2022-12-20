using CatsContract;
using CatsServerDebug.Converters;
using CatsServerEngineDebug.ControllersImpl;
using CatsServerEngineDebug.Converters;
using Microsoft.AspNetCore.Http.Features;
using Net.Leksi.Pocota.Asp;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
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
            DateTime start = DateTime.Now;
            if (context.Request.Headers.ContainsKey(Constants.RequestStartTimeHeaderName))
            {
                start = DateTime.Parse(context.Request.Headers[Constants.RequestStartTimeHeaderName][0]);
                Console.WriteLine($"Request {HttpUtility.UrlDecode(context.Request.Path)} started: {start:O}");
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
                Console.WriteLine($"Request {HttpUtility.UrlDecode(context.Request.Path)} done: {stop:o}, elapsed: {stop - start}");
            }
        });

        app.MapControllers();
        app.UsePocotaExceptionsHandler();

        return app;
    }
}
