
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatPrimaryKey                               //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-06T13:36:50                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatPrimaryKey : IPrimaryKey<ICat>
{
    private Int32? _idCat = null;
    private Int32? _idCattery = null;
    private static readonly IList<KeyDefinition> _definitions = new List<KeyDefinition>()
    {
        new() {Name = "IdCat", Type = typeof(Int32), Property = null, KeyReference = null},
        new() {Name = "IdCattery", Type = typeof(Int32), Property = "Cattery", KeyReference = "IdCattery"},
    }.AsReadOnly();

    public virtual object? this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return _idCat;
                case 1:
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
                    _idCat = value as Int32?;
                    if (value is null || _idCat is null)
                    {
                        throw new InvalidCastException();
                    }
                    break;
                case 1:
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
                case "IdCat":
                    return _idCat;
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
                case "IdCat":
                    _idCat = value as Int32?;
                    if (value is null || _idCat is null)
                    {
                        throw new InvalidCastException();
                    }
                    break;
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

    public virtual Int32? IdCat 
    {
        get => _idCat;
        set
        {
            _idCat = value as Int32?;
            if (value is null || _idCat is null)
            {
                throw new InvalidCastException();
            }
        }
    }
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
            this[1],
        };
    }
}