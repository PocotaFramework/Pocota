using Microsoft.AspNetCore.Mvc;

namespace Net.Leksi.Pocota.FrameworkGenerator.Pages.Server
{
    public class DtoBaseModel: PocoModel
    {
        public void OnGet([FromServices] Generator generator)
        {
            generator.RenderServerDtoBase(this);
        }
    }
}
