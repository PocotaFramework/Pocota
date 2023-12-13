namespace Net.Leksi.Pocota.FrameworkGenerator;

internal class MethodModel
{
    internal string Name { get; set; } = null!;
    internal string Route { get; set; } = null!;
    internal string? Authorize { get; set; }
    internal List<ParameterModel> Parameters { get; private init; } = [];
    internal string JsonSerializerOptionsVariable { get; set; } = "jsop";
    internal string PocoContextVariable { get; set; } = "pocoContext";
}
