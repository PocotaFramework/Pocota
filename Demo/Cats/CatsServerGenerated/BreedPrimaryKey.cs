/////////////////////////////////////////////////////////////
// Server Poco Primary Key                                 //
// CatsCommon.Model.BreedPrimaryKey                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-21T18:50:10                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server.Generic;
using System;

namespace CatsCommon.Model;

public class BreedPrimaryKey: IPrimaryKey<BreedPoco>, IPrimaryKey<IBreed>
{
    private static string[] s_names = new string[] { "IdBreed", "IdGroup" };

    private readonly IServiceProvider _services;
    private readonly WeakReference _source = new(null);

    private String _idBreed = default!;
    private String _idGroup = default!;

    public IProjector? Source 
    { 
        get => (IProjector?)_source.Target; 
        internal set 
        {
            _source.Target = value;
        }
    }

    public object? this[int index]
    {
        get => this[s_names[index]];
        set => this[s_names[index]] = value;
    }

    public object? this[string name]
    {
        get 
        {
            switch(name)
            {
                case "IdBreed":
                    return IdBreed;
                case "IdGroup":
                    return IdGroup;
                default:
                    throw new IndexOutOfRangeException($"{name}");
            }
        }
        set 
        {
            switch(name)
            {
                case "IdBreed":
                    IdBreed = (String)value!;
                    break;
                case "IdGroup":
                    IdGroup = (String)value!;
                    break;
                default:
                    throw new IndexOutOfRangeException($"{name}");
            }
        }
    }


    public String IdBreed
    {
        get 
        {
            if(_source.Target is {})
            {
                return ((BreedPoco)_source.Target).Code;
            }
            return _idBreed;
        }
        set
        {
            if(_source.Target is {})
            {
                ((BreedPoco)_source.Target).Code = value;
            }
            _idBreed = value;
        }
    }

    public String IdGroup
    {
        get 
        {
            if(_source.Target is {})
            {
                return ((BreedPoco)_source.Target).Group;
            }
            return _idGroup;
        }
        set
        {
            if(_source.Target is {})
            {
                ((BreedPoco)_source.Target).Group = value;
            }
            _idGroup = value;
        }
    }


    public IEnumerable<string> Names => s_names.Select(n => n);

    public IEnumerable<object?> Items => s_names.Select(n => this[n]);



    public BreedPrimaryKey(IServiceProvider services)
    {
        _services = services;
    }

    public override bool Equals(object? obj)
    {
        return obj is BreedPrimaryKey other && Enumerable.SequenceEqual(Items, other.Items);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IdBreed, IdGroup);
    }


    public void Assign(Net.Leksi.Pocota.Server.IPrimaryKey other)
    {
        if(other is not BreedPrimaryKey)
        {
            throw new ArgumentException($"{nameof(other)} must be the BreedPrimaryKey!");
        }
        foreach(string name in s_names)
        {
            other[name] = this[name];
        }
    }

    public bool TryGetPresets(string property, Dictionary<string, object> presets)
    {
        presets.Clear();
        switch(property)
        {
            case "Code":
                presets.Add(string.Empty, IdBreed);
                return true;
            case "Group":
                presets.Add(string.Empty, IdGroup);
                return true;
        }
        return false;
    }

}