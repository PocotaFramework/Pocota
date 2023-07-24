using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.Common;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public interface IPocoContext
{
    ControllerContext ControllerContext { get; set; }
    JsonSerializerOptions JsonSerializerOptions { get; }
    bool WithTracing { get; set; }
    IPrimaryKey CreatePrimaryKey(Type targetType);
    IEnumerable<T> Build<T>(PropertyUse propertyUse, DataProvider dataProvider, bool isSingleQuery);
    T ConfirmAccess<T>(T value);
}
