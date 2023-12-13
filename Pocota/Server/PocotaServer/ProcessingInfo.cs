namespace Net.Leksi.Pocota.Server;

public class ProcessingInfo : IProcessingInfo
{
    private ProcessingStage _stage = ProcessingStage.None;
    public ProcessingStage ProcessingStage => _stage;
    internal void SetProcessingStage(ProcessingStage stage)
    {
        _stage = stage;
    }
}
