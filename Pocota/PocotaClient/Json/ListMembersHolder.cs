using System.Reflection;

namespace Net.Leksi.Pocota.Client.Json;

internal class ListMembersHolder
{
    internal MethodInfo? Clear { get; set; }
    internal MethodInfo? Add { get; set; }
    internal MethodInfo? RemoveAt { get; set; }
    internal PropertyInfo? Count { get; set; }
    internal PropertyInfo? Items { get; set; }
}
