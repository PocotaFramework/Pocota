/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.CatFilterPoco                        //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Filters;

public class CatFilterPoco: EnvelopeBase, IProjector
{
    

    #region Projection classes;


    public class CatFilterICatFilterProjection: ICatFilter, IProjector, IProjection<CatFilterPoco>
    {

        public CatFilterPoco Projector  { get; init; }

        public IBreed? Breed 
        {
            get => ((IProjector?)Projector.Breed)?.As<IBreed>();
            set => Projector.Breed = (BreedPoco?)value;
        }

        public ICattery? Cattery 
        {
            get => ((IProjector?)Projector.Cattery)?.As<ICattery>();
            set => Projector.Cattery = (CatteryPoco?)value;
        }

        public DateOnly? BornAfter 
        {
            get => Projector.BornAfter;
            set => Projector.BornAfter = value;
        }

        public DateOnly? BornBefore 
        {
            get => Projector.BornBefore;
            set => Projector.BornBefore = value;
        }

        public String? NameRegex 
        {
            get => Projector.NameRegex;
            set => Projector.NameRegex = value;
        }

        public Gender? Gender 
        {
            get => Projector.Gender;
            set => Projector.Gender = value;
        }

        public ICat? Child 
        {
            get => ((IProjector?)Projector.Child)?.As<ICat>();
            set => Projector.Child = (CatPoco?)value;
        }

        public ICat? Self 
        {
            get => ((IProjector?)Projector.Self)?.As<ICat>();
            set => Projector.Self = (CatPoco?)value;
        }

        public ICat? Mother 
        {
            get => ((IProjector?)Projector.Mother)?.As<ICat>();
            set => Projector.Mother = (CatPoco?)value;
        }

        public ICat? Father 
        {
            get => ((IProjector?)Projector.Father)?.As<ICat>();
            set => Projector.Father = (CatPoco?)value;
        }

        public ICat? Ancestor 
        {
            get => ((IProjector?)Projector.Ancestor)?.As<ICat>();
            set => Projector.Ancestor = (CatPoco?)value;
        }

        public ICat? Descendant 
        {
            get => ((IProjector?)Projector.Descendant)?.As<ICat>();
            set => Projector.Descendant = (CatPoco?)value;
        }

        public ILitter? Litter 
        {
            get => ((IProjector?)Projector.Litter)?.As<ILitter>();
            set => Projector.Litter = (LitterPoco?)value;
        }

        public String? ExteriorRegex 
        {
            get => Projector.ExteriorRegex;
            set => Projector.ExteriorRegex = value;
        }

        public String? TitleRegex 
        {
            get => Projector.TitleRegex;
            set => Projector.TitleRegex = value;
        }


        internal CatFilterICatFilterProjection(CatFilterPoco projector)
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
        Properties.Add(typeof(CatFilterPoco), new Properties<PocoBase>());
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "Breed", 
                typeof(BreedPoco),
                GetBreedValue, 
                SetBreedValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, IBreed>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "Cattery", 
                typeof(CatteryPoco),
                GetCatteryValue, 
                SetCatteryValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICattery>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "BornAfter", 
                typeof(DateOnly),
                GetBornAfterValue, 
                SetBornAfterValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, DateOnly>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "BornBefore", 
                typeof(DateOnly),
                GetBornBeforeValue, 
                SetBornBeforeValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, DateOnly>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "NameRegex", 
                typeof(String),
                GetNameRegexValue, 
                SetNameRegexValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, String>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "Gender", 
                typeof(Gender),
                GetGenderValue, 
                SetGenderValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, Gender>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "Child", 
                typeof(CatPoco),
                GetChildValue, 
                SetChildValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "Self", 
                typeof(CatPoco),
                GetSelfValue, 
                SetSelfValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "Mother", 
                typeof(CatPoco),
                GetMotherValue, 
                SetMotherValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "Father", 
                typeof(CatPoco),
                GetFatherValue, 
                SetFatherValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "Ancestor", 
                typeof(CatPoco),
                GetAncestorValue, 
                SetAncestorValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "Descendant", 
                typeof(CatPoco),
                GetDescendantValue, 
                SetDescendantValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, ICat>()
        );
        Properties[typeof(CatFilterPoco)].Add(
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
            .AddPropertyType<ICatFilter, ILitter>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "ExteriorRegex", 
                typeof(String),
                GetExteriorRegexValue, 
                SetExteriorRegexValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, String>()
        );
        Properties[typeof(CatFilterPoco)].Add(
                new Property<PocoBase>(
                "TitleRegex", 
                typeof(String),
                GetTitleRegexValue, 
                SetTitleRegexValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ICatFilter, String>()
        );
    }


    
    private CatFilterICatFilterProjection? _asCatFilterICatFilterProjection = null;

