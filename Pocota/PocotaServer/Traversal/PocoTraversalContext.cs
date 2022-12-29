using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

internal class PocoTraversalContext : IPocoTraversalContext
{
    private ConditionalWeakTable<object, string>? _usedObjects;
    private Dictionary<string, object>? _referencedObjects;
    private Dictionary<string, HashSet<PropertyInfo>>? _referencedProperties;

    private const string ReferencePrefix = "#";

    private readonly IServiceProvider _services;
    private readonly PocotaCore _core;

    private HashSet<IPrimaryKey>? _highLevelListObjects;

    private BuildingContext? _buildingContext = null;


    private int _genUsedObjectRef = 0;

    //internal Type? ItemType { get; set; } = null;

    internal JsonSerializerOptions? JsonSerializerOptions { get; set; }

    internal bool IsHighLevel { get; set; } = true;

    internal bool HighLevelListUniqueness { get; set; } = true;

    internal bool IsBuilding { get; set; } = false;

    internal bool IsListItem { get; set; } = false;

    internal BuildingContext? BuildingContext 
    {
        get
        {
            if(JsonSerializerOptions is { } && _buildingContext is null)
            {
                _buildingContext = _services.GetRequiredService<BuildingContext>();
                _buildingContext.TraversalContext = this;
            }
            return _buildingContext;
        }
    }

    public object? Target { get; set; } = null;

    public bool IsUpdating { get; set; } = true;

    public PocoTraversalContext(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<PocotaCore>();
    }

    internal string GetReference(object source, out bool alreadyExists)
    {
        if(_usedObjects is null)
        {
            _usedObjects = new ConditionalWeakTable<object, string>();
        }
        alreadyExists = _usedObjects!.TryGetValue(source, out string? reference);
        if (!alreadyExists)
        {
            reference = $"{ReferencePrefix}{++_genUsedObjectRef}";
            _usedObjects!.Add(source, reference);
        }
        return reference!;
    }

    internal bool TestReference(object source)
    {
        return _usedObjects?.TryGetValue(source, out string? _) ?? false;
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

    internal bool IsPropertySerialized(string reference, PropertyInfo propertyInfo)
    {
        if(_referencedProperties is null)
        {
            _referencedProperties = new Dictionary<string, HashSet<PropertyInfo>>();
        }
        if(!_referencedProperties.TryGetValue(reference, out HashSet<PropertyInfo>? set))
        {
            set = new HashSet<PropertyInfo>();
            _referencedProperties.Add(reference, set);
        }
        return !set.Add(propertyInfo);
    }

    internal bool IsHighLevelListUnique(IPrimaryKey primaryKey)
    {
        if (HighLevelListUniqueness)
        {
            if (_highLevelListObjects is null)
            {
                _highLevelListObjects = new HashSet<IPrimaryKey>();
            }
            return _highLevelListObjects.Add(primaryKey);
        }
        return true;
    }
}
