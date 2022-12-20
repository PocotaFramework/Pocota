/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatPoco                                //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using Net.Leksi.Pocota;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;

namespace CatsCommon.Model;

public class CatPoco: EntityBase, IProjector
{
    public static readonly Type PrimaryKeyType = typeof(CatPrimaryKey);
    

    #region Projection classes;


    public class CatICatProjection: ICat, IProjector, IProjection<CatPoco>
    {
        private readonly ProjectionList<LitterPoco,ILitter> _litters;

        public CatPoco Projector  { get; init; }

        public ICattery Cattery 
        {
            get => ((IProjector)Projector.Cattery).As<ICattery>()!;
            set => Projector.Cattery = (CatteryPoco)value;
        }

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
            get => Projector.Gender!;
            set => Projector.Gender = value;
        }

        public IBreed Breed 
        {
            get => ((IProjector)Projector.Breed).As<IBreed>()!;
            set => Projector.Breed = (BreedPoco)value;
        }

        public ILitter? Litter 
        {
            get => ((IProjector?)Projector.Litter)?.As<ILitter>();
            set => Projector.Litter = (LitterPoco?)value;
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
            set => throw new NotImplementedException();
        }


        internal CatICatProjection(CatPoco projector)
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

    public class CatICatForListingProjection: ICatForListing, IProjector, IProjection<CatPoco>
    {

        public CatPoco Projector  { get; init; }

        public ICattery Cattery 
        {
            get => ((IProjector)Projector.Cattery).As<ICattery>()!;
        }

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
            get => Projector.Gender!;
        }

        public IBreed Breed 
        {
            get => ((IProjector)Projector.Breed).As<IBreed>()!;
        }

