namespace Net.Leksi.Pocota.Server;

public abstract class DataProvider
{
    protected readonly IServiceProvider _services;
    protected BuildingContext? BuildingContext { get; private set; } = null;

    protected abstract object? this[string path] { get; }

    internal DataProviderRequest _request = DataProviderRequest.None;

    protected DataProviderRequest Request => _request;

    public DataProvider(IServiceProvider services)
    {
        _services = services;
    }

    protected abstract bool Read();

    internal bool Read(BuildingContext buildingContext)
    {
        BuildingContext = buildingContext;
        return Read();
    }

    internal object? Get(BuildingContext buildingContext, string path)
    {
        BuildingContext = buildingContext;
        return this[path];
    }
}
