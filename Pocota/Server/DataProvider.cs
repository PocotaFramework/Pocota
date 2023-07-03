using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public abstract class DataProvider
{
    protected readonly IServiceProvider _services;

    public abstract object? this[string path] { get; }

    public DataProviderRequest Request { get; set; } = DataProviderRequest.None;

    public DataProvider(IServiceProvider services)
    {
        _services = services;
    }

    public abstract bool Read();
}
