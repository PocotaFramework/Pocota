using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Common;
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

    public object? Build(DataProvider data, bool withDirectOutput)
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
                        .IsAssignableFrom(ExpectedOutputType)
        };
        buildingContext.DataReaderRoot = buildingContext;

        object? result = ProcessBuildingContext(buildingContext);

        return result;
    }

    private object? ProcessBuildingContext(BuildingContext buildingContext)
    {
        int count = 0;
        object? result = null;
        while (buildingContext.DataReaderRoot.DataProvider!.Read())
        {
            object? item = null;
            if(buildingContext.PropertyUse.Property is { })
            {
                if(typeof(IEntity).IsAssignableFrom(buildingContext.PropertyUse.Property.Type))
                {
                    IPrimaryKey pk = CreatePrimaryKey(buildingContext.PropertyUse.Property.Type);
                    foreach(string name in pk.Names)
                    {
                        string path = string.Intern(
                            string.IsNullOrEmpty(buildingContext.PropertyUse.Path) 
                            ? name
                            : $"{buildingContext.PropertyUse.Path}.{name}"
                        );
                        pk[name] = 
                            buildingContext.DataReaderRoot
                                .DataProvider[path];
                    }
                    if (!pk.IsAssigned)
                    {
                        throw new InvalidOperationException();
                    }
                }
                else
                {

                }
            }
            else 
            {
                item = buildingContext.DataReaderRoot.DataProvider[buildingContext.PropertyUse.Path];
                if(item == DBNull.Value)
                {
                    item = null;
                }
            }
            
            ++count;
            if (buildingContext.DataReaderRoot.IsSingleQuery)
            {
                break;
            }
        }
        return buildingContext.WithDirectOutput ? null : result;
    }
}
