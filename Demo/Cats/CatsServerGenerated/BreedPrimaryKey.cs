/////////////////////////////////////////////////////////////
// Server Poco Primary Key                                 //
// CatsCommon.Model.BreedPrimaryKey                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-04-24T21:55:14                                  //
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

    public IProjection? Source 
    { 
        get => (IProjection?)_source.Target; 
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
                    IdBreed = (String)Convert.ChangeType(value!, typeof(String));
                    break;
                case "IdGroup":
                    IdGroup = (String)Convert.ChangeType(value!, typeof(String));
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
            if(_source.Target is BreedPoco obj)
            {
                return obj.Code;
            }
            return _idBreed;
        }
        set
        {
            if(_source.Target is BreedPoco obj)
            {
                obj.Code = value;
            }
            _idBreed = value;
        }
    }

    public String IdGroup
    {
        get 
        {
            if(_source.Target is BreedPoco obj)
            {
                return obj.Group;
            }
            return _idGroup;
        }
        set
        {
            if(_source.Target is BreedPoco obj)
            {
                obj.Group = value;
            }
            _idGroup = value;
        }
    }


    public Type SourceType => typeof(BreedPoco);

    public bool IsAssigned => IdBreed != default && IdGroup != default;

    public IEnumerable<string> Names => s_names.Select(n => n);

    public IEnumerable<object?> Items => s_names.Select(n => this[n]);

    public IEnumerable<string> NotAssignedFields => GetNotAssignedFields();

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
        if(!other.IsAssigned)
        {
            throw new ArgumentException($"{nameof(other)} must be assigned!");
        }
        if(other is not BreedPrimaryKey)
        {
            throw new ArgumentException($"{nameof(other)} must be the BreedPrimaryKey!");
        }
        foreach(string name in s_names)
        {
            this[name] = other[name];
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

    private IEnumerable<string> GetNotAssignedFields()
    {
        if (IdBreed == default)
        {
            yield return "IdBreed";
        }

        if (IdGroup == default)
        {
            yield return "IdGroup";
        }

    }

}