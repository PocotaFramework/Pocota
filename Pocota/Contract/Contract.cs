using System.Runtime.CompilerServices;

namespace Net.Leksi.Pocota.Common;

public abstract class Contract
{
    public event AddPocoEventHandler? AddPoco;
    public event EventHandler? AddPrimaryKey;
    public event EventHandler? AddAccessSelector;
    public event EventHandler? MandatoryOn;
    public event EventHandler? MandatoryOff;

    public Func<Type, object?> GetObject { get; set; } = null!;

    internal void PrimaryKey<T>(Func<T, object> name)
    {
        if(GetObject(typeof(T)) is T target)
        {
            AddPrimaryKey?.Invoke(this, EventArgs.Empty);
            name?.Invoke(target);
        }
    }

    internal void AccessSelector<T>(Func<T, object> name)
    {
        if (GetObject(typeof(T)) is T target)
        {
            AddAccessSelector?.Invoke(this, EventArgs.Empty);
            name?.Invoke(target);
        }
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

    protected void ReturnProperties<T>(Func<T, object> paths, [CallerMemberName]string? methodName = null) where T: class
    {
        if(GetObject.Invoke(typeof(T)) is T target)
        {
            paths.Invoke(target);
        }
    }

    protected object Mandatory(object value) 
    {
        try
        {
            MandatoryOn?.Invoke(this, EventArgs.Empty);
            return value;
        }
        finally
        {
            MandatoryOff?.Invoke(this, EventArgs.Empty);
        }
    }
}
