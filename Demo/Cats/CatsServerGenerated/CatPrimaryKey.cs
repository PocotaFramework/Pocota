/////////////////////////////////////////////////////////////
// Server Poco Primary Key                                 //
// CatsCommon.Model.CatPrimaryKey                          //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Server;
using Net.Leksi.Pocota.Server.Generic;
using System;

namespace CatsCommon.Model;

public class CatPrimaryKey: IPrimaryKey<CatPoco>, IPrimaryKey<ICat>, IPrimaryKey<ICatForListing>, IPrimaryKey<ICatAsParent>, IPrimaryKey<ICatForView>
{
    private static string[] s_names = new string[] { "IdCat", "IdCattery" };

    internal CatPoco? Source { get; init; }

    private Int32 _idCat = default!;
    private Int32 _idCattery = default!;

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
                case "IdCat":
                    return IdCat;
                case "IdCattery":
                    return IdCattery;
                default:
                    throw new IndexOutOfRangeException($"{name}");
            }
        }
        set 
        {
            switch(name)
            {
                case "IdCat":
                    IdCat = (Int32)value!;
                    break;
                case "IdCattery":
                    IdCattery = (Int32)value!;
                    break;
                default:
                    throw new IndexOutOfRangeException($"{name}");
            }
        }
    }


    public Int32 IdCat
    {
        get {
           return _idCat;
        }
        set
        {
           _idCat = value;
        }
    }

    public Int32 IdCattery
    {
        get {
            if(Source is {})
            {
                return (((IEntity)Source.Cattery).PrimaryKey as CatteryPrimaryKey)!.IdCattery;
            }
            return _idCattery;
        }
        set
        {
            if(Source is {})
            {
                (((IEntity)Source.Cattery).PrimaryKey as CatteryPrimaryKey)!.IdCattery = value;
            }
            _idCattery = value;
        }
    }


    public IEnumerable<string> Names => s_names.Select(n => n);

    public IEnumerable<object> Items => s_names.Select(n => this[n]);



    public CatPrimaryKey(CatPoco? source)
    {
        Source = source;
    }

    public override bool Equals(object? obj)
    {
        return obj is CatPrimaryKey other && Enumerable.SequenceEqual(Items, other.Items);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IdCat, IdCattery);
    }

}