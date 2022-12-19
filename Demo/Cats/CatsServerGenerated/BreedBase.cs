/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.BreedBase                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-19T17:40:44                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using Net.Leksi.Pocota.Server;
    using System;
    
namespace CatsCommon.Model;

public class BreedBase: EntityBase, IProjector, IProjection<BreedBase>
{

    #region Projection classes;


    [Poco(typeof(IBreed))]
    public class BreedProjection: IBreed, IProjector, IProjection<BreedBase>
    {

        public  BreedBase Projection  { get; init; }

        public virtual String Code 
        {
            get => Projection.Code!;
            set => Projection.Code = value;
        }

        public virtual String Group 
        {
            get => Projection.Group!;
            set => Projection.Group = value;
        }

        public virtual String? NameEng 
        {
            get => Projection.NameEng;
            set => Projection.NameEng = value;
        }

        public virtual String? NameNat 
        {
            get => Projection.NameNat;
            set => Projection.NameNat = value;
        }


        internal BreedProjection(BreedBase source)
        {
            Projection = source;
        }

        public I As<I>()
        {
            return (I)Projection.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projection.As(type);
        }




    }
    #endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(BreedBase), new Properties<PocoBase>());
        Properties[typeof(BreedBase)].Add(
                new Property<PocoBase>(
                "Code", 
                typeof(String),
                GetCodeValue, 
                SetCodeValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IBreed, String>()
        );
        Properties[typeof(BreedBase)].Add(
                new Property<PocoBase>(
                "Group", 
                typeof(String),
                GetGroupValue, 
                SetGroupValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IBreed, String>()
        );
        Properties[typeof(BreedBase)].Add(
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
            .AddPropertyType<IBreed, String>()
        );
        Properties[typeof(BreedBase)].Add(
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
            .AddPropertyType<IBreed, String>()
        );
    }


    
    private BreedProjection? _asBreedProjection = null;

    public BreedProjection AsBreedProjection => _asBreedProjection ??= new(this);


    
    public BreedBase Projection { get => this; }

    
    public String        Code  { get; set; } = default!;            
    public String        Group  { get; set; } = default!;            
    public String?        NameEng  { get; set; } = default;            
    public String?        NameNat  { get; set; } = default;            


    public BreedBase(IServiceProvider services) : base(services) 
    { 
        SetPrimaryKey(new BreedPrimaryKey(this));
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(BreedBase)];

    public override object? As(Type type)
    {
        if(type == typeof(BreedProjection) || type == typeof(IBreed))
        {
            return AsBreedProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetCodeValue(PocoBase target)
    {
        return ((BreedBase)target).Code;
    }

    private static void SetCodeValue(PocoBase target, object? value)
    {
        ((BreedBase)target).Code = (String)value!;
    }
    private static object? GetGroupValue(PocoBase target)
    {
        return ((BreedBase)target).Group;
    }

    private static void SetGroupValue(PocoBase target, object? value)
    {
        ((BreedBase)target).Group = (String)value!;
    }
    private static object? GetNameEngValue(PocoBase target)
    {
        return ((BreedBase)target).NameEng;
    }

    private static void SetNameEngValue(PocoBase target, object? value)
    {
        ((BreedBase)target).NameEng = (String)value!;
    }
    private static object? GetNameNatValue(PocoBase target)
    {
        return ((BreedBase)target).NameNat;
    }

    private static void SetNameNatValue(PocoBase target, object? value)
    {
        ((BreedBase)target).NameNat = (String)value!;
    }

    #endregion Properties accessors;


}