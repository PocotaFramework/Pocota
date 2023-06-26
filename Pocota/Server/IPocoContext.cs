using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public interface IPocoContext
{
    JsonSerializerOptions CreateJsonSerializerOptions();
}
