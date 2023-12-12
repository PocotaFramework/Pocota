﻿namespace Net.Leksi.Pocota.FrameworkGenerator;

internal class MethodHolder
{
    internal string Name { get; set; } = null!;
    internal PropertyUse PropertyUse { get; set; } = new();
    internal List<ParameterHolder> Parameters {get; private init;} = [];
}