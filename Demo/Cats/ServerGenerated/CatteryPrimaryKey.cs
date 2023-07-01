
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatteryPrimaryKey                           //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-01T13:56:28                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common.Generic;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatteryPrimaryKey : IPrimaryKey<ICattery>
{
    private Int32? _idCattery = null;
    private readonly IList<string> _names = new List<string>
    {
        "IdCattery",
    }.AsReadOnly();
    public virtual object? this[int index]
    {
        get
        {
            switch(index)
            {
                case 0:
                    return _idCattery;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch(index)
            {
                case 0:
                    _idCattery = value as Int32?;
                    if(value is {} && _idCattery is null)
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
            switch(name)
            {
                case "IdCattery":
                    return _idCattery;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch(name)
            {
                case "IdCattery":
                    _idCattery = value as Int32?;
                    if(value is {} && _idCattery is null)
                    {
                        throw new InvalidCastException();
                    }
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
    public IList<string> Names => _names;
    public int Count => Names.Count;
    public bool IsAssigned => Names.Select(n => this[n] is { }).All(e => e);

    public virtual Int32? IdCattery 
    {
        get => _idCattery;
        set
        {
            _idCattery = value as Int32?;
            if(value is {} && _idCattery is null)
            {
                throw new InvalidCastException();
            }
        }
    }
}