using Net.Leksi.Pocota.ORMGenerator;

namespace Net.Leksi.Pocota.Pipeline;

public class Options
{
    public int NodesCount { get; set; }
    public double EntitiesFraction { get; set; }
    public double Completeness { get; set; }
    public double InheritanceFraction { get; set; }
    public string GeneratedContractProjectDir { get; set; } = null!;
    public string PipelineCommonProjectDir { get; set; } = null!;
    public string ContractProjectDir { get; set; } = null!;
    public int NamespacesCount { get; set; }
    public int PKCountBase { get; set; }
    public double ReadOnlyFraction { get; set; }
    public double CollectionFraction { get; set; }
    public double NullableFraction { get; set; }
    public int AutoLinkBase { get; set; }
    public int PropertiesTreeDepth { get; set; }
    public int AccessSelectorsCountBase { get; set; }
    public double OutputDepthDamping { get; set; }
    public double OutputAutoLinkDamping { get; set; }
    public double FindersIsCollectionFraction { get; set; }
    public int FindersCountBase { get; set; }
    public int FindersParamsCountBase { get; set; }
    public double FindersMandatoryFraction { get; set; }
    public string GeneratedServerStuffProjectDir { get; set; } = null!;
    public string ContractClassName { get; set; } = null!;
    public string TargetFramework { get; set; } = null!;
    public string ContractNamespace { get; set; } = null!;
    public string? CustomContractAssemblyLocation { get; set; } = null;
    public string ServerImplementationProject { get; set; } = null!;
    public double CompositionFraction { get; set; }
    public string? ContractProcessorDir { get; set; } = null;
    public Dialect DatabaseDialect { get; set; } = Dialect.MSSql;
    public string ConnectionString { get; set; } = null!;
    public double AutoFraction { get; set; }
    public string GeneratedCSharpClientStuffProjectDir { get; set; } = null!;
    public string ClientImplementation1Project { get; set; } = null!;
    internal string? UpdateAuthorize { get; set; } = null;
}
