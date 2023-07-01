using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Common;
using System.Data.Common;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public interface IPocoContext
{
    Type ExpectedOutputType { get; set; }
    PropertyUse PropertyUse { get; set; }
    ControllerContext ControllerContext { get; set; }
    JsonSerializerOptions JsonSerializerOptions { get; }
    object? Build(DataProvider data, bool withDirectOutput);
    IPrimaryKey CreatePrimaryKey(Type targetType);
}
