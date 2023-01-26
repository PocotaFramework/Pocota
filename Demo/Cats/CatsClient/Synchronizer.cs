using Net.Leksi.Pocota.Client.Event;
using System;

namespace CatsClient;

public class Synchronizer
{
    private readonly IServiceProvider _services;

    public Synchronizer(IServiceProvider services)
    {
        _services = services;
    }

    public void ModifiedPocosChanged(object? sender, NotifyModifiedPocosChangedEventArgs e)
    {
        Console.WriteLine(e);
    }


}
