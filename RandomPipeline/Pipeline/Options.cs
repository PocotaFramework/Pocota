namespace Net.Leksi.Pocota.Pipeline;

public class Options
{
    public int NodesCount { get; set; }
    public double EntitiesFraction { get; set; }
    public double Completeness { get; set; }
    public double InheritanceFraction { get; set; }
    public string GeneratedModelProjectDir { get; set; } = null!;
    public string GeneratedContractProjectDir { get; set; } = null!;
    public string PipelineCommonProjectDir { get; set; } = null!;
    public string ContractProjectDir { get; set; } = null!;
    public int NamespacesCount { get; set; }
    public int PKCountBase { get; set; }
    public double ReadOnlyFraction { get; set; }
    public double CollectionFraction { get; set; }
    public double NullableFraction { get; set; }
}
