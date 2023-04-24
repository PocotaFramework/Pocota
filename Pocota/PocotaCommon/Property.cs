using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Common;

public abstract class Property : IProperty
{
    public abstract string Name { get; }
    public abstract bool IsReadOnly { get; }
    public abstract bool IsNullable { get; }
    public abstract bool IsCollection { get; }
    public abstract bool IsPoco { get; }
    public abstract bool IsEntity { get; }
    public abstract bool IsKeyPart { get; }
    public abstract Type Type { get; }
    public abstract Type? ItemType { get; }

    public abstract object? Get(object target);
    public abstract bool IsSet(object target);
    public abstract void Set(object target, object? value);
    public abstract void Touch(object target);

    protected T? Convert<T>(object? value)
    {
        if (value is null)
        {
            return default(T);
        }
        if (value is T)
        {
            return (T)value;
        }
        return (T)System.Convert.ChangeType(value, typeof(T));
    }
}
