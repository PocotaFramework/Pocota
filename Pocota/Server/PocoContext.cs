using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Common;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public class PocoContext : IPocoContext
{
    private const string s_invalidPrimaryKey = $"<{nameof(DataProviderResponse.Skip)}> or not null key(part) value expected.";
    private const string s_primaryKeyIsNotAssigned = $"Primary Key is not assigned.";
    private const string s_invalidValue = $"<{nameof(DataProviderResponse.Skip)}> or value expected.";
    private const string s_invalidPocoResponse = $"<{nameof(DataProviderResponse.Skip)}> or <{nameof(DataProviderResponse.Touch)}> expected.";

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

    }

    private void ProcessBuildingContext(BuildingContext buildingContext, List<object?>? target)
    {
        HashSet<string> processedProperties = new();
        Queue<BuildingContext> queue = new();


        while (buildingContext.DataProvider?.Read() ?? true)
        {
            bool isSkipped = false;
            processedProperties.Clear();
            buildingContext.Clear();

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
                            buildingContext.Trace(new TracingEntry
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
                                buildingContext.LastTracingEntry!.Success = true;
                            }
                            break;
                        }
                        if (value is DataProviderResponse || value is DataProvider || value is null)
                        {
                            buildingContext.HasError = true;
                            if (buildingContext.WithTracing)
                            {
                                buildingContext.LastTracingEntry!.Success = false;
                            }
                            else
                            {
                                buildingContext.Trace(new TracingEntry
                                {
                                    Request = buildingContext.DataReaderRoot.DataProvider!.Request,
                                    Path = path,
                                    Response = PresentResponse(value),
                                    Success = false,
                                });
                            }
                            buildingContext.LastTracingEntry!.Comment = s_invalidPrimaryKey;
                        }
                        else
                        {
                            try
                            {
                                pk[name] = value;
                                if (buildingContext.WithTracing)
                                {
                                    buildingContext.LastTracingEntry!.Success = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                buildingContext.HasError = true;
                                if (buildingContext.WithTracing)
                                {
                                    buildingContext.LastTracingEntry!.Success = false;
                                    buildingContext.LastTracingEntry!.Exception = ex;
                                }
                                else
                                {
                                    buildingContext.Trace(new TracingEntry
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
                            else if (pk[def.Name] is { })
                            {
                                entity.PrimaryKey[def.Name] = pk[def.Name];
                            }
                        }
                        while(queue.TryDequeue(out BuildingContext? bc1))
                        {
                            ProcessBuildingContext(bc1, null);
                            if(bc1.PropertyUse.Property.GetAccess(entity) is PropertyAccessMode.Denied)
                            {
                                try
                                {
                                    bc1.PropertyUse.Property.SetValue(entity, bc1.Value);
                                    buildingContext.Trace(new TracingEntry
                                    {
                                        Request = DataProviderRequest.Value,
                                        Path = bc1.PropertyUse.Path,
                                        Response = PresentResponse(bc1.Value),
                                        Success = true,
                                    });
                                }
                                catch (Exception ex)
                                {
                                    buildingContext.HasError = true;
                                    buildingContext.Trace(new TracingEntry
                                    {
                                        Request = DataProviderRequest.Value,
                                        Path = bc1.PropertyUse.Path,
                                        Response = PresentResponse(bc1.Value),
                                        Success = false,
                                        Exception = ex,
                                    });
                                }
                            }
                        }
                    }
                    buildingContext.Value = entity;
                    if (buildingContext.WithTracing || !entity.PrimaryKey.IsAssigned)
                    {
                        buildingContext.Trace(new TracingEntry
                        {
                            Request = DataProviderRequest.Entity,
                            Path = buildingContext.PropertyUse.Path,
                            Response = PresentResponse(entity),
                            Success = entity.PrimaryKey.IsAssigned,
                        });
                    }
                    if (!entity.PrimaryKey.IsAssigned)
                    {
                        buildingContext.HasError = true;
                        buildingContext.LastTracingEntry!.Comment = s_primaryKeyIsNotAssigned;
                    }
                }
                else
                {
                    buildingContext.DataReaderRoot.DataProvider!.Request = DataProviderRequest.Poco;

                    object? value = buildingContext.DataReaderRoot.DataProvider![buildingContext.PropertyUse.Path];

                    if (buildingContext.WithTracing)
                    {
                        buildingContext.Trace(new TracingEntry
                        {
                            Request = buildingContext.DataReaderRoot.DataProvider!.Request,
                            Path = buildingContext.PropertyUse.Path,
                            Response = PresentResponse(value),
                        });
                    }

                    if (value is DataProviderResponse.Skip)
                    {
                        value = null;
                        if (buildingContext.WithTracing)
                        {
                            buildingContext.LastTracingEntry!.Success = true;
                        }
                    }
                    else if (value is DataProviderResponse.Touch)
                    {
                        value = _services.GetRequiredService(buildingContext.PropertyUse.Property.Type);
                        if (buildingContext.WithTracing)
                        {
                            buildingContext.LastTracingEntry!.Success = true;
                        }
                    }
                    else
                    {
                        buildingContext.HasError = true;
                        if (buildingContext.WithTracing)
                        {
                            buildingContext.LastTracingEntry!.Success = false;
                            buildingContext.LastTracingEntry!.Comment = s_invalidPocoResponse;
                        }
                        else
                        {
                            buildingContext.Trace(new TracingEntry
                            {
                                Request = buildingContext.DataReaderRoot.DataProvider!.Request,
                                Path = buildingContext.PropertyUse.Path,
                                Response = PresentResponse(value),
                                Success = false,
                                Comment = s_invalidPocoResponse,
                            });
                        }
                        if(value is DataProviderResponse.Miss)
                        {
                            value = _services.GetRequiredService(buildingContext.PropertyUse.Property.Type);
                        }
                    }
                    if (value is not DataProviderResponse)
                    {
                        buildingContext.Value = value;
                    }
                    buildingContext.DataReaderRoot.DataProvider!.Request = DataProviderRequest.None;
                }
                if(buildingContext.Value is { })
                {
                    foreach (PropertyUse pu in
                        buildingContext.PropertyUse.Properties
                            .Where(p => !processedProperties.Contains(p.Property.Name)))
                    {
                        if (pu.Property.IsPoco)
                        {
                            if (!buildingContext.PropertyUsesContexts.TryGetValue(pu.Property.Name, out BuildingContext? bc))
                            {
                                bc = new BuildingContext(buildingContext)
                                {
                                    PropertyUse = pu,
                                    DataReaderRoot = buildingContext.DataReaderRoot,
                                    EntityLevel = buildingContext.EntityLevel + (pu.Property.IsEntity ? 1 : 0),
                                };
                                buildingContext.PropertyUsesContexts.Add(pu.Property.Name, bc);
                            }
                            ProcessBuildingContext(bc, null);
                            try
                            {
                                pu.Property.SetValue(buildingContext.Value, bc.Value);
                                buildingContext.Trace(new TracingEntry
                                {
                                    Request = DataProviderRequest.Value,
                                    Path = pu.Path,
                                    Response = PresentResponse(bc.Value),
                                    Success = true,
                                });
                            }
                            catch (Exception ex)
                            {
                                buildingContext.HasError = true;
                                buildingContext.Trace(new TracingEntry
                                {
                                    Request = DataProviderRequest.Value,
                                    Path = pu.Path,
                                    Response = PresentResponse(bc.Value),
                                    Success = false,
                                    Exception = ex,
                                });
                            }
                        }
                        else
                        {
                            buildingContext.DataReaderRoot.DataProvider!.Request = DataProviderRequest.Value;

                            object? value = buildingContext.DataReaderRoot.DataProvider![pu.Path];

                            if (buildingContext.WithTracing)
                            {
                                buildingContext.Trace(new TracingEntry
                                {
                                    Request = buildingContext.DataReaderRoot.DataProvider!.Request,
                                    Path = pu.Path,
                                    Response = PresentResponse(value),
                                });
                            }

                            if (value is DataProviderResponse.Skip)
                            {
                                value = null;
                            }
                            else if (value is DataProviderResponse)
                            {
                                buildingContext.HasError = true;
                                if (buildingContext.WithTracing)
                                {
                                    buildingContext.LastTracingEntry!.Success = false;
                                    buildingContext.LastTracingEntry!.Comment = s_invalidValue;
                                }
                                else
                                {
                                    buildingContext.Trace(new TracingEntry
                                    {
                                        Request = buildingContext.DataReaderRoot.DataProvider!.Request,
                                        Path = pu.Path,
                                        Response = PresentResponse(value),
                                        Success = false,
                                        Comment = s_invalidValue,
                                    });
                                }
                            }

                            if(value is not DataProviderResponse)
                            {
                                try
                                {
                                    pu.Property.SetValue(buildingContext.Value, value);
                                    if (buildingContext.WithTracing)
                                    {
                                        buildingContext.LastTracingEntry!.Success = true;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    buildingContext.HasError = true;
                                    if (buildingContext.WithTracing)
                                    {
                                        buildingContext.LastTracingEntry!.Success = false;
                                    }
                                    else
                                    {
                                        buildingContext.Trace(new TracingEntry
                                        {
                                            Request = buildingContext.DataReaderRoot.DataProvider!.Request,
                                            Path = pu.Path,
                                            Response = PresentResponse(value),
                                            Success = false,
                                            Exception = ex,
                                        });
                                    }
                                }
                            }

                            buildingContext.DataReaderRoot.DataProvider!.Request = DataProviderRequest.None;
                        }
                    }
                }
            }
            else 
            {
                buildingContext.DataReaderRoot.DataProvider!.Request = DataProviderRequest.Value;

                buildingContext.Value = buildingContext.DataReaderRoot.DataProvider![buildingContext.PropertyUse.Path];

                if(buildingContext.Value == DBNull.Value)
                {
                    buildingContext.Value = null;
                }

                buildingContext.DataReaderRoot.DataProvider!.Request = DataProviderRequest.None;
            }

            target?.Add(buildingContext.Value);

            if(buildingContext.IsTop)
            {
                if (buildingContext.HasError)
                {
                    throw BuildingException.Create(null, buildingContext.TracingLog);
                }
                if (buildingContext.WithTracing)
                {
                    foreach (TracingEntry th in buildingContext.TracingLog)
                    {
                        Console.WriteLine(th);
                    }
                }

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
