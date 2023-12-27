using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.FrameworkGenerator.Pages.Client.CSharp;

public class ClientDtoModel : PocoModel
{
    public void OnGet([FromServices] Generator generator)
    {
        generator.RenderClientDto(this);
    }
}
