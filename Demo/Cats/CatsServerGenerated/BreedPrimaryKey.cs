//------------------------------
// PrimaryKey implementation
// CatsCommon.Model.BreedPrimaryKey
// (Generated automatically 2022-12-17T12:54:33)
//------------------------------

using Net.Leksi.Pocota.Server.Generic;
    using System;
    
namespace CatsCommon.Model;

public class BreedPrimaryKey: IPrimaryKey<BreedBase>
{
    private static string[] s_names = new string[] { "IdBreed", "IdGroup" };

    internal BreedBase? Source { get; init; }

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


    public BreedPrimaryKey(BreedBase? source)
    {
        Source = source;
    }
}