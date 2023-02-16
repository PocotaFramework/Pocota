using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;

public class PropertyValueInfo: INotifyPropertyChanged
{
    private readonly WeakReference<PocoBase> _pocoWR;
    private readonly Property _property;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Name { get; init; }
    public object? InitialValue { get; private set; }
    public object? CurrentValue { get; private set; }

    public PropertyValueInfo(Property property, WeakReference<PocoBase> pocoWR)
    {
        _property = property;
        _pocoWR = pocoWR;
        Name = property.Name;
        if (_pocoWR.TryGetTarget(out PocoBase? poco))
        {
            InitialValue = property.GetInitial(poco);
            CurrentValue = property.Get(poco);
        }
    }

    public void OnPropertyChanged(object? sender, PropertyChangedEventArgs args)
    {
        if(_pocoWR.TryGetTarget(out PocoBase? poco))
        {
            CurrentValue = _property.Get(poco);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentValue)));
        }
    }
}
