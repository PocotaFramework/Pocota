namespace Net.Leksi.Pocota.Common;

public interface IProperty
{
    string Name { get; }
    bool IsReadOnly { get; }
    bool IsNullable { get; }
    bool IsCollection { get; }
    bool IsPoco { get; }
    bool IsEntity { get; }
    string? KeyPart { get; }
    Type Type { get; }
    Type? ItemType { get; }
    bool IsSet(object target);
    object? Get(object target);
    void Touch(object target);
    void Set(object target, object? value);
}
