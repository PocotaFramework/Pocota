using System.Reflection;

namespace Net.Leksi.Pocota.Common;

internal class ClassHolder
{
    internal string Name { get; set; } = null!;
    internal Type Class { get; set; } = null!;
    internal bool IsEntity { get; set; } = false;
    internal Type? ContractProcessingStub { get; set; } = null;
    internal UsePropertyBuilder? UsePropertyBuilder { get; set; } = null;

}
