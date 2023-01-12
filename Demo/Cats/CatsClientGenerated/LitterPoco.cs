/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.LitterPoco                             //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-12T11:37:42                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CatsCommon.Model;

public class LitterPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
{

    #region Projection classes

    public class LitterILitterProjection: ILitter, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
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


        private event PropertyChangedEventHandler? _propertyChanged;


            public event PropertyChangedEventHandler? PropertyChanged
            {
                add
                {
                    _propertyChanged += value;
                }

                remove
                {
                    _propertyChanged -= value;
                }
            }


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
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

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

    public class LitterILitterForCatProjection: ILitterForCat, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
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


        private event PropertyChangedEventHandler? _propertyChanged;


            public event PropertyChangedEventHandler? PropertyChanged
            {
                add
                {
                    _propertyChanged += value;
                }

                remove
                {
                    _propertyChanged -= value;
                }
            }


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
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

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

    public class LitterILitterForDateProjection: ILitterForDate, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
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


        private event PropertyChangedEventHandler? _propertyChanged;


            public event PropertyChangedEventHandler? PropertyChanged
            {
                add
                {
                    _propertyChanged += value;
                }

                remove
                {
                    _propertyChanged -= value;
                }
            }


        private readonly LitterPoco _projector;


       public DateOnly Date 
        {
            get => _projector.Date!;
        }


        internal LitterILitterForDateProjection(LitterPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

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

    public class LitterILitterWithCatsProjection: ILitterWithCats, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
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


        private event PropertyChangedEventHandler? _propertyChanged;


            public event PropertyChangedEventHandler? PropertyChanged
            {
                add
                {
                    _propertyChanged += value;
                }

                remove
                {
                    _propertyChanged -= value;
                }
            }


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
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

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
                typeof(ObservableCollection<String>),
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
                typeof(ObservableCollection<CatPoco>),
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
    private Int32 _order = default!;
    private CatPoco _female = default!;
    private CatPoco? _male = default;
    private readonly ObservableCollection<String> _strings = new();
    private readonly List<String> _initial_strings = new();
    private readonly ObservableCollection<CatPoco> _cats = new();
    private readonly List<CatPoco> _initial_cats = new();

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

    public virtual DateOnly Date
    {
        get => _date;
        set
        {
            if(_date != value)
            {
                object oldValue = _date;
                _date = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Int32 Order
    {
        get => _order;
        set
        {
            if(_order != value)
            {
                object oldValue = _order;
                _order = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatPoco Female
    {
        get => _female;
        set
        {
            if(_female != value)
            {
                object oldValue = _female;
                if(_female is {})
                {
                    _female.PocoChanged -= FemalePocoChanged;
                }
                _female = value;
                if(_female is {})
                {
                    _female.PocoChanged += FemalePocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatPoco? Male
    {
        get => _male;
        set
        {
            if(_male != value)
            {
                object? oldValue = _male;
                if(_male is {})
                {
                    _male.PocoChanged -= MalePocoChanged;
                }
                _male = value;
                if(_male is {})
                {
                    _male.PocoChanged += MalePocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual ObservableCollection<String> Strings
    {
        get => _strings;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<CatPoco> Cats
    {
        get => _cats;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public LitterPoco(IServiceProvider services) : base(services) 
    { 
        _strings.CollectionChanged += StringsCollectionChanged;
        _cats.CollectionChanged += CatsCollectionChanged;
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


    
#region Collections

    protected override bool IsCollectionChanged(string property)
    {
        switch(property)
        {
            case "Strings":
                return !Enumerable.SequenceEqual(
                        _strings.OrderBy(o => o.GetHashCode()), 
                        _initial_strings.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            case "Cats":
                return !Enumerable.SequenceEqual(
                        _cats.OrderBy(o => o.GetHashCode()), 
                        _initial_cats.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
        for(int i = _strings.Count - 1; i >= 0; --i)
        {
            if (!_initial_strings.Contains(_strings[i]))
            {
                _strings.RemoveAt(i);
            }
        }
        foreach(var item in _initial_strings)
        {
            if(!_strings.Contains(item))
            {
                _strings.Add(item);
            }
        }
        for(int i = _cats.Count - 1; i >= 0; --i)
        {
            if (!_initial_cats.Contains(_cats[i]))
            {
                _cats.RemoveAt(i);
            }
        }
        foreach(var item in _initial_cats)
        {
            if(!_cats.Contains(item))
            {
                _cats.Add(item);
            }
        }
    }

    protected override void AcceptCollectionsChanges()
    {
        if(_modified is null || !_modified.ContainsKey("Strings"))
        {
            _initial_strings.Clear();
            _initial_strings.AddRange(_strings);
        }
        if(_modified is null || !_modified.ContainsKey("Cats"))
        {
            _initial_cats.Clear();
            _initial_cats.AddRange(_cats);
        }
    }
    
#endregion Collections;


    
#region Poco Changed

    protected virtual void FemalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Female));

    protected virtual void MalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Male));

    protected virtual void CatsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cats));


    protected virtual void StringsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        OnPocoChanged(_initial_strings, _strings, nameof(Strings));
        OnPropertyChanged(nameof(Strings));
    }

    protected virtual void CatsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is { })
        {
            foreach (INotifyPocoChanged item in e.OldItems)
            {
                item.PocoChanged -= CatsPocoChanged;
            }
        }
        if (e.NewItems is { })
        {
            foreach (INotifyPocoChanged item in e.NewItems)
            {
                item.PocoChanged += CatsPocoChanged;
            }
        }
        OnPocoChanged(_initial_cats, _cats, nameof(Cats));
        OnPropertyChanged(nameof(Cats));
    }


#endregion Poco Changed;


    
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




