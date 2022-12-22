/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.ViewCatHeartPoco                                     //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2022-12-22T18:29:21                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsClient;

public abstract class ViewCatHeartPoco: EnvelopeBase, IPoco, IProjection, IProjection<ViewCatHeartPoco>, IProjection<IViewCatHeart>
{

#region Projection classes

    public class ViewCatHeartIViewCatHeartProjection: IViewCatHeart, IProjection, IProjection<ViewCatHeartPoco>, IProjection<IViewCatHeart>
    {
        private readonly ProjectionList<LitterPoco,ILitter> _selectedLitters;

        
#region Projectors

        public ViewCatHeartPoco Projector { get; init; }
        IProjector IProjection.Projector => Projector;

        IViewCatHeart IProjection<IViewCatHeart>.Projector => Projector.As<IViewCatHeart>()!;

#endregion Projectors;



        public EditKind EditKind 
        {
            get => Projector.EditKind!;
            set => Projector.EditKind = value;
        }

        public ICatForView Cat 
        {
            get => ((IProjector)Projector.Cat).As<ICatForView>()!;
            set => Projector.Cat = (CatPoco)value;
        }

        public Object LittersView 
        {
            get => Projector.LittersView!;
            set => Projector.LittersView = value;
        }

        public IList<ILitter> SelectedLitters 
        {
            get => _selectedLitters;
            set => throw new NotImplementedException();
        }


        internal ViewCatHeartIViewCatHeartProjection(ViewCatHeartPoco projector)
        {
            Projector = projector;
            _selectedLitters = new(Projector.SelectedLitters);
        }

        public I? As<I>() where I : class
        {
            return (I?)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }

        public void LittersSelectionChanged(Object sender, EventArgs e)
        {
            Projector.LittersSelectionChanged(sender, e);
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


    
#region Projectors

    public ViewCatHeartPoco Projector => this;
    IProjector IProjection.Projector => Projector;

    IViewCatHeart IProjection<IViewCatHeart>.Projector => Projector.As<IViewCatHeart>()!;

#endregion Projectors;

    
    
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
        return null;
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
        ((ViewCatHeartPoco)target).Cat = (CatPoco)(value as IProjection)?.Projector!;

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


