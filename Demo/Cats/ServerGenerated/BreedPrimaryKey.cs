
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.BreedPrimaryKey                             //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-04T15:46:08                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class BreedPrimaryKey : IPrimaryKey<IBreed>
{
    private String? _idBreed = null;
    private String? _idGroup = null;
    private static readonly IList<KeyDefinition> _definitions = new List<KeyDefinition>()
    {
        new() {Name = "IdBreed", Type = typeof(String), Property = "Code", KeyReference = null},
        new() {Name = "IdGroup", Type = typeof(String), Property = "Group", KeyReference = null},
    }.AsReadOnly();

    public virtual object? this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return _idBreed;
                case 1:
                    return _idGroup;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0:
                    _idBreed = value as String;
                    if (value is null || _idBreed is null)
                    {
                        throw new InvalidCastException();
                    }
                    break;
                case 1:
                    _idGroup = value as String;
                    if (value is null || _idGroup is null)
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
                case "IdBreed":
                    return _idBreed;
                case "IdGroup":
                    return _idGroup;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (name)
            {
                case "IdBreed":
                    _idBreed = value as String;
                    if (value is null || _idBreed is null)
                    {
                        throw new InvalidCastException();
                    }
                    break;
                case "IdGroup":
                    _idGroup = value as String;
                    if (value is null || _idGroup is null)
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

    public virtual String? IdBreed 
    {
        get => _idBreed;
        set
        {
            _idBreed = value as String;
            if (value is null || _idBreed is null)
            {
                throw new InvalidCastException();
            }
        }
    }
    public virtual String? IdGroup 
    {
        get => _idGroup;
        set
        {
            _idGroup = value as String;
            if (value is null || _idGroup is null)
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