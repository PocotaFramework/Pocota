//////////////////////////////////////////////////////////////
// Client Poco Implementation                               //
// CatsCommon.Model.CatteryBase                             //
// Generated automatically from Cats.Contract.ICatsContract //
// at 2022-12-16T18:40:09                                   //
//////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;

namespace CatsCommon.Model;

public class CatteryBase: EntityBase, IProjector
{

#region Projection classes;

    [Poco(typeof(ICattery))]
    public class CatteryProjection: ICattery, IProjector, IProjection<CatteryBase>
    {

        public CatteryBase Projector  { get; init; }

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


        internal CatteryProjection(CatteryBase projector)
        {
            Projector = projector;
        }

        public I As<I>()
        {
            return (I)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }




    }
#endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(CatteryBase), new Properties<PocoBase>());
        Properties[typeof(CatteryBase)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(CatteryBase)].Add(
                new Property<PocoBase>(
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

    
    
    private String? _nameEng = default;
    private String? _nameNat = default;


    
    private CatteryProjection? _asCatteryProjection = null;

    public CatteryProjection AsCatteryProjection => _asCatteryProjection ??= new(this);



    
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



    public CatteryBase(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(CatteryBase)];

    public override object? As(Type type)
    {
        if(type == typeof(CatteryProjection) || type == typeof(ICattery))
        {
            return AsCatteryProjection;
        }
        return null;
    }




    
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
    

    



    
    #region Properties accessors;

    private static object? GetNameEngValue(PocoBase target)
    {
        return ((CatteryBase)target).NameEng;
    }

    private static void SetNameEngValue(PocoBase target, object? value)
    {
        ((CatteryBase)target).NameEng = (String)value!;
    }
    private static object? GetNameNatValue(PocoBase target)
    {
        return ((CatteryBase)target).NameNat;
    }

    private static void SetNameNatValue(PocoBase target, object? value)
    {
        ((CatteryBase)target).NameNat = (String)value!;
    }

    #endregion Properties accessors;



}


