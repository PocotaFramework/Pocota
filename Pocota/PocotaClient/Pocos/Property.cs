using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Client;

public abstract class Property: IProperty
{
    public abstract string Name { get; }
    public abstract bool IsReadOnly { get; }
    public abstract bool IsNullable { get; }
    public abstract bool IsCollection { get; }
    public abstract Type Type { get; }
    public abstract Type? ItemType { get; }
    public abstract bool IsPoco { get; }
    public abstract bool IsEntity { get; }
    public abstract bool IsKeyPart { get; }

    public abstract object? Get(object target);
    public abstract bool IsSet(object target);
    public abstract void Set(object target, object? value);
    public abstract void Touch(object target);

    public abstract bool IsModified(object target);
    public abstract bool IsInitial(object target);
    public abstract void CancelChange(object target);
    public abstract void AcceptChange(object target);
    public abstract object? GetInitial(object target);

    protected T? Convert<T>(object? value)
    {
        if(value is null)
        {
            return default;
        }
        if (value is T)
        {
            return (T)value;
        }
        return (T)System.Convert.ChangeType(value, typeof(T));
    }
}
