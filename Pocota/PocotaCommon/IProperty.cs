namespace Net.Leksi.Pocota.Common;

public interface IProperty
{
    string Name { get; }
    bool IsReadOnly { get; }
    bool IsNullable { get; }
    bool IsCollection { get; }
    Type Type { get; }
    Type? ItemType { get; }

    bool IsValueSet(object target);

    object? GetValue(object target);

    void TouchValue(object target);

    void SetValue(object target, object? value);

}
