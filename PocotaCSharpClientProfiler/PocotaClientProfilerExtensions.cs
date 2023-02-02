using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Net.Leksi.Pocota.Client;

public static class PocotaClientProfilerExtensions
{
    public static IServiceCollection AddPocotaClientProfiler<T>(this IServiceCollection services) where T:Application
    {
        services.AddSingleton<TracedPocos>(serv => 
        {
            TracedPocos tracedPocos = new(serv);
            serv.GetRequiredService<IPocoContext>().TracePocos = true;
            serv.GetRequiredService<T>().MainWindow.Closed += (s, e) =>
            {
                tracedPocos.CanClose = true;
                tracedPocos.Close();
            };
            tracedPocos.Show();
            return tracedPocos;
        });
        services.AddTransient<ViewTracedPoco>();
        services.AddTransient<TracedPocosHeart>();

        return services;
    }
}
