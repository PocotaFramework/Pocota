/////////////////////////////////////////////////////////////
// Server Poco Primary Key                                 //
// CatsCommon.Model.LitterPrimaryKey                       //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Server;
using Net.Leksi.Pocota.Server.Generic;
using System;

namespace CatsCommon.Model;

public class LitterPrimaryKey: IPrimaryKey<LitterPoco>, IPrimaryKey<ILitter>, IPrimaryKey<ILitterForCat>, IPrimaryKey<ILitterForDate>, IPrimaryKey<ILitterWithCats>
{
    private static string[] s_names = new string[] { "IdFemale", "IdFemaleCattery", "IdLitter" };

    internal LitterPoco? Source { get; init; }

    private Int32 _idFemale = default!;
    private Int32 _idFemaleCattery = default!;
    private Int32 _idLitter = default!;

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
                case "IdFemale":
                    return IdFemale;
                case "IdFemaleCattery":
                    return IdFemaleCattery;
                case "IdLitter":
                    return IdLitter;
                default:
                    throw new IndexOutOfRangeException($"{name}");
            }
        }
        set 
        {
            switch(name)
            {
                case "IdFemale":
                    IdFemale = (Int32)value!;
                    break;
                case "IdFemaleCattery":
                    IdFemaleCattery = (Int32)value!;
                    break;
                case "IdLitter":
                    IdLitter = (Int32)value!;
                    break;
                default:
                    throw new IndexOutOfRangeException($"{name}");
            }
        }
    }


    public Int32 IdFemale
    {
        get {
            if(Source is {})
            {
                return (((IEntity)Source.Female).PrimaryKey as CatPrimaryKey)!.IdCat;
            }
            return _idFemale;
        }
        set
        {
            if(Source is {})
            {
                (((IEntity)Source.Female).PrimaryKey as CatPrimaryKey)!.IdCat = value;
            }
            _idFemale = value;
        }
    }

    public Int32 IdFemaleCattery
    {
        get {
            if(Source is {})
            {
                return (((IEntity)Source.Female).PrimaryKey as CatPrimaryKey)!.IdCattery;
            }
            return _idFemaleCattery;
        }
        set
        {
            if(Source is {})
            {
                (((IEntity)Source.Female).PrimaryKey as CatPrimaryKey)!.IdCattery = value;
            }
            _idFemaleCattery = value;
        }
    }

    public Int32 IdLitter
    {
        get {
            if(Source is {})
            {
                return Source.Order;
            }
            return _idLitter;
        }
        set
        {
            if(Source is {})
            {
                Source.Order = value;
            }
            _idLitter = value;
        }
    }


    public IEnumerable<string> Names => s_names.Select(n => n);

    public IEnumerable<object> Items => s_names.Select(n => this[n]);



    public LitterPrimaryKey(LitterPoco? source)
    {
        Source = source;
    }

    public override bool Equals(object? obj)
    {
        return obj is LitterPrimaryKey other && Enumerable.SequenceEqual(Items, other.Items);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IdFemale, IdFemaleCattery, IdLitter);
    }

}