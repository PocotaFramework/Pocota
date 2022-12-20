/////////////////////////////////////////////////////////////
// Server Poco Primary Key                                 //
// CatsCommon.Model.CatteryPrimaryKey                      //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Server.Generic;
using System;

namespace CatsCommon.Model;

public class CatteryPrimaryKey: IPrimaryKey<CatteryPoco>, IPrimaryKey<ICattery>
{
    private static string[] s_names = new string[] { "IdCattery" };

    internal CatteryPoco? Source { get; init; }

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
                case "IdCattery":
                    IdCattery = (Int32)value!;
                    break;
                default:
                    throw new IndexOutOfRangeException($"{name}");
            }
        }
    }


    public Int32 IdCattery
    {
        get {
           return _idCattery;
        }
        set
        {
           _idCattery = value;
        }
    }


    public IEnumerable<string> Names => s_names.Select(n => n);

    public IEnumerable<object> Items => s_names.Select(n => this[n]);



    public CatteryPrimaryKey(CatteryPoco? source)
    {
        Source = source;
    }

    public override bool Equals(object? obj)
    {
        return obj is CatteryPrimaryKey other && Enumerable.SequenceEqual(Items, other.Items);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IdCattery);
    }

}