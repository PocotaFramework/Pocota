/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.ViewCatHeartPoco                                     //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2022-12-24T12:27:28                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsClient;

public abstract class ViewCatHeartPoco: EnvelopeBase, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<ViewCatHeartPoco>, IProjection<IViewCatHeart>
{

#region Projection classes

    public class ViewCatHeartIViewCatHeartProjection: IViewCatHeart, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<ViewCatHeartPoco>, IProjection<IViewCatHeart>
    {
        private readonly IProjection _projector;

        private readonly ProjectionList<LitterPoco,ILitter> _selectedLitters;

        public EditKind EditKind 
        {
            get => ((ViewCatHeartPoco)_projector).EditKind!;
            set => ((ViewCatHeartPoco)_projector).EditKind = value;
        }

        public ICatForView Cat 
        {
            get => ((IProjection)((ViewCatHeartPoco)_projector).Cat).As<ICatForView>()!;
            set => ((ViewCatHeartPoco)_projector).Cat = (CatPoco)value;
        }

        public Object LittersView 
        {
            get => ((ViewCatHeartPoco)_projector).LittersView!;
            set => ((ViewCatHeartPoco)_projector).LittersView = value;
        }

        public IList<ILitter> SelectedLitters 
        {
            get => _selectedLitters;
            set => throw new NotImplementedException();
        }


        internal ViewCatHeartIViewCatHeartProjection(IProjection projector)
        {
            _projector = projector;
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
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
                new Property(
                "EditKind", 
                typeof(EditKind),
                GetEditKindValue, 
                SetEditKindValue, 
                target => ((IPoco)target).TouchProperty("EditKind"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IViewCatHeart, EditKind>()
        );
        properties.Add(
                new Property(
                "Cat", 
                typeof(CatPoco),
                GetCatValue, 
                SetCatValue, 
                target => ((IPoco)target).TouchProperty("Cat"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IViewCatHeart, ICatForView>()
        );
        properties.Add(
                new Property(
                "LittersView", 
                typeof(Object),
                GetLittersViewValue, 
                SetLittersViewValue, 
                target => ((IPoco)target).TouchProperty("LittersView"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IViewCatHeart, Object>()
        );
        properties.Add(
                new Property(
                "SelectedLitters", 
                typeof(ObservableCollection<LitterPoco>),
                GetSelectedLittersValue, 
                null, 
                target => ((IPoco)target).TouchProperty("SelectedLitters"), 
                false, 
                false, 
                true            
            )
            .AddPropertyType<IViewCatHeart, IList<ILitter>>()
        );
    }
#endregion Init Properties;

    
    
#region Fields

    private EditKind _editKind = default!;
    private CatPoco _cat = default!;
    private Object _littersView = default!;
    private readonly ObservableCollection<LitterPoco> _selectedLitters = new();
    private readonly List<LitterPoco> _initial_selectedLitters = new();

#endregion Fields;


    
#region Projection Properties

    private ViewCatHeartIViewCatHeartProjection? _asViewCatHeartIViewCatHeartProjection = null;

    private ViewCatHeartIViewCatHeartProjection AsViewCatHeartIViewCatHeartProjection => _asViewCatHeartIViewCatHeartProjection ??= new(this);

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

    public abstract void LittersSelectionChanged(Object sender, EventArgs e);

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
        OnPocoChanged(_initial_selectedLitters, _selectedLitters, nameof(SelectedLitters));
        OnPropertyChanged(nameof(SelectedLitters));
    }


#endregion Poco Changed;


    
#region Properties Accessors

    private static object? GetEditKindValue(object target)
    {
        return ((ViewCatHeartPoco)target).EditKind;
    }

    private static void SetEditKindValue(object target, object? value)
    {
        ((ViewCatHeartPoco)target).EditKind = (EditKind)value!;

    }

    private static object? GetCatValue(object target)
    {
        return ((ViewCatHeartPoco)target).Cat;
    }

    private static void SetCatValue(object target, object? value)
    {
        ((ViewCatHeartPoco)target).Cat = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetLittersViewValue(object target)
    {
        return ((ViewCatHeartPoco)target).LittersView;
    }

    private static void SetLittersViewValue(object target, object? value)
    {
        ((ViewCatHeartPoco)target).LittersView = (Object)value!;

    }

    private static object? GetSelectedLittersValue(object target)
    {
        return ((ViewCatHeartPoco)target).SelectedLitters;
    }



#endregion Properties Accessors;



}


