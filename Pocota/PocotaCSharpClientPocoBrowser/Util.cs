using System;

namespace Net.Leksi.Pocota.Client;

public class Util
{
    private readonly IServiceProvider _services;

    public Util(IServiceProvider services)
    {
        _services = services;
    }

    public string GetPocoLabel(object? obj)
    {
        if(obj is IEntity entity)
        {
        }
        return obj?.GetHashCode().ToString() ?? "null";
    }
}
