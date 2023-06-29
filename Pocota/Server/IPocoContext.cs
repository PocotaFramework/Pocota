using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public interface IPocoContext
{
    Type? ExpectedOutputType { get; set; }
    PropertyUse? PropertyUse { get; set; }
    JsonSerializerOptions CreateJsonSerializerOptions();
}
