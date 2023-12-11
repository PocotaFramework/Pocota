using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.FrameworkGenerator.Pages.Server;

public class PrimaryKeyModel : PocoModel
{
    internal string ArgumentClass { get; set; } = null!;
    public void OnGet([FromServices] Generator generator)
    {
        generator.RenderServerPrimaryKey(this);
    }
}
