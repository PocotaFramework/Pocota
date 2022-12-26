using System.Reflection.Metadata;

namespace Net.Leksi.Pocota.Common;

public class Property
{
    private readonly Func<object, object?> _getter;
    private readonly Action<object, object?>? _setter;
    private readonly Action<object>? _toucher;

    public string Name { get; init; }
    public List<Type> Interfaces { get; init; } = new();
    public bool IsReadOnly { get; init; }
    public bool IsNullable { get; init; }
    public bool IsCollection { get; init; }
    public Type Type { get; init; }
    public Type? ItemType { get; init; }


    public object? GetValue(object target)
    {
        return _getter?.Invoke(target) ?? null;
    }

    public void SetValue(object target, object? value)
    {
        _setter?.Invoke(target, value);
    }

    public void TouchValue(object target)
    {
        _toucher?.Invoke(target);
    }

    public Property(string name, Type type, Func<object, object?> getter, Action<object, object?>? setter, Action<object>? toucher, bool isNullable, bool isReadOnly, Type? itemType)
    {
        _getter = getter;
        _setter = setter;
        _toucher = toucher;
        Type = type;
        IsNullable = isNullable;
        IsReadOnly = isReadOnly;
        IsCollection = itemType is { };
        Name = name;
        ItemType = itemType;
    }

}
