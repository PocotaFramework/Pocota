using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota;

public abstract class PocoBase: IProjector
{
    public static Dictionary<Type, Properties<PocoBase>> Properties { get; private set; } = new();

    public I? As<I>()
    {
        return (I)As(typeof(I))!;
    }

    public abstract object? As(Type type);

    public abstract Properties<PocoBase> GetProperties();
}
