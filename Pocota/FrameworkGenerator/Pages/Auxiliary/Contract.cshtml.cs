using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Pages.Auxiliary;

public class ContractModel : PageModel
{
    internal Contract Contract { get; set; } = null!;
    public void OnGet([FromServices]Generator generator)
    {
        generator.GenerateContractClass(this);
    }
}
