using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Demo.Cats.Common;
using System.Collections;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public class PocoContext : IPocoContext
{
    private const string s_missFirstPrimaryKeyWithDataProvider = $"(null | <{nameof(DataProviderResponse.Skip)}> | {{0}} | {nameof(DataProvider)}) expected.";
    private const string s_missFirstPrimaryKey = $"(null | <{nameof(DataProviderResponse.Skip)}> | {{0}}) expected.";
    private const string s_missNextPrimaryKey = $"({{0}}) expected.";
    private const string s_primaryKeyIsNotAssigned = $"Primary Key is not assigned.";
    private const string s_missNullableNotPoco = $"(null | <{nameof(DataProviderResponse.Skip)}> | {{0}}) expected.";
    private const string s_missNotNullableNotPoco = $"({{0}}) expected.";
    private const string s_invalidPocoResponse = $"(null | <{nameof(DataProviderResponse.Skip)}> | <{nameof(DataProviderResponse.Touch)}> | {nameof(DataProvider)}) expected.";
    private const string s_notNullableNullKeyPart = $"{{0}} expected.";
    private const string s_notNullableNull = $"{{0}} expected.";
    private const string s_readOnlyListRewrite = $"(<{nameof(DataProviderResponse.Touch)}> | typeof{nameof(DataProvider)}) expected.";
    private const string s_missNotNullableNotPocoList = $"(<{nameof(DataProviderResponse.Touch)}> | {nameof(DataProvider)} | {nameof(IList)}<{{0}}>) expected.";
    private const string s_missNullableNotPocoList = $"(null | <{nameof(DataProviderResponse.Skip)}> | <{nameof(DataProviderResponse.Touch)}> | {nameof(DataProvider)} | {nameof(IList)}<{{0}}>) expected.";
    private const string s_missNotNullablePocoList = $"(<{nameof(DataProviderResponse.Touch)}> | {nameof(DataProvider)}) expected.";
    private const string s_missNullablePocoList = $"(null | <{nameof(DataProviderResponse.Skip)}> | <{nameof(DataProviderResponse.Touch)}> | {nameof(DataProvider)}) expected.";

    private enum ListRequestResponseCase
    {
        None,
        NullateNotNullable,
        MissNotNullableNotPoco,
        MissNotNullablePoco,
        MissNullableNotPoco,
        MissNullablePoco,
        Touch,
        Nullate,
        RewriteReadOnly,
        DataProvider,
        SuppliedValue,
    }

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
        if (ControllerContext is null)
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
        buildingContext.DataProviderRoot = buildingContext;

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
                    buildingContext.DataProviderRoot.DataProvider!._request = DataProviderRequest.List;
                    object? value = buildingContext.DataProviderRoot.DataProvider!.Get(buildingContext, buildingContext.PropertyUse.Path);
                    if (buildingContext.WithTracing)
                    {
                        buildingContext.Trace(new TracingEntry
                        {
                            Request = buildingContext.DataProviderRoot.DataProvider!._request,
                            Path = buildingContext.PropertyUse.Path,
                            Response = PresentResponse(value),
                        });
                    }
                    ListRequestResponseCase selector = ListRequestResponseCase.None;
                    DataProvider? dataProvider = null;
                    if (
                        (value is null || value is DataProviderResponse.Skip) && !buildingContext.PropertyUse.Property.IsNullable && (selector = ListRequestResponseCase.NullateNotNullable) == selector
                        || value is DataProviderResponse.Miss && (
                            !buildingContext.PropertyUse.Property.IsNullable && !buildingContext.PropertyUse.Property.IsPoco && (selector = ListRequestResponseCase.MissNotNullableNotPoco) == selector
                            || !buildingContext.PropertyUse.Property.IsNullable && buildingContext.PropertyUse.Property.IsPoco && (selector = ListRequestResponseCase.MissNotNullablePoco) == selector
                            || buildingContext.PropertyUse.Property.IsNullable && !buildingContext.PropertyUse.Property.IsPoco && (selector = ListRequestResponseCase.MissNullableNotPoco) == selector
                            || buildingContext.PropertyUse.Property.IsNullable && buildingContext.PropertyUse.Property.IsPoco && (selector = ListRequestResponseCase.MissNullablePoco) == selector
                        )
                        || value is DataProviderResponse.Touch && (selector = ListRequestResponseCase.Touch) == selector
                        || value is DataProvider dp && (selector = ListRequestResponseCase.DataProvider) == selector && (dataProvider = dp) == dataProvider
                        || selector is ListRequestResponseCase.None && (value is null || value is DataProviderResponse.Skip) && (selector = ListRequestResponseCase.Nullate) == selector
                        || buildingContext.PropertyUse.Property.IsReadOnly && buildingContext.Value != value && (selector = ListRequestResponseCase.RewriteReadOnly) == selector
                        || (selector = ListRequestResponseCase.SuppliedValue) == selector
                    )
                    {
                        if (
                            selector is ListRequestResponseCase.NullateNotNullable
                            || selector is ListRequestResponseCase.MissNotNullableNotPoco
                            || selector is ListRequestResponseCase.MissNotNullablePoco
                            || selector is ListRequestResponseCase.MissNullableNotPoco
                            || selector is ListRequestResponseCase.MissNullablePoco
                            || selector is ListRequestResponseCase.RewriteReadOnly
                        )
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
                                    Request = buildingContext.DataProviderRoot.DataProvider!._request,
                                    Path = buildingContext.PropertyUse.Path,
                                    Response = PresentResponse(value),
                                    Success = false,
                                });
                            }
                            switch (selector)
                            {
                                case ListRequestResponseCase.NullateNotNullable:
                                    buildingContext.LastTracingEntry!.Comment = string.Format(s_notNullableNull, Util.MakeTypeName(buildingContext.PropertyUse.Property.Type));
                                    break;
                                case ListRequestResponseCase.MissNullableNotPoco:
                                    buildingContext.LastTracingEntry!.Comment = string.Format(s_missNullableNotPocoList, Util.MakeTypeName(buildingContext.PropertyUse.Property.ItemType!));
                                    break;
                                case ListRequestResponseCase.MissNotNullableNotPoco:
                                    buildingContext.LastTracingEntry!.Comment = string.Format(s_missNotNullableNotPocoList, Util.MakeTypeName(buildingContext.PropertyUse.Property.ItemType!));
                                    break;
                                case ListRequestResponseCase.MissNotNullablePoco:
                                    buildingContext.LastTracingEntry!.Comment = s_missNotNullablePocoList;
                                    break;
                                case ListRequestResponseCase.MissNullablePoco:
                                    buildingContext.LastTracingEntry!.Comment = s_missNullablePocoList;
                                    break;
                                case ListRequestResponseCase.RewriteReadOnly:
                                    buildingContext.LastTracingEntry!.Comment = s_readOnlyListRewrite;
                                    break;

                            }
                            if (buildingContext.Value is null && selector is not ListRequestResponseCase.Nullate)
                            {
                                buildingContext.Value = Activator.CreateInstance(buildingContext.PropertyUse.Property.Type);
                            }
                        }
                        else
                        {
                            if(selector is ListRequestResponseCase.SuppliedValue)
                            {
                                buildingContext.Value = value;
                                buildingContext.ProcessAList = () =>
                                {
                                    Console.WriteLine("todo: check structure");
                                };
                            }
                            else if (buildingContext.Value is null && selector is not ListRequestResponseCase.Nullate)
                            {
                                buildingContext.Value = Activator.CreateInstance(buildingContext.PropertyUse.Property.Type);
                            }
                            if (buildingContext.WithTracing)
                            {
                                buildingContext.LastTracingEntry!.Success = true;
                            }
                            if (dataProvider is { })
                            {
                                buildingContext.ProcessAList = () =>
                                {
                                    ReprocessBuildingContextWithDataProvider(buildingContext, dataProvider, false);
                                };
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                    buildingContext.DataProviderRoot.DataProvider!._request = DataProviderRequest.None;

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
                    buildingContext.DataProviderRoot.DataProvider!._request = DataProviderRequest.PrimaryKey;
                    for (int i = 0; i < pk.Definitions.Count; ++i)
                    {
                        KeyDefinition def = pk.Definitions[i];
                        object? value = null;
                        string path =
                            string.IsNullOrEmpty(buildingContext.PropertyUse.Path)
                            ? def.Name
                            : $"{buildingContext.PropertyUse.Path}.{def.Name}"
                        ;
                        if (!buildingContext.SetKeyParts.TryGetValue(def.Name, out value))
                        {
                            value = buildingContext.DataProviderRoot.DataProvider!.Get(buildingContext, path);
                        }
                        if (buildingContext.WithTracing)
                        {
                            buildingContext.Trace(new TracingEntry
                            {
                                Request = buildingContext.DataProviderRoot.DataProvider!._request,
                                Path = path,
                                Response = PresentResponse(value),
                            });
                        }
                        if ((value is DataProviderResponse.Skip || value is null) && !buildingContext.SetKeyParts.Any())
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
                                        Request = buildingContext.DataProviderRoot.DataProvider!._request,
                                        Path = path,
                                        Response = PresentResponse(value),
                                        Success = false,
                                    });
                                }
                                buildingContext.LastTracingEntry!.Comment = string.Format(s_notNullableNull, Util.MakeTypeName(def.Type));
                            }
                            break;
                        }
                        if (value is null || !def.Type.IsAssignableFrom(value.GetType()) || value is DataProvider && buildingContext.DataProvider is { })
                        {
                            string mess = i == 0 ? (buildingContext.DataProvider is { } ? s_missFirstPrimaryKey : s_missFirstPrimaryKeyWithDataProvider) : s_missNextPrimaryKey;
                            buildingContext.HasError = true;
                            if (buildingContext.WithTracing)
                            {
                                buildingContext.LastTracingEntry!.Success = false;
                            }
                            else
                            {
                                buildingContext.Trace(new TracingEntry
                                {
                                    Request = buildingContext.DataProviderRoot.DataProvider!._request,
                                    Path = path,
                                    Response = PresentResponse(value),
                                    Success = false,
                                });
                            }
                            buildingContext.LastTracingEntry!.Comment = string.Format(mess, Util.MakeTypeName(def.Type));
                        }
                        else if(value is DataProvider dp)
                        {
                            if (buildingContext.WithTracing)
                            {
                                buildingContext.LastTracingEntry!.Success = true;
                            }
                            ReprocessBuildingContextWithDataProvider(buildingContext, dp, true);
                            return;
                        }
                        else
                        {
                            try
                            {
                                pk[def.Name] = value;
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
                                        Request = buildingContext.DataProviderRoot.DataProvider!._request,
                                        Path = path,
                                        Response = PresentResponse(value),
                                        Success = false,
                                        Exception = ex,
                                    });
                                }
                            }
                        }
                    }
                    buildingContext.DataProviderRoot.DataProvider!._request = DataProviderRequest.None;
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
                    buildingContext.DataProviderRoot.DataProvider!._request = DataProviderRequest.Poco;

                    object? value = buildingContext.DataProviderRoot.DataProvider!.Get(buildingContext, buildingContext.PropertyUse.Path);

                    if (buildingContext.WithTracing)
                    {
                        buildingContext.Trace(new TracingEntry
                        {
                            Request = buildingContext.DataProviderRoot.DataProvider!._request,
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
                                    Request = buildingContext.DataProviderRoot.DataProvider!._request,
                                    Path = buildingContext.PropertyUse.Path,
                                    Response = PresentResponse(value),
                                    Success = false,
                                });
                            }
                            buildingContext.LastTracingEntry!.Comment = string.Format(s_notNullableNull, Util.MakeTypeName(buildingContext.PropertyUse.Property.Type));
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
                                Request = buildingContext.DataProviderRoot.DataProvider!._request,
                                Path = buildingContext.PropertyUse.Path,
                                Response = PresentResponse(value),
                                Success = false,
                                Comment = s_invalidPocoResponse,
                            });
                        }
                        if (value is DataProviderResponse.Miss)
                        {
                            value = _services.GetRequiredService(buildingContext.PropertyUse.Property.Type);
                        }
                    }
                    if (value is not DataProviderResponse)
                    {
                        buildingContext.Value = value;
                    }
                    buildingContext.DataProviderRoot.DataProvider!._request = DataProviderRequest.None;
                }
                if (!buildingContext.PropertyUse.Property.IsList && buildingContext.Value is { } && buildingContext.PropertyUse.Properties is { })
                {
                    foreach (PropertyUse pu in
                        buildingContext.PropertyUse.Properties
                            .Where(p => p.Property is { } && !p.Property.IsKeyPart))
                    {
                        if (pu.Property!.IsList)
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
                                bc.ProcessAList?.Invoke();
                                bc.ProcessAList = null;
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
                            if (buildingContext.PropertyUse.Property.IsList)
                            {
                                try
                                {
                                    ((IList)buildingContext.Value).Add(bc.Value);
                                    if (buildingContext.WithTracing)
                                    {
                                        buildingContext.Trace(new TracingEntry
                                        {
                                            Request = DataProviderRequest.Item,
                                            Path = pu.Path,
                                            Response = PresentResponse(bc.Value),
                                            Success = true,
                                        });
                                    }
                                }
                                catch (Exception ex)
                                {
                                    buildingContext.HasError = true;
                                    buildingContext.Trace(new TracingEntry
                                    {
                                        Request = DataProviderRequest.Item,
                                        Path = pu.Path,
                                        Response = PresentResponse(bc.Value),
                                        Success = false,
                                        Exception = ex,
                                    });
                                }
                            }
                            else
                            {
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
                        }
                        else
                        {
                            buildingContext.DataProviderRoot.DataProvider!._request = DataProviderRequest.Value;

                            object? value = buildingContext.DataProviderRoot.DataProvider!.Get(buildingContext, pu.Path);

                            if (buildingContext.WithTracing)
                            {
                                buildingContext.Trace(new TracingEntry
                                {
                                    Request = buildingContext.DataProviderRoot.DataProvider!._request,
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
                                string mess = pu.Property.IsNullable ? s_missNullableNotPoco : s_missNotNullableNotPoco;
                                buildingContext.HasError = true;
                                if (buildingContext.WithTracing)
                                {
                                    buildingContext.LastTracingEntry!.Success = false;
                                    buildingContext.LastTracingEntry!.Comment = string.Format(mess, Util.MakeTypeName(pu.Property.Type));
                                }
                                else
                                {
                                    buildingContext.Trace(new TracingEntry
                                    {
                                        Request = buildingContext.DataProviderRoot.DataProvider!._request,
                                        Path = pu.Path,
                                        Response = PresentResponse(value),
                                        Success = false,
                                        Comment = string.Format(mess, pu.Property.Type.Name),
                                    });
                                }
                            }

                            if (value is not DataProviderResponse)
                            {
                                if (buildingContext.PropertyUse.Property.IsList)
                                {
                                    try
                                    {
                                        ((IList)buildingContext.Value).Add(value);
                                        if (buildingContext.WithTracing)
                                        {
                                            buildingContext.Trace(new TracingEntry
                                            {
                                                Request = DataProviderRequest.Item,
                                                Path = pu.Path,
                                                Response = PresentResponse(value),
                                                Success = true,
                                            });
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        buildingContext.HasError = true;
                                        buildingContext.Trace(new TracingEntry
                                        {
                                            Request = DataProviderRequest.Item,
                                            Path = pu.Path,
                                            Response = PresentResponse(value),
                                            Success = false,
                                            Exception = ex,
                                        });
                                    }
                                }
                                else
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
                                                Request = buildingContext.DataProviderRoot.DataProvider!._request,
                                                Path = pu.Path,
                                                Response = PresentResponse(value),
                                                Success = false,
                                                Exception = ex,
                                            });
                                        }
                                    }
                                }
                            }

                            buildingContext.DataProviderRoot.DataProvider!._request = DataProviderRequest.None;
                        }
                    }
                }
            }
            else
            {
                buildingContext.DataProviderRoot.DataProvider!._request = DataProviderRequest.Value;

                buildingContext.Value = buildingContext.DataProviderRoot.DataProvider!.Get(buildingContext, buildingContext.PropertyUse.Path);

                buildingContext.DataProviderRoot.DataProvider!._request = DataProviderRequest.None;
            }

            target?.Add(buildingContext.Value);

            if (buildingContext.IsRoot)
            {
                if (buildingContext.HasError)
                {
                    throw new BuildingException(null, buildingContext.TracingLog);
                }
                if (buildingContext.WithTracing)
                {
                    foreach (TracingEntry th in buildingContext.TracingLog)
                    {
                        Console.WriteLine(th);
                    }
                }

            }

            if (buildingContext.DataProviderRoot.IsSingleQuery || buildingContext.DataProvider is null)
            {
                break;
            }
        }
    }

    private void ReprocessBuildingContextWithDataProvider(BuildingContext buildingContext, DataProvider dataProvider, bool isSingleQuery)
    {
        DataProvider? saveDp = buildingContext.DataProvider;
        BuildingContext saveDpr = buildingContext.DataProviderRoot;
        bool saveSq = buildingContext.IsSingleQuery;
        buildingContext.DataProvider = dataProvider;
        buildingContext.DataProviderRoot = buildingContext;
        buildingContext.IsSingleQuery = isSingleQuery;

        ProcessBuildingContext(buildingContext, null);

        buildingContext.DataProvider = saveDp;
        buildingContext.DataProviderRoot = saveDpr;
        buildingContext.IsSingleQuery = saveSq;
    }

    public bool TryGetEntity(Type type, object[] keysArray, out IEntity entity)
    {
        if (keysArray.Any(e => e is null))
        {
            entity = (IEntity)_services.GetRequiredService(type);
            return false;
        }
        if (!_entitiesCache.TryGetValue(type, out Dictionary<object[], IEntity>? dict))
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
            return $"NULL";
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
