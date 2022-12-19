/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.LitterBase                             //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-19T17:40:44                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using Net.Leksi.Pocota.Server;
    using System;
    using System.Collections.Generic;
    
namespace CatsCommon.Model;

public class LitterBase: EntityBase, IProjector, IProjection<LitterBase>
{

    #region Projection classes;


    [Poco(typeof(ILitter))]
    public class LitterProjection: ILitter, IProjector, IProjection<LitterBase>
    {
        private readonly ProjectionList<CatBase,ICat> _cats;

        public  LitterBase Projection  { get; init; }

        public virtual Int32 Order 
        {
            get => Projection.Order!;
            set => Projection.Order = value;
        }

        public virtual ICat Female 
        {
            get => Projection.Female!;
            set => Projection.Female = value;
        }

        public virtual DateOnly Date 
        {
            get => Projection.Date!;
            set => Projection.Date = value;
        }

        public virtual ICat? Male 
        {
            get => Projection.Male;
            set => Projection.Male = value;
        }

        public virtual IList<ICat> Cats 
        {
            get => _cats;
        }

        public virtual IList<String> Strings 
        {
            get => Projection.Strings!;
        }


        internal LitterProjection(LitterBase source)
        {
            Projection = source;
            _cats = new(Projection.Cats);
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

    [Poco(typeof(ILitterForCat))]
    public class LitterForCatProjection: ILitterForCat, IProjector, IProjection<LitterBase>
    {

        public  LitterBase Projection  { get; init; }

        public virtual Int32 Order 
        {
            get => Projection.Order!;
        }

        public virtual ICatAsParent Female 
        {
            get => Projection.Female!;
        }

        public virtual DateOnly Date 
        {
            get => Projection.Date!;
        }

        public virtual ICatAsParent? Male 
        {
            get => Projection.Male;
        }


        internal LitterForCatProjection(LitterBase source)
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

    [Poco(typeof(ILitterForDate))]
    public class LitterForDateProjection: ILitterForDate, IProjector, IProjection<LitterBase>
    {

        public  LitterBase Projection  { get; init; }

        public virtual DateOnly Date 
        {
            get => Projection.Date!;
        }


        internal LitterForDateProjection(LitterBase source)
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

    [Poco(typeof(ILitterWithCats))]
    public class LitterWithCatsProjection: ILitterWithCats, IProjector, IProjection<LitterBase>
    {
        private readonly ProjectionList<CatBase,ICatForListing> _cats;

        public  LitterBase Projection  { get; init; }

        public virtual IList<ICatForListing> Cats 
        {
            get => _cats;
        }


        internal LitterWithCatsProjection(LitterBase source)
        {
            Projection = source;
            _cats = new(Projection.Cats);
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
        Properties.Add(typeof(LitterBase), new Properties<PocoBase>());
        Properties[typeof(LitterBase)].Add(
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
        Properties[typeof(LitterBase)].Add(
                new Property<PocoBase>(
                "Female", 
                typeof(CatBase),
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
        Properties[typeof(LitterBase)].Add(
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
        Properties[typeof(LitterBase)].Add(
                new Property<PocoBase>(
                "Male", 
                typeof(CatBase),
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
        Properties[typeof(LitterBase)].Add(
                new Property<PocoBase>(
                "Cats", 
                typeof(List<CatBase>),
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
        Properties[typeof(LitterBase)].Add(
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


    
    private LitterProjection? _asLitterProjection = null;
    private LitterForCatProjection? _asLitterForCatProjection = null;
    private LitterForDateProjection? _asLitterForDateProjection = null;
    private LitterWithCatsProjection? _asLitterWithCatsProjection = null;

    public LitterProjection AsLitterProjection => _asLitterProjection ??= new(this);
    public LitterForCatProjection AsLitterForCatProjection => _asLitterForCatProjection ??= new(this);
    public LitterForDateProjection AsLitterForDateProjection => _asLitterForDateProjection ??= new(this);
    public LitterWithCatsProjection AsLitterWithCatsProjection => _asLitterWithCatsProjection ??= new(this);


    
    public LitterBase Projection { get => this; }

    
    public Int32        Order  { get; set; } = default!;            
    public CatBase        Female  { get; set; } = default!;            
    public DateOnly        Date  { get; set; } = default!;            
    public CatBase?        Male  { get; set; } = default;            
    public List<CatBase>        Cats  { get; init; } = new();            
    public List<String>        Strings  { get; init; } = new();            


    public LitterBase(IServiceProvider services) : base(services) 
    { 
        SetPrimaryKey(new LitterPrimaryKey(this));
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(LitterBase)];

    public override object? As(Type type)
    {
        if(type == typeof(LitterProjection) || type == typeof(ILitter))
        {
            return AsLitterProjection;
        }
        if(type == typeof(LitterForCatProjection) || type == typeof(ILitterForCat))
        {
            return AsLitterForCatProjection;
        }
        if(type == typeof(LitterForDateProjection) || type == typeof(ILitterForDate))
        {
            return AsLitterForDateProjection;
        }
        if(type == typeof(LitterWithCatsProjection) || type == typeof(ILitterWithCats))
        {
            return AsLitterWithCatsProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetOrderValue(PocoBase target)
    {
        return ((LitterBase)target).Order;
    }

    private static void SetOrderValue(PocoBase target, object? value)
    {
        ((LitterBase)target).Order = (Int32)value!;
    }
    private static object? GetFemaleValue(PocoBase target)
    {
        return ((LitterBase)target).Female;
    }

    private static void SetFemaleValue(PocoBase target, object? value)
    {
        ((LitterBase)target).Female = (CatBase)value!;
    }
    private static object? GetDateValue(PocoBase target)
    {
        return ((LitterBase)target).Date;
    }

    private static void SetDateValue(PocoBase target, object? value)
    {
        ((LitterBase)target).Date = (DateOnly)value!;
    }
    private static object? GetMaleValue(PocoBase target)
    {
        return ((LitterBase)target).Male;
    }

    private static void SetMaleValue(PocoBase target, object? value)
    {
        ((LitterBase)target).Male = (CatBase)value!;
    }
    private static object? GetCatsValue(PocoBase target)
    {
        return ((LitterBase)target).Cats;
    }

    private static object? GetStringsValue(PocoBase target)
    {
        return ((LitterBase)target).Strings;
    }


    #endregion Properties accessors;


}