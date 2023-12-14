using Microsoft.AspNetCore.Authorization;

namespace Net.Leksi.Pocota.FrameworkGenerator;

internal class MethodHolder
{
    internal string Name { get; set; } = null!;
    internal PropertyUse PropertyUse { get; set; } = new();
    internal List<ParameterHolder> Parameters {get; private init;} = [];
    internal AuthorizeAttribute? Authorize {  get; set; }
    internal Type ReturnType { get; set; } = null!;
    internal Type ReturnItemType { get; set; } = null!;
    internal bool IsCollectionReturn { get; set; } = false;
}
