﻿
using System.Reflection;

namespace Net.Leksi.Pocota;

public class FrameworkGeneratorOptions
{
    public Contract Contract { get; set; } = null!;
    public string[]? AdditionalReferences { get; set; }
}