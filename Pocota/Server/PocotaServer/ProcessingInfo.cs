namespace Net.Leksi.Pocota.Server;

public class ProcessingInfo : IProcessingInfo
{
    private ProcessingStage _stage = ProcessingStage.None;
    private PocoState _state = PocoState.Unchanged;
    public ProcessingStage ProcessingStage => _stage;
    public PocoState PocoState => _state;
    internal void SetProcessingStage(ProcessingStage stage)
    {
        _stage = stage;
    }
    internal void SetState(PocoState state)
    {
        _state = state;
    }
}
