using System;
using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;

internal class PropertyValueHolder: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly string _name = null!;
    private readonly Property _property = null!;
    private readonly WeakReference<PocoBase> _targetRererence = new(null!);
    private object? _lastInitial = null;
    private object? _lastCurrent = null;
    private bool _lastIsModified = true;

    public string Name => _name;

    public bool IsReadOnly => _property.IsReadOnly;
    
    public object? Initial
    {
        get
        {
            if(_targetRererence.TryGetTarget(out PocoBase? poco))
            {
                if (_property.Type.IsPrimitive || _property.Type.IsEnum || _property.Type == typeof(string) || _property.Type.IsValueType)
                {
                    _lastInitial = _property.GetInitial(poco);
                }
                else
                {
                    object? result = _property.GetInitial(poco);
                    if (result is { })
                    {
                        _lastInitial = new WeakReference(result);
                    }
                    else
                    {
                        _lastInitial = null;
                    }
                }
            }
            return _lastInitial;
        }
    }
    
    public object? Current
    {
        get
        {
            if (_targetRererence.TryGetTarget(out PocoBase? poco))
            {
                if (_property.Type.IsPrimitive || _property.Type.IsEnum || _property.Type == typeof(string) || _property.Type.IsValueType)
                {
                    _lastCurrent = _property.Get(poco);
                }
                else
                {
                    object? result = _property.Get(poco);
                    if(result is { })
                    {
                        _lastCurrent = new WeakReference(result);
                    }
                    else
                    {
                        _lastCurrent = null;
                    }
                }
            }
            return _lastCurrent;
        }
        set
        {
            if (_targetRererence.TryGetTarget(out PocoBase? poco) && !_property.IsReadOnly)
            {
                _property.Set(poco, value);
                _ = Current;
                Touch();
            }
        }
    }

    public bool IsModified
    {
        get
        {
            if (_targetRererence.TryGetTarget(out PocoBase? poco))
            {
                _lastIsModified = _property.IsModified(poco);
            }
            return _lastIsModified;
        }
    }

    public bool IsPoco => _property.IsPoco;

    public bool IsCollection => _property.IsCollection;

    public bool IsNullable => _property.IsNullable;

    public Type Type => _property.Type;

    public string? KeyPart => _property.KeyPart;

    public PropertyValueHolder(Property property, PocoBase target)
    {
        _name = property.Name + (property.KeyPart is { } ? $" ({property.KeyPart})" : string.Empty);
        _property = property;
        _targetRererence.SetTarget(target);
    }

    internal void Touch()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
    }
}
