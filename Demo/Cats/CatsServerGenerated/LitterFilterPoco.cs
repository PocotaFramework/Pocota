/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.LitterFilterPoco                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-21T18:50:10                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;

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
    private bool _loaded_female = false;
    private CatPoco _male = default!;
    private bool _loaded_male = false;

#endregion Fields;

    
    
#region Projection Properties;

    private LitterFilterILitterFilterProjection? _asLitterFilterILitterFilterProjection = null;

    public LitterFilterILitterFilterProjection AsLitterFilterILitterFilterProjection => _asLitterFilterILitterFilterProjection ??= new(this);

#endregion Projection Properties;

    
    
#region Properties;
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


    
#region IPoco;

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