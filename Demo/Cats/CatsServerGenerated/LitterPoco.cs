/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.LitterPoco                             //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-11T18:42:24                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;

namespace CatsCommon.Model;

public class LitterPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
{
    public static readonly Type PrimaryKeyType = typeof(LitterPrimaryKey);
    

#region Projection classes


    public class LitterILitterProjection: ILitter, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "Date", 
                    typeof(DateOnly),
                    GetDateValue, 
                    SetDateValue, 
                    target => ((IPoco)((LitterILitterProjection)target)._projector).TouchProperty("Date"), 
                    false, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Order", 
                    typeof(Int32),
                    GetOrderValue, 
                    SetOrderValue, 
                    target => ((IPoco)((LitterILitterProjection)target)._projector).TouchProperty("Order"), 
                    false, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Female", 
                    typeof(ICat),
                    GetFemaleValue, 
                    SetFemaleValue, 
                    target => ((IPoco)((LitterILitterProjection)target)._projector).TouchProperty("Female"), 
                    false, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Male", 
                    typeof(ICat),
                    GetMaleValue, 
                    SetMaleValue, 
                    target => ((IPoco)((LitterILitterProjection)target)._projector).TouchProperty("Male"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Strings", 
                    typeof(IList<String>),
                    GetStringsValue, 
                    null, 
                    target => ((IPoco)((LitterILitterProjection)target)._projector).TouchProperty("Strings"), 
                    false, 
                    true, 
                    typeof(String)
                )
            );
            properties.Add(
                new Property(
                    "Cats", 
                    typeof(IList<ICat>),
                    GetCatsValue, 
                    null, 
                    target => ((IPoco)((LitterILitterProjection)target)._projector).TouchProperty("Cats"), 
                    false, 
                    true, 
                    typeof(ICat)
                )
            );
        }
