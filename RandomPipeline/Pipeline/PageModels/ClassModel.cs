using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Pipeline;

public class ClassModel : PageModel
{
    internal Node Node { get; set; } = null!;
    internal HashSet<string> Usings { get; init; } = new();

    public void OnGet([FromServices] SourcesGenerator generator)
    {
        generator.GenerateClass(this);
    }
}
