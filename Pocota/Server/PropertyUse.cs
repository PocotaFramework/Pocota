using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

public interface PropertyUse
{
    string Name { get; }
    string Path { get; }
    PropertyUseKinds Kinds { get; }
    IProperty Property { get; }
}
