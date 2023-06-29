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

    public PropertyUse PropertyUse { get; set; } = null!;

    public Type ExpectedOutputType { get; set; } = null!;

    public ControllerContext ControllerContext { get; set; } = null!;

    public JsonSerializerOptions JsonSerializerOptions => _jsonSerializerOptions.Value;

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
        object? result = null;
        BuildingContext buildingContext = new()
        {
            PropertyUse = this.PropertyUse,
            DataReader = data,
            IsSingleQuery = !ExpectedOutputType.IsGenericType
                         || !typeof(IList<>).MakeGenericType(new Type[] { ExpectedOutputType.GetGenericArguments()[0] })
                            .IsAssignableFrom(ExpectedOutputType)
        };
        buildingContext.DataReaderRoot = buildingContext;

        return result;
    }

    public JsonSerializerOptions CreateJsonSerializerOptions()
    {
        JsonSerializerOptions res = new();

        return res;
    }
}
