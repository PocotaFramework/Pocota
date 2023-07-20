using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Common;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public interface IPocoContext
{
    PropertyUse PropertyUse { get; set; }
    ControllerContext ControllerContext { get; set; }
    JsonSerializerOptions JsonSerializerOptions { get; }
    bool WithTracing { get; set; }
    IPrimaryKey CreatePrimaryKey(Type targetType);
    bool TryGetEntity(Type type, object[] keysArray, out IEntity entity);
    IEnumerable<T> Build<T>(DataProvider dataProvider, bool isSingleQuery);
}
