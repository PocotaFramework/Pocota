using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Pipeline;

public class ContractModel: PageModel
{
    internal HashSet<string> Usings { get; private init; } = [];
    internal string ClassName { get; set; } = null!;
    internal string Namespace { get; set; } = null!;
    internal List<Node> Nodes { get; private init; } = [];
    public void OnGet([FromServices] SourcesGenerator generator)
    {
        SourcesGenerator.RenderContractClass(this);
    }
}
