/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.BreedFilterPoco                      //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-23T18:45:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.ComponentModel;

namespace CatsCommon.Filters;

public class BreedFilterPoco: EnvelopeBase, IPoco, IProjection, IProjection<BreedFilterPoco>, IProjection<IBreedFilter>
{

#region Projection classes

    public class BreedFilterIBreedFilterProjection: IBreedFilter, IPoco, IProjection, IProjection<BreedFilterPoco>, IProjection<IBreedFilter>
    {
        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)Projector).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)Projector).PropertyChanged -= value;
            }
        }

        event PocoChangedEventHandler? INotifyPocoChanged.PocoChanged
        {
            add
            {
                ((INotifyPocoChanged)Projector).PocoChanged += value;
            }

            remove
            {
                ((INotifyPocoChanged)Projector).PocoChanged -= value;
            }
        }

        event PocoStateChangedEventHandler? INotifyPocoChanged.PocoStateChanged
        {
            add
            {
                ((INotifyPocoChanged)Projector).PocoStateChanged += value;
            }

            remove
            {
                ((INotifyPocoChanged)Projector).PocoStateChanged -= value;
            }
        }




        public IProjection Projector { get; init; }

        PocoState IPoco.PocoState =>  ((IPoco)Projector).PocoState;

        public String? SearchRegex 
        {
            get => ((BreedFilterPoco)Projector).SearchRegex;
            set => ((BreedFilterPoco)Projector).SearchRegex = value;
        }


        internal BreedFilterIBreedFilterProjection(IProjection projector)
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
            return obj is IProjection<BreedFilterPoco> other && object.ReferenceEquals(Projector, other.Projector);
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

        void IPoco.AcceptChanges()
        {
            ((IPoco)Projector).AcceptChanges();
        }

        void IPoco.CancelChanges()
        {
            ((IPoco)Projector).CancelChanges();
        }

        bool IPoco.IsModified(string property)
        {
                return ((IPoco)Projector).IsModified(property);
        }

        void IPoco.Invalidate()
        {
            ((IPoco)Projector).Invalidate();
        }

        

    }
#endregion Projection classes

    
#region Init Properties
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
                new Property(
                "SearchRegex", 
                typeof(String),
                GetSearchRegexValue, 
                SetSearchRegexValue, 
                target => ((IPoco)target).TouchProperty("SearchRegex"), 
                true, 
                false, 
                false            
            )
            .AddPropertyType<IBreedFilter, String>()
        );
    }
#endregion Init Properties;

    
    
#region Fields

    private String? _searchRegex = default;

#endregion Fields;


    
#region Projection Properties

    private BreedFilterIBreedFilterProjection? _asBreedFilterIBreedFilterProjection = null;

    private BreedFilterIBreedFilterProjection AsBreedFilterIBreedFilterProjection => _asBreedFilterIBreedFilterProjection ??= new(this);

#endregion Projection Properties;


    
#region Properties

    public IProjection Projector => this;

    public virtual String? SearchRegex
    {
        get => _searchRegex;
        set
        {
            if(_searchRegex != value)
            {
                object? oldValue = _searchRegex;
                _searchRegex = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

#endregion Properties;


    public BreedFilterPoco(IServiceProvider services) : base(services) 
    { 
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(IBreedFilter))
        {
            return AsBreedFilterIBreedFilterProjection;
        }
        if(type == typeof(BreedFilterPoco))
        {
            return this;
        }
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<BreedFilterPoco> other && object.ReferenceEquals(this, other.Projector);
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
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
    }

    protected override void AcceptCollectionsChanges()
    {
    }
    
#endregion Collections;


    
#region Poco Changed



#endregion Poco Changed;


    
#region Properties Accessors

    private static object? GetSearchRegexValue(object target)
    {
        return ((BreedFilterPoco)target).SearchRegex;
    }

    private static void SetSearchRegexValue(object target, object? value)
    {
        ((BreedFilterPoco)target).SearchRegex = (String)value!;

    }


#endregion Properties Accessors;



}


