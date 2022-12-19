/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatBase                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-19T17:40:43                                  //
/////////////////////////////////////////////////////////////


using CatsClientMisc;
    using CatsCommon;
    using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using Net.Leksi.Pocota.Server;
    using System;
    using System.Collections.Generic;
    
namespace CatsCommon.Model;

public class CatBase: EntityBase, IProjector, IProjection<Cat>
{

    #region Projection classes;


    [Poco(typeof(ICat))]
    public class CatProjection: ICat, IProjector, IProjection<CatBase>
    {
        private readonly ProjectionList<LitterBase,ILitter> _litters;

        public  CatBase Projection  { get; init; }

        public virtual ICattery Cattery 
        {
            get => Projection.Cattery!;
            set => Projection.Cattery = value;
        }

        public virtual String? NameNat 
        {
            get => Projection.NameNat;
            set => Projection.NameNat = value;
        }

        public virtual String? NameEng 
        {
            get => Projection.NameEng;
            set => Projection.NameEng = value;
        }

        public virtual Gender Gender 
        {
            get => Projection.Gender!;
            set => Projection.Gender = value;
        }

        public virtual IBreed Breed 
        {
            get => Projection.Breed!;
            set => Projection.Breed = value;
        }

        public virtual ILitter? Litter 
        {
            get => Projection.Litter;
            set => Projection.Litter = value;
        }

        public virtual String? Exterior 
        {
            get => Projection.Exterior;
            set => Projection.Exterior = value;
        }

        public virtual String? Description 
        {
            get => Projection.Description;
            set => Projection.Description = value;
        }

        public virtual String? Title 
        {
            get => Projection.Title;
            set => Projection.Title = value;
        }

        public virtual IList<ILitter> Litters 
        {
            get => _litters;
            set => throw new NotImplementedException();
        }


