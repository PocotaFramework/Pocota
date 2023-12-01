﻿namespace Net.Leksi.Pocota.Pipeline;

internal class MethodHolder
{
    internal string Name { get; set; } = null!;
    internal Node? ReturnNode { get; set; } = null;
    internal Type? ReturnType { get; set; } = null;
    internal bool IsCollection { get; set; } = false;
    internal string ReturnTypeName { get; set; } = null!;
    internal List<string>? Output { get; set; } = null;
    internal List<ParamHolder> Params { get; private init; } = new();
}
