using System.Reflection;

namespace Net.Leksi.Pocota.Common;

internal class MethodHolder
{
    internal MethodInfo MethodInfo { get; set; } = null!;
    internal Type ReturnItemType { get; set; } = null!;
    internal PropertyUseBuilder PropertyUseBuilder { get; private init; } = new();

}