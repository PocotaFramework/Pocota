using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Pipeline.Pages;

public class BuilderModel : PageModel
{
    internal HashSet<string> Usings { get; private init; } = [];
    internal string ClassName { get; set; } = null!;
    internal string Namespace { get; set; } = null!;
    internal List<string> BaseClasses { get; private init; } = [];
    internal List<MethodHolder> Methods { get; private init; } = [];
    public void OnGet([FromServices] SourcesGenerator generator)
    {
        SourcesGenerator.RenderBuilder(this);
    }
}
