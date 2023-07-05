namespace Net.Leksi.Pocota.Common;

public interface IProperty
{
    string Name { get; }
    Type Type { get; }
    bool IsNullable { get; }
    bool IsReadOnly { get; }
    bool IsPoco { get; }
    bool IsEntity { get; }
    bool IsList { get; }
    bool IsExtender { get; }
    bool IsKeyPart { get; }
    Type? ItemType { get; }
    void SetValue(object target, object? value);
    object? GetValue(object target);
    PropertyAccessMode GetAccess(object target);
    void SetAccess(object target, PropertyAccessMode mode);
}
