namespace Net.Leksi.Pocota;

public interface IProcessingInfo
{
    ProcessingStage ProcessingStage { get; }
    PocoState PocoState { get; }
}