        internal CatProjection(CatBase source)
        {
            Projection = source;
            _litters = new(Projection.Litters);
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

    [Poco(typeof(ICatForListing))]
    public class CatForListingProjection: ICatForListing, IProjector, IProjection<CatBase>
    {

        public  CatBase Projection  { get; init; }

        public virtual ICattery Cattery 
        {
            get => Projection.Cattery!;
        }

        public virtual String? NameNat 
        {
            get => Projection.NameNat;
        }

        public virtual String? NameEng 
        {
            get => Projection.NameEng;
        }

        public virtual Gender Gender 
        {
            get => Projection.Gender!;
        }

        public virtual IBreed Breed 
        {
            get => Projection.Breed!;
        }

        public virtual ILitterForCat? Litter 
        {
            get => Projection.Litter;
        }

        public virtual String? Exterior 
        {
            get => Projection.Exterior;
        }

        public virtual String? Description 
        {
            get => Projection.Description;
        }

        public virtual String? Title 
        {
            get => Projection.Title;
        }


        internal CatForListingProjection(CatBase source)
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

    [Poco(typeof(ICatAsParent))]
    public class CatAsParentProjection: ICatAsParent, IProjector, IProjection<CatBase>
    {

        public  CatBase Projection  { get; init; }

        public virtual ICattery Cattery 
        {
            get => Projection.Cattery!;
        }

        public virtual String? NameNat 
        {
            get => Projection.NameNat;
        }

        public virtual String? NameEng 
        {
            get => Projection.NameEng;
        }

        public virtual IBreed Breed 
        {
            get => Projection.Breed!;
        }

        public virtual ILitterForDate? Litter 
        {
            get => Projection.Litter;
        }

        public virtual String? Exterior 
        {
            get => Projection.Exterior;
        }

        public virtual String? Title 
        {
            get => Projection.Title;
        }


        internal CatAsParentProjection(CatBase source)
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

    [Poco(typeof(ICatForView))]
    public class CatForViewProjection: ICatForView, IProjector, IProjection<CatBase>
    {
        private readonly ProjectionList<LitterBase,ILitterForCat> _litters;

        public  CatBase Projection  { get; init; }

        public virtual ICattery Cattery 
        {
            get => Projection.Cattery!;
        }

        public virtual String? NameNat 
        {
            get => Projection.NameNat;
        }

        public virtual String? NameEng 
        {
            get => Projection.NameEng;
        }

        public virtual Gender Gender 
        {
            get => Projection.Gender!;
        }

        public virtual IBreed Breed 
        {
            get => Projection.Breed!;
        }

        public virtual ILitterForCat? Litter 
        {
            get => Projection.Litter;
        }

        public virtual String? Exterior 
        {
            get => Projection.Exterior;
        }

        public virtual String? Description 
        {
            get => Projection.Description;
        }

        public virtual String? Title 
        {
            get => Projection.Title;
        }

        public virtual IList<ILitterForCat> Litters 
        {
            get => _litters;
        }


        internal CatForViewProjection(CatBase source)
        {
            Projection = source;
            _litters = new(Projection.Litters);
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
        Properties.Add(typeof(CatBase), new Properties<PocoBase>());
        Properties[typeof(CatBase)].Add(
                new Property<PocoBase>(
                "Cattery", 
                typeof(CatteryBase),
                GetCatteryValue, 
                SetCatteryValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ICat, ICattery>()
            .AddPropertyType<ICatForListing, ICattery>()
            .AddPropertyType<ICatAsParent, ICattery>()
            .AddPropertyType<ICatForView, ICattery>()
        );
        Properties[typeof(CatBase)].Add(
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
            .AddPropertyType<ICat, String>()
            .AddPropertyType<ICatForListing, String>()
            .AddPropertyType<ICatAsParent, String>()
            .AddPropertyType<ICatForView, String>()
        );
        Properties[typeof(CatBase)].Add(
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
            .AddPropertyType<ICat, String>()
            .AddPropertyType<ICatForListing, String>()
            .AddPropertyType<ICatAsParent, String>()
            .AddPropertyType<ICatForView, String>()
        );
        Properties[typeof(CatBase)].Add(
                new Property<PocoBase>(
                "Gender", 
                typeof(Gender),
                GetGenderValue, 
                SetGenderValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ICat, Gender>()
            .AddPropertyType<ICatForListing, Gender>()
            .AddPropertyType<ICatForView, Gender>()
        );
        Properties[typeof(CatBase)].Add(
                new Property<PocoBase>(
                "Breed", 
                typeof(BreedBase),
                GetBreedValue, 
                SetBreedValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ICat, IBreed>()
            .AddPropertyType<ICatForListing, IBreed>()
            .AddPropertyType<ICatAsParent, IBreed>()
            .AddPropertyType<ICatForView, IBreed>()
        );
        Properties[typeof(CatBase)].Add(
                new Property<PocoBase>(
                "Litter", 
                typeof(LitterBase),
                GetLitterValue, 
                SetLitterValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICat, ILitter>()
            .AddPropertyType<ICatForListing, ILitterForCat>()
            .AddPropertyType<ICatAsParent, ILitterForDate>()
            .AddPropertyType<ICatForView, ILitterForCat>()
        );
        Properties[typeof(CatBase)].Add(
                new Property<PocoBase>(
                "Exterior", 
                typeof(String),
                GetExteriorValue, 
                SetExteriorValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICat, String>()
            .AddPropertyType<ICatForListing, String>()
            .AddPropertyType<ICatAsParent, String>()
            .AddPropertyType<ICatForView, String>()
        );
        Properties[typeof(CatBase)].Add(
                new Property<PocoBase>(
                "Description", 
                typeof(String),
                GetDescriptionValue, 
                SetDescriptionValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICat, String>()
            .AddPropertyType<ICatForListing, String>()
            .AddPropertyType<ICatForView, String>()
        );
        Properties[typeof(CatBase)].Add(
                new Property<PocoBase>(
                "Title", 
                typeof(String),
                GetTitleValue, 
                SetTitleValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICat, String>()
            .AddPropertyType<ICatForListing, String>()
            .AddPropertyType<ICatAsParent, String>()
            .AddPropertyType<ICatForView, String>()
        );
        Properties[typeof(CatBase)].Add(
                new Property<PocoBase>(
                "Litters", 
                typeof(List<LitterBase>),
                GetLittersValue, 
                null, 
                null, 
                false, 
                false, 
                true            
            )
            .AddPropertyType<ICat, IList<ILitter>>()
            .AddPropertyType<ICatForView, IList<ILitterForCat>>()
        );
    }


    
    private CatProjection? _asCatProjection = null;
    private CatForListingProjection? _asCatForListingProjection = null;
    private CatAsParentProjection? _asCatAsParentProjection = null;
    private CatForViewProjection? _asCatForViewProjection = null;

    public CatProjection AsCatProjection => _asCatProjection ??= new(this);
    public CatForListingProjection AsCatForListingProjection => _asCatForListingProjection ??= new(this);
    public CatAsParentProjection AsCatAsParentProjection => _asCatAsParentProjection ??= new(this);
    public CatForViewProjection AsCatForViewProjection => _asCatForViewProjection ??= new(this);


    
    public Cat Projection { get; protected set; }

    
    public CatteryBase        Cattery 
    public String?        NameNat 
    public String?        NameEng 
    public Gender        Gender 
    public BreedBase        Breed 
    public LitterBase?        Litter 
    public String?        Exterior 
    public String?        Description 
    public String?        Title 
    public List<LitterBase>        Litters 


    public CatBase(IServiceProvider services) : base(services) 
    { 
        SetPrimaryKey(new CatPrimaryKey(this));
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(CatBase)];

    public override object? As(Type type)
    {
        if(type == typeof(CatProjection) || type == typeof(ICat))
        {
            return AsCatProjection;
        }
        if(type == typeof(CatForListingProjection) || type == typeof(ICatForListing))
        {
            return AsCatForListingProjection;
        }
        if(type == typeof(CatAsParentProjection) || type == typeof(ICatAsParent))
        {
            return AsCatAsParentProjection;
        }
        if(type == typeof(CatForViewProjection) || type == typeof(ICatForView))
        {
            return AsCatForViewProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetCatteryValue(PocoBase target)
    {
        return ((CatBase)target).Cattery;
    }

    private static void SetCatteryValue(PocoBase target, object? value)
    {
        ((CatBase)target).Cattery = (CatteryBase)value!;
    }
    private static object? GetNameNatValue(PocoBase target)
    {
        return ((CatBase)target).NameNat;
    }

    private static void SetNameNatValue(PocoBase target, object? value)
    {
        ((CatBase)target).NameNat = (String)value!;
    }
    private static object? GetNameEngValue(PocoBase target)
    {
        return ((CatBase)target).NameEng;
    }

    private static void SetNameEngValue(PocoBase target, object? value)
    {
        ((CatBase)target).NameEng = (String)value!;
    }
    private static object? GetGenderValue(PocoBase target)
    {
        return ((CatBase)target).Gender;
    }

    private static void SetGenderValue(PocoBase target, object? value)
    {
        ((CatBase)target).Gender = (Gender)value!;
    }
    private static object? GetBreedValue(PocoBase target)
    {
        return ((CatBase)target).Breed;
    }

    private static void SetBreedValue(PocoBase target, object? value)
    {
        ((CatBase)target).Breed = (BreedBase)value!;
    }
    private static object? GetLitterValue(PocoBase target)
    {
        return ((CatBase)target).Litter;
    }

    private static void SetLitterValue(PocoBase target, object? value)
    {
        ((CatBase)target).Litter = (LitterBase)value!;
    }
    private static object? GetExteriorValue(PocoBase target)
    {
        return ((CatBase)target).Exterior;
    }

    private static void SetExteriorValue(PocoBase target, object? value)
    {
        ((CatBase)target).Exterior = (String)value!;
    }
    private static object? GetDescriptionValue(PocoBase target)
    {
        return ((CatBase)target).Description;
    }

    private static void SetDescriptionValue(PocoBase target, object? value)
    {
        ((CatBase)target).Description = (String)value!;
    }
    private static object? GetTitleValue(PocoBase target)
    {
        return ((CatBase)target).Title;
    }

    private static void SetTitleValue(PocoBase target, object? value)
    {
        ((CatBase)target).Title = (String)value!;
    }
    private static object? GetLittersValue(PocoBase target)
    {
        return ((CatBase)target).Litters;
    }


    #endregion Properties accessors;


}