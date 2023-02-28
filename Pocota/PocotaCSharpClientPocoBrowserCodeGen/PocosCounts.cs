using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;

public class PocosCounts: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private int _count = 0;
    private bool _isShowing = false;

    public Type Type { get; init; }
    public int Count 
    { 
        get => _count; 
        set 
        { 
            if (_count != value)
            {
                _count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            }
        } 
    }
    public bool IsShowing
    {
        get => _isShowing;
        set
        {
            if (_isShowing != value)
            {
                _isShowing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsShowing)));
            }
        }
    }

    public ObservableCollection<object> Items { get; init; } = new();

    public PocosCounts(Type type)
    {
        Type = type;
    }

    public void Touch()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
    }
}