#endregion Init Properties;




        private readonly LitterPoco _projector;

        private readonly ProjectionList<CatPoco,ICat> _cats;

       public DateOnly Date 
        {
            get => _projector.Date!;
            set => _projector.Date = (DateOnly)value!;
        }

       public Int32 Order 
        {
            get => _projector.Order!;
            set => _projector.Order = (Int32)value!;
        }

       public ICat Female 
        {
            get => ((IProjection)_projector.Female)?.As<ICat>()!;
            set => _projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
        }

       public ICat? Male 
        {
            get => ((IProjection?)_projector.Male)?.As<ICat>();
            set => _projector.Male = ((IProjection?)value)?.As<CatPoco>();
        }

       public IList<String> Strings 
        {
            get => _projector.Strings!;
        }

       public IList<ICat> Cats 
        {
            get => _cats;
        }


        internal LitterILitterProjection(LitterPoco projector)
        {
            _projector = projector;

            _cats = new(((LitterPoco)_projector).Cats);
        }

        public I? As<I>() where I : class
        {
            return (I?)_projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return _projector.As(type);
        }


        public override bool Equals(object? obj)
        {
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(_projector, other.As<LitterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

        
#region Properties Accessors

        private static object? GetDateValue(object target)
        {
            return ((LitterILitterProjection)target)._projector.Date!;
        }

        private static void SetDateValue(object target, object? value)
        {
             ((LitterILitterProjection)target)._projector.Date = (DateOnly)value!;
        }

        private static object? GetOrderValue(object target)
        {
            return ((LitterILitterProjection)target)._projector.Order!;
        }

        private static void SetOrderValue(object target, object? value)
        {
             ((LitterILitterProjection)target)._projector.Order = (Int32)value!;
        }

        private static object? GetFemaleValue(object target)
        {
            return ((IProjection)((LitterILitterProjection)target)._projector.Female)?.As<ICat>()!;
        }

        private static void SetFemaleValue(object target, object? value)
        {
             ((LitterILitterProjection)target)._projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
        }

        private static object? GetMaleValue(object target)
        {
            return ((IProjection?)((LitterILitterProjection)target)._projector.Male)?.As<ICat>();
        }

        private static void SetMaleValue(object target, object? value)
        {
             ((LitterILitterProjection)target)._projector.Male = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetStringsValue(object target)
        {
            return ((LitterILitterProjection)target)._projector.Strings!;
        }


        private static object? GetCatsValue(object target)
        {
            return ((LitterILitterProjection)target)._cats;
        }



#endregion Properties Accessors;



    }

    public class LitterILitterForCatProjection: ILitterForCat, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "Date", 
                    typeof(DateOnly),
                    GetDateValue, 
                    SetDateValue, 
                    target => ((IPoco)((LitterILitterForCatProjection)target)._projector).TouchProperty("Date"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Order", 
                    typeof(Int32),
                    GetOrderValue, 
                    SetOrderValue, 
                    target => ((IPoco)((LitterILitterForCatProjection)target)._projector).TouchProperty("Order"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Female", 
                    typeof(ICatAsParent),
                    GetFemaleValue, 
                    SetFemaleValue, 
                    target => ((IPoco)((LitterILitterForCatProjection)target)._projector).TouchProperty("Female"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Male", 
                    typeof(ICatAsParent),
                    GetMaleValue, 
                    SetMaleValue, 
                    target => ((IPoco)((LitterILitterForCatProjection)target)._projector).TouchProperty("Male"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Cats", 
                    typeof(IList<ICatAsSibling>),
                    GetCatsValue, 
                    null, 
                    target => ((IPoco)((LitterILitterForCatProjection)target)._projector).TouchProperty("Cats"), 
                    false, 
                    true, 
                    typeof(ICatAsSibling)
                )
            );
        }
#endregion Init Properties;




        private readonly LitterPoco _projector;

        private readonly ProjectionList<CatPoco,ICatAsSibling> _cats;

       public DateOnly Date 
        {
            get => _projector.Date!;
        }

       public Int32 Order 
        {
            get => _projector.Order!;
        }

       public ICatAsParent Female 
        {
            get => ((IProjection)_projector.Female)?.As<ICatAsParent>()!;
        }

       public ICatAsParent? Male 
        {
            get => ((IProjection?)_projector.Male)?.As<ICatAsParent>();
        }

       public IList<ICatAsSibling> Cats 
        {
            get => _cats;
        }


        internal LitterILitterForCatProjection(LitterPoco projector)
        {
            _projector = projector;

            _cats = new(((LitterPoco)_projector).Cats);
        }

        public I? As<I>() where I : class
        {
            return (I?)_projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return _projector.As(type);
        }


        public override bool Equals(object? obj)
        {
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(_projector, other.As<LitterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

        
#region Properties Accessors

        private static object? GetDateValue(object target)
        {
            return ((LitterILitterForCatProjection)target)._projector.Date!;
        }

        private static void SetDateValue(object target, object? value)
        {
             ((LitterILitterForCatProjection)target)._projector.Date = (DateOnly)value!;
        }

        private static object? GetOrderValue(object target)
        {
            return ((LitterILitterForCatProjection)target)._projector.Order!;
        }

        private static void SetOrderValue(object target, object? value)
        {
             ((LitterILitterForCatProjection)target)._projector.Order = (Int32)value!;
        }

        private static object? GetFemaleValue(object target)
        {
            return ((IProjection)((LitterILitterForCatProjection)target)._projector.Female)?.As<ICatAsParent>()!;
        }

        private static void SetFemaleValue(object target, object? value)
        {
             ((LitterILitterForCatProjection)target)._projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
        }

        private static object? GetMaleValue(object target)
        {
            return ((IProjection?)((LitterILitterForCatProjection)target)._projector.Male)?.As<ICatAsParent>();
        }

        private static void SetMaleValue(object target, object? value)
        {
             ((LitterILitterForCatProjection)target)._projector.Male = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetCatsValue(object target)
        {
            return ((LitterILitterForCatProjection)target)._cats;
        }



#endregion Properties Accessors;



    }

    public class LitterILitterForDateProjection: ILitterForDate, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "Date", 
                    typeof(DateOnly),
                    GetDateValue, 
                    SetDateValue, 
                    target => ((IPoco)((LitterILitterForDateProjection)target)._projector).TouchProperty("Date"), 
                    false, 
                    true, 
                    null
                )
            );
        }
#endregion Init Properties;




        private readonly LitterPoco _projector;


       public DateOnly Date 
        {
            get => _projector.Date!;
        }


        internal LitterILitterForDateProjection(LitterPoco projector)
        {
            _projector = projector;

        }

        public I? As<I>() where I : class
        {
            return (I?)_projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return _projector.As(type);
        }


        public override bool Equals(object? obj)
        {
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(_projector, other.As<LitterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

        
#region Properties Accessors

        private static object? GetDateValue(object target)
        {
            return ((LitterILitterForDateProjection)target)._projector.Date!;
        }

        private static void SetDateValue(object target, object? value)
        {
             ((LitterILitterForDateProjection)target)._projector.Date = (DateOnly)value!;
        }


#endregion Properties Accessors;



    }

    public class LitterILitterWithCatsProjection: ILitterWithCats, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "Female", 
                    typeof(ICatAsParent),
                    GetFemaleValue, 
                    SetFemaleValue, 
                    target => ((IPoco)((LitterILitterWithCatsProjection)target)._projector).TouchProperty("Female"), 
                    false, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Male", 
                    typeof(ICatAsParent),
                    GetMaleValue, 
                    SetMaleValue, 
                    target => ((IPoco)((LitterILitterWithCatsProjection)target)._projector).TouchProperty("Male"), 
                    true, 
                    true, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Cats", 
                    typeof(IList<ICatAsSibling>),
                    GetCatsValue, 
                    null, 
                    target => ((IPoco)((LitterILitterWithCatsProjection)target)._projector).TouchProperty("Cats"), 
                    false, 
                    true, 
                    typeof(ICatAsSibling)
                )
            );
        }
