using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Common;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public class PocoContext : IPocoContext
{
    private const string s_invalidPrimaryKey = $"(<{nameof(DataProviderResponse.Skip)}> | not null key(part) value) expected.";
    private const string s_primaryKeyIsNotAssigned = $"Primary Key is not assigned.";
    private const string s_invalidValue = $"(<{nameof(DataProviderResponse.Skip)}> | appropriate value) expected.";
    private const string s_invalidPocoResponse = $"(<{nameof(DataProviderResponse.Skip)}> | <{nameof(DataProviderResponse.Touch)}>) expected.";
    private const string s_notNullableNullKeyPart = $"Not null key(part) appropriate value expected.";
    private const string s_notNullableNull = $"Not null appropriate value expected.";
    private const string s_invalidListResponse = $"(<{nameof(DataProviderResponse.Skip)}> | <{nameof(DataProviderResponse.Touch)}> | {nameof(DataProvider)} | {nameof(IList)}<appropriate type>) expected.";
    private const string s_readOnlyListRewrite = $"(<{nameof(DataProviderResponse.Touch)}> | typeof{nameof(DataProvider)}) expected.";

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


        while (buildingContext.DataProvider?.Read(buildingContext) ?? true)
        {
            bool isSkipped = false;
            processedProperties.Clear();
            buildingContext.Clear();

            if (buildingContext.PropertyUse.Property is { })
            {
                if (buildingContext.PropertyUse.Property.IsList)
                {
                    buildingContext.DataReaderRoot.DataProvider!._request = DataProviderRequest.List;
                    object? value = buildingContext.DataReaderRoot.DataProvider!.Get(buildingContext, buildingContext.PropertyUse.Path);
                    if (buildingContext.WithTracing)
                    {
                        buildingContext.Trace(new TracingEntry
                        {
                            Request = buildingContext.DataReaderRoot.DataProvider!._request,
                            Path = buildingContext.PropertyUse.Path,
                            Response = PresentResponse(value),
                        });
                    }
                    if (value is null || value is DataProviderResponse)
                    {
                        int selector = 0;
                        DataProvider? dataProvider = null;
                        if (
                            (value is null || value is DataProviderResponse.Skip) && !buildingContext.PropertyUse.Property.IsNullable && (selector = 1) == selector
                            || value is DataProviderResponse.Miss && (selector = 2) == selector
                            || value is DataProviderResponse.Touch && (selector = 3) == selector
                            || value is DataProvider dp && (selector = 4) == selector && (dataProvider = dp) == dataProvider
                            || selector == 0 && (value is null || value is DataProviderResponse.Skip) && (selector = 5) == selector
                            || buildingContext.PropertyUse.Property.IsReadOnly && buildingContext.Value != value && (selector = 6) == selector
                        )
                        {
                            if (selector == 1 || selector == 2 || selector == 6)
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
                                        Request = buildingContext.DataReaderRoot.DataProvider!._request,
                                        Path = buildingContext.PropertyUse.Path,
                                        Response = PresentResponse(value),
                                        Success = false,
                                    });
                                }
                                switch (selector)
                                {
                                    case 1:
                                        buildingContext.LastTracingEntry!.Comment = s_notNullableNull;
                                        break;
                                    case 2:
                                        buildingContext.LastTracingEntry!.Comment = s_invalidListResponse;
                                        break;
                                    case 6:
                                        buildingContext.LastTracingEntry!.Comment = s_readOnlyListRewrite;
                                        break;

                                }
                            }
                        }
                        if (buildingContext.Value is null && selector < 5)
                        {
                            buildingContext.Value = Activator.CreateInstance(buildingContext.PropertyUse.Property.Type);
                        }
                        if(dataProvider is { })
                        {
                        }
                    }
                    buildingContext.DataReaderRoot.DataProvider!._request = DataProviderRequest.None;

                }
                else if (buildingContext.PropertyUse.Property.IsEntity || buildingContext.PropertyUse.Property.IsExtender)
                {
                    IExtender? extender = null;
                    IPrimaryKey pk;
                    if (buildingContext.PropertyUse.Property.IsExtender)
                    {
                        extender = (IExtender)_services.GetRequiredService(buildingContext.PropertyUse.Property.Type);
                        pk = extender.PrimaryKey;
                    }
                    else
                    {
                        pk = CreatePrimaryKey(buildingContext.PropertyUse.Property.Type);
                    }
                    buildingContext.DataReaderRoot.DataProvider!._request = DataProviderRequest.PrimaryKey;
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
                            value = buildingContext.DataReaderRoot.DataProvider!.Get(buildingContext, path);
                        }
                        if (buildingContext.WithTracing)
                        {
                            buildingContext.Trace(new TracingEntry
                            {
                                Request = buildingContext.DataReaderRoot.DataProvider!._request,
                                Path = path,
                                Response = PresentResponse(value),
                            });
                        }
                        if (value is DataProviderResponse.Skip && !buildingContext.SetKeyParts.Any())
                        {
                            if (buildingContext.PropertyUse.Property.IsNullable)
                            {
                                isSkipped = true;
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
                                }
                                else
                                {
                                    buildingContext.Trace(new TracingEntry
                                    {
                                        Request = buildingContext.DataReaderRoot.DataProvider!._request,
                                        Path = path,
                                        Response = PresentResponse(value),
                                        Success = false,
                                    });
                                }
                                buildingContext.LastTracingEntry!.Comment = s_notNullableNullKeyPart;
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
                                    Request = buildingContext.DataReaderRoot.DataProvider!._request,
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
                                        Request = buildingContext.DataReaderRoot.DataProvider!._request,
                                        Path = path,
                                        Response = PresentResponse(value),
                                        Success = false,
                                        Exception = ex,
                                    });
                                }
                            }
                        }
                    }
                    buildingContext.DataReaderRoot.DataProvider!._request = DataProviderRequest.None;
                    if (isSkipped)
                    {
                        continue;
                    }
                    if (buildingContext.PropertyUse.Property.IsEntity)
                    {
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
                                if (def.KeyReference is { })
                                {
                                    if (!buildingContext.PropertyUsesContexts.TryGetValue(def.Property!, out BuildingContext? bc))
                                    {
                                        bc = new BuildingContext(buildingContext)
                                        {
                                            PropertyUse = buildingContext.PropertyUse.Properties?
                                                .Where(p => def.Property!.Equals(p.Property?.Name)).FirstOrDefault()!,
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
                            while (queue.TryDequeue(out BuildingContext? bc1))
                            {
                                ProcessBuildingContext(bc1, null);
                                if (bc1.PropertyUse.Property!.GetAccess(entity) is PropertyAccessMode.Denied)
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
                        pk = entity.PrimaryKey;
                    }
                    else
                    {
                        buildingContext.Value = extender;
                    }
                    if (buildingContext.WithTracing || !pk.IsAssigned)
                    {
                        buildingContext.Trace(new TracingEntry
                        {
                            Request = DataProviderRequest.Entity,
                            Path = buildingContext.PropertyUse.Path,
                            Response = PresentResponse(buildingContext.Value),
                            Success = pk.IsAssigned,
                        });
                    }
                    if (!pk.IsAssigned)
                    {
                        buildingContext.HasError = true;
                        buildingContext.LastTracingEntry!.Comment = s_primaryKeyIsNotAssigned;
                    }
                }
                else
                {
                    buildingContext.DataReaderRoot.DataProvider!._request = DataProviderRequest.Poco;

                    object? value = buildingContext.DataReaderRoot.DataProvider!.Get(buildingContext, buildingContext.PropertyUse.Path);

                    if (buildingContext.WithTracing)
                    {
                        buildingContext.Trace(new TracingEntry
                        {
                            Request = buildingContext.DataReaderRoot.DataProvider!._request,
                            Path = buildingContext.PropertyUse.Path,
                            Response = PresentResponse(value),
                        });
                    }

                    if (value is DataProviderResponse.Skip)
                    {
                        if (buildingContext.PropertyUse.Property.IsNullable)
                        {
                            value = null;
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
                            }
                            else
                            {
                                buildingContext.Trace(new TracingEntry
                                {
                                    Request = buildingContext.DataReaderRoot.DataProvider!._request,
                                    Path = buildingContext.PropertyUse.Path,
                                    Response = PresentResponse(value),
                                    Success = false,
                                });
                            }
                            buildingContext.LastTracingEntry!.Comment = s_notNullableNullKeyPart;
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
                                Request = buildingContext.DataReaderRoot.DataProvider!._request,
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
                    buildingContext.DataReaderRoot.DataProvider!._request = DataProviderRequest.None;
                }
                if(buildingContext.Value is { } && buildingContext.PropertyUse.Properties is { })
                {
                    foreach (PropertyUse pu in
                        buildingContext.PropertyUse.Properties
                            .Where(p => p.Property is { } &&  !p.Property.IsKeyPart))
                    {
                        if(pu.Property!.IsList)
                        {
                            if (!buildingContext.PropertyUsesContexts.TryGetValue(pu.Property.Name, out BuildingContext? bc))
                            {
                                bc = new BuildingContext(buildingContext)
                                {
                                    PropertyUse = pu,
                                };
                                buildingContext.PropertyUsesContexts.Add(pu.Property.Name, bc);
                            }
                            if (pu.Property.IsReadOnly)
                            {
                                bc.Value = pu.Property.GetValue(buildingContext.Value);
                            }
                            ProcessBuildingContext(bc, null);
                            if (!pu.Property.IsReadOnly)
                            {
                                pu.Property.SetValue(buildingContext.Value, bc.Value);
                            }
                        }
                        else if (pu.Property!.IsPoco)
                        {
                            if (!buildingContext.PropertyUsesContexts.TryGetValue(pu.Property.Name, out BuildingContext? bc))
                            {
                                bc = new BuildingContext(buildingContext)
                                {
                                    PropertyUse = pu,
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
                            buildingContext.DataReaderRoot.DataProvider!._request = DataProviderRequest.Value;

                            object? value = buildingContext.DataReaderRoot.DataProvider!.Get(buildingContext, pu.Path);

                            if (buildingContext.WithTracing)
                            {
                                buildingContext.Trace(new TracingEntry
                                {
                                    Request = buildingContext.DataReaderRoot.DataProvider!._request,
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
                                        Request = buildingContext.DataReaderRoot.DataProvider!._request,
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
                                            Request = buildingContext.DataReaderRoot.DataProvider!._request,
                                            Path = pu.Path,
                                            Response = PresentResponse(value),
                                            Success = false,
                                            Exception = ex,
                                        });
                                    }
                                }
                            }

                            buildingContext.DataReaderRoot.DataProvider!._request = DataProviderRequest.None;
                        }
                    }
                }
            }
            else 
            {
                buildingContext.DataReaderRoot.DataProvider!._request = DataProviderRequest.Value;

                buildingContext.Value = buildingContext.DataReaderRoot.DataProvider!.Get(buildingContext, buildingContext.PropertyUse.Path);

                if(buildingContext.Value == DBNull.Value)
                {
                    buildingContext.Value = null;
                }

                buildingContext.DataReaderRoot.DataProvider!._request = DataProviderRequest.None;
            }

            target?.Add(buildingContext.Value);

            if(buildingContext.IsRoot)
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
