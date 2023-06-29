using Microsoft.AspNetCore.Mvc;
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

    public PropertyUse PropertyUse { get; set; } = null!;

    public Type ExpectedOutputType { get; set; } = null!;

    public ControllerContext ControllerContext { get; set; } = null!;

    public JsonSerializerOptions JsonSerializerOptions => _jsonSerializerOptions.Value;

    public PocoContext(IServiceProvider services)
    {
        _services = services;
    }

    public object? Build(DbDataReader data, bool withDirectOutput)
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
            DataReader = data,
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
        while (buildingContext.DataReaderRoot.DataReader!.Read())
        {
            object? item = null;
            if(buildingContext.PropertyUse.Property is { })
            {
                item = _services.GetRequiredService(buildingContext.PropertyUse.Property.Type);
            }
            else 
            {
                item = buildingContext.DataReaderRoot.DataReader[buildingContext.PropertyUse.Path];
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
