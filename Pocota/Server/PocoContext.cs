using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Common;
using System.IO;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public class PocoContext : IPocoContext
{
    private const string? s_invalidPrimaryKey = $"Invalid response. <{nameof(DataProviderResponse.Skip)}> or not null value expected.";

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

    public void Build(DataProvider data, List<object?>? target, bool withDirectOutput, bool withTracing)
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
        BuildingContext buildingContext = new(withDirectOutput, withTracing)
        {
            PropertyUse = this.PropertyUse,
            DataProvider = data,
            IsSingleQuery = !ExpectedOutputType.IsGenericType
                || !typeof(IList<>).MakeGenericType(new Type[] { ExpectedOutputType.GetGenericArguments()[0] })
                        .IsAssignableFrom(ExpectedOutputType),
        };
        buildingContext.DataReaderRoot = buildingContext;

        ProcessBuildingContext(buildingContext, target);

        if (buildingContext.WithTracing)
        {
            foreach(TracingHolder th in buildingContext.TracingLog)
            {
                Console.WriteLine(th);
            }
        }
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
            if (buildingContext.IsTop)
            {
                buildingContext.TracingLog.Clear();
            }

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
                        string path =
                            string.IsNullOrEmpty(buildingContext.PropertyUse.Path)
                            ? name
                            : $"{buildingContext.PropertyUse.Path}.{name}"
                        ;
                        if (!buildingContext.SetKeyParts.TryGetValue(name, out value))
                        {
                            value = buildingContext.DataReaderRoot.DataProvider![path];
                        }
                        if (buildingContext.WithTracing)
                        {
                            buildingContext.TracingLog.Add(new TracingHolder
                            {
                                Request = buildingContext.DataReaderRoot.DataProvider!.Request,
                                Path = path,
                                Response = PresentResponse(value),
                            });
                        }
                        if (value is DataProviderResponse.Skip && !buildingContext.SetKeyParts.Any())
                        {
                            isSkipped = true;
                            if (buildingContext.WithTracing)
                            {
                                buildingContext.TracingLog.Last().Success = true;
                            }
                            break;
                        }
                        if (value is DataProviderResponse || value is DataProvider || value is null)
                        {
                            buildingContext.HasError = true;
                            if (buildingContext.WithTracing)
                            {
                                buildingContext.TracingLog.Last().Success = false;
                            }
                            else
                            {
                                buildingContext.TracingLog.Add(new TracingHolder
                                {
                                    Request = buildingContext.DataReaderRoot.DataProvider!.Request,
                                    Path = path,
                                    Response = PresentResponse(value),
                                    Success = false,
                                });
                            }
                            buildingContext.TracingLog.Last().Comment = s_invalidPrimaryKey;
                        }
                        try
                        {
                            pk[name] = value;
                            if (buildingContext.WithTracing)
                            {
                                buildingContext.TracingLog.Last().Success = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            buildingContext.HasError = true;
                            if (buildingContext.TracingLog.Any() && buildingContext.TracingLog.Last().Success is null)
                            {
                                buildingContext.TracingLog.Last().Success = false;
                                buildingContext.TracingLog.Last().Exception = ex;
                            }
                            else
                            {
                                buildingContext.TracingLog.Add(new TracingHolder
                                {
                                    Request = buildingContext.DataReaderRoot.DataProvider!.Request,
                                    Path = path,
                                    Response = PresentResponse(value),
                                    Success = false,
                                    Exception = ex,
                                });
                            }
                        }

                    }
                    buildingContext.DataReaderRoot.DataProvider!.Request = DataProviderRequest.None;
                    if (isSkipped)
                    {
                        continue;
                    }
                    if (
                        !TryGetEntity(
                            buildingContext.PropertyUse.Property.Type, 
                            pk.ToArray()!, 
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
                                    bc = new BuildingContext(buildingContext)
                                    {
                                        PropertyUse = buildingContext.PropertyUse.Properties
                                            .Where(p => def.Property!.Equals(p.Property.Name)).FirstOrDefault()!,
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

            if(buildingContext.IsTop && buildingContext.HasError)
            {
                throw BuildingException.Create(null, buildingContext.TracingLog);
            }

            if (buildingContext.DataReaderRoot.IsSingleQuery || buildingContext.DataProvider is null)
            {
                break;
            }
        }
    }

    public bool TryGetEntity(Type type, object[] keysArray, out IEntity entity)
    {
        if(keysArray.Any(e => e is null))
        {
            entity = (IEntity)_services.GetRequiredService(type);
            return false;
        }
        if(!_entitiesCache.TryGetValue(type, out Dictionary<object[], IEntity>? dict))
        {
            dict = new Dictionary<object[], IEntity>(ObjectArrayEqualityComparer.Instance);
            _entitiesCache.Add(type, dict);
        }
        bool result = dict.TryGetValue(keysArray, out entity!);
        if (!result)
        {
            entity = (IEntity)_services.GetRequiredService(type);
            dict.Add(keysArray, entity);
        }
        Console.WriteLine($"_entitiesCache: {{{string.Join(',', _entitiesCache.Select(e => $"{e.Key}={{{string.Join(',', e.Value.Select(e1 => $"[{string.Join(',', e1.Key)}]={e1.Value.GetHashCode()}"))}}}"))}}}");
        return result;
    }

    private string PresentResponse(object? value)
    {
        if (value is null)
        {
            return $"<null>";
        }
        if (value is DataProviderResponse)
        {
            return $"<{value}>";
        }
        if (value is string str)
        {
            return $"\"{str}\"";
        }
        return value!.ToString()!;
    }

}
