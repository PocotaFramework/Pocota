using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Pipeline;

public class ContractModel: PageModel
{
    internal HashSet<string> Usings { get; init; } = new();
    internal string ClassName { get; set; } = null!;
    internal string Namespace { get; set; } = null!;
    internal Graph Graph { get; set; } = null!;
    public void OnGet([FromServices] SourcesGenerator generator)
    {
        generator.GenerateContractClass(this);
    }
}