        public ILitterForCat? Litter 
        {
            get => ((IProjector?)Projector.Litter)?.As<ILitterForCat>();
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


        internal CatICatForListingProjection(CatPoco projector)
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

    public class CatICatAsParentProjection: ICatAsParent, IProjector, IProjection<CatPoco>
    {

        public CatPoco Projector  { get; init; }

        public ICattery Cattery 
        {
            get => ((IProjector)Projector.Cattery).As<ICattery>()!;
        }

        public String? NameNat 
        {
            get => Projector.NameNat;
        }

        public String? NameEng 
        {
            get => Projector.NameEng;
        }

        public IBreed Breed 
        {
            get => ((IProjector)Projector.Breed).As<IBreed>()!;
        }

        public ILitterForDate? Litter 
        {
            get => ((IProjector?)Projector.Litter)?.As<ILitterForDate>();
        }

        public String? Exterior 
        {
            get => Projector.Exterior;
        }

        public String? Title 
        {
            get => Projector.Title;
        }


        internal CatICatAsParentProjection(CatPoco projector)
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

    public class CatICatForViewProjection: ICatForView, IProjector, IProjection<CatPoco>
    {
        private readonly ProjectionList<LitterPoco,ILitterForCat> _litters;

        public CatPoco Projector  { get; init; }

        public ICattery Cattery 
        {
            get => ((IProjector)Projector.Cattery).As<ICattery>()!;
        }

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
            get => Projector.Gender!;
        }

        public IBreed Breed 
        {
            get => ((IProjector)Projector.Breed).As<IBreed>()!;
        }

        public ILitterForCat? Litter 
        {
            get => ((IProjector?)Projector.Litter)?.As<ILitterForCat>();
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


        internal CatICatForViewProjection(CatPoco projector)
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
    #endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(CatPoco), new Properties<PocoBase>());
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
                "Cattery", 
                typeof(CatteryPoco),
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
        Properties[typeof(CatPoco)].Add(
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
        Properties[typeof(CatPoco)].Add(
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
        Properties[typeof(CatPoco)].Add(
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
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
                "Breed", 
                typeof(BreedPoco),
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
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
                "Litter", 
                typeof(LitterPoco),
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
        Properties[typeof(CatPoco)].Add(
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
        Properties[typeof(CatPoco)].Add(
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
        Properties[typeof(CatPoco)].Add(
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
        Properties[typeof(CatPoco)].Add(
                new Property<PocoBase>(
                "Litters", 
                typeof(List<LitterPoco>),
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


    
    private CatICatProjection? _asCatICatProjection = null;
    private CatICatForListingProjection? _asCatICatForListingProjection = null;
    private CatICatAsParentProjection? _asCatICatAsParentProjection = null;
    private CatICatForViewProjection? _asCatICatForViewProjection = null;

    public CatICatProjection AsCatICatProjection => _asCatICatProjection ??= new(this);
    public CatICatForListingProjection AsCatICatForListingProjection => _asCatICatForListingProjection ??= new(this);
    public CatICatAsParentProjection AsCatICatAsParentProjection => _asCatICatAsParentProjection ??= new(this);
    public CatICatForViewProjection AsCatICatForViewProjection => _asCatICatForViewProjection ??= new(this);


    
    
    public CatteryPoco Cattery { get; set; } = default!;
    public String? NameNat { get; set; } = default;
    public String? NameEng { get; set; } = default;
    public Gender Gender { get; set; } = default!;
    public BreedPoco Breed { get; set; } = default!;
    public LitterPoco? Litter { get; set; } = default;
    public String? Exterior { get; set; } = default;
    public String? Description { get; set; } = default;
    public String? Title { get; set; } = default;
    public List<LitterPoco> Litters { get; init; } = new();


    public CatPoco(IServiceProvider services) : base(services) 
    { 
        SetPrimaryKey(new CatPrimaryKey(this));
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(CatPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(CatICatProjection) || type == typeof(ICat))
        {
            return AsCatICatProjection;
        }
        if(type == typeof(CatICatForListingProjection) || type == typeof(ICatForListing))
        {
            return AsCatICatForListingProjection;
        }
        if(type == typeof(CatICatAsParentProjection) || type == typeof(ICatAsParent))
        {
            return AsCatICatAsParentProjection;
        }
        if(type == typeof(CatICatForViewProjection) || type == typeof(ICatForView))
        {
            return AsCatICatForViewProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetCatteryValue(PocoBase target)
    {
        return ((CatPoco)target).Cattery;
    }

    private static void SetCatteryValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Cattery = (CatteryPoco)value!;
    }
    private static object? GetNameNatValue(PocoBase target)
    {
        return ((CatPoco)target).NameNat;
    }

    private static void SetNameNatValue(PocoBase target, object? value)
    {
        ((CatPoco)target).NameNat = (String)value!;
    }
    private static object? GetNameEngValue(PocoBase target)
    {
        return ((CatPoco)target).NameEng;
    }

    private static void SetNameEngValue(PocoBase target, object? value)
    {
        ((CatPoco)target).NameEng = (String)value!;
    }
    private static object? GetGenderValue(PocoBase target)
    {
        return ((CatPoco)target).Gender;
    }

    private static void SetGenderValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Gender = (Gender)value!;
    }
    private static object? GetBreedValue(PocoBase target)
    {
        return ((CatPoco)target).Breed;
    }

    private static void SetBreedValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Breed = (BreedPoco)value!;
    }
    private static object? GetLitterValue(PocoBase target)
    {
        return ((CatPoco)target).Litter;
    }

    private static void SetLitterValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Litter = (LitterPoco)value!;
    }
    private static object? GetExteriorValue(PocoBase target)
    {
        return ((CatPoco)target).Exterior;
    }

    private static void SetExteriorValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Exterior = (String)value!;
    }
    private static object? GetDescriptionValue(PocoBase target)
    {
        return ((CatPoco)target).Description;
    }

    private static void SetDescriptionValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Description = (String)value!;
    }
    private static object? GetTitleValue(PocoBase target)
    {
        return ((CatPoco)target).Title;
    }

    private static void SetTitleValue(PocoBase target, object? value)
    {
        ((CatPoco)target).Title = (String)value!;
    }
    private static object? GetLittersValue(PocoBase target)
    {
        return ((CatPoco)target).Litters;
    }


    #endregion Properties accessors;


}