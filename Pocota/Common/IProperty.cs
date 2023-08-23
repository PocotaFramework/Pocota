namespace Net.Leksi.Pocota.Common;

public interface IProperty
{
    string Name { get; }
    Type Type { get; }
    bool IsNullable { get; }
    bool IsReadonly { get; }
    PocoKind PocoKind { get; }
    bool IsCollection { get; }
    Type? ItemType { get; }

    bool IsSet(object target);
    object? GetValue(object target);
    void SetValue(object target, object? value);
}
