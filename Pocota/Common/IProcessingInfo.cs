namespace Net.Leksi.Pocota;

public interface IProcessingInfo
{
    event ProcessingStageChangedEventHandler ProcessingStageChanged;
    ProcessingStage ProcessingStage { get; }
    PocoState PocoState { get; }
    void SetEntity(object entity);
}
