using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public abstract class PocoBase
{ 
    protected readonly IServiceProvider _services;

    public PocoBase(IServiceProvider services)
    {
        _services= services;
    }

    protected virtual void OnProjectionCreated(Type @interface, IProjection projection) { }

}
