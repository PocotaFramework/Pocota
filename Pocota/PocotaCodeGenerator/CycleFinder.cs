﻿using System.Diagnostics.Contracts;
using System.Reflection;

namespace Net.Leksi.Pocota.Common;

internal class CycleFinder
{
    private readonly Dictionary<Type, ProjectorHolder> _projectors;
    private PropertyInfo _property;
    private string _keyPartName;

    internal CycleFinder(Dictionary<Type, ProjectorHolder> projectors, PropertyInfo property, string keyPartName)
    {
        _projectors = projectors;
        _property = property;
        _keyPartName = keyPartName;
    }

    internal bool Move()
    {
        if (
            _projectors.TryGetValue(_property.PropertyType, out ProjectorHolder? projector)
            && projector.KeysDefinitions.TryGetValue(_keyPartName, out PrimaryKeyDefinition? key)
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

    internal static void CheckNoCycle(Dictionary<Type, ProjectorHolder> projectors, Type targetType, PrimaryKeyDefinition key)
    {
        CycleFinder pointer1 = new(projectors, key.Property!, key.KeyReference!);
        CycleFinder pointer2 = new(projectors, key.Property!, key.KeyReference!);
        while (pointer1.Move() && pointer2.Move() && pointer2.Move())
        {
            if (pointer2.Equals(pointer1))
            {
                throw new InvalidOperationException($"Key part {key.Property!.DeclaringType}.{key.Property.Name}.{key.KeyReference} referenced by keyDefinition['{key.Name}']='{key.Property.Name}.{key.KeyReference}' for {nameof(targetType)}={targetType} is cyclic!");
            }
        }
    }

}
