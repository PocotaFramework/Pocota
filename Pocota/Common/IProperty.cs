namespace Net.Leksi.Pocota;

public interface IProperty
{
    string Name { get; }
    Type Type { get; }
    Type ItemType { get; }
    bool IsCollection { get; }
    bool IsNullable { get; }
    bool IsReadOnly { get; }
    PocoKind PocoKind { get; }
    object? GetValue(object obj, bool setUsed);
    void SetValue(object obj, object? value);
    bool IsSet(object obj);
}
