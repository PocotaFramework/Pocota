using System.Reflection;

namespace Net.Leksi.Pocota.Common;

internal class ClassHolder
{
    internal string Name { get; set; } = null!;
    internal Type Class { get; set; } = null!;
    internal PocoKind PocoKind { get; set; } = PocoKind.Envelope;
    internal Type? ContractProcessingStub { get; set; } = null;
    internal PropertyUseBuilder? PropertyUseBuilder { get; set; } = null;

}
