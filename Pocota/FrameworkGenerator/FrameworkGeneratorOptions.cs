namespace Net.Leksi.Pocota.FrameworkGenerator;

public class FrameworkGeneratorOptions
{
    public Contract Contract { get; set; } = null!;
    public string[]? AdditionalReferences { get; set; }
    public string ServerStuffProject { get; set; } = null!;
    public bool DoCreateProject { get; set; } = false;
    public bool ReplaceFilesIfExist { get; set; } = false;
    public string? TargetFramework { get; set; } = null;
    public string? ContractProcessorDir { get; set; } = null;
    public string? CSharpClientStuffProject { get; set; } = null;
}
