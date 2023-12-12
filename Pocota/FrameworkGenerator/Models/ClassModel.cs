using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.FrameworkGenerator;

public class ClassModel: PageModel
{
    internal string? Namespace { get; set; }
    internal string ClassName { get; set; } = null!;
    internal string FullName => $"{(Namespace is { } ? $"{Namespace}." : string.Empty)}{ClassName}";
    internal HashSet<string> Usings { get; init; } = [];
    internal Contract Contract { get; set; } = null!;
    internal List<string> BaseClasses { get; private init; } = [];
    internal PropertyUseModel? PropertyUse;
}
