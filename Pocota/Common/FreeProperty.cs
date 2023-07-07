namespace Net.Leksi.Pocota.Common;

public class FreeProperty : IProperty
{

    public string Name => string.Empty;

    public Type Type { get; init; } = null!;

    public bool IsNullable => false;

    public bool IsReadOnly => true;

    public bool IsPoco => false;

    public bool IsEntity => false;

    public bool IsList => false;

    public bool IsExtender => false;

    public bool IsKeyPart => false;

    public Type? ItemType => null;

    public PropertyAccessMode GetAccess(object target)
    {
        throw new InvalidOperationException();
    }

    public object? GetValue(object target)
    {
        throw new InvalidOperationException();
    }

    public void SetAccess(object target, PropertyAccessMode mode)
    {
        throw new InvalidOperationException();
    }

    public void SetValue(object target, object? value)
    {
        throw new InvalidOperationException();
    }
}
