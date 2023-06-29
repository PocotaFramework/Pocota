using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public class PocoContext : IPocoContext
{
    public PropertyUse PropertyUse { get; set; } = null!;

    public Type ExpectedOutputType { get; set; } = null!;

    public ControllerContext ControllerContext { get; set; } = null!;

    public void Build(DbDataReader data)
    {
        if (PropertyUse is null)
        {
            throw new InvalidOperationException(nameof(PropertyUse));
        }
        if (ExpectedOutputType is null)
        {
            throw new InvalidOperationException(nameof(ExpectedOutputType));
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
    }

    public JsonSerializerOptions CreateJsonSerializerOptions()
    {
        JsonSerializerOptions res = new();

        return res;
    }
}
