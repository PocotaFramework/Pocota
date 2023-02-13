using System;

namespace Net.Leksi.Pocota.Client;

internal class PropertyValueHolder
{
    private readonly Property _property = null!;
    private readonly WeakReference<PocoBase> _targetRererence = new(null!);
    private object? _lastInitial = null;
    private object? _lastCurrent = null;
    private bool _lastIsModified = true;

    public string Name => _property.Name;
    
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
                    _lastInitial = new WeakReference(_property.GetInitial(poco));
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
                    _lastCurrent = _property.GetInitial(poco);
                }
                else
                {
                    _lastCurrent = new WeakReference(_property.Get(poco));
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

    public PropertyValueHolder(Property property, PocoBase target)
    {
        _property = property;
        _targetRererence.SetTarget(target);
    }
}
