/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.LitterFilterPoco                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-23T18:45:23                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System.ComponentModel;

namespace CatsCommon.Filters;

public class LitterFilterPoco: EnvelopeBase, IPoco, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
{

#region Projection classes

    public class LitterFilterILitterFilterProjection: ILitterFilter, IPoco, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
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

        public ICat Female 
        {
            get => ((IProjection)((LitterFilterPoco)Projector).Female).As<ICat>()!;
            set => ((LitterFilterPoco)Projector).Female = (CatPoco)value;
        }

        public ICat Male 
        {
            get => ((IProjection)((LitterFilterPoco)Projector).Male).As<ICat>()!;
            set => ((LitterFilterPoco)Projector).Male = (CatPoco)value;
        }


        internal LitterFilterILitterFilterProjection(IProjection projector)
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
            return obj is IProjection<LitterFilterPoco> other && object.ReferenceEquals(Projector, other.Projector);
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
                "Female", 
                typeof(CatPoco),
                GetFemaleValue, 
                SetFemaleValue, 
                target => ((IPoco)target).TouchProperty("Female"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitterFilter, ICat>()
        );
        properties.Add(
                new Property(
                "Male", 
                typeof(CatPoco),
                GetMaleValue, 
                SetMaleValue, 
                target => ((IPoco)target).TouchProperty("Male"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitterFilter, ICat>()
        );
    }
#endregion Init Properties;

    
    
#region Fields

    private CatPoco _female = default!;
    private CatPoco _male = default!;

#endregion Fields;


    
#region Projection Properties

    private LitterFilterILitterFilterProjection? _asLitterFilterILitterFilterProjection = null;

    private LitterFilterILitterFilterProjection AsLitterFilterILitterFilterProjection => _asLitterFilterILitterFilterProjection ??= new(this);

#endregion Projection Properties;


    
#region Properties

    public IProjection Projector => this;

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

    public virtual CatPoco Male
    {
        get => _male;
        set
        {
            if(_male != value)
            {
                object oldValue = _male;
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

#endregion Properties;


    public LitterFilterPoco(IServiceProvider services) : base(services) 
    { 
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ILitterFilter))
        {
            return AsLitterFilterILitterFilterProjection;
        }
        if(type == typeof(LitterFilterPoco))
        {
            return this;
        }
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<LitterFilterPoco> other && object.ReferenceEquals(this, other.Projector);
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

    protected virtual void FemalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Female));

    protected virtual void MalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Male));



#endregion Poco Changed;


    
#region Properties Accessors

    private static object? GetFemaleValue(object target)
    {
        return ((LitterFilterPoco)target).Female;
    }

    private static void SetFemaleValue(object target, object? value)
    {
        ((LitterFilterPoco)target).Female = (CatPoco)(value as IProjection)?.Projector!;

    }

    private static object? GetMaleValue(object target)
    {
        return ((LitterFilterPoco)target).Male;
    }

    private static void SetMaleValue(object target, object? value)
    {
        ((LitterFilterPoco)target).Male = (CatPoco)(value as IProjection)?.Projector!;

    }


#endregion Properties Accessors;



}


