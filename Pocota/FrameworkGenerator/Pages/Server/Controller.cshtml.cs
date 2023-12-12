using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.FrameworkGenerator.Pages.Server
{
    public class ControllerModel : CoreModel
    {
        internal List<MethodModel> Methods { get; private init; } = [];
        public void OnGet([FromServices] Generator generator)
        {
            generator.RenderController(this);
        }
    }
}
