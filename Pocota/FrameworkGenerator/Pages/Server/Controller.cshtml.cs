using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.FrameworkGenerator.Pages.Server
{
    public class ControllerModel : MethodsModel
    {
        internal string BuilderClassName { get; set; } = null!;
        internal string BuilderVariable { get; set; } = "builderVar";
        internal string? UpdateAuthorize { get; set; } = null;
        public void OnGet([FromServices] Generator generator)
        {
            generator.RenderController(this);
        }
    }
}
