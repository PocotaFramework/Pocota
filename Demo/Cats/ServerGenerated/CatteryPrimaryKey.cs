
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatteryPrimaryKey                           //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-10T17:24:30                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatteryPrimaryKey : IPrimaryKey<ICattery>
{
    private Int32? _idCattery = null;
    private static readonly IList<KeyDefinition> _definitions = new List<KeyDefinition>()
    {
        new() {Name = "IdCattery", Type = typeof(Int32), Property = null, KeyReference = null},
    }.AsReadOnly();

    public virtual object? this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return _idCattery;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0:
                    _idCattery = value as Int32?;
                    if (value is null || _idCattery is null)
                    {
                        throw new InvalidCastException();
                    }
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
    public virtual object? this[string name]
    {
        get
        {
            switch (name)
            {
                case "IdCattery":
                    return _idCattery;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (name)
            {
                case "IdCattery":
                    _idCattery = value as Int32?;
                    if (value is null || _idCattery is null)
                    {
                        throw new InvalidCastException();
                    }
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
    public IList<KeyDefinition> Definitions => _definitions;
    public int Count => _definitions.Count;
    public virtual bool IsAssigned => _definitions.Select(def => this[def.Name] is { }).All(e => e);

    public virtual Int32? IdCattery 
    {
        get => _idCattery;
        set
        {
            _idCattery = value as Int32?;
            if (value is null || _idCattery is null)
            {
                throw new InvalidCastException();
            }
        }
    }
    public object?[] ToArray()
    {
        return new object?[] 
        {
            this[0],
        };
    }
}