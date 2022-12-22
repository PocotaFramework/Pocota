/////////////////////////////////////////////////////////////
// Server Poco Primary Key                                 //
// CatsCommon.Model.CatteryPrimaryKey                      //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-22T18:29:21                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server.Generic;
using System;

namespace CatsCommon.Model;

public class CatteryPrimaryKey: IPrimaryKey<CatteryPoco>, IPrimaryKey<ICattery>
{
    private static string[] s_names = new string[] { "IdCattery" };

    private readonly IServiceProvider _services;
    private readonly WeakReference _source = new(null);

    private Int32 _idCattery = default!;

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
        get 
        {
           return _idCattery;
        }
        set
        {
           _idCattery = value;
        }
    }


    public Type SourceType => typeof(CatteryPoco);

    public bool IsAssigned => IdCattery != default(Int32);

    public IEnumerable<string> Names => s_names.Select(n => n);

    public IEnumerable<object?> Items => s_names.Select(n => this[n]);

    public IEnumerable<string> NotAssignedFields => GetNotAssignedFields();

    public CatteryPrimaryKey(IServiceProvider services)
    {
        _services = services;
    }

    public override bool Equals(object? obj)
    {
        return obj is CatteryPrimaryKey other && Enumerable.SequenceEqual(Items, other.Items);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IdCattery);
    }


    public void Assign(Net.Leksi.Pocota.Server.IPrimaryKey other)
    {
        if(!other.IsAssigned)
        {
            throw new ArgumentException($"{nameof(other)} must be assigned!");
        }
        if(other is not CatteryPrimaryKey)
        {
            throw new ArgumentException($"{nameof(other)} must be the CatteryPrimaryKey!");
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
        }
        return false;
    }

    private IEnumerable<string> GetNotAssignedFields()
    {
        if (IdCattery == default(Int32))
        {
            yield return "IdCattery";
        }

    }

}