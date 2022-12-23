/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.LitterFilterPoco                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-23T18:45:23                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;

namespace CatsCommon.Filters;

public class LitterFilterPoco: EnvelopeBase, IPoco, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
{
    

#region Projection classes


    public class LitterFilterILitterFilterProjection: ILitterFilter, IPoco, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
    {

        public IProjection Projector { get; init; }


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

        void IPoco.Clear()
        {
            ((IPoco)Projector).Clear();
        }

        bool IPoco.IsPropertySet(string property)
        {
            return ((IPoco)Projector).IsPropertySet(property);
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
    private bool _loaded_female = false;
    private CatPoco _male = default!;
    private bool _loaded_male = false;

#endregion Fields;

    
    
#region Projection Properties

    private LitterFilterILitterFilterProjection? _asLitterFilterILitterFilterProjection = null;

    private LitterFilterILitterFilterProjection AsLitterFilterILitterFilterProjection => _asLitterFilterILitterFilterProjection ??= new(this);

#endregion Projection Properties;

    
    
#region Properties

    public IProjection Projector => this;

    public CatPoco Female 
    { 
        get => _female; 
        set
        {
            _female = value;
            _loaded_female = true;
        }
    }

    public CatPoco Male 
    { 
        get => _male; 
        set
        {
            _male = value;
            _loaded_male = true;
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


    
#region IPoco

    void IPoco.Clear()
    {
        _loaded_female = false;
        _loaded_male = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ILitterFilter))
        {
            return _loaded_female
                && _loaded_male
            ;
        }
        return false;
    }

    bool IPoco.IsLoaded<T>()
    {
        return ((IPoco)this).IsLoaded(typeof(T));
    }

    bool IPoco.IsPropertySet(string property)
    {
        switch(property)
        {
            case "Female":
                return _loaded_female;
            case "Male":
                return _loaded_male;
            default:
                return false;
        }
    }

    void IPoco.TouchProperty(string property)
    {
        switch(property)
        {
            case "Female":
                _loaded_female = true;
                break;
            case "Male":
                _loaded_male = true;
                break;
        }
    }

#endregion IPoco;


    
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