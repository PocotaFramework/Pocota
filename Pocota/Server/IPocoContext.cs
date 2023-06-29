using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public interface IPocoContext
{
    Type ExpectedOutputType { get; set; }
    PropertyUse PropertyUse { get; set; }
    ControllerContext ControllerContext { get; set; }
    JsonSerializerOptions CreateJsonSerializerOptions();
    void Build(DbDataReader data);
}
