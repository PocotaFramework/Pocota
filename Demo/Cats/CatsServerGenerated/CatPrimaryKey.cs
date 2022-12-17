//------------------------------
// PrimaryKey implementation
// CatsCommon.Model.CatPrimaryKey
// (Generated automatically 2022-12-17T12:54:33)
//------------------------------

using Net.Leksi.Pocota.Server;
    using Net.Leksi.Pocota.Server.Generic;
    using System;
    
namespace CatsCommon.Model;

public class CatPrimaryKey: IPrimaryKey<CatBase>
{
    private static string[] s_names = new string[] { "IdCat", "IdCattery" };

    internal CatBase? Source { get; init; }

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


    public CatPrimaryKey(CatBase? source)
    {
        Source = source;
    }
}