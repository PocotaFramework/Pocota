using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.FrameworkGenerator.Pages.Client.CSharp;

public class ClientExtensionsModel : CoreModel
{
    internal string AddMethodName { get; set; } = null!;
    public void OnGet([FromServices] Generator generator)
    {
        generator.RenderCSharpClientCore(this);
    }
}
