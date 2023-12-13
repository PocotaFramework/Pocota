using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.FrameworkGenerator.Pages.Server;

public class DtoModel : PocoModel
{
    internal PocoKind PocoKind {  get; set; }
    public void OnGet([FromServices] Generator generator)
    {
        generator.RenderServerDto(this);
    }
}
