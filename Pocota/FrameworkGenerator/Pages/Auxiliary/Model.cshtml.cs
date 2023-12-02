using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Pages.Auxiliary;

public class ModelModel : PageModel
{
    internal string? Namespace { get; set; }
    internal string ClassName { get; set; } = null!;
    internal string BaseName { get; set; } = null!;
    internal List<PropertyModel> Properties { get; private init; } = new();
    internal HashSet<string> Usings { get; init; } = new();

    public void OnGet([FromServices]Generator generator)
    {
        generator.GenerateModelClass(this);
    }
}
