using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Common;

public class PropertyUseModel: PageModel
{
    public Type? Type { get; set; } = null;
    public string? TypeName { get; set; } = null;
    public string PropertyField { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public List<PropertyUseModel>? Properties { get; set; } = null;
    public string FirstIndentation { get; set; } = string.Empty;
    public string Indentation { get; set; } = string.Empty;

}
