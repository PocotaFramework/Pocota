/////////////////////////////////////////////////////////////
// Server Poco Primary Key                                 //
// CatsCommon.Model.CatteryPrimaryKey                      //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-19T17:40:44                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Server.Generic;
    using System;
    
namespace CatsCommon.Model;

public class CatteryPrimaryKey: IPrimaryKey<CatteryBase>
{
    private static string[] s_names = new string[] { "IdCattery" };

    internal CatteryBase? Source { get; init; }

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


    public CatteryPrimaryKey(CatteryBase? source)
    {
        Source = source;
    }
}