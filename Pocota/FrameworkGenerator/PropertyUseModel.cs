using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.FrameworkGenerator;

public class PropertyUseModel: PageModel
{
    internal int Level {  get; set; }
    internal string PropertyName { get; set; } = null!;
    public PropertyUseFlags Flags { get; set; } = PropertyUseFlags.None;
    internal List<PropertyUseModel>? Children { get; set; }
}