    public CatFilterICatFilterProjection AsCatFilterICatFilterProjection => _asCatFilterICatFilterProjection ??= new(this);


    
    
    public BreedPoco? Breed { get; set; } = default;
    public CatteryPoco? Cattery { get; set; } = default;
    public DateOnly? BornAfter { get; set; } = default;
    public DateOnly? BornBefore { get; set; } = default;
    public String? NameRegex { get; set; } = default;
    public Gender? Gender { get; set; } = default;
    public CatPoco? Child { get; set; } = default;
    public CatPoco? Self { get; set; } = default;
    public CatPoco? Mother { get; set; } = default;
    public CatPoco? Father { get; set; } = default;
    public CatPoco? Ancestor { get; set; } = default;
    public CatPoco? Descendant { get; set; } = default;
    public LitterPoco? Litter { get; set; } = default;
    public String? ExteriorRegex { get; set; } = default;
    public String? TitleRegex { get; set; } = default;


    public CatFilterPoco(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(CatFilterPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(CatFilterICatFilterProjection) || type == typeof(ICatFilter))
        {
            return AsCatFilterICatFilterProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetBreedValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Breed;
    }

    private static void SetBreedValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Breed = (BreedPoco)value!;
    }
    private static object? GetCatteryValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Cattery;
    }

    private static void SetCatteryValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Cattery = (CatteryPoco)value!;
    }
    private static object? GetBornAfterValue(PocoBase target)
    {
        return ((CatFilterPoco)target).BornAfter;
    }

    private static void SetBornAfterValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).BornAfter = (DateOnly)value!;
    }
    private static object? GetBornBeforeValue(PocoBase target)
    {
        return ((CatFilterPoco)target).BornBefore;
    }

    private static void SetBornBeforeValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).BornBefore = (DateOnly)value!;
    }
    private static object? GetNameRegexValue(PocoBase target)
    {
        return ((CatFilterPoco)target).NameRegex;
    }

    private static void SetNameRegexValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).NameRegex = (String)value!;
    }
    private static object? GetGenderValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Gender;
    }

    private static void SetGenderValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Gender = (Gender)value!;
    }
    private static object? GetChildValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Child;
    }

    private static void SetChildValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Child = (CatPoco)value!;
    }
    private static object? GetSelfValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Self;
    }

    private static void SetSelfValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Self = (CatPoco)value!;
    }
    private static object? GetMotherValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Mother;
    }

    private static void SetMotherValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Mother = (CatPoco)value!;
    }
    private static object? GetFatherValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Father;
    }

    private static void SetFatherValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Father = (CatPoco)value!;
    }
    private static object? GetAncestorValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Ancestor;
    }

    private static void SetAncestorValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Ancestor = (CatPoco)value!;
    }
    private static object? GetDescendantValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Descendant;
    }

    private static void SetDescendantValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Descendant = (CatPoco)value!;
    }
    private static object? GetLitterValue(PocoBase target)
    {
        return ((CatFilterPoco)target).Litter;
    }

    private static void SetLitterValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).Litter = (LitterPoco)value!;
    }
    private static object? GetExteriorRegexValue(PocoBase target)
    {
        return ((CatFilterPoco)target).ExteriorRegex;
    }

    private static void SetExteriorRegexValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).ExteriorRegex = (String)value!;
    }
    private static object? GetTitleRegexValue(PocoBase target)
    {
        return ((CatFilterPoco)target).TitleRegex;
    }

    private static void SetTitleRegexValue(PocoBase target, object? value)
    {
        ((CatFilterPoco)target).TitleRegex = (String)value!;
    }

    #endregion Properties accessors;


}