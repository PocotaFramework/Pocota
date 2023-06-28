using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public class PocoContext : IPocoContext
{
    public JsonSerializerOptions CreateJsonSerializerOptions()
    {
        JsonSerializerOptions res = new();

        return res;
    }
}
