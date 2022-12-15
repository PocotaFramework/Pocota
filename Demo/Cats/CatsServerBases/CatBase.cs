

//------------------------------
// Server implementation
// CatsCommon.Model.CatBase
// (Generated automatically 2022-12-15T18:56:29)
//------------------------------

using CatsCommon;
    using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using System;
    using System.Collections.Generic;
    
namespace CatsCommon.Model;

public abstract class CatBase: EntityBase, IProjector
{

    #region Projection classes;


    public class CatProjection: ICat, IProjector, IProjection<CatBase>
    {
        private readonly ProjectionList<LitterBase,ILitter> _litters;

        public CatBase Projector  { get; init; }

        public String? NameNat 
        {
            get => Projector.NameNat;
            set => Projector.NameNat = value;
        }

        public String? NameEng 
        {
            get => Projector.NameEng;
            set => Projector.NameEng = value;
        }

        public Gender Gender 
        {
            get => Projector.Gender;
            set => Projector.Gender = value;
        }

        public ICattery Cattery 
        {
            get => Projector.Cattery.As<ICattery>();
            set => Projector.Cattery = (CatteryBase)value;
        }

        public IBreed Breed 
        {
            get => Projector.Breed.As<IBreed>();
            set => Projector.Breed = (BreedBase)value;
        }

        public ILitter? Litter 
        {
            get => Projector.Litter?.As<ILitter>();
            set => Projector.Litter = (LitterBase?)value;
        }

        public String? Exterior 
        {
            get => Projector.Exterior;
            set => Projector.Exterior = value;
        }

        public String? Description 
        {
            get => Projector.Description;
            set => Projector.Description = value;
        }

        public String? Title 
        {
            get => Projector.Title;
            set => Projector.Title = value;
        }

        public IList<ILitter> Litters 
        {
            get => _litters;
        }


        internal CatProjection(CatBase projector)
        {
            Projector = projector;
            _litters = new(Projector.Litters);
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

    public class CatForListingProjection: ICatForListing, IProjector, IProjection<CatBase>
    {

        public CatBase Projector  { get; init; }

        public String? NameNat 
        {
            get => Projector.NameNat;
        }

        public String? NameEng 
        {
            get => Projector.NameEng;
        }

        public Gender Gender 
        {
            get => Projector.Gender;
        }

        public ICattery Cattery 
        {
            get => Projector.Cattery.As<ICattery>();
        }

        public IBreed Breed 
        {
            get => Projector.Breed.As<IBreed>();
        }

        public ILitterForCat? Litter 
        {
            get => Projector.Litter?.As<ILitterForCat>();
        }

        public String? Exterior 
        {
            get => Projector.Exterior;
        }

        public String? Description 
        {
            get => Projector.Description;
        }

        public String? Title 
        {
            get => Projector.Title;
        }


        internal CatForListingProjection(CatBase projector)
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

    public class CatAsParentProjection: ICatAsParent, IProjector, IProjection<CatBase>
    {

        public CatBase Projector  { get; init; }

        public String? NameNat 
        {
            get => Projector.NameNat;
        }

        public String? NameEng 
        {
            get => Projector.NameEng;
        }

        public ICattery Cattery 
        {
            get => Projector.Cattery.As<ICattery>();
        }

        public IBreed Breed 
        {
            get => Projector.Breed.As<IBreed>();
        }

        public ILitterForDate? Litter 
        {
            get => Projector.Litter?.As<ILitterForDate>();
        }

        public String? Exterior 
        {
            get => Projector.Exterior;
        }

        public String? Title 
        {
            get => Projector.Title;
        }


        internal CatAsParentProjection(CatBase projector)
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

    public class CatForViewProjection: ICatForView, IProjector, IProjection<CatBase>
    {
        private readonly ProjectionList<LitterBase,ILitterForCat> _litters;

        public CatBase Projector  { get; init; }

        public String? NameNat 
        {
            get => Projector.NameNat;
        }

        public String? NameEng 
        {
            get => Projector.NameEng;
        }

        public Gender Gender 
        {
            get => Projector.Gender;
        }

        public ICattery Cattery 
        {
            get => Projector.Cattery.As<ICattery>();
        }

        public IBreed Breed 
        {
            get => Projector.Breed.As<IBreed>();
        }

        public ILitterForCat? Litter 
        {
            get => Projector.Litter?.As<ILitterForCat>();
        }

        public String? Exterior 
        {
            get => Projector.Exterior;
        }

        public String? Description 
        {
            get => Projector.Description;
        }

        public String? Title 
        {
            get => Projector.Title;
        }

        public IList<ILitterForCat> Litters 
        {
            get => _litters;
        }


        internal CatForViewProjection(CatBase projector)
        {
            Projector = projector;
            _litters = new(Projector.Litters);
        }

        public I As<I>()
        {
            return (I)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }

        public IList<ILitterForCat> test(IList<ICat> cats)
        {
            object? result = Projector.test(cats);
            return (IList<ILitterForCat>)result;
        }



    }
    #endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(CatBase), new Properties<PocoBase>());
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


    
    
    private String? NameNat { get; set; } = default;
    private String? NameEng { get; set; } = default;
    private Gender Gender { get; set; } = default!;
    private CatteryBase Cattery { get; set; } = default!;
    private BreedBase Breed { get; set; } = default!;
    private LitterBase? Litter { get; set; } = default;
    private String? Exterior { get; set; } = default;
    private String? Description { get; set; } = default;
    private String? Title { get; set; } = default;
    private List<LitterBase> Litters { get; init; } = new();


    
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

    public abstract IList<ILitterForCat> test(IList<ICat> cats);



    
    #region Properties accessors;

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
    private static object? GetCatteryValue(PocoBase target)
    {
        return ((CatBase)target).Cattery;
    }

    private static void SetCatteryValue(PocoBase target, object? value)
    {
        ((CatBase)target).Cattery = (CatteryBase)value!;
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