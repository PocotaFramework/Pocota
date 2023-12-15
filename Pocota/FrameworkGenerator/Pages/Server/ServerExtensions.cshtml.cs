using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.FrameworkGenerator.Pages.Server;

public class ServerExtensionsModel : CoreModel
{
    internal string AddMethodName { get; set; } = null!;
    public void OnGet([FromServices] Generator generator)
    {
        generator.RenderCore(this);
    }
}
