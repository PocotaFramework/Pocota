using System.Reflection;

namespace Net.Leksi.Pocota.Common;

internal class CycleFinder
{
    private readonly Dictionary<Type, SortedDictionary<string, PrimaryKeyDefinition>> _keyDefinitions;
    private PropertyInfo _property;
    private string _keyPartName;

    internal CycleFinder(Dictionary<Type, SortedDictionary<string, PrimaryKeyDefinition>> keyDefinitions, PropertyInfo property, string keyPartName)
    {
        _keyDefinitions = keyDefinitions;
        _property = property;
        _keyPartName = keyPartName;
    }

    internal bool Move()
    {
        if (
            _keyDefinitions.TryGetValue(_property.PropertyType, out SortedDictionary<string, PrimaryKeyDefinition>? definition)
            && definition.TryGetValue(_keyPartName, out PrimaryKeyDefinition? key)
            && key.KeyReference is { })
        {
            _property = key.Property!;
            _keyPartName = key.KeyReference!;
            return true;
        }
        return false;
    }
    internal bool Equals(CycleFinder another)
    {
        return _property == another._property && _keyPartName.Equals(another._keyPartName);
    }

    internal static void CheckNoCycleAndSetAbsentTypes(Dictionary<Type, SortedDictionary<string, PrimaryKeyDefinition>> primaryKeysDefinitions, Type targetType, PrimaryKeyDefinition key)
    {
        Stack<KeyValuePair<Type, string>> stack = new();
        CycleFinder pointer1 = new CycleFinder(primaryKeysDefinitions, key.Property!, key.KeyReference!);
        CycleFinder pointer2 = new CycleFinder(primaryKeysDefinitions, key.Property!, key.KeyReference!);
        while (pointer1.Move() && pointer2.Move() && pointer2.Move())
        {
            if (pointer2.Equals(pointer1))
            {
                throw new InvalidOperationException($"Key part {key.Property!.DeclaringType}.{key.Property.Name}.{key.KeyReference} referenced by keyDefinition['{key.Name}']='{key.Property.Name}.{key.KeyReference}' for {nameof(targetType)}={targetType} is cyclic!");
            }
        }
        stack.Push(new KeyValuePair<Type, string>(targetType, key.Name));
        while (stack.TryPeek(out var item))
        {
            if (primaryKeysDefinitions[item.Key][item.Value].Type is { })
            {
                break;
            }
            stack.Push(
                new KeyValuePair<Type, string>(
                    primaryKeysDefinitions[item.Key][item.Value].Property!.PropertyType, 
                    primaryKeysDefinitions[item.Key][item.Value].KeyReference!
                )
            );
        }
        if (stack.TryPop(out var item1))
        {
            Type type = primaryKeysDefinitions[item1.Key!][item1.Value].Type;
            while (stack.TryPop(out var item2))
            {
                primaryKeysDefinitions[item2.Key!][item2.Value].Type = type;
            }
        }
    }

}
