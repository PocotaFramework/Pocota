/////////////////////////////////////////////////////////////////////
// Client Poco Implementation                                      //
// CatsClient.ViewCatHeartBase                                     //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2022-12-17T12:54:34                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CatsClient;

public abstract class ViewCatHeartBase: EnvelopeBase, IProjector, IProjection<ViewCatHeartBase>
{

#region Projection classes;

    [Poco(typeof(IViewCatHeart))]
    public class ViewCatHeartProjection: IViewCatHeart, IProjector, IProjection<ViewCatHeartBase>
    {
        private readonly ProjectionList<LitterBase,ILitter> _selectedLitters;

        public  ViewCatHeartBase Source  { get; init; }

        public virtual EditKind EditKind 
        {
            get => Source.EditKind!;
            set => Source.EditKind = value;
        }

        public virtual ICatForView Cat 
        {
            get => Source.Cat.As<ICatForView>()!;
            set => Source.Cat = (CatBase)value;
        }

        public virtual Object LittersView 
        {
            get => Source.LittersView!;
            set => Source.LittersView = value;
        }

        public virtual IList<ILitter> SelectedLitters 
        {
            get => _selectedLitters;
            set => throw new NotImplementedException();
        }


        internal ViewCatHeartProjection(ViewCatHeartBase source)
        {
            Source = source;
            _selectedLitters = new(Source.SelectedLitters);
        }

        public I As<I>()
        {
            return (I)Source.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Source.As(type);
        }

        public void LittersSelectionChanged(Object sender, EventArgs e)
        {
            Source.LittersSelectionChanged(sender, e);
        }



    }
#endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(ViewCatHeartBase), new Properties<PocoBase>());
        Properties[typeof(ViewCatHeartBase)].Add(
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
        Properties[typeof(ViewCatHeartBase)].Add(
                new Property<PocoBase>(
                "Cat", 
                typeof(CatBase),
                GetCatValue, 
                SetCatValue, 
                target => ((IPoco)target).TouchProperty("Cat"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IViewCatHeart, ICatForView>()
        );
        Properties[typeof(ViewCatHeartBase)].Add(
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
        Properties[typeof(ViewCatHeartBase)].Add(
                new Property<PocoBase>(
                "SelectedLitters", 
                typeof(ObservableCollection<LitterBase>),
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
    private CatBase _cat = default!;
    private Object _littersView = default!;
    private readonly ObservableCollection<LitterBase> _selectedLitters = new();
    private readonly List<LitterBase> _initial_selectedLitters = new();


    
    private ViewCatHeartProjection? _asViewCatHeartProjection = null;

    public ViewCatHeartProjection AsViewCatHeartProjection => _asViewCatHeartProjection ??= new(this);



    public ViewCatHeartBase Source { get => this; }

    
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

    public virtual CatBase Cat
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

    public virtual ObservableCollection<LitterBase> SelectedLitters
    {
        get => _selectedLitters;
        set => throw new NotImplementedException();
    }



    public ViewCatHeartBase(IServiceProvider services) : base(services) 
    { 
        _selectedLitters.CollectionChanged += SelectedLittersCollectionChanged;
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(ViewCatHeartBase)];

    public override object? As(Type type)
    {
        if(type == typeof(ViewCatHeartProjection) || type == typeof(IViewCatHeart))
        {
            return AsViewCatHeartProjection;
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
        return ((ViewCatHeartBase)target).EditKind;
    }

    private static void SetEditKindValue(PocoBase target, object? value)
    {
        ((ViewCatHeartBase)target).EditKind = (EditKind)value!;
    }
    private static object? GetCatValue(PocoBase target)
    {
        return ((ViewCatHeartBase)target).Cat;
    }

    private static void SetCatValue(PocoBase target, object? value)
    {
        ((ViewCatHeartBase)target).Cat = (CatBase)value!;
    }
    private static object? GetLittersViewValue(PocoBase target)
    {
        return ((ViewCatHeartBase)target).LittersView;
    }

    private static void SetLittersViewValue(PocoBase target, object? value)
    {
        ((ViewCatHeartBase)target).LittersView = (Object)value!;
    }
    private static object? GetSelectedLittersValue(PocoBase target)
    {
        return ((ViewCatHeartBase)target).SelectedLitters;
    }


    #endregion Properties accessors;



}


