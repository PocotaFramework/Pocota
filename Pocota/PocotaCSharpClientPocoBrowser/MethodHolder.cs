using System.Reflection;

namespace Net.Leksi.Pocota.Client;

public class MethodHolder
{
    public MethodInfo Method { get; set; } = null!;
    public Connector Connector { get; set; } = null!;
}
