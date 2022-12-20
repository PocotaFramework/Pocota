/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatteryPoco                            //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Model;

public class CatteryPoco: EntityBase, IProjector
{
    public static readonly Type PrimaryKeyType = typeof(CatteryPrimaryKey);
    

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
        Properties.Add(typeof(CatteryPoco), new Properties<PocoBase>());
        Properties[typeof(CatteryPoco)].Add(
                new Property<PocoBase>(
                "NameEng", 
                typeof(String),
                GetNameEngValue, 
                SetNameEngValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICattery, String>()
        );
        Properties[typeof(CatteryPoco)].Add(
                new Property<PocoBase>(
                "NameNat", 
                typeof(String),
                GetNameNatValue, 
                SetNameNatValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICattery, String>()
        );
    }


    
    private CatteryICatteryProjection? _asCatteryICatteryProjection = null;

    public CatteryICatteryProjection AsCatteryICatteryProjection => _asCatteryICatteryProjection ??= new(this);


    
    
    public String? NameEng { get; set; } = default;
    public String? NameNat { get; set; } = default;


    public CatteryPoco(IServiceProvider services) : base(services) 
    { 
        SetPrimaryKey(new CatteryPrimaryKey(this));
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(CatteryPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(CatteryICatteryProjection) || type == typeof(ICattery))
        {
            return AsCatteryICatteryProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetNameEngValue(PocoBase target)
    {
        return ((CatteryPoco)target).NameEng;
    }

    private static void SetNameEngValue(PocoBase target, object? value)
    {
        ((CatteryPoco)target).NameEng = (String)value!;
    }
    private static object? GetNameNatValue(PocoBase target)
    {
        return ((CatteryPoco)target).NameNat;
    }

    private static void SetNameNatValue(PocoBase target, object? value)
    {
        ((CatteryPoco)target).NameNat = (String)value!;
    }

    #endregion Properties accessors;


}