#endregion Init Properties;




        private readonly LitterPoco _projector;

        private readonly ProjectionList<CatPoco,ICatAsSibling> _cats;

       public ICatAsParent Female 
        {
            get => ((IProjection)_projector.Female)?.As<ICatAsParent>()!;
        }

       public ICatAsParent? Male 
        {
            get => ((IProjection?)_projector.Male)?.As<ICatAsParent>();
        }

       public IList<ICatAsSibling> Cats 
        {
            get => _cats;
        }


        internal LitterILitterWithCatsProjection(LitterPoco projector)
        {
            _projector = projector;

            _cats = new(((LitterPoco)_projector).Cats);
        }

        public I? As<I>() where I : class
        {
            return (I?)_projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return _projector.As(type);
        }


        public override bool Equals(object? obj)
        {
            return obj is IProjection<LitterPoco> other && object.ReferenceEquals(_projector, other.As<LitterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

        
#region Properties Accessors

        private static object? GetFemaleValue(object target)
        {
            return ((IProjection)((LitterILitterWithCatsProjection)target)._projector.Female)?.As<ICatAsParent>()!;
        }

        private static void SetFemaleValue(object target, object? value)
        {
             ((LitterILitterWithCatsProjection)target)._projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
        }

        private static object? GetMaleValue(object target)
        {
            return ((IProjection?)((LitterILitterWithCatsProjection)target)._projector.Male)?.As<ICatAsParent>();
        }

        private static void SetMaleValue(object target, object? value)
        {
             ((LitterILitterWithCatsProjection)target)._projector.Male = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetCatsValue(object target)
        {
            return ((LitterILitterWithCatsProjection)target)._cats;
        }



#endregion Properties Accessors;



    }
#endregion Projection classes

    
#region Init Properties
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
            new Property(
                "Date", 
                typeof(DateOnly),
                GetDateValue, 
                SetDateValue, 
                target => ((IPoco)target).TouchProperty("Date"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "Order", 
                typeof(Int32),
                GetOrderValue, 
                SetOrderValue, 
                target => ((IPoco)target).TouchProperty("Order"), 
                false, 
                false, 
                null
            )
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
                null
            )
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
                null
            )
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
                typeof(String)
            )
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
                typeof(CatPoco)
            )
        );
    }
#endregion Init Properties;


    
#region Fields

    private DateOnly _date = default!;
    private bool _loaded_date = false;
    private Int32 _order = default!;
    private bool _loaded_order = false;
    private CatPoco _female = default!;
    private bool _loaded_female = false;
    private CatPoco? _male = default;
    private bool _loaded_male = false;
    private readonly List<String> _strings = new();
    private bool _loaded_strings = false;
    private readonly List<CatPoco> _cats = new();
    private bool _loaded_cats = false;

#endregion Fields;

    
    
