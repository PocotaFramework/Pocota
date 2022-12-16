//////////////////////////////////////////////////////////////
// Client Poco Implementation                               //
// CatsCommon.Filters.LitterFilterBase                      //
// Generated automatically from Cats.Contract.ICatsContract //
// at 2022-12-16T18:40:09                                   //
//////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;

namespace CatsCommon.Filters;

public class LitterFilterBase: EnvelopeBase, IProjector
{

#region Projection classes;

    [Poco(typeof(ILitterFilter))]
    public class LitterFilterProjection: ILitterFilter, IProjector, IProjection<LitterFilterBase>
    {

        public LitterFilterBase Projector  { get; init; }

        public ICat Female 
        {
            get => Projector.Female.As<ICat>()!;
            set => Projector.Female = (CatBase)value;
        }

        public ICat Male 
        {
            get => Projector.Male.As<ICat>()!;
            set => Projector.Male = (CatBase)value;
        }


        internal LitterFilterProjection(LitterFilterBase projector)
        {
            Projector = projector;
        }

        public I As<I>()
        {
            return (I)Projector.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Projector.As(type);
        }




    }
#endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(LitterFilterBase), new Properties<PocoBase>());
        Properties[typeof(LitterFilterBase)].Add(
                new Property<PocoBase>(
                "Female", 
                typeof(CatBase),
                GetFemaleValue, 
                SetFemaleValue, 
                target => ((IPoco)target).TouchProperty("Female"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<ILitterFilter, ICat>()
        );
        Properties[typeof(LitterFilterBase)].Add(
                new Property<PocoBase>(
                "Male", 
                typeof(CatBase),
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

    
    
    private CatBase _female = default!;
    private CatBase _male = default!;


    
    private LitterFilterProjection? _asLitterFilterProjection = null;

    public LitterFilterProjection AsLitterFilterProjection => _asLitterFilterProjection ??= new(this);



    
    public virtual CatBase Female
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

    public virtual CatBase Male
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



    public LitterFilterBase(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(LitterFilterBase)];

    public override object? As(Type type)
    {
        if(type == typeof(LitterFilterProjection) || type == typeof(ILitterFilter))
        {
            return AsLitterFilterProjection;
        }
        return null;
    }




    
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
    

    
    protected virtual void FemalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Female));

    protected virtual void MalePocoChanged(object? sender, NotifyPocoChangedEventArgs e) => PropagateChangeEvent(e, nameof(Male));




    
    #region Properties accessors;

    private static object? GetFemaleValue(PocoBase target)
    {
        return ((LitterFilterBase)target).Female;
    }

    private static void SetFemaleValue(PocoBase target, object? value)
    {
        ((LitterFilterBase)target).Female = (CatBase)value!;
    }
    private static object? GetMaleValue(PocoBase target)
    {
        return ((LitterFilterBase)target).Male;
    }

    private static void SetMaleValue(PocoBase target, object? value)
    {
        ((LitterFilterBase)target).Male = (CatBase)value!;
    }

    #endregion Properties accessors;



}


