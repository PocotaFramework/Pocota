namespace Net.Leksi.Pocota.Server.Generic;

internal class BuildingContext<T>: BuildingContext where T : class
{
    private readonly IServiceProvider _services;

    internal T? Value { get; set; }

    internal BuildingContext(IServiceProvider services)
    {
        _services = services;
    }

}
