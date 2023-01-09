using System.Reflection;

namespace Net.Leksi.Pocota.Common;

public class ListMembersHolder
{
    public MethodInfo? Clear { get; set; }
    public MethodInfo? Add { get; set; }
    public MethodInfo? RemoveAt { get; set; }
    public PropertyInfo? Count { get; set; }
    public PropertyInfo? Item { get; set; }
}
