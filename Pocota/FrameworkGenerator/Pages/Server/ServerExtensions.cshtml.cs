using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.FrameworkGenerator.Pages.Server;

public class ServerExtensionsModel : CoreModel
{
    public void OnGet([FromServices] Generator generator)
    {
        generator.RenderAddServerExtensions(this);
    }
}
