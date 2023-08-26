using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class ContractModel : PageModel
{
    internal Universe Universe { get; set; }
    internal HashSet<string> Usings { get; private init; } = new();
    internal List<MethodModel> Methods { get; private init; } = new();

    public void OnGet([FromServices] InterfacesGenerator generator)
    {
        generator.GenerateContract(this);
    }
}
