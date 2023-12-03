namespace Net.Leksi.Pocota.FrameworkGenerator;

internal class PropertyUse
{
    internal string ClassName { get; set; } = null!;
    internal string PropertyName { get; set; } = null!;
    internal List<PropertyUse>? Children { get; set; }
}
