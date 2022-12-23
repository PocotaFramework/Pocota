/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.LitterPoco                             //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-23T18:45:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;

namespace CatsCommon.Model;

public class LitterPoco: EntityBase, IPoco, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
{
    public static readonly Type PrimaryKeyType = typeof(LitterPrimaryKey);
    

#region Projection classes


    public class LitterILitterProjection: ILitter, IPoco, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {
        private readonly ProjectionList<CatPoco,ICat> _cats;

        public IProjection Projector { get; init; }


        public Int32 Order 
        {
            get => ((LitterPoco)Projector).Order!;
            set => ((LitterPoco)Projector).Order = value;
        }

        public ICat Female 
        {
            get => ((IProjection)((LitterPoco)Projector).Female).As<ICat>()!;
            set => ((LitterPoco)Projector).Female = (CatPoco)value;
        }

        public DateOnly Date 
        {
            get => ((LitterPoco)Projector).Date!;
            set => ((LitterPoco)Projector).Date = value;
        }

        public ICat? Male 
        {
            get => ((IProjection?)((LitterPoco)Projector).Male)?.As<ICat>();
            set => ((LitterPoco)Projector).Male = (CatPoco?)value;
        }

        public IList<ICat> Cats 
        {
            get => _cats;
        }

        public IList<String> Strings 
        {
            get => ((LitterPoco)Projector).Strings!;
        }


        internal LitterILitterProjection(IProjection projector)
        {
            Projector = projector;
            _cats = new(((LitterPoco)Projector).Cats);
        }

        public I? As<I>() where I : class
        {
            return (I?)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }


        public override bool Equals(object? obj)
        {
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(Projector, other.Projector);
        }

        public override int GetHashCode()
        {
            return Projector.GetHashCode();
        }

        bool IPoco.IsLoaded(Type @interface)
        {
            return ((IPoco)Projector).IsLoaded(@interface);
        }

        bool IPoco.IsLoaded<T>()
        {
            return ((IPoco)Projector).IsLoaded<T>();
        }

        void IPoco.TouchProperty(string property)
        {
            ((IPoco)Projector).TouchProperty(property);
        }

        void IPoco.Clear()
        {
            ((IPoco)Projector).Clear();
        }

        bool IPoco.IsPropertySet(string property)
        {
            return ((IPoco)Projector).IsPropertySet(property);
        }




        

    }

    public class LitterILitterForCatProjection: ILitterForCat, IPoco, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {

        public IProjection Projector { get; init; }


        public Int32 Order 
        {
            get => ((LitterPoco)Projector).Order!;
        }

        public ICatAsParent Female 
        {
            get => ((IProjection)((LitterPoco)Projector).Female).As<ICatAsParent>()!;
        }

        public DateOnly Date 
        {
            get => ((LitterPoco)Projector).Date!;
        }

        public ICatAsParent? Male 
        {
            get => ((IProjection?)((LitterPoco)Projector).Male)?.As<ICatAsParent>();
        }


        internal LitterILitterForCatProjection(IProjection projector)
        {
            Projector = projector;
        }

        public I? As<I>() where I : class
        {
            return (I?)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }


        public override bool Equals(object? obj)
        {
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(Projector, other.Projector);
        }

        public override int GetHashCode()
        {
            return Projector.GetHashCode();
        }

        bool IPoco.IsLoaded(Type @interface)
        {
            return ((IPoco)Projector).IsLoaded(@interface);
        }

        bool IPoco.IsLoaded<T>()
        {
            return ((IPoco)Projector).IsLoaded<T>();
        }

        void IPoco.TouchProperty(string property)
        {
            ((IPoco)Projector).TouchProperty(property);
        }

        void IPoco.Clear()
        {
            ((IPoco)Projector).Clear();
        }

        bool IPoco.IsPropertySet(string property)
        {
            return ((IPoco)Projector).IsPropertySet(property);
        }




        

    }

    public class LitterILitterForDateProjection: ILitterForDate, IPoco, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {

        public IProjection Projector { get; init; }


        public DateOnly Date 
        {
            get => ((LitterPoco)Projector).Date!;
        }


        internal LitterILitterForDateProjection(IProjection projector)
        {
            Projector = projector;
        }

        public I? As<I>() where I : class
        {
            return (I?)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }


        public override bool Equals(object? obj)
        {
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(Projector, other.Projector);
        }

        public override int GetHashCode()
        {
            return Projector.GetHashCode();
        }

        bool IPoco.IsLoaded(Type @interface)
        {
            return ((IPoco)Projector).IsLoaded(@interface);
        }

        bool IPoco.IsLoaded<T>()
        {
            return ((IPoco)Projector).IsLoaded<T>();
        }

        void IPoco.TouchProperty(string property)
        {
            ((IPoco)Projector).TouchProperty(property);
        }

