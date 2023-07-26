using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public abstract class Property : IProperty
{
    public abstract string Name { get; }
    public abstract Type Type { get; }
    public abstract bool IsNullable { get; }
    public abstract bool IsReadOnly { get; }
    public abstract bool IsPoco { get; }
    public abstract bool IsEntity { get; }
    public abstract bool IsList { get; }
    public abstract bool IsKeyPart { get; }
    public abstract Type? ItemType { get; }

    public abstract PropertyAccessMode GetAccess(object target);
    public abstract object? GetValue(object target);

    protected internal abstract void SetAccess(object target, PropertyAccessMode mode);
    protected internal abstract void SetValue(object target, object? value);
}
