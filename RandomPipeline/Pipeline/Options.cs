namespace Net.Leksi.Pocota.Pipeline;

public class Options
{
    public int NodesCount { get; set; }
    public double EntitiesFraction { get; set; }
    public double Completeness { get; set; }
    public double InheritanceFraction { get; set; }
    public string GeneratedModelProjectDir { get; set; } = null!;
    public string PipelineCommonProjectDir { get; set; } = null!;
}