        void IPoco.Clear()
        {
            ((IPoco)Projector).Clear();
        }

        bool IPoco.IsPropertySet(string property)
        {
            return ((IPoco)Projector).IsPropertySet(property);
        }




        

    }

    public class LitterILitterWithCatsProjection: ILitterWithCats, IPoco, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {
        private readonly ProjectionList<CatPoco,ICatForListing> _cats;

        public IProjection Projector { get; init; }


        public IList<ICatForListing> Cats 
        {
            get => _cats;
        }


        internal LitterILitterWithCatsProjection(IProjection projector)
        {
            Projector = projector;
            _cats = new(((LitterPoco)Projector).Cats);
        }

        public I? As<I>() where I : class
        {
            return (I?)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }


        public override bool Equals(object? obj)
        {
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(Projector, other.Projector);
        }

        public override int GetHashCode()
        {
            return Projector.GetHashCode();
        }

        bool IPoco.IsLoaded(Type @interface)
        {
            return ((IPoco)Projector).IsLoaded(@interface);
        }

        bool IPoco.IsLoaded<T>()
        {
            return ((IPoco)Projector).IsLoaded<T>();
        }

        void IPoco.TouchProperty(string property)
        {
            ((IPoco)Projector).TouchProperty(property);
        }

        void IPoco.Clear()
        {
            ((IPoco)Projector).Clear();
        }

