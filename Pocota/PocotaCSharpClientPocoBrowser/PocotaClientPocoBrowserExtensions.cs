using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Net.Leksi.Pocota.Client;

public static class PocotaClientPocoBrowserExtensions
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
        services.AddTransient<ViewInBrowserCommand>();
        services.AddTransient<ViewConnectorMethodCommand>();
        services.AddTransient<ViewConnectorMethod>();
        services.AddTransient<SetFilterCommand>();
        services.AddTransient<UnsetFilterCommand>();
        services.AddTransient<ClearPocoPropertyCommand>();
        services.AddTransient<AddNewPocoPropertyCommand>();

        return services;
    }

}
