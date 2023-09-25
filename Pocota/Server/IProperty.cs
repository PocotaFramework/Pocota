using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface IProperty
{
    string Name { get; }
    Type Type { get; }
    Type? Owner { get; }
    bool IsNullable { get; }
    bool IsReadonly { get; }
    PocoKind PocoKind { get; }
    bool IsCollection { get; }
    Type? ItemType { get; }

    bool IsSet(object target);
    object? GetValue(object target);
    void SetValue(object target, object? value);
}
