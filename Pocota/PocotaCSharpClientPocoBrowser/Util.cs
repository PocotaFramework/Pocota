using System;

namespace Net.Leksi.Pocota.Client;

public class Util
{
    private readonly IServiceProvider _services;

    public Util(IServiceProvider services)
    {
        _services = services;
    }

    public string GetPocoLabel(IPoco? poco)
    {
        return poco?.GetHashCode().ToString() ?? "null";
    }
}
