using Net.Leksi.Pocota.Common;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Net.Leksi.Pocota.Client.Json;

public class PocoTraversalContext : IPocoTraversalContext
{
    private Dictionary<string, object>? _referencedObjects;
    private ConditionalWeakTable<object, string>? _usedObjects;
    private Dictionary<string, HashSet<PropertyInfo>>? _referencedProperties;

    private int _genUsedObjectRef = 0;

    internal JsonSerializerOptionsKind JsonSerializerOptionsKind { get; set; } = JsonSerializerOptionsKind.Ordinary;
    internal JsonSerializerOptions? JsonSerializerOptions { get; set; }
    internal Type? ItemType { get; set; } = null;

    internal ApiCallContext? CallContext { get; set; } = null;

    public object? Target { get; set; }

    public PocoTraversalContext(IServiceProvider services)
    {
    }

    internal bool AddReference(string reference, object source)
    {
        if (_referencedObjects is null)
        {
            _referencedObjects = new Dictionary<string, object>();
        }
        return _referencedObjects!.TryAdd(reference, source);
    }

    internal object? ResolveReference(string reference)
    {
        if (_referencedObjects is { } && _referencedObjects.TryGetValue(reference, out object? obj))
        {
            return obj;
        }
        return null;
    }

    internal string GetReference(object source, out bool alreadyExists)
    {
        if (_usedObjects is null)
        {
            _usedObjects = new ConditionalWeakTable<object, string>();
        }
        alreadyExists = _usedObjects!.TryGetValue(source, out string? reference);
        if (!alreadyExists)
        {
            reference = $"{Constants.ReferencePrefix}{++_genUsedObjectRef}";
            _usedObjects!.Add(source, reference);
        }
        return reference!;
    }

    internal bool IsPropertySerialized(string reference, PropertyInfo propertyInfo)
    {
        if (_referencedProperties is null)
        {
            _referencedProperties = new Dictionary<string, HashSet<PropertyInfo>>();
        }
        if (!_referencedProperties.TryGetValue(reference, out HashSet<PropertyInfo>? set))
        {
            set = new HashSet<PropertyInfo>();
            _referencedProperties.Add(reference, set);
        }
        return !set.Add(propertyInfo);
    }

}