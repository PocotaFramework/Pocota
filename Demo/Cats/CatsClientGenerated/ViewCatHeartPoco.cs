/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.ViewCatHeartPoco                                     //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2023-01-15T13:32:57                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CatsClient;

public abstract class ViewCatHeartPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<ViewCatHeartPoco>, IProjection<IViewCatHeart>
{

    #region Projection classes

    public class ViewCatHeartIViewCatHeartProjection: IViewCatHeart, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<ViewCatHeartPoco>, IProjection<IViewCatHeart>
    {


#region Init Properties

        public class EditKindProperty: IProperty
        {
            public string Name => "EditKind";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(EditKind);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((ViewCatHeartIViewCatHeartProjection)target)._projector._is_set_editKind;
            public object? Get(object target)
            {
                return ((ViewCatHeartIViewCatHeartProjection)target)._projector.EditKind!;
            }
            public void Touch(object target)
            {
                ((ViewCatHeartIViewCatHeartProjection)target)._projector.TouchEditKind();
            }
            public void Set(object target, object? value)
            {
                ((ViewCatHeartIViewCatHeartProjection)target)._projector.EditKind = (EditKind)value!;
            }
        }
        public class LittersViewProperty: IProperty
        {
            public string Name => "LittersView";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(Object);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((ViewCatHeartIViewCatHeartProjection)target)._projector._is_set_littersView;
            public object? Get(object target)
            {
                return ((ViewCatHeartIViewCatHeartProjection)target)._projector.LittersView!;
            }
            public void Touch(object target)
            {
                ((ViewCatHeartIViewCatHeartProjection)target)._projector.TouchLittersView();
            }
            public void Set(object target, object? value)
            {
                ((ViewCatHeartIViewCatHeartProjection)target)._projector.LittersView = (Object)value!;
            }
        }
        public class CatProperty: IProperty
        {
            public string Name => "Cat";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(ICat);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((ViewCatHeartIViewCatHeartProjection)target)._projector._is_set_cat;
            public object? Get(object target)
            {
                return ((IProjection)((ViewCatHeartIViewCatHeartProjection)target)._projector.Cat)?.As<ICat>()!;
            }
            public void Touch(object target)
            {
                ((ViewCatHeartIViewCatHeartProjection)target)._projector.TouchCat();
            }
            public void Set(object target, object? value)
            {
                ((ViewCatHeartIViewCatHeartProjection)target)._projector.Cat = ((IProjection?)value)?.As<CatPoco>()!;
            }
        }
        public class SelectedLittersProperty: IProperty
        {
            public string Name => "SelectedLitters";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  true;
            public Type Type => typeof(IList<ILitter>);
            public Type? ItemType => typeof(ILitter);
            public bool IsSet(object target) =>  ((ViewCatHeartIViewCatHeartProjection)target)._projector.SelectedLitters.IsSet;
            public object? Get(object target)
            {
                return ((ViewCatHeartIViewCatHeartProjection)target)._selectedLitters;
            }
            public void Touch(object target)
            {
                ((ViewCatHeartIViewCatHeartProjection)target)._projector.TouchSelectedLitters();
            }
            public void Set(object target, object? value)
            {
            }
        }
        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new EditKindProperty());
            properties.Add(new LittersViewProperty());
            properties.Add(new CatProperty());
            properties.Add(new SelectedLittersProperty());
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


        private readonly ViewCatHeartPoco _projector;

        private readonly ProjectionList<LitterPoco,ILitter> _selectedLitters;

       public EditKind EditKind 
        {
            get => _projector.EditKind!;
            set => _projector.EditKind = (EditKind)value!;
        }

       public Object LittersView 
        {
            get => _projector.LittersView!;
            set => _projector.LittersView = (Object)value!;
        }

       public ICat Cat 
        {
            get => ((IProjection)_projector.Cat)?.As<ICat>()!;
            set => _projector.Cat = ((IProjection)value!)?.As<CatPoco>()!;
        }

