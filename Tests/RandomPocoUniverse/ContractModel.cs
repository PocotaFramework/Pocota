using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class ContractModel : PageModel
{
    internal Universe Universe { get; set; } = null!;
    internal HashSet<string> Usings { get; private init; } = new();
    internal List<MethodModel> Methods { get; private init; } = new();
    internal string Namespace { get; set; } = null!;

    public void OnGet([FromServices] SourcesGenerator generator)
    {
        generator.GenerateContract(this);
    }
}
