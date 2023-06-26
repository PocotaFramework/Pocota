namespace Net.Leksi.Pocota.Common;

internal class MethodModel
{
    internal string Name { get; set; } = null!;
    internal string ReturnType { get; set; } = null!;
    internal string ExpectedOutputType { get; set; } = null!;
    internal List<ParameterModel> Parameters { get; init; } = new();
    internal List<AttributeModel> Attributes { get; init; } = new();
    internal List<FilterModel> Filters { get; init; } = new();
    internal string JsonSerializerOptionsVariable { get; set; } = "jsonSerializerOptions";
    internal string PocoContextVariable { get; set; } = "pocoContext";
    internal string ControllerVariable { get; set; } = "contra";
    internal List<string> CallParameters { get; init; } = new();
}