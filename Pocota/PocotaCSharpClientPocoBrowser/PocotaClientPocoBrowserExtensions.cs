using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Windows;

namespace Net.Leksi.Pocota.Client;

public static class PocotaClientPocoBrowserExtensions
{
    public static IServiceCollection AddPocotaClientProfiler<T>(this IServiceCollection services) where T:Application
    {
        services.AddSingleton<Util>();
        services.AddSingleton(serv => 
        {
            TracedPocos.Instance = new(serv);
            serv.GetRequiredService<IPocoContext>().TracePocos = true;
            T app = serv.GetRequiredService<T>();
            app.MainWindow.Closed += (s, e) =>
            {
                TracedPocos.Instance.CanClose = true;
                TracedPocos.Instance.Close();
            };
            TracedPocos.Instance.Show();
            return TracedPocos.Instance;
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

        if (!services.Where(it => it.ServiceType == typeof(CancelChangesCommand)).Any())
        {
            services.AddTransient<CancelChangesCommand>();
        }
        if (!services.Where(it => it.ServiceType == typeof(AcceptChangesCommand)).Any())
        {
            services.AddTransient<AcceptChangesCommand>();
        }

        return services;
    }

}
