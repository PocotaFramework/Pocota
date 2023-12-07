using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Pipeline;

public class ClassModel : PageModel
{
    internal Node Node { get; set; } = null!;
    internal HashSet<string> Usings { get; init; } = [];
    public void OnGet([FromServices] SourcesGenerator generator)
    {
        SourcesGenerator.RenderModelClass(this);
    }
}
