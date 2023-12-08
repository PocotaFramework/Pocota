using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.FrameworkGenerator.Pages.Server;

public class EntityAdapterModel : ClassModel
{
    public string EntityClassName { get; set; } = null!;
    public void OnGet([FromServices] Generator generator)
    {
        generator.RenderServerEntityAdapter(this);
    }
}
