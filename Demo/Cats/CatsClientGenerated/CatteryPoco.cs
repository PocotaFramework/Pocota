/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.CatteryPoco                            //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-21T18:50:10                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;

namespace CatsCommon.Model;

public class CatteryPoco: EntityBase, IPoco, IProjector
{

#region Projection classes;

    public class CatteryICatteryProjection: ICattery, IProjector, IProjection<CatteryPoco>
    {

        public CatteryPoco Projector  { get; init; }

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

        I? IProjector.As<I>() where I : class
        {
            return (I?)((IProjector)Projector).As(typeof(I))!;
        }

        object? IProjector.As(Type type) 
        {
            return ((IProjector)Projector).As(type);
        }




    }
#endregion Projection classes;

    
#region Init Properties;
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

    
    
#region Fields;

    private String? _nameEng = default;
    private String? _nameNat = default;

#endregion Fields;


    
#region Projection Properties;

    private CatteryICatteryProjection? _asCatteryICatteryProjection = null;

    public CatteryICatteryProjection AsCatteryICatteryProjection => _asCatteryICatteryProjection ??= new(this);

#endregion Projection Properties;


    
#region Properties;
    public virtual String? NameEng
    {
        get => _nameEng;
        set
        {
            if(_nameEng != value)
            {
                object? oldValue = _nameEng;
                _nameEng = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? NameNat
    {
        get => _nameNat;
        set
        {
            if(_nameNat != value)
            {
                object? oldValue = _nameNat;
                _nameNat = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

#endregion Properties;


    public CatteryPoco(IServiceProvider services) : base(services) 
    { 
    }

    
#region Methods;
    I? IProjector.As<I>() where I : class
    {
        return (I?)((IProjector)this).As(typeof(I));
    }

    object? IProjector.As(Type type)
    {
        if(type == typeof(CatteryICatteryProjection) || type == typeof(ICattery))
        {
            return AsCatteryICatteryProjection;
        }
        return null;
    }


#endregion Methods;


    
#region Collections;

    protected override bool IsCollectionChanged(string property)
    {
        switch(property)
        {
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
    }

    protected override void AcceptCollectionsChanges()
    {
    }
    
#endregion Collections;


    
#region Poco Changed;



#endregion Poco Changed;


    
#region Properties Accessors;

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


