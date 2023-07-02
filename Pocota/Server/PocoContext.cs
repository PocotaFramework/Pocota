using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server.Generic;
using System.Collections;
using System.Data.Common;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public class PocoContext : IPocoContext
{
    private readonly Lazy<JsonSerializerOptions> _jsonSerializerOptions = new(() =>
    {
        return new JsonSerializerOptions();
    });
    private readonly IServiceProvider _services;
    private readonly Core _core;
    private readonly Dictionary<Type, Dictionary<object[], IEntity>> _entitiesCache = new();

    public PropertyUse PropertyUse { get; set; } = null!;

    public Type ExpectedOutputType { get; set; } = null!;

    public ControllerContext ControllerContext { get; set; } = null!;

    public JsonSerializerOptions JsonSerializerOptions => _jsonSerializerOptions.Value;

    public PocoContext(IServiceProvider services)
    {
        _services = services;
        _core = _services.GetRequiredService<Core>();
    }

    public IPrimaryKey CreatePrimaryKey(Type targetType)
    {
        return (IPrimaryKey)_services.GetRequiredService(_core.GetPrimaryKeyType(targetType));
    }

    public void Build(DataProvider data, bool withDirectOutput, List<object?>? target)
    {
        if (PropertyUse is null)
        {
            throw new InvalidOperationException(nameof(PropertyUse));
        }
        if (ExpectedOutputType is null)
        {
            throw new InvalidOperationException(nameof(ExpectedOutputType));
        }
        if(ControllerContext is null)
        {
            throw new InvalidOperationException(nameof(ControllerContext));
        }
        if (data is null)
        {
            throw new InvalidOperationException(nameof(data));
        }
        BuildingContext buildingContext = new()
        {
            PropertyUse = this.PropertyUse,
            DataProvider = data,
            IsSingleQuery = !ExpectedOutputType.IsGenericType
                || !typeof(IList<>).MakeGenericType(new Type[] { ExpectedOutputType.GetGenericArguments()[0] })
                        .IsAssignableFrom(ExpectedOutputType),
            Errors = new List<ErrorHolder>(),
        };
        buildingContext.DataReaderRoot = buildingContext;

        ProcessBuildingContext(buildingContext, target);
    }

    private void ProcessBuildingContext(BuildingContext buildingContext, List<object?>? target)
    {
        HashSet<string> processedProperties = new();
        Queue<BuildingContext> queue = new();

        buildingContext.Value = null;

        while (buildingContext.DataProvider?.Read() ?? true)
        {
            bool isSkipped = false;
            processedProperties.Clear();

            if (buildingContext.PropertyUse.Property is { })
            {
                if(typeof(IEntity).IsAssignableFrom(buildingContext.PropertyUse.Property.Type))
                {
                    if(buildingContext.EntityLevel == -1)
                    {
                        buildingContext.EntityLevel = 0;
                    }
                    IPrimaryKey pk = CreatePrimaryKey(buildingContext.PropertyUse.Property.Type);
                    buildingContext.DataReaderRoot.DataProvider!.Request = DataProviderRequest.PrimaryKey;
                    foreach (string name in pk.Definitions.Select(def => def.Name))
                    {
                        object? value = null;
                        if (!buildingContext.SetKeyParts.TryGetValue(name, out value))
                        {
                            string path = 
                                string.IsNullOrEmpty(buildingContext.PropertyUse.Path)
                                ? name
                                : $"{buildingContext.PropertyUse.Path}.{name}"
                            ;
                            value = buildingContext.DataReaderRoot.DataProvider![path];
                            if(value is DataProviderResponse.Skip)
                            {
                                isSkipped = !buildingContext.SetKeyParts.Any();
                                break;
                            }
                            if(value is DataProviderResponse || value is DataProvider)
                            {
                                buildingContext.Errors.Add(new ErrorHolder());
                            }
                        }
                        pk[name] = value;

                    }
                    buildingContext.DataReaderRoot.DataProvider!.Request = DataProviderRequest.None;
                    if (isSkipped)
                    {
                        continue;
                    }
                    if (!pk.IsAssigned)
                    {
                        foreach (KeyDefinition def in pk.Definitions)
                        {
                            if (pk[def.Name] is null)
                            {
                                buildingContext.Errors.Add(new ErrorHolder());
                            }
                        }
                    }
                    else
                    {
                        if (
                            !TryGetEntity(
                                buildingContext.PropertyUse.Property.Type, 
                                pk.ToArray(), 
                                out IEntity entity
                            )
                        )
                        {
                            foreach (KeyDefinition def in pk.Definitions)
                            {
                                if(def.KeyReference is { })
                                {
                                    if(!buildingContext.PropertyUsesContexts.TryGetValue(def.Property!, out BuildingContext? bc))
                                    {
                                        bc = new BuildingContext
                                        {
                                            PropertyUse = buildingContext.PropertyUse.Properties
                                                .Where(p => def.Property!.Equals(p.Property.Name)).FirstOrDefault()!,
                                            Errors = buildingContext.Errors,
                                            Parent = buildingContext,
                                            DataReaderRoot = buildingContext.DataReaderRoot,
                                            EntityLevel = buildingContext.EntityLevel + 1,
                                        };
                                        buildingContext.PropertyUsesContexts.Add(def.Property!, bc);
                                    }
                                    if (processedProperties.Add(def.Property!))
                                    {
                                        bc.SetKeyParts.Clear();
                                        queue.Enqueue(bc);
                                    }
                                    bc.SetKeyParts.Add(def.KeyReference, pk[def.Name]!);
                                }
                            }
                            while(queue.TryDequeue(out BuildingContext? bc1))
                            {
                                ProcessBuildingContext(bc1, null);
                            }
                        }
                        buildingContext.Value = entity;
                    }
                }
                else
                {
                    buildingContext.Value = _services.GetRequiredService(buildingContext.PropertyUse.Property.Type);
                }
                foreach (PropertyUse pu in 
                    buildingContext.PropertyUse.Properties
                        .Where(p => !processedProperties.Contains(p.Property.Name)))
                {

                }
            }
            else 
            {
                buildingContext.Value = buildingContext.DataReaderRoot.DataProvider![buildingContext.PropertyUse.Path];
                if(buildingContext.Value == DBNull.Value)
                {
                    buildingContext.Value = null;
                }
            }

            target?.Add(buildingContext.Value);

            if (buildingContext.DataReaderRoot.IsSingleQuery || buildingContext.DataProvider is null)
            {
                break;
            }
        }
    }

    public bool TryGetEntity(Type type, object[] keysArray, out IEntity entity)
    {
        if(!_entitiesCache.TryGetValue(type, out Dictionary<object[], IEntity>? dict))
        {
            dict = new Dictionary<object[], IEntity>(ObjectArrayEqualityComparer.Instance);
        }
        bool result = dict.TryGetValue(keysArray, out entity!);
        if (!result)
        {
            entity = (IEntity)_services.GetRequiredService(type);
            dict.Add(keysArray, entity);
        }
        Console.WriteLine($"_entitiesCache: {{{string.Join(',', _entitiesCache.Select(e => $"{e.Key}={{{string.Join(',', e.Value.Select(e1 => $"{e1.Key}={e1.Value.GetHashCode()}"))}}}"))}}}");
        return result;
    }
}
