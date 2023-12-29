using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.FrameworkGenerator.Client.CSharp;

public class ClientDtoBaseModel : PocoModel
{
    public void OnGet([FromServices] Generator generator)
    {
        generator.RenderCSharpClientDtoBase(this);
    }
}