#region Projection Properties

    private LitterILitterProjection? _asLitterILitterProjection = null;
    private LitterILitterForCatProjection? _asLitterILitterForCatProjection = null;
    private LitterILitterForDateProjection? _asLitterILitterForDateProjection = null;
    private LitterILitterWithCatsProjection? _asLitterILitterWithCatsProjection = null;

    private LitterILitterProjection AsLitterILitterProjection 
        {
            get
            {
                if(_asLitterILitterProjection is null)
                {
                    _asLitterILitterProjection = new LitterILitterProjection(this);
                    ProjectionCreated(typeof(ILitter), _asLitterILitterProjection);
                }
                return _asLitterILitterProjection;
            }
        }
    private LitterILitterForCatProjection AsLitterILitterForCatProjection 
        {
            get
            {
                if(_asLitterILitterForCatProjection is null)
                {
                    _asLitterILitterForCatProjection = new LitterILitterForCatProjection(this);
                    ProjectionCreated(typeof(ILitterForCat), _asLitterILitterForCatProjection);
                }
                return _asLitterILitterForCatProjection;
            }
        }
    private LitterILitterForDateProjection AsLitterILitterForDateProjection 
        {
            get
            {
                if(_asLitterILitterForDateProjection is null)
                {
                    _asLitterILitterForDateProjection = new LitterILitterForDateProjection(this);
                    ProjectionCreated(typeof(ILitterForDate), _asLitterILitterForDateProjection);
                }
                return _asLitterILitterForDateProjection;
            }
        }
    private LitterILitterWithCatsProjection AsLitterILitterWithCatsProjection 
        {
            get
            {
                if(_asLitterILitterWithCatsProjection is null)
                {
                    _asLitterILitterWithCatsProjection = new LitterILitterWithCatsProjection(this);
                    ProjectionCreated(typeof(ILitterWithCats), _asLitterILitterWithCatsProjection);
                }
                return _asLitterILitterWithCatsProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

    public DateOnly Date 
    { 
        get => _date; 
        set
        {
            _date = value;
            _loaded_date = true;
        }
    }

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

    public CatPoco? Male 
    { 
        get => _male; 
        set
        {
            _male = value;
            _loaded_male = true;
        }
    }

    public List<String> Strings 
    { 
        get => _strings; 
    }

    public List<CatPoco> Cats 
    { 
        get => _cats; 
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
        if(type == typeof(ILitterForCat))
        {
            return AsLitterILitterForCatProjection;
        }
        if(type == typeof(ILitterForDate))
        {
            return AsLitterILitterForDateProjection;
        }
        if(type == typeof(ILitterWithCats))
        {
            return AsLitterILitterWithCatsProjection;
        }
        if(type == typeof(LitterPoco))
        {
            return this;
        }
        if(type == typeof(IPoco))
        {
            return this;
        }
        if(type == typeof(PocoBase))
        {
            return this;
        }
        
        if(type == typeof(IEntity))
        {
            return this;
        }
        if(type == typeof(EntityBase))
        {
            return this;
        }
        
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is LitterPoco other && object.ReferenceEquals(this, other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


    private void ProjectionCreated(Type @interface, IProjection projection)
    {
        OnProjectionCreated(@interface, projection);
    }

#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _loaded_date = false;
        _loaded_order = false;
        _loaded_female = false;
        _loaded_male = false;
        _loaded_strings = false;
        _loaded_cats = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ILitter))
        {
            return true
                && _loaded_date
                && _loaded_order
                && _loaded_female
                && _loaded_male
                && _loaded_strings
                && _loaded_cats
            ;
        }
        if(@interface == typeof(ILitterForCat))
        {
            return true
                && _loaded_date
                && _loaded_order
                && _loaded_female
                && _loaded_male
                && _loaded_cats
            ;
        }
        if(@interface == typeof(ILitterForDate))
        {
            return true
                && _loaded_date
            ;
        }
        if(@interface == typeof(ILitterWithCats))
        {
            return true
                && _loaded_female
                && _loaded_male
                && _loaded_cats
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
            case "Date":
                return _loaded_date;
            case "Order":
                return _loaded_order;
            case "Female":
                return _loaded_female;
            case "Male":
                return _loaded_male;
            case "Strings":
                return _loaded_strings;
            case "Cats":
                return _loaded_cats;
            default:
                return false;
        }
    }

    void IPoco.TouchProperty(string property)
    {
        switch(property)
        {
            case "Date":
                _loaded_date = true;
                break;
            case "Order":
                _loaded_order = true;
                break;
            case "Female":
                _loaded_female = true;
                break;
            case "Male":
                _loaded_male = true;
                break;
            case "Strings":
                _loaded_strings = true;
                break;
            case "Cats":
                _loaded_cats = true;
                break;
        }
    }

#endregion IPoco;


    
#region Properties Accessors

    private static object? GetDateValue(object target)
    {
        return ((LitterPoco)target).Date;
    }

    private static void SetDateValue(object target, object? value)
    {
        ((LitterPoco)target).Date = (DateOnly)value!;

    }

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
        ((LitterPoco)target).Female = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetMaleValue(object target)
    {
        return ((LitterPoco)target).Male;
    }

    private static void SetMaleValue(object target, object? value)
    {
        ((LitterPoco)target).Male = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetStringsValue(object target)
    {
        return ((LitterPoco)target).Strings;
    }


    private static object? GetCatsValue(object target)
    {
        return ((LitterPoco)target).Cats;
    }



#endregion Properties Accessors;


}