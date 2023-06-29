using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public class PocoContext : IPocoContext
{
    public PropertyUse? PropertyUse { get; set; }

    public Type? ExpectedOutputType { get; set; }

    public JsonSerializerOptions CreateJsonSerializerOptions()
    {
        JsonSerializerOptions res = new();

        return res;
    }
}
