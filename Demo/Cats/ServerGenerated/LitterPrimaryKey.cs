
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterPrimaryKey                            //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-29T16:58:28                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common.Generic;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterPrimaryKey : IPrimaryKey<ILitter>
{
    private Int32? _idFemale = null;
    private Int32? _idFemaleCattery = null;
    private Int32? _idLitter = null;
    private readonly IList<string> _names = new List<string>
    {
        "IdFemale",
        "IdFemaleCattery",
        "IdLitter",
    }.AsReadOnly();
    public virtual object? this[int index]
    {
        get
        {
            switch(index)
            {
                case 0:
                    return _idFemale;
                case 1:
                    return _idFemaleCattery;
                case 2:
                    return _idLitter;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch(index)
            {
                case 0:
                    _idFemale = value as Int32?;
                    if(value is {} && _idFemale is null)
                    {
                        throw new InvalidCastException();
                    }
                    break;
                case 1:
                    _idFemaleCattery = value as Int32?;
                    if(value is {} && _idFemaleCattery is null)
                    {
                        throw new InvalidCastException();
                    }
                    break;
                case 2:
                    _idLitter = value as Int32?;
                    if(value is {} && _idLitter is null)
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
                case "IdFemale":
                    return _idFemale;
                case "IdFemaleCattery":
                    return _idFemaleCattery;
                case "IdLitter":
                    return _idLitter;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch(name)
            {
                case "IdFemale":
                    _idFemale = value as Int32?;
                    if(value is {} && _idFemale is null)
                    {
                        throw new InvalidCastException();
                    }
                    break;
                case "IdFemaleCattery":
                    _idFemaleCattery = value as Int32?;
                    if(value is {} && _idFemaleCattery is null)
                    {
                        throw new InvalidCastException();
                    }
                    break;
                case "IdLitter":
                    _idLitter = value as Int32?;
                    if(value is {} && _idLitter is null)
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

    public virtual Int32? IdFemale 
    {
        get => _idFemale;
        set
        {
            _idFemale = value as Int32?;
            if(value is {} && _idFemale is null)
            {
                throw new InvalidCastException();
            }
        }
    }
    public virtual Int32? IdFemaleCattery 
    {
        get => _idFemaleCattery;
        set
        {
            _idFemaleCattery = value as Int32?;
            if(value is {} && _idFemaleCattery is null)
            {
                throw new InvalidCastException();
            }
        }
    }
    public virtual Int32? IdLitter 
    {
        get => _idLitter;
        set
        {
            _idLitter = value as Int32?;
            if(value is {} && _idLitter is null)
            {
                throw new InvalidCastException();
            }
        }
    }
}