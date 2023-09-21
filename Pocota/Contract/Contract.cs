using System.Runtime.CompilerServices;

namespace Net.Leksi.Pocota.Common;

public abstract class Contract
{
    public event AddPocoEventHandler? AddPoco;
    public event EventHandler? AddPrimaryKey;
    public event EventHandler? AddAccess;

    public Func<Type, object> GetObject { get; set; } = null!;

    internal void PrimaryKey<T>(Func<T, object> name)
    {
        name?.Invoke((T)GetObject(typeof(T)));
    }

    internal void Access<T>(Func<T, object> name)
    {
        name?.Invoke((T)GetObject(typeof(T)));
    }

    public abstract void DefinePocos();

    protected PocoEntityInfo<T> Entity<T>(Action<PocoEntityInfo<T>>? config = null) where T : class
    {
        PocoEntityInfo<T> result = new PocoEntityInfo<T>(this);
        config?.Invoke(result);
        AddPoco?.Invoke(new AddPocoEventArgs { Type = typeof(T), IsEntity = true });
        return result;
    }

    protected PocoInfo<T> Envelope<T>(Action<PocoInfo<T>>? config = null) where T : class
    {
        PocoInfo<T> result = new PocoInfo<T>(this);
        config?.Invoke(result);
        AddPoco?.Invoke(new AddPocoEventArgs { Type = typeof(T), IsEntity = false });
        return result;
    }

    protected T DefinePaths<T>(Func<T, object[]> paths, [CallerMemberName]string? methodName = null) where T: new()
    {
        T result = (T)GetObject?.Invoke(typeof(T))! ?? new T();
        paths.Invoke(result);
        return result;
    }
}
