using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota;

public abstract class PocoBase: IProjector
{
    protected readonly IServiceProvider _services;

    public static Dictionary<Type, Properties<PocoBase>> Properties { get; private set; } = new();

    public PocoBase(IServiceProvider services)
    {
        _services= services;
    }

    public I? As<I>()
    {
        return (I)As(typeof(I))!;
    }

    public abstract object? As(Type type);

    public abstract Properties<PocoBase> GetProperties();
}
