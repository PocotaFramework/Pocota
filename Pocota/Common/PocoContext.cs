﻿
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Net.Leksi.Pocota;

public class PocoContext: IPocoContext
{
    protected readonly IServiceProvider _services;
    private Dictionary<Type, EntityNode> _entitiesCache = new();
    public PocoContext(IServiceProvider services)
    {
        _services = services;
    }
    public bool TryFindEntity<T>(IEnumerable<object> primaryKey, out T obj) where T : class
    { 
        bool result = true;
        EntityNode node = FindEntity(typeof(T), primaryKey);
        if(node.Entity is null)
        {
            node.Entity = _services.GetRequiredService<T>();
            result = false;
        }
        obj = (T)node.Entity!;
        return result;
    }
    public JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions();
    }
    internal EntityNode FindEntity(Type type, IEnumerable<object> primaryKey)
    {
        if (!_entitiesCache.TryGetValue(type, out EntityNode? current))
        {
            current = new EntityNode();
            _entitiesCache.Add(type, current);
        }

        foreach (object? part in primaryKey)
        {
            if (part == default)
            {
                throw new InvalidOperationException("Primary Key cannot have default part!");
            }
            if (current.Children is null)
            {
                current.Children = [];
            }
            if (!current.Children.TryGetValue(part, out EntityNode? node))
            {
                node = new EntityNode();
            }
            current = node;
        }

        return current;
    }
}
