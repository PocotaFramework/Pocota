/////////////////////////////////////////////////////////////
// Server Poco Primary Key                                 //
// CatsCommon.Model.CatPrimaryKey                          //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-30T16:08:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using Net.Leksi.Pocota.Server.Generic;
using System;

namespace CatsCommon.Model;

public class CatPrimaryKey: IPrimaryKey<CatPoco>, IPrimaryKey<ICat>, IPrimaryKey<ICatForListing>, IPrimaryKey<ICatAsParent>, IPrimaryKey<ICatForView>, IPrimaryKey<ICatWithSiblings>
{
    private static string[] s_names = new string[] { "IdCat", "IdCattery" };

    private readonly IServiceProvider _services;
    private readonly WeakReference _source = new(null);

    private Int32 _idCat = default!;
    private Int32 _idCattery = default!;

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
                    IdCat = (Int32)Convert.ChangeType(value!, typeof(Int32));
                    break;
                case "IdCattery":
                    IdCattery = (Int32)Convert.ChangeType(value!, typeof(Int32));
                    break;
                default:
                    throw new IndexOutOfRangeException($"{name}");
            }
        }
    }


    public Int32 IdCat
    {
        get 
        {
           return _idCat;
        }
        set
        {
           _idCat = value;
        }
    }

    public Int32 IdCattery
    {
        get 
        {
            if(_source.Target is CatPoco obj && obj.Cattery is IEntity entity)
            {
                return (entity.PrimaryKey as CatteryPrimaryKey)!.IdCattery;
            }
            return _idCattery;
        }
        set
        {
            if(_source.Target is CatPoco obj && obj.Cattery is IEntity entity)
            {
                (entity.PrimaryKey as CatteryPrimaryKey)!.IdCattery = value;
            }
            else 
            {
                _idCattery = value;
            }
        }
    }


    public Type SourceType => typeof(CatPoco);

    public bool IsAssigned => IdCat != default(Int32) && IdCattery != default(Int32);

    public IEnumerable<string> Names => s_names.Select(n => n);

    public IEnumerable<object?> Items => s_names.Select(n => this[n]);

    public IEnumerable<string> NotAssignedFields => GetNotAssignedFields();

    public CatPrimaryKey(IServiceProvider services)
    {
        _services = services;
    }

    public override bool Equals(object? obj)
    {
        return obj is CatPrimaryKey other && Enumerable.SequenceEqual(Items, other.Items);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IdCat, IdCattery);
    }


    public void Assign(Net.Leksi.Pocota.Server.IPrimaryKey other)
    {
        if(!other.IsAssigned)
        {
            throw new ArgumentException($"{nameof(other)} must be assigned!");
        }
        if(other is not CatPrimaryKey)
        {
            throw new ArgumentException($"{nameof(other)} must be the CatPrimaryKey!");
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
            case "Cattery":
                presets.Add("IdCattery", IdCattery);
                return true;
        }
        return false;
    }

    private IEnumerable<string> GetNotAssignedFields()
    {
        if (IdCat == default(Int32))
        {
            yield return "IdCat";
        }

        if (IdCattery == default(Int32))
        {
            yield return "IdCattery";
        }

    }

}