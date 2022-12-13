using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Common;

public class Properties<T> where T : class
{
    private readonly Dictionary<string, Property<T>> _byName = new();
    private readonly List<Property<T>> _byPosition = new();
    private readonly Dictionary<Type, List<Property<T>>> _propertiesByInterface = new();

    public Property<T> this[int index] => _byPosition[index];

    public Property<T>? this[string name] => _byName.TryGetValue(name, out Property<T>? property) ? property : null;

    public IEnumerable<Property<T>>? GetProperties(Type? @interface)
    {
        if(_propertiesByInterface.TryGetValue(@interface, out List<Property<T>>? list))
        {
            return list.Select(p => p);
        }
        return _byPosition;
    }

    public int Count => _byPosition.Count;

    public void Add(Property<T> item)
    {
        if (_byName.TryAdd(item.Name, item))
        {
            _byPosition.Add(item);
            foreach(Type @interface in item.Interfaces)
            {
                if(!_propertiesByInterface.TryGetValue(@interface, out List<Property<T>>? properties))
                {
                    properties = new List<Property<T>>();
                    _propertiesByInterface.Add(@interface, properties);
                }
                properties.Add(item);
            }
        }
    }

}
