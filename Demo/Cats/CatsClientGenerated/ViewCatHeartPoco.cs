/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.ViewCatHeartPoco                                     //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2022-12-20T14:53:23                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsClient;

public abstract class ViewCatHeartPoco: EnvelopeBase, IProjector
{

#region Projection classes;

    public class ViewCatHeartIViewCatHeartProjection: IViewCatHeart, IProjector, IProjection<ViewCatHeartPoco>
    {
        private readonly ProjectionList<LitterPoco,ILitter> _selectedLitters;

        public ViewCatHeartPoco Projector  { get; init; }

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

        public I As<I>()
        {
            return (I)Projector.As(typeof(I))!;
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
#endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(ViewCatHeartPoco), new Properties<PocoBase>());
        Properties[typeof(ViewCatHeartPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(ViewCatHeartPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(ViewCatHeartPoco)].Add(
                new Property<PocoBase>(
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
        Properties[typeof(ViewCatHeartPoco)].Add(
                new Property<PocoBase>(
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

    
    
    private EditKind _editKind = default!;
    private CatPoco _cat = default!;
    private Object _littersView = default!;
    private readonly ObservableCollection<LitterPoco> _selectedLitters = new();
    private readonly List<LitterPoco> _initial_selectedLitters = new();


    
    private ViewCatHeartIViewCatHeartProjection? _asViewCatHeartIViewCatHeartProjection = null;

    public ViewCatHeartIViewCatHeartProjection AsViewCatHeartIViewCatHeartProjection => _asViewCatHeartIViewCatHeartProjection ??= new(this);



    
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



    public ViewCatHeartPoco(IServiceProvider services) : base(services) 
    { 
        _selectedLitters.CollectionChanged += SelectedLittersCollectionChanged;
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(ViewCatHeartPoco)];

    public I? As<I>()
    {
        return (I)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ViewCatHeartIViewCatHeartProjection) || type == typeof(IViewCatHeart))
        {
            return AsViewCatHeartIViewCatHeartProjection;
        }
        return null;
    }

    public abstract void LittersSelectionChanged(Object sender, EventArgs e);



    
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
    

    
    protected virtual void CatPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Cat));

    protected virtual void SelectedLittersPocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(SelectedLitters));


    protected virtual void SelectedLittersCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {

        OnPocoChanged(_initial_selectedLitters, _selectedLitters, nameof(SelectedLitters));
        OnPropertyChanged(nameof(SelectedLitters));
    }

    

    
    #region Properties accessors;

    private static object? GetEditKindValue(PocoBase target)
    {
        return ((ViewCatHeartPoco)target).EditKind;
    }

    private static void SetEditKindValue(PocoBase target, object? value)
    {
        ((ViewCatHeartPoco)target).EditKind = (EditKind)value!;
    }
    private static object? GetCatValue(PocoBase target)
    {
        return ((ViewCatHeartPoco)target).Cat;
    }

    private static void SetCatValue(PocoBase target, object? value)
    {
        ((ViewCatHeartPoco)target).Cat = (CatPoco)value!;
    }
    private static object? GetLittersViewValue(PocoBase target)
    {
        return ((ViewCatHeartPoco)target).LittersView;
    }

    private static void SetLittersViewValue(PocoBase target, object? value)
    {
        ((ViewCatHeartPoco)target).LittersView = (Object)value!;
    }
    private static object? GetSelectedLittersValue(PocoBase target)
    {
        return ((ViewCatHeartPoco)target).SelectedLitters;
    }


    #endregion Properties accessors;



}


