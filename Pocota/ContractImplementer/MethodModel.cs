namespace Net.Leksi.Pocota.Common;

internal class MethodModel
{
    internal string Name { get; set; } = null!;
    internal string ReturnType { get; set; } = null!;
    internal string ExpectedOutputType { get; set; } = null!;
    internal List<ParameterModel> Parameters { get; init; } = new();
    internal List<AttributeModel> Attributes { get; init; } = new();
    internal List<FilterModel> Filters { get; init; } = new();
    internal string PocoContextVariable { get; set; } = "pocoContext";
    internal List<string> CallParameters { get; init; } = new();
    internal string? PropertyUseVariable { get; set; } = null;
    internal PropertyUseModel? PropertyUse { get; set; } = null;
    internal string DataProviderFactoryInterface { get; set; } = null!;
    internal string ProcessorFactoryInterface { get; set; } = null!;
    internal string? DefaultDataProviderFactoryName { get; set; } = null;
}