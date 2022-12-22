using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public interface IPocoTraversalContext
{
    object? Target { get; set; }
}
