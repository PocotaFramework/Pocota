using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Windows;

namespace Net.Leksi.Pocota.Client;

public static class PocotaClientProfilerExtensions
{
    public static IServiceCollection AddPocotaClientProfiler<T>(this IServiceCollection services) where T:Application
    {
        services.AddSingleton<Util>();
        services.AddSingleton<TracedPocos>(serv => 
        {
            TracedPocos tracedPocos = new(serv);
            serv.GetRequiredService<IPocoContext>().TracePocos = true;
            T app = serv.GetRequiredService<T>();
            app.MainWindow.Closed += (s, e) =>
            {
                tracedPocos.CanClose = true;
                tracedPocos.Close();
            };
            tracedPocos.Show();
            return tracedPocos;
        });
        
        services.AddTransient<ViewTracedPoco>();
        services.AddTransient<TracedPocosHeart>();
        services.AddTransient<PropertyValueConverter>();

        return services;
    }

    private static void App_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
    {
        Console.WriteLine("here");
    }
}
