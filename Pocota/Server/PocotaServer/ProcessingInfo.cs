namespace Net.Leksi.Pocota.Server;

public class ProcessingInfo : IProcessingInfo
{
    public event ProcessingStageChangedEventHandler? ProcessingStageChanged;
    private ProcessingStage _stage = ProcessingStage.None;
    private PocoState _state = PocoState.Unchanged;
    public ProcessingStage ProcessingStage => _stage;
    public PocoState PocoState => _state;
    public void SetEntity(object entity)
    {
        throw new NotImplementedException();
    }
    internal void SetProcessingStage(ProcessingStage stage)
    {
        if(_stage != stage)
        {
            _stage = stage;
            ProcessingStageChanged?.Invoke(this, new ProcessingStageChangedEventArgs { });
        }
    }
}
