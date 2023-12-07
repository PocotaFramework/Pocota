namespace Net.Leksi.Pocota;

public interface IProperty
{
    string Name { get; }
    Type Type { get; }
    Type ItemType { get; }
    bool IsCollection { get; }
    bool IsNullable { get; }
    bool IsReadOnly { get; }
    bool IsPoco { get; }
    object? GetValue(object obj);
    void SetValue(object obj, object? value);
}