       public IList<ILitter> SelectedLitters 
        {
            get => _selectedLitters;
            set => throw new NotImplementedException();
        }


        internal ViewCatHeartIViewCatHeartProjection(ViewCatHeartPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };

            _selectedLitters = new(((ViewCatHeartPoco)_projector).SelectedLitters);
        }

        public I? As<I>() where I : class
        {
            return (I?)_projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return _projector.As(type);
        }

        public void LittersSelectionChanged(Object sender, EventArgs e)
        {
            ((ViewCatHeartPoco)_projector).LittersSelectionChanged(sender, e);
        }

        public override bool Equals(object? obj)
        {
            return obj is IProjection<ViewCatHeartPoco> other && object.ReferenceEquals(_projector, other.As<ViewCatHeartPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }


    }
    #endregion Projection classes
    
    
#region Init Properties

    public class EditKindProperty: IProperty
    {
        public string Name => "EditKind";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(EditKind);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((ViewCatHeartPoco)target)._is_set_editKind;
        public object? Get(object target)
        {
            return ((ViewCatHeartPoco)target).EditKind;
        }
        public void Touch(object target)
        {
            ((ViewCatHeartPoco)target).TouchEditKind();
        }
        public void Set(object target, object? value)
        {
            ((ViewCatHeartPoco)target).EditKind = (EditKind)value!;
        }
    }
    public class LittersViewProperty: IProperty
    {
        public string Name => "LittersView";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(Object);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((ViewCatHeartPoco)target)._is_set_littersView;
        public object? Get(object target)
        {
            return ((ViewCatHeartPoco)target).LittersView;
        }
        public void Touch(object target)
        {
            ((ViewCatHeartPoco)target).TouchLittersView();
        }
        public void Set(object target, object? value)
        {
            ((ViewCatHeartPoco)target).LittersView = (Object)value!;
        }
    }
    public class CatProperty: IProperty
    {
        public string Name => "Cat";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(CatPoco);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((ViewCatHeartPoco)target)._is_set_cat;
        public object? Get(object target)
        {
            return ((ViewCatHeartPoco)target).Cat;
        }
        public void Touch(object target)
        {
            ((ViewCatHeartPoco)target).TouchCat();
        }
        public void Set(object target, object? value)
        {
            ((ViewCatHeartPoco)target).Cat = ((IProjection?)value)?.As<CatPoco>()!;
        }
    }
    public class SelectedLittersProperty: IProperty
    {
        public string Name => "SelectedLitters";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  true;
        public Type Type => typeof(ObservableCollection<LitterPoco>);
        public Type? ItemType => typeof(LitterPoco);
        public bool IsSet(object target) =>  ((ViewCatHeartPoco)target).SelectedLitters.IsSet;
        public object? Get(object target)
        {
            return ((ViewCatHeartPoco)target).SelectedLitters;
        }
        public void Touch(object target)
        {
            ((ViewCatHeartPoco)target).TouchSelectedLitters();
        }
        public void Set(object target, object? value)
        {
        }
    }
    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new EditKindProperty());
        properties.Add(new LittersViewProperty());
        properties.Add(new CatProperty());
        properties.Add(new SelectedLittersProperty());
    }

       internal static EditKindProperty EditKindProp = new();
       internal static LittersViewProperty LittersViewProp = new();
       internal static CatProperty CatProp = new();
       internal static SelectedLittersProperty SelectedLittersProp = new();
#endregion Init Properties;

    
    
#region Fields

    private EditKind _editKind = default!;
    private bool _is_set_editKind = false;
    private Object _littersView = default!;
    private bool _is_set_littersView = false;
    private CatPoco _cat = default!;
    private bool _is_set_cat = false;
    private readonly ObservableCollection<LitterPoco> _selectedLitters = new();
    private readonly List<LitterPoco> _initial_selectedLitters = new();
    private bool _is_set_selectedLitters = false;

