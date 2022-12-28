using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public abstract class PocoBase
{ 
    protected readonly IServiceProvider _services;

    public static new bool ReferenceEquals(object? obj1, object? obj2)
    {
        if (obj1 is IProjection proj1 && obj2 is IProjection proj2)
        {
            return object.ReferenceEquals(proj1.As<IPoco>(), proj2.As<IPoco>());
        }
        return object.ReferenceEquals(obj1, obj2);
    }

    public PocoBase(IServiceProvider services)
    {
        _services= services;
    }

    protected virtual void OnProjectionCreated(Type @interface, IProjection projection) { }

}
