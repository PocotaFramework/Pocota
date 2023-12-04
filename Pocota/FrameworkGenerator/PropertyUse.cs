namespace Net.Leksi.Pocota.FrameworkGenerator;

internal class PropertyUse
{
    internal Type? Type { get; set; } = null;
    internal string Name { get; set; } = string.Empty;
    internal List<PropertyUse>? Children { get; set; }
    internal PropertyUse? Parent { get; set; } = null;
    internal PropertyUseFlags Flags { get; set; } = PropertyUseFlags.None;
}
