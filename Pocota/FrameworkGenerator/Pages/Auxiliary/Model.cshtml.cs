using Microsoft.AspNetCore.Mvc;
using Net.Leksi.Pocota.FrameworkGenerator;

namespace Net.Leksi.Pocota.Pages.Auxiliary;

public class ModelModel : PocoModel
{
    public void OnGet([FromServices]Generator generator)
    {
        generator.RenderModelClass(this);
    }
}
