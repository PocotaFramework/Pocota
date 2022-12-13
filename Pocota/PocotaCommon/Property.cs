namespace Net.Leksi.Pocota.Common;

public class Property<T> where T : class
{
    private readonly Func<T, object?> _getter;
    private readonly Action<T, object?>? _setter;
    private readonly Action<T>? _toucher;
    private readonly Dictionary<Type, Type> _propertyTypes = new();
    private readonly Dictionary<Type, Type> _propertyItemTypes = new();

    public string Name { get; init; }
    public List<Type> Interfaces { get; init; } = new();

    public object? GetValue(T target)
    {
        return _getter?.Invoke(target) ?? null;
    }

    public void SetValue(T target, object? value)
    {
        _setter?.Invoke(target, value);
    }

    public void TouchValue(T target)
    {
        _toucher?.Invoke(target);
    }

    public bool IsReadOnly { get; init; }
    public bool IsNullable { get; init; }
    public bool IsCollection { get; init; }
    public Type Type { get; init; }

    public Property(string name, Type type, Func<T, object?> getter, Action<T, object?>? setter, Action<T>? toucher, bool isNullable, bool isReadOnly, bool isCollection)
    {
        _getter = getter;
        _setter = setter;
        _toucher = toucher;
        Type = type;
        IsNullable = isNullable;
        IsReadOnly = isReadOnly;
        IsCollection = isCollection;
        Name = name;
    }

    public Type? ItemType(Type @interface)
    {
        if (_propertyItemTypes.TryGetValue(@interface, out Type? type))
        {
            return type;
        }
        return null;
    }

    public Type? PropertyType(Type @interface)
    {
        if (_propertyTypes.TryGetValue(@interface, out Type? type))
        {
            return type;
        }
        return null;
    }

    public Property<T> AddPropertyType<ITarget, IPropery>()
    {
        Interfaces.Add(typeof(ITarget));
        _propertyTypes.Add(typeof(ITarget), typeof(IPropery));
        if (IsCollection)
        {
            _propertyItemTypes.Add(typeof(ITarget), typeof(IPropery).GetGenericArguments()[0]);
        }
        return this;
    }

}
