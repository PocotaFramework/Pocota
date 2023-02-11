/////////////////////////////////////////////////////////////
// Server Poco Primary Key                                 //
// CatsCommon.Model.LitterPrimaryKey                       //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-02-11T12:23:45                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using Net.Leksi.Pocota.Server.Generic;
using System;

namespace CatsCommon.Model;

public class LitterPrimaryKey: IPrimaryKey<LitterPoco>, IPrimaryKey<ILitter>, IPrimaryKey<ILitterForCat>, IPrimaryKey<ILitterForDate>, IPrimaryKey<ILitterWithCats>
{
    private static string[] s_names = new string[] { "IdFemale", "IdFemaleCattery", "IdLitter" };

    private readonly IServiceProvider _services;
    private readonly WeakReference _source = new(null);

    private Int32 _idFemale = default!;
    private Int32 _idFemaleCattery = default!;
    private Int32 _idLitter = default!;

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
                    IdFemale = (Int32)Convert.ChangeType(value!, typeof(Int32));
                    break;
                case "IdFemaleCattery":
                    IdFemaleCattery = (Int32)Convert.ChangeType(value!, typeof(Int32));
                    break;
                case "IdLitter":
                    IdLitter = (Int32)Convert.ChangeType(value!, typeof(Int32));
                    break;
                default:
                    throw new IndexOutOfRangeException($"{name}");
            }
        }
    }


    public Int32 IdFemale
    {
        get 
        {
            if(_source.Target is LitterPoco obj && LitterPoco.FemaleProp.IsSet(obj) && obj.Female is IEntity entity)
            {
                return (entity.PrimaryKey as CatPrimaryKey)!.IdCat;
            }
            return _idFemale;
        }
        set
        {
            if(_source.Target is LitterPoco obj && LitterPoco.FemaleProp.IsSet(obj) && obj.Female is IEntity entity)
            {
                (entity.PrimaryKey as CatPrimaryKey)!.IdCat = value;
            }
            else 
            {
                _idFemale = value;
            }
        }
    }

    public Int32 IdFemaleCattery
    {
        get 
        {
            if(_source.Target is LitterPoco obj && LitterPoco.FemaleProp.IsSet(obj) && obj.Female is IEntity entity)
            {
                return (entity.PrimaryKey as CatPrimaryKey)!.IdCattery;
            }
            return _idFemaleCattery;
        }
        set
        {
            if(_source.Target is LitterPoco obj && LitterPoco.FemaleProp.IsSet(obj) && obj.Female is IEntity entity)
            {
                (entity.PrimaryKey as CatPrimaryKey)!.IdCattery = value;
            }
            else 
            {
                _idFemaleCattery = value;
            }
        }
    }

    public Int32 IdLitter
    {
        get 
        {
            if(_source.Target is LitterPoco obj)
            {
                return obj.Order;
            }
            return _idLitter;
        }
        set
        {
            if(_source.Target is LitterPoco obj)
            {
                obj.Order = value;
            }
            _idLitter = value;
        }
    }


    public Type SourceType => typeof(LitterPoco);

    public bool IsAssigned => IdFemale != default && IdFemaleCattery != default && IdLitter != default;

    public IEnumerable<string> Names => s_names.Select(n => n);

    public IEnumerable<object?> Items => s_names.Select(n => this[n]);

    public IEnumerable<string> NotAssignedFields => GetNotAssignedFields();

    public LitterPrimaryKey(IServiceProvider services)
    {
        _services = services;
    }

    public override bool Equals(object? obj)
    {
        return obj is LitterPrimaryKey other && Enumerable.SequenceEqual(Items, other.Items);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IdFemale, IdFemaleCattery, IdLitter);
    }


    public void Assign(Net.Leksi.Pocota.Server.IPrimaryKey other)
    {
        if(!other.IsAssigned)
        {
            throw new ArgumentException($"{nameof(other)} must be assigned!");
        }
        if(other is not LitterPrimaryKey)
        {
            throw new ArgumentException($"{nameof(other)} must be the LitterPrimaryKey!");
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
            case "Female":
                presets.Add("IdCat", IdFemale);
                presets.Add("IdCattery", IdFemaleCattery);
                return true;
            case "Order":
                presets.Add(string.Empty, IdLitter);
                return true;
        }
        return false;
    }

    private IEnumerable<string> GetNotAssignedFields()
    {
        if (IdFemale == default)
        {
            yield return "IdFemale";
        }

        if (IdFemaleCattery == default)
        {
            yield return "IdFemaleCattery";
        }

        if (IdLitter == default)
        {
            yield return "IdLitter";
        }

    }

}