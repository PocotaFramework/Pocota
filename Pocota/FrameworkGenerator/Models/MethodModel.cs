﻿namespace Net.Leksi.Pocota.FrameworkGenerator;

internal class MethodModel
{
    internal string Name { get; set; } = null!;
    internal string Route { get; set; } = null!;
    internal string? Authorize { get; set; } = null;
    internal List<ParameterModel> Parameters { get; private init; } = [];
    internal string JsonSerializerOptionsVariable { get; set; } = "jsopVar";
    internal string PocoContextVariable { get; set; } = "pocoContextVar";
    internal string ReturnItemTypeName { get; set; } = null!;
    internal bool IsCollectionReturn { get; set; } = false;
    internal PropertyUseModel? PropertyUse = null;
}
