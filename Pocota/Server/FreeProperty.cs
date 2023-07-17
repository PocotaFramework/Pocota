using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public class FreeProperty : Property
{
    private readonly Type _type;

    public override string Name => string.Empty;

    public override Type Type => _type;

    public override bool IsNullable => false;

    public override bool IsReadOnly => true;

    public override bool IsPoco => false;

    public override bool IsEntity => false;

    public override bool IsList => false;

    public override bool IsExtender => false;

    public override bool IsKeyPart => false;

    public override Type? ItemType => null;

    public FreeProperty(Type type)
    {
        _type = type;
    }

    public override PropertyAccessMode GetAccess(object target)
    {
        throw new InvalidOperationException();
    }

    public override object? GetValue(object target)
    {
        throw new InvalidOperationException();
    }

    protected internal override void SetAccess(object target, PropertyAccessMode mode)
    {
        throw new InvalidOperationException();
    }

    protected internal override void SetValue(object target, object? value)
    {
        throw new InvalidOperationException();
    }
}
