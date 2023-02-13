using System;
using System.ComponentModel;
using System.Reflection;

namespace Net.Leksi.Pocota.Client;

internal class MethodParameterHolder: INotifyPropertyChanged, INotifyPropertyChanging
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public event PropertyChangingEventHandler? PropertyChanging;

    private ParameterInfo _parameter = null!;
    private object? _value = null;

    public ParameterInfo Parameter 
    {
        get => _parameter;
        set
        {
            if(_parameter != value)
            {
                _parameter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
            }
        }
    }
    public int Position => Parameter?.Position ?? -1;
    public string Name => Parameter?.Name ?? string.Empty;
    public Type Type => Parameter?.ParameterType ?? typeof(object);
    public object? Value 
    {
        get => _value;
        internal set
        {
            if(_value != value)
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(Value)));
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }
    }

}
