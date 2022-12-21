/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Filters.LitterFilterPoco                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-21T18:50:10                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;

namespace CatsCommon.Filters;

public class LitterFilterPoco: EnvelopeBase, IPoco, IProjector
{

#region Projection classes;

    public class LitterFilterILitterFilterProjection: ILitterFilter, IProjector, IProjection<LitterFilterPoco>
    {

        public LitterFilterPoco Projector  { get; init; }

        public ICat Female 
        {
            get => ((IProjector)Projector.Female).As<ICat>()!;
            set => Projector.Female = (CatPoco)value;
        }

        public ICat Male 
        {
            get => ((IProjector)Projector.Male).As<ICat>()!;
            set => Projector.Male = (CatPoco)value;
        }


        internal LitterFilterILitterFilterProjection(LitterFilterPoco projector)
        {
            Projector = projector;
        }

        I? IProjector.As<I>() where I : class
        {
            return (I?)((IProjector)Projector).As(typeof(I))!;
        }

        object? IProjector.As(Type type) 
        {
            return ((IProjector)Projector).As(type);
        }




    }
#endregion Projection classes;

    
#region Init Properties;
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

    
    
#region Fields;

    private CatPoco _female = default!;
    private CatPoco _male = default!;

#endregion Fields;


    
#region Projection Properties;

    private LitterFilterILitterFilterProjection? _asLitterFilterILitterFilterProjection = null;

    public LitterFilterILitterFilterProjection AsLitterFilterILitterFilterProjection => _asLitterFilterILitterFilterProjection ??= new(this);

#endregion Projection Properties;


    
#region Properties;
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

    
#region Methods;
    I? IProjector.As<I>() where I : class
    {
        return (I?)((IProjector)this).As(typeof(I));
    }

    object? IProjector.As(Type type)
    {
        if(type == typeof(LitterFilterILitterFilterProjection) || type == typeof(ILitterFilter))
        {
            return AsLitterFilterILitterFilterProjection;
        }
        return null;
    }


#endregion Methods;


    
#region Collections;

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


    
#region Poco Changed;

    protected virtual void FemalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Female));

    protected virtual void MalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Male));



#endregion Poco Changed;


    
#region Properties Accessors;

    private static object? GetFemaleValue(object target)
    {
        return ((LitterFilterPoco)target).Female;
    }

    private static void SetFemaleValue(object target, object? value)
    {
        ((LitterFilterPoco)target).Female = (CatPoco)value!;
    }
    private static object? GetMaleValue(object target)
    {
        return ((LitterFilterPoco)target).Male;
    }

    private static void SetMaleValue(object target, object? value)
    {
        ((LitterFilterPoco)target).Male = (CatPoco)value!;
    }

#endregion Properties Accessors;



}


