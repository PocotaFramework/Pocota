using Net.Leksi.RuntimeAssemblyCompiler;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class UniverseOptions
{
    public string GeneratedModelProjectDir { get; set; } = null!;
    public string GeneratedContractProjectDir { get; set; } = null!;
    public string GeneratedServerStuffProjectDir { get; set; } = null!;
    public string GeneratedClientStuffProjectDir { get; set; } = null!;
    public string ContractProjectFile { get; set; } = null!;
    public string CommonProjectFile { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public Action<Universe, Project>? ModelAndContractTelemetry { get; set; } = null;
    public static string Namespace => "Net.Leksi.Test.RandomPocoUniverse";
    public static string ContractName => "IContract";
}
