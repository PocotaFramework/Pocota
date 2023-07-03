using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Common;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public interface IPocoContext
{
    Type ExpectedOutputType { get; set; }
    PropertyUse PropertyUse { get; set; }
    ControllerContext ControllerContext { get; set; }
    JsonSerializerOptions JsonSerializerOptions { get; }
    void Build(DataProvider data, List<object?>? target, bool withDirectOutput, bool withTracing);
    IPrimaryKey CreatePrimaryKey(Type targetType);
    bool TryGetEntity(Type type, object[] keysArray, out IEntity entity);
}
