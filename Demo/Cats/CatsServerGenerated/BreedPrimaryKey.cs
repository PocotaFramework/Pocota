/////////////////////////////////////////////////////////////
// Server Poco Primary Key                                 //
// CatsCommon.Model.BreedPrimaryKey                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Server.Generic;
using System;

namespace CatsCommon.Model;

public class BreedPrimaryKey: IPrimaryKey<BreedPoco>, IPrimaryKey<IBreed>
{
    private static string[] s_names = new string[] { "IdBreed", "IdGroup" };

    internal BreedPoco? Source { get; init; }

    private String _idBreed = default!;
    private String _idGroup = default!;

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
        get {
            if(Source is {})
            {
                return Source.Code;
            }
            return _idBreed;
        }
        set
        {
            if(Source is {})
            {
                Source.Code = value;
            }
            _idBreed = value;
        }
    }

    public String IdGroup
    {
        get {
            if(Source is {})
            {
                return Source.Group;
            }
            return _idGroup;
        }
        set
        {
            if(Source is {})
            {
                Source.Group = value;
            }
            _idGroup = value;
        }
    }


    public IEnumerable<string> Names => s_names.Select(n => n);

    public IEnumerable<object> Items => s_names.Select(n => this[n]);



    public BreedPrimaryKey(BreedPoco? source)
    {
        Source = source;
    }

    public override bool Equals(object? obj)
    {
        return obj is BreedPrimaryKey other && Enumerable.SequenceEqual(Items, other.Items);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IdBreed, IdGroup);
    }

}