        bool IPoco.IsPropertySet(string property)
        {
            return ((IPoco)Projector).IsPropertySet(property);
        }




        

    }
#endregion Projection classes

    
#region Init Properties
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
                new Property(
                "Order", 
                typeof(Int32),
                GetOrderValue, 
                SetOrderValue, 
                target => ((IPoco)target).TouchProperty("Order"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitter, Int32>()
            .AddPropertyType<ILitterForCat, Int32>()
        );
        properties.Add(
                new Property(
                "Female", 
                typeof(CatPoco),
                GetFemaleValue, 
                SetFemaleValue, 
                target => ((IPoco)target).TouchProperty("Female"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitter, ICat>()
            .AddPropertyType<ILitterForCat, ICatAsParent>()
        );
        properties.Add(
                new Property(
                "Date", 
                typeof(DateOnly),
                GetDateValue, 
                SetDateValue, 
                target => ((IPoco)target).TouchProperty("Date"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitter, DateOnly>()
            .AddPropertyType<ILitterForCat, DateOnly>()
            .AddPropertyType<ILitterForDate, DateOnly>()
        );
        properties.Add(
                new Property(
                "Male", 
                typeof(CatPoco),
                GetMaleValue, 
                SetMaleValue, 
                target => ((IPoco)target).TouchProperty("Male"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<ILitter, ICat>()
            .AddPropertyType<ILitterForCat, ICatAsParent>()
        );
        properties.Add(
                new Property(
                "Cats", 
                typeof(List<CatPoco>),
                GetCatsValue, 
                null, 
                target => ((IPoco)target).TouchProperty("Cats"), 
                false, 
                false, 
                true            
            )
            .AddPropertyType<ILitter, IList<ICat>>()
            .AddPropertyType<ILitterWithCats, IList<ICatForListing>>()
        );
        properties.Add(
                new Property(
                "Strings", 
                typeof(List<String>),
                GetStringsValue, 
                null, 
                target => ((IPoco)target).TouchProperty("Strings"), 
                false, 
                false, 
                true            
            )
            .AddPropertyType<ILitter, IList<String>>()
        );
    }
#endregion Init Properties;


    
#region Fields

    private Int32 _order = default!;
    private bool _loaded_order = false;
    private CatPoco _female = default!;
    private bool _loaded_female = false;
    private DateOnly _date = default!;
    private bool _loaded_date = false;
    private CatPoco? _male = default;
    private bool _loaded_male = false;
    private readonly List<CatPoco> _cats = new();
    private bool _loaded_cats = false;
    private List<String> _strings = default!;
    private bool _loaded_strings = false;

#endregion Fields;

    
    
#region Projection Properties

    private LitterILitterProjection? _asLitterILitterProjection = null;
    private LitterILitterForCatProjection? _asLitterILitterForCatProjection = null;
    private LitterILitterForDateProjection? _asLitterILitterForDateProjection = null;
    private LitterILitterWithCatsProjection? _asLitterILitterWithCatsProjection = null;

    private LitterILitterProjection AsLitterILitterProjection => _asLitterILitterProjection ??= new(this);
    private LitterILitterForCatProjection AsLitterILitterForCatProjection => _asLitterILitterForCatProjection ??= new(this);
    private LitterILitterForDateProjection AsLitterILitterForDateProjection => _asLitterILitterForDateProjection ??= new(this);
    private LitterILitterWithCatsProjection AsLitterILitterWithCatsProjection => _asLitterILitterWithCatsProjection ??= new(this);

#endregion Projection Properties;

    
    
#region Properties

    public IProjection Projector => this;

    public Int32 Order 
    { 
        get => _order; 
        set
        {
            _order = value;
            _loaded_order = true;
        }
    }

    public CatPoco Female 
    { 
        get => _female; 
        set
        {
            _female = value;
            _loaded_female = true;
        }
    }

    public DateOnly Date 
    { 
        get => _date; 
        set
        {
            _date = value;
            _loaded_date = true;
        }
    }

    public CatPoco? Male 
    { 
        get => _male; 
        set
        {
            _male = value;
            _loaded_male = true;
        }
    }

    public List<CatPoco> Cats 
    { 
        get => _cats; 
    }

    public List<String> Strings 
    { 
        get => _strings; 
    }

#endregion Properties;


    public LitterPoco(IServiceProvider services) : base(services) 
    { 
        _primaryKey = new LitterPrimaryKey(services);
        (_primaryKey as LitterPrimaryKey)!.Source = this;
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ILitter))
        {
            return AsLitterILitterProjection;
        }
        if(type == typeof(LitterPoco))
        {
            return this;
        }
        if(type == typeof(ILitterForCat))
        {
            return AsLitterILitterForCatProjection;
        }
        if(type == typeof(LitterPoco))
        {
            return this;
        }
        if(type == typeof(ILitterForDate))
        {
            return AsLitterILitterForDateProjection;
        }
        if(type == typeof(LitterPoco))
        {
            return this;
        }
        if(type == typeof(ILitterWithCats))
        {
            return AsLitterILitterWithCatsProjection;
        }
        if(type == typeof(LitterPoco))
        {
            return this;
        }
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<LitterPoco> other && object.ReferenceEquals(this, other.Projector);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _loaded_order = false;
        _loaded_female = false;
        _loaded_date = false;
        _loaded_male = false;
        _loaded_cats = false;
        _loaded_strings = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ILitter))
        {
            return _loaded_order
                && _loaded_female
                && _loaded_date
                && _loaded_male
                && _loaded_cats
                && _loaded_strings
            ;
        }
        if(@interface == typeof(ILitterForCat))
        {
            return _loaded_order
                && _loaded_female
                && _loaded_date
                && _loaded_male
            ;
        }
        if(@interface == typeof(ILitterForDate))
        {
            return _loaded_date
            ;
        }
        if(@interface == typeof(ILitterWithCats))
        {
            return _loaded_cats
            ;
        }
        return false;
    }

    bool IPoco.IsLoaded<T>()
    {
        return ((IPoco)this).IsLoaded(typeof(T));
    }

    bool IPoco.IsPropertySet(string property)
    {
        switch(property)
        {
            case "Order":
                return _loaded_order;
            case "Female":
                return _loaded_female;
            case "Date":
                return _loaded_date;
            case "Male":
                return _loaded_male;
            case "Cats":
                return _loaded_cats;
            case "Strings":
                return _loaded_strings;
            default:
                return false;
        }
    }

    void IPoco.TouchProperty(string property)
    {
        switch(property)
        {
            case "Order":
                _loaded_order = true;
                break;
            case "Female":
                _loaded_female = true;
                break;
            case "Date":
                _loaded_date = true;
                break;
            case "Male":
                _loaded_male = true;
                break;
            case "Cats":
                _loaded_cats = true;
                break;
            case "Strings":
                _loaded_strings = true;
                break;
        }
    }

#endregion IPoco;


    
#region Properties Accessors

    private static object? GetOrderValue(object target)
    {
        return ((LitterPoco)target).Order;
    }

    private static void SetOrderValue(object target, object? value)
    {
        ((LitterPoco)target).Order = (Int32)value!;

    }

    private static object? GetFemaleValue(object target)
    {
        return ((LitterPoco)target).Female;
    }

    private static void SetFemaleValue(object target, object? value)
    {
        ((LitterPoco)target).Female = (CatPoco)(value as IProjection)?.Projector!;

    }

    private static object? GetDateValue(object target)
    {
        return ((LitterPoco)target).Date;
    }

    private static void SetDateValue(object target, object? value)
    {
        ((LitterPoco)target).Date = (DateOnly)value!;

    }

    private static object? GetMaleValue(object target)
    {
        return ((LitterPoco)target).Male;
    }

    private static void SetMaleValue(object target, object? value)
    {
        ((LitterPoco)target).Male = (CatPoco)(value as IProjection)?.Projector!;

    }

    private static object? GetCatsValue(object target)
    {
        return ((LitterPoco)target).Cats;
    }


    private static object? GetStringsValue(object target)
    {
        return ((LitterPoco)target).Strings;
    }



#endregion Properties Accessors;


}