#endregion Fields;


    
#region Projection Properties

    private ViewCatHeartIViewCatHeartProjection? _asViewCatHeartIViewCatHeartProjection = null;

    private ViewCatHeartIViewCatHeartProjection AsViewCatHeartIViewCatHeartProjection 
        {
            get
            {
                if(_asViewCatHeartIViewCatHeartProjection is null)
                {
                    _asViewCatHeartIViewCatHeartProjection = new ViewCatHeartIViewCatHeartProjection(this);
                    ProjectionCreated(typeof(IViewCatHeart), _asViewCatHeartIViewCatHeartProjection);
                }
                return _asViewCatHeartIViewCatHeartProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    public virtual EditKind EditKind
    {
        get => _editKind;
        set
        {
            if(_editKind != value)
            {
                object oldValue = _editKind;
                _editKind = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual Object LittersView
    {
        get => _littersView;
        set
        {
            if(_littersView != value)
            {
                object oldValue = _littersView;
                _littersView = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual CatPoco Cat
    {
        get => _cat;
        set
        {
            if(_cat != value)
            {
                object oldValue = _cat;
                if(_cat is {})
                {
                    _cat.PocoChanged -= CatPocoChanged;
                }
                _cat = value;
                if(_cat is {})
                {
                    _cat.PocoChanged += CatPocoChanged;
                }
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual ObservableCollection<LitterPoco> SelectedLitters
    {
        get => _selectedLitters;
        set => throw new NotImplementedException();
    }

#endregion Properties;


    public ViewCatHeartPoco(IServiceProvider services) : base(services) 
    { 
        _selectedLitters.CollectionChanged += SelectedLittersCollectionChanged;
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(IViewCatHeart))
        {
            return AsViewCatHeartIViewCatHeartProjection;
        }
        if(type == typeof(ViewCatHeartPoco))
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
        
        if(type == typeof(EnvelopeBase))
        {
            return this;
        }
        
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is ViewCatHeartPoco other && object.ReferenceEquals(this, other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public void TouchEditKind()
    {
        _is_set_editKind = true;

    }
    public void TouchLittersView()
    {
        _is_set_littersView = true;

    }
    public void TouchCat()
    {
        _is_set_cat = true;

    }
    public void TouchSelectedLitters()
    {
        SelectedLitters.Touch();

    }

    public abstract void LittersSelectionChanged(Object sender, EventArgs e);

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
            case "SelectedLitters":
                return !Enumerable.SequenceEqual(
                        _selectedLitters.OrderBy(o => o.GetHashCode()), 
                        _initial_selectedLitters.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
        for(int i = _selectedLitters.Count - 1; i >= 0; --i)
        {
            if (!_initial_selectedLitters.Contains(_selectedLitters[i]))
            {
                _selectedLitters.RemoveAt(i);
            }
        }
        foreach(var item in _initial_selectedLitters)
        {
            if(!_selectedLitters.Contains(item))
            {
                _selectedLitters.Add(item);
            }
        }
    }

    protected override void AcceptCollectionsChanges()
    {
        if(_modified is null || !_modified.ContainsKey("SelectedLitters"))
        {
            _initial_selectedLitters.Clear();
            _initial_selectedLitters.AddRange(_selectedLitters);
        }
    }
    
#endregion Collections;


    
#region Poco Changed

    protected virtual void CatPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cat));

    protected virtual void SelectedLittersPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedLitters));


    protected virtual void SelectedLittersCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is { })
        {
            foreach (INotifyPocoChanged item in e.OldItems)
            {
                item.PocoChanged -= SelectedLittersPocoChanged;
            }
        }
        if (e.NewItems is { })
        {
            foreach (INotifyPocoChanged item in e.NewItems)
            {
                item.PocoChanged += SelectedLittersPocoChanged;
            }
        }
        OnPocoChanged(_initial_selectedLitters, _selectedLitters, nameof(SelectedLitters));
        OnPropertyChanged(nameof(SelectedLitters));
    }


#endregion Poco Changed;



}




