using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class InterfaceModel: PageModel
{
    internal Node Node { get; set; } = null!;
    internal HashSet<string> Usings { get; init; } = new();

    public void OnGet([FromServices] InterfacesGenerator generator)
    {
        generator.GenerateInterface(this);
    }
}
