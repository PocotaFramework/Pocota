using System.Text.Json;

namespace Net.Leksi.Pocota;

public interface IPocoTraversalContext
{
    object? Target { get; set; }
}
