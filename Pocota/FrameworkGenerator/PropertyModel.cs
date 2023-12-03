﻿namespace Net.Leksi.Pocota;

internal class PropertyModel
{
    internal string Name { get; set; } = null!;
    internal string TypeName { get; set; } = null!;
    internal string ItemTypeName { get; set; } = null!;
    internal bool IsReadOnly { get; set; }
    internal bool IsNullable { get; set; }
    internal bool IsPoco { get; set; }
    internal bool IsCollection { get; set; }
}