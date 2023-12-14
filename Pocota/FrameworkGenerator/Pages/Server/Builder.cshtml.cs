using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.FrameworkGenerator.Pages.Server
{
    public class BuilderModel : MethodsModel
    {
        public void OnGet([FromServices] Generator generator)
        {
            generator.RenderBuilder(this);
        }
    }
}
