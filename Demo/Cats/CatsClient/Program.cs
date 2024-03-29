﻿using CatsClient.Commands;
using CatsCommon;
using CatsCommon.Filters;
using CatsCommon.JsonConverters;
using CatsCommon.Model;
using CatsContract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net.Leksi.Pocota.Client;
using System;

namespace CatsClient;

public class Program
{
    //TODO при просмотре редактируется
    [STAThread]
    public static void Main()
     {
        IHostBuilder hostBuilder = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<App>();
                services.AddSingleton<MainWindow>();
                services.AddTransient<ViewCat>();

                services.AddTransient<FindCatsCommand>();
                services.AddTransient<GetCatCommand>();
                services.AddTransient<FindBreedsCommand>();
                services.AddTransient<FindCatteriesCommand>();
                services.AddTransient<ViewCatCommand>();
                services.AddTransient<StopGetCatsCommand>();
                services.AddTransient<FindSiblingsCatsCommand>();
                services.AddTransient<AddLitterCommand>();
                services.AddTransient<AddCatCommand>();
                services.AddTransient<CancelChangesCommand>();

                services.AddScoped<CopyEntitiesReferencesCommand>();
                services.AddScoped<PasteParentCommand>();

                services.AddTransient<SiblingCatsConverter>();

                services.AddScoped<CatsConnector>();

                services.AddPocota(
                    configurePocos: serv =>
                    {
                        serv.AddPocotaClientBrowser<App>();

                        serv.AddTransient<Cat>();
                        serv.AddTransient<Litter>();
                        serv.AddTransient<BreedPoco>();
                        serv.AddTransient<CatteryPoco>();
                        serv.AddTransient<CatFilter>();
                        serv.AddTransient<BreedFilterPoco>();
                        serv.AddTransient<CatteryFilterPoco>();
                        serv.AddTransient<MainWindowHeart>();
                        serv.AddTransient<ViewCatHeart>();
                    },
                    configureJson: conf =>
                    {
                        conf
                        .At<ICatFilter>()
                        .At<ICatForListing>()
                        .At<ILitterWithCats>()
                            .AddJsonConverter<DateOnlyJsonConverter>()
                            .AddJsonConverter<EnumJsonConverter<Gender>>();
                    }
                );

            });
        IHost host = hostBuilder.Build();

        App app = host.Services.GetRequiredService<App>()!;
        app.DispatcherUnhandledException += app.Application_DispatcherUnhandledException;

        app.Run(host.Services.GetRequiredService<MainWindow>());
    }

}
