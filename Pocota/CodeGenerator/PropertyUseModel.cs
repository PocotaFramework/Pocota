﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net.Leksi.Pocota.Common;

public class PropertyUseModel: PageModel
{
    internal string Name { get; set; } = string.Empty;
    internal Type? Type { get; set; } = null;
    internal string? TypeName { get; set; } = null;
    internal string PropertyField { get; set; } = string.Empty;
    internal string Path { get; set; } = string.Empty;
    internal List<PropertyUseModel>? Properties { get; set; } = null;
    internal string FirstIndentation { get; set; } = string.Empty;
    internal string Indentation { get; set; } = string.Empty;

}