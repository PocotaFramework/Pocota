/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.LitterPoco                             //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-20T14:53:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;

namespace CatsCommon.Model;

public class LitterPoco: EntityBase, IProjector
{
    public static readonly Type PrimaryKeyType = typeof(LitterPrimaryKey);
    

    #region Projection classes;


    public class LitterILitterProjection: ILitter, IProjector, IProjection<LitterPoco>
    {
        private readonly ProjectionList<CatPoco,ICat> _cats;

        public LitterPoco Projector  { get; init; }

        public Int32 Order 
        {
            get => Projector.Order!;
            set => Projector.Order = value;
        }

        public ICat Female 
        {
            get => ((IProjector)Projector.Female).As<ICat>()!;
            set => Projector.Female = (CatPoco)value;
        }

        public DateOnly Date 
        {
            get => Projector.Date!;
            set => Projector.Date = value;
        }

        public ICat? Male 
        {
            get => ((IProjector?)Projector.Male)?.As<ICat>();
            set => Projector.Male = (CatPoco?)value;
        }

        public IList<ICat> Cats 
        {
            get => _cats;
        }

        public IList<String> Strings 
        {
            get => Projector.Strings!;
        }


        internal LitterILitterProjection(LitterPoco projector)
        {
            Projector = projector;
            _cats = new(Projector.Cats);
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

    public class LitterILitterForCatProjection: ILitterForCat, IProjector, IProjection<LitterPoco>
    {

        public LitterPoco Projector  { get; init; }

        public Int32 Order 
        {
            get => Projector.Order!;
        }

        public ICatAsParent Female 
        {
            get => ((IProjector)Projector.Female).As<ICatAsParent>()!;
        }

        public DateOnly Date 
        {
            get => Projector.Date!;
        }

        public ICatAsParent? Male 
        {
            get => ((IProjector?)Projector.Male)?.As<ICatAsParent>();
        }


        internal LitterILitterForCatProjection(LitterPoco projector)
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

    public class LitterILitterForDateProjection: ILitterForDate, IProjector, IProjection<LitterPoco>
    {

        public LitterPoco Projector  { get; init; }

        public DateOnly Date 
        {
            get => Projector.Date!;
        }


        internal LitterILitterForDateProjection(LitterPoco projector)
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

    public class LitterILitterWithCatsProjection: ILitterWithCats, IProjector, IProjection<LitterPoco>
    {
        private readonly ProjectionList<CatPoco,ICatForListing> _cats;

        public LitterPoco Projector  { get; init; }

        public IList<ICatForListing> Cats 
        {
            get => _cats;
        }


        internal LitterILitterWithCatsProjection(LitterPoco projector)
        {
            Projector = projector;
            _cats = new(Projector.Cats);
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
        Properties.Add(typeof(LitterPoco), new Properties<PocoBase>());
        Properties[typeof(LitterPoco)].Add(
                new Property<PocoBase>(
                "Order", 
                typeof(Int32),
                GetOrderValue, 
                SetOrderValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitter, Int32>()
            .AddPropertyType<ILitterForCat, Int32>()
        );
        Properties[typeof(LitterPoco)].Add(
                new Property<PocoBase>(
                "Female", 
                typeof(CatPoco),
                GetFemaleValue, 
                SetFemaleValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitter, ICat>()
            .AddPropertyType<ILitterForCat, ICatAsParent>()
        );
        Properties[typeof(LitterPoco)].Add(
                new Property<PocoBase>(
                "Date", 
                typeof(DateOnly),
                GetDateValue, 
                SetDateValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitter, DateOnly>()
            .AddPropertyType<ILitterForCat, DateOnly>()
            .AddPropertyType<ILitterForDate, DateOnly>()
        );
        Properties[typeof(LitterPoco)].Add(
                new Property<PocoBase>(
                "Male", 
                typeof(CatPoco),
                GetMaleValue, 
                SetMaleValue, 
                null, 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ILitter, ICat>()
            .AddPropertyType<ILitterForCat, ICatAsParent>()
        );
        Properties[typeof(LitterPoco)].Add(
                new Property<PocoBase>(
                "Cats", 
                typeof(List<CatPoco>),
                GetCatsValue, 
                null, 
                null, 
                false, 
                false, 
                true            
            )
            .AddPropertyType<ILitter, IList<ICat>>()
            .AddPropertyType<ILitterWithCats, IList<ICatForListing>>()
        );
        Properties[typeof(LitterPoco)].Add(
                new Property<PocoBase>(
                "Strings", 
                typeof(List<String>),
                GetStringsValue, 
                null, 
                null, 
                false, 
                false, 
                true            
            )
            .AddPropertyType<ILitter, IList<String>>()
        );
    }


    
    private LitterILitterProjection? _asLitterILitterProjection = null;
    private LitterILitterForCatProjection? _asLitterILitterForCatProjection = null;
    private LitterILitterForDateProjection? _asLitterILitterForDateProjection = null;
    private LitterILitterWithCatsProjection? _asLitterILitterWithCatsProjection = null;

    public LitterILitterProjection AsLitterILitterProjection => _asLitterILitterProjection ??= new(this);
    public LitterILitterForCatProjection AsLitterILitterForCatProjection => _asLitterILitterForCatProjection ??= new(this);
    public LitterILitterForDateProjection AsLitterILitterForDateProjection => _asLitterILitterForDateProjection ??= new(this);
    public LitterILitterWithCatsProjection AsLitterILitterWithCatsProjection => _asLitterILitterWithCatsProjection ??= new(this);


    
    
    public Int32 Order { get; set; } = default!;
    public CatPoco Female { get; set; } = default!;
    public DateOnly Date { get; set; } = default!;
    public CatPoco? Male { get; set; } = default;
    public List<CatPoco> Cats { get; init; } = new();
    public List<String> Strings { get; init; } = new();


    public LitterPoco(IServiceProvider services) : base(services) 
    { 
        SetPrimaryKey(new LitterPrimaryKey(this));
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(LitterPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(LitterILitterProjection) || type == typeof(ILitter))
        {
            return AsLitterILitterProjection;
        }
        if(type == typeof(LitterILitterForCatProjection) || type == typeof(ILitterForCat))
        {
            return AsLitterILitterForCatProjection;
        }
        if(type == typeof(LitterILitterForDateProjection) || type == typeof(ILitterForDate))
        {
            return AsLitterILitterForDateProjection;
        }
        if(type == typeof(LitterILitterWithCatsProjection) || type == typeof(ILitterWithCats))
        {
            return AsLitterILitterWithCatsProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetOrderValue(PocoBase target)
    {
        return ((LitterPoco)target).Order;
    }

    private static void SetOrderValue(PocoBase target, object? value)
    {
        ((LitterPoco)target).Order = (Int32)value!;
    }
    private static object? GetFemaleValue(PocoBase target)
    {
        return ((LitterPoco)target).Female;
    }

    private static void SetFemaleValue(PocoBase target, object? value)
    {
        ((LitterPoco)target).Female = (CatPoco)value!;
    }
    private static object? GetDateValue(PocoBase target)
    {
        return ((LitterPoco)target).Date;
    }

    private static void SetDateValue(PocoBase target, object? value)
    {
        ((LitterPoco)target).Date = (DateOnly)value!;
    }
    private static object? GetMaleValue(PocoBase target)
    {
        return ((LitterPoco)target).Male;
    }

    private static void SetMaleValue(PocoBase target, object? value)
    {
        ((LitterPoco)target).Male = (CatPoco)value!;
    }
    private static object? GetCatsValue(PocoBase target)
    {
        return ((LitterPoco)target).Cats;
    }

    private static object? GetStringsValue(PocoBase target)
    {
        return ((LitterPoco)target).Strings;
    }


    #endregion Properties accessors;


}