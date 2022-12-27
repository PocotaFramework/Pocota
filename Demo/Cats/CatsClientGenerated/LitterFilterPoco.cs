/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.LitterFilterPoco                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-27T18:28:56                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System.ComponentModel;

namespace CatsCommon.Filters;

public class LitterFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
{

#region Projection classes

    public class LitterFilterILitterFilterProjection: ILitterFilter, INotifyPropertyChanged, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "Female", 
                    typeof(ICat),
                    GetFemaleValue, 
                    SetFemaleValue, 
                    target => ((IPoco)((LitterFilterILitterFilterProjection)target)._projector).TouchProperty("Female"), 
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
                    target => ((IPoco)((LitterFilterILitterFilterProjection)target)._projector).TouchProperty("Male"), 
                    false, 
                    false, 
                    null
                )
            );
        }
#endregion Init Properties;


        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)_projector).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)_projector).PropertyChanged -= value;
            }
        }


        private readonly LitterFilterPoco _projector;


       public ICat Female 
        {
            get => ((IProjection)_projector.Female).As<ICat>()!;
            set => _projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
        }

       public ICat Male 
        {
            get => ((IProjection)_projector.Male).As<ICat>()!;
            set => _projector.Male = ((IProjection)value!)?.As<CatPoco>()!;
        }


        internal LitterFilterILitterFilterProjection(LitterFilterPoco projector)
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
            return obj is IProjection<LitterFilterPoco> other && object.ReferenceEquals(_projector, other.As<LitterFilterPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

        
#region Properties Accessors

        private static object? GetFemaleValue(object target)
        {
            return ((IProjection)((LitterFilterILitterFilterProjection)target)._projector.Female)?.As<ICat>()!;
        }

        private static void SetFemaleValue(object target, object? value)
        {
             ((LitterFilterILitterFilterProjection)target)._projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
        }

        private static object? GetMaleValue(object target)
        {
            return ((IProjection)((LitterFilterILitterFilterProjection)target)._projector.Male)?.As<ICat>()!;
        }

        private static void SetMaleValue(object target, object? value)
        {
             ((LitterFilterILitterFilterProjection)target)._projector.Male = ((IProjection)value!)?.As<CatPoco>()!;
        }


#endregion Properties Accessors;



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
                false, 
                false, 
                null
            )
        );
    }
#endregion Init Properties;

    
    
#region Fields

    private CatPoco _female = default!;
    private CatPoco _male = default!;

#endregion Fields;


    
#region Projection Properties

    private LitterFilterILitterFilterProjection? _asLitterFilterILitterFilterProjection = null;

    private LitterFilterILitterFilterProjection AsLitterFilterILitterFilterProjection 
        {
            get
            {
                if(_asLitterFilterILitterFilterProjection is null)
                {
                    _asLitterFilterILitterFilterProjection = new LitterFilterILitterFilterProjection(this);
                    ProjectionCreated(typeof(ILitterFilter), _asLitterFilterILitterFilterProjection);
                }
                return _asLitterFilterILitterFilterProjection = new(this);
            }
        }

#endregion Projection Properties;


    
#region Properties

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
        return obj is LitterFilterPoco other && object.ReferenceEquals(this, other);
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
        ((LitterFilterPoco)target).Female = (value as IProjection)?.As<CatPoco>()!;

    }

    private static object? GetMaleValue(object target)
    {
        return ((LitterFilterPoco)target).Male;
    }

    private static void SetMaleValue(object target, object? value)
    {
        ((LitterFilterPoco)target).Male = (value as IProjection)?.As<CatPoco>()!;

    }


#endregion Properties Accessors;



}


