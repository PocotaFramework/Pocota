using Net.Leksi.Pocota.Common;
using System;
using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;

internal class PropertyValueHolder: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly string _name = null!;
    internal readonly Property _property = null!;
    private readonly WeakReference<PocoBase> _targetRererence = new(null!);
    private object? _lastInitial = null;
    private object? _lastCurrent = null;
    private bool _lastIsModified = true;
    private bool _lastIsSet = true;
    private Type? _projectionType = null;

    public string Name => _name;

    public bool IsReadOnly => _property.IsReadOnly;
    
    public object? Initial
    {
        get
        {
            if(_targetRererence.TryGetTarget(out PocoBase? poco) && poco is IProjection projection && projection.As(_projectionType!) is object target)
            {
                if (_property.Type.IsPrimitive || _property.Type.IsEnum || _property.Type == typeof(string) || _property.Type.IsValueType)
                {
                    _lastInitial = _property.GetInitial(target);
                }
                else
                {
                    object? result = _property.GetInitial(target);
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
            if (_targetRererence.TryGetTarget(out PocoBase? poco) && poco is IProjection projection && projection.As(_projectionType!) is object target)
            {
                if (_property.Type.IsPrimitive || _property.Type.IsEnum || _property.Type == typeof(string) || _property.Type.IsValueType)
                {
                    _lastCurrent = _property.Get(target);
                }
                else
                {
                    object? result = _property.Get(target);
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
            Console.WriteLine($"phv.Current: {(_lastCurrent is WeakReference wr ? wr.Target : _lastCurrent)}, property: {_property}, {(_lastCurrent is WeakReference wr1 ? ((IProjection)wr1.Target).HashCode() : _lastCurrent.GetHashCode())}, {_lastCurrent.GetHashCode()}");
            return _lastCurrent;
        }
        set
        {
            if (_targetRererence.TryGetTarget(out PocoBase? poco) && !_property.IsReadOnly && poco is IProjection projection && projection.As(_projectionType!) is object target)
            {
                _property.Set(target, value);
                _ = Current;
                Touch();
            }
        }
    }

    public bool IsModified
    {
        get
        {
            if (_targetRererence.TryGetTarget(out PocoBase? poco) && poco is IProjection projection && projection.As(_projectionType!) is object target)
            {
                _lastIsModified = _property.IsModified(target);
            }
            return _lastIsModified;
        }
    }

    public bool IsSet
    {
        get
        {
            if (_targetRererence.TryGetTarget(out PocoBase? poco) && poco is IProjection projection && projection.As(_projectionType!) is object target)
            {
                _lastIsSet = _property.IsSet(target);
            }
            return _lastIsSet;
        }
    }

    public bool IsPoco => _property.IsPoco;

    public bool IsCollection => _property.IsCollection;

    public bool IsNullable => _property.IsNullable;

    public Type Type => _property.Type;

    public string? KeyPart => _property.KeyPart;

    public PropertyValueHolder(Property property, PocoBase target, Type? projectionType)
    {
        _name = property.Name + (property.KeyPart is { } ? $" ({property.KeyPart})" : string.Empty);
        _property = property;
        _targetRererence.SetTarget(target);
        _projectionType = projectionType;
    }

    internal void Touch()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
    }
}
