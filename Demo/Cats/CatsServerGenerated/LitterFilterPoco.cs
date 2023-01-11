/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Filters.LitterFilterPoco                     //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-11T18:42:24                                  //
/////////////////////////////////////////////////////////////


using CatsCommon.Model;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;

namespace CatsCommon.Filters;

public class LitterFilterPoco: EnvelopeBase, IProjection<EnvelopeBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
{
    

#region Projection classes


    public class LitterFilterILitterFilterProjection: ILitterFilter, IProjection<EnvelopeBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<LitterFilterPoco>, IProjection<ILitterFilter>
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




        private readonly LitterFilterPoco _projector;


       public ICat Female 
        {
            get => ((IProjection)_projector.Female)?.As<ICat>()!;
            set => _projector.Female = ((IProjection)value!)?.As<CatPoco>()!;
        }

       public ICat Male 
        {
            get => ((IProjection)_projector.Male)?.As<ICat>()!;
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
    private bool _loaded_female = false;
    private CatPoco _male = default!;
    private bool _loaded_male = false;

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
                return _asLitterFilterILitterFilterProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

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
            return true
                && _loaded_female
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