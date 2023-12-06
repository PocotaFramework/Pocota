using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.FrameworkGenerator;

public class ClassModel: PageModel
{
    internal string? Namespace { get; set; }
    internal string ClassName { get; set; } = null!;
    internal HashSet<string> Usings { get; init; } = new();
    internal Contract Contract { get; set; } = null!;
    internal List<PropertyModel> Properties { get; private init; } = new();
    internal List<string> BaseClasses { get; private init; } = new();

}
