/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.LitterPoco                             //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-26T18:18:11                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsCommon.Model;

public class LitterPoco: EntityBase, IProjection<IEntity>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
{

#region Projection classes

    public class LitterILitterProjection: ILitter, IProjection<IEntity>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
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
                    "Cats", 
                    typeof(IList<ICat>),
                    GetCatsValue, 
                    null, 
                    target => ((IPoco)((LitterILitterProjection)target)._projector).TouchProperty("Cats"), 
                    false, 
                    true, 
                    typeof(CatPoco)
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
        }
#endregion Init Properties;


        private readonly LitterPoco _projector;

        private readonly ProjectionList<CatPoco,ICat> _cats;

        public Int32 Order 
        {
            get => _projector.Order!;
            set => _projector.Order = (Int32)value!;
        }

        public ICat Female 
        {
            get => ((IProjection)_projector.Female).As<ICat>()!;
            set => _projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
        }

        public DateOnly Date 
        {
            get => _projector.Date!;
            set => _projector.Date = (DateOnly)value!;
        }

        public ICat? Male 
        {
            get => ((IProjection?)_projector.Male)?.As<ICat>();
            set => _projector.Male = ((IProjection?)value)?.As<CatPoco>();
        }

        public IList<ICat> Cats 
        {
            get => _cats;
        }

        public IList<String> Strings 
        {
            get => _projector.Strings!;
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

        private static object? GetDateValue(object target)
        {
            return ((LitterILitterProjection)target)._projector.Date!;
        }

        private static void SetDateValue(object target, object? value)
        {
             ((LitterILitterProjection)target)._projector.Date = (DateOnly)value!;
        }

        private static object? GetMaleValue(object target)
        {
            return ((IProjection?)((LitterILitterProjection)target)._projector.Male)?.As<ICat>();
        }

        private static void SetMaleValue(object target, object? value)
        {
             ((LitterILitterProjection)target)._projector.Male = ((IProjection?)value)?.As<CatPoco>();
        }

        private static object? GetCatsValue(object target)
        {
            return ((LitterILitterProjection)target)._cats;
        }


        private static object? GetStringsValue(object target)
        {
            return ((LitterILitterProjection)target)._projector.Strings!;
        }



#endregion Properties Accessors;



    }

    public class LitterILitterForCatProjection: ILitterForCat, IProjection<IEntity>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
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
        }
#endregion Init Properties;


        private readonly LitterPoco _projector;


        public Int32 Order 
        {
            get => _projector.Order!;
        }

        public ICatAsParent Female 
        {
            get => ((IProjection)_projector.Female).As<ICatAsParent>()!;
        }

        public DateOnly Date 
        {
            get => _projector.Date!;
        }

        public ICatAsParent? Male 
        {
            get => ((IProjection?)_projector.Male)?.As<ICatAsParent>();
        }


        internal LitterILitterForCatProjection(LitterPoco projector)
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

        private static object? GetDateValue(object target)
        {
            return ((LitterILitterForCatProjection)target)._projector.Date!;
        }

        private static void SetDateValue(object target, object? value)
        {
             ((LitterILitterForCatProjection)target)._projector.Date = (DateOnly)value!;
        }

        private static object? GetMaleValue(object target)
        {
            return ((IProjection?)((LitterILitterForCatProjection)target)._projector.Male)?.As<ICatAsParent>();
        }

        private static void SetMaleValue(object target, object? value)
        {
             ((LitterILitterForCatProjection)target)._projector.Male = ((IProjection?)value)?.As<CatPoco>();
        }


#endregion Properties Accessors;



    }

    public class LitterILitterForDateProjection: ILitterForDate, IProjection<IEntity>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
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

    public class LitterILitterWithCatsProjection: ILitterWithCats, IProjection<IEntity>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterPoco>, IProjection<ILitter>, IProjection<ILitterForCat>, IProjection<ILitterForDate>, IProjection<ILitterWithCats>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "Cats", 
                    typeof(IList<ICatForListing>),
                    GetCatsValue, 
                    null, 
                    target => ((IPoco)((LitterILitterWithCatsProjection)target)._projector).TouchProperty("Cats"), 
                    false, 
                    true, 
                    typeof(CatPoco)
                )
            );
        }
#endregion Init Properties;


        private readonly LitterPoco _projector;

        private readonly ProjectionList<CatPoco,ICatForListing> _cats;

        public IList<ICatForListing> Cats 
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
    }
#endregion Init Properties;

    
    
#region Fields

    private Int32 _order = default!;
    private CatPoco _female = default!;
    private DateOnly _date = default!;
    private CatPoco? _male = default;
    private readonly ObservableCollection<CatPoco> _cats = new();
    private readonly List<CatPoco> _initial_cats = new();
    private readonly ObservableCollection<String> _strings = new();
    private readonly List<String> _initial_strings = new();

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

    public virtual ObservableCollection<CatPoco> Cats
    {
        get => _cats;
        set => throw new NotImplementedException();
    }

    public virtual ObservableCollection<String> Strings
    {
        get => _strings;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public LitterPoco(IServiceProvider services) : base(services) 
    { 
        _cats.CollectionChanged += CatsCollectionChanged;
        _strings.CollectionChanged += StringsCollectionChanged;
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
        
        if(type == typeof(ILitterForCat))
        {
            return AsLitterILitterForCatProjection;
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
        
        if(type == typeof(ILitterForDate))
        {
            return AsLitterILitterForDateProjection;
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


#endregion Methods;


    
#region Collections

    protected override bool IsCollectionChanged(string property)
    {
        switch(property)
        {
            case "Cats":
                return !Enumerable.SequenceEqual(
                        _cats.OrderBy(o => o.GetHashCode()), 
                        _initial_cats.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            case "Strings":
                return !Enumerable.SequenceEqual(
                        _strings.OrderBy(o => o.GetHashCode()), 
                        _initial_strings.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
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
    }

    protected override void AcceptCollectionsChanges()
    {
        if(_modified is null || !_modified.ContainsKey("Cats"))
        {
            _initial_cats.Clear();
            _initial_cats.AddRange(_cats);
        }
        if(_modified is null || !_modified.ContainsKey("Strings"))
        {
            _initial_strings.Clear();
            _initial_strings.AddRange(_strings);
        }
    }
    
#endregion Collections;


    
#region Poco Changed

    protected virtual void FemalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Female));

    protected virtual void MalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Male));

    protected virtual void CatsPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cats));


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

    protected virtual void StringsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        OnPocoChanged(_initial_strings, _strings, nameof(Strings));
        OnPropertyChanged(nameof(Strings));
    }


#endregion Poco Changed;


    
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
        ((LitterPoco)target).Female = (value as IProjection)?.As<CatPoco>()!;

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
        ((LitterPoco)target).Male = (value as IProjection)?.As<CatPoco>()!;

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


