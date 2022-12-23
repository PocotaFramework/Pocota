/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatteryPoco                            //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-23T18:45:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Model;

public class CatteryPoco: EntityBase, IPoco, IProjection, IProjection<CatteryPoco>, IProjection<ICattery>
{
    public static readonly Type PrimaryKeyType = typeof(CatteryPrimaryKey);
    

#region Projection classes


    public class CatteryICatteryProjection: ICattery, IPoco, IProjection, IProjection<CatteryPoco>, IProjection<ICattery>
    {

        public IProjection Projector { get; init; }


        public String? NameEng 
        {
            get => ((CatteryPoco)Projector).NameEng;
            set => ((CatteryPoco)Projector).NameEng = value;
        }

        public String? NameNat 
        {
            get => ((CatteryPoco)Projector).NameNat;
            set => ((CatteryPoco)Projector).NameNat = value;
        }


        internal CatteryICatteryProjection(IProjection projector)
        {
            Projector = projector;
        }

        public I? As<I>() where I : class
        {
            return (I?)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }


        public override bool Equals(object? obj)
        {
            return obj is IProjection<CatteryPoco> other && object.ReferenceEquals(Projector, other.Projector);
        }

        public override int GetHashCode()
        {
            return Projector.GetHashCode();
        }

        bool IPoco.IsLoaded(Type @interface)
        {
            return ((IPoco)Projector).IsLoaded(@interface);
        }

        bool IPoco.IsLoaded<T>()
        {
            return ((IPoco)Projector).IsLoaded<T>();
        }

        void IPoco.TouchProperty(string property)
        {
            ((IPoco)Projector).TouchProperty(property);
        }

        void IPoco.Clear()
        {
            ((IPoco)Projector).Clear();
        }

        bool IPoco.IsPropertySet(string property)
        {
            return ((IPoco)Projector).IsPropertySet(property);
        }




        

    }
#endregion Projection classes

    
#region Init Properties
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
                new Property(
                "NameEng", 
                typeof(String),
                GetNameEngValue, 
                SetNameEngValue, 
                target => ((IPoco)target).TouchProperty("NameEng"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICattery, String>()
        );
        properties.Add(
                new Property(
                "NameNat", 
                typeof(String),
                GetNameNatValue, 
                SetNameNatValue, 
                target => ((IPoco)target).TouchProperty("NameNat"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICattery, String>()
        );
    }
#endregion Init Properties;


    
#region Fields

    private String? _nameEng = default;
    private bool _loaded_nameEng = false;
    private String? _nameNat = default;
    private bool _loaded_nameNat = false;

#endregion Fields;

    
    
#region Projection Properties

    private CatteryICatteryProjection? _asCatteryICatteryProjection = null;

    private CatteryICatteryProjection AsCatteryICatteryProjection => _asCatteryICatteryProjection ??= new(this);

#endregion Projection Properties;

    
    
#region Properties

    public IProjection Projector => this;

    public String? NameEng 
    { 
        get => _nameEng; 
        set
        {
            _nameEng = value;
            _loaded_nameEng = true;
        }
    }

    public String? NameNat 
    { 
        get => _nameNat; 
        set
        {
            _nameNat = value;
            _loaded_nameNat = true;
        }
    }

#endregion Properties;


    public CatteryPoco(IServiceProvider services) : base(services) 
    { 
        _primaryKey = new CatteryPrimaryKey(services);
        (_primaryKey as CatteryPrimaryKey)!.Source = this;
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ICattery))
        {
            return AsCatteryICatteryProjection;
        }
        if(type == typeof(CatteryPoco))
        {
            return this;
        }
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<CatteryPoco> other && object.ReferenceEquals(this, other.Projector);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _loaded_nameEng = false;
        _loaded_nameNat = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ICattery))
        {
            return _loaded_nameEng
                && _loaded_nameNat
            ;
        }
        return false;
    }

    bool IPoco.IsLoaded<T>()
    {
        return ((IPoco)this).IsLoaded(typeof(T));
    }

    bool IPoco.IsPropertySet(string property)
    {
        switch(property)
        {
            case "NameEng":
                return _loaded_nameEng;
            case "NameNat":
                return _loaded_nameNat;
            default:
                return false;
        }
    }

    void IPoco.TouchProperty(string property)
    {
        switch(property)
        {
            case "NameEng":
                _loaded_nameEng = true;
                break;
            case "NameNat":
                _loaded_nameNat = true;
                break;
        }
    }

#endregion IPoco;


    
#region Properties Accessors

    private static object? GetNameEngValue(object target)
    {
        return ((CatteryPoco)target).NameEng;
    }

    private static void SetNameEngValue(object target, object? value)
    {
        ((CatteryPoco)target).NameEng = (String)value!;

    }

    private static object? GetNameNatValue(object target)
    {
        return ((CatteryPoco)target).NameNat;
    }

    private static void SetNameNatValue(object target, object? value)
    {
        ((CatteryPoco)target).NameNat = (String)value!;

    }


#endregion Properties Accessors;


}