/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatteryPoco                            //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-22T18:29:21                                  //
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


    public class CatteryICatteryProjection: ICattery, IProjection, IProjection<CatteryPoco>, IProjection<ICattery>
    {

        
#region Projectors

        public CatteryPoco Projector { get; init; }
        IProjector IProjection.Projector => Projector;

        ICattery IProjection<ICattery>.Projector => Projector.As<ICattery>()!;

#endregion Projectors;



        public String? NameEng 
        {
            get => Projector.NameEng;
            set => Projector.NameEng = value;
        }

        public String? NameNat 
        {
            get => Projector.NameNat;
            set => Projector.NameNat = value;
        }


        internal CatteryICatteryProjection(CatteryPoco projector)
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

    
    
#region Projectors

    public CatteryPoco Projector => this;
    IProjector IProjection.Projector => Projector;

    ICattery IProjection<ICattery>.Projector => Projector.As<ICattery>()!;

#endregion Projectors;

    
    
#region Properties

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
        return null;
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