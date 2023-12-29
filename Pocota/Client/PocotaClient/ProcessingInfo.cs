using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;

public class ProcessingInfo : IProcessingInfo
{
    public event ProcessingStageChangedEventHandler? ProcessingStageChanged;
    private IEntity _entity = null!;
    private PocoState _pocoState = PocoState.None;
    private ProcessingStage _stage = ProcessingStage.None;
    public ProcessingStage ProcessingStage => _stage;
    public PocoState PocoState => throw new NotImplementedException();
    public void SetEntity(object entity)
    {
        if(entity is IEntity en &&  _entity is null) 
        {
            _entity = en;
            _entity.PropertyChanged += EntityPropertyChanged;
            _entity.PocoStateChanged += EntityPocoStateChanged;
        }
    }
    internal void SetProcessingStage(ProcessingStage stage)
    {
        if (_stage != stage)
        {
            _stage = stage;
            ProcessingStageChanged?.Invoke(this, new ProcessingStageChangedEventArgs { });
        }
    }
    private void EntityPocoStateChanged(object? sender, PocoStateChangedEventArgs args)
    {
        if (args.State is PocoState.Created && _pocoState is not PocoState.None)
        {
            throw new InvalidOperationException("Cannot create an existing entity!");
        }
        if (args.State is PocoState.Deleted && (_pocoState is PocoState.None || _pocoState is PocoState.Created))
        {
            throw new InvalidOperationException($"Cannot delete an entity at {_pocoState} state!");
        }
        _pocoState = args.State;
    }
    private void EntityPropertyChanged(object? sender, PropertyChangedEventArgs args)
    {

    }
}
