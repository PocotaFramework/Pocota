using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.FrameworkGenerator;

public class PropertyUseModel
{
    internal int Level {  get; set; }
    internal string? SourcePropertyName { get; set; } = null;
    internal string PropertyName { get; set; } = null!;
    public PropertyUseFlags Flags { get; set; } = PropertyUseFlags.None;
    internal List<PropertyUseModel>? Children { get; set; }
}
