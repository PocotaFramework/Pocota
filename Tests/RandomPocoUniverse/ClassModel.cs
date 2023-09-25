using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class ClassModel: PageModel
{
    internal Node Node { get; set; } = null!;
    internal HashSet<string> Usings { get; init; } = new();
    internal string? Class { get; set; } = null;
 
    public void OnGet([FromServices] SourcesGenerator generator)
    {
        generator.GenerateClass(this);
    }
}
