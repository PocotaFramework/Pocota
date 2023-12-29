using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.FrameworkGenerator.Pages.Client.CSharp;

public class ClientDtoModel : PocoModel
{
    internal PocoKind PocoKind { get; set; } = PocoKind.None;

    public void OnGet([FromServices] Generator generator)
    {
        generator.RenderCSharpClientDto(this);
    }
}
