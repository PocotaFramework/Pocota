/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.BreedPoco                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-28T18:41:16                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Model;


[Projection(typeof(BreedIBreedProjection))]


public class BreedPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<BreedPoco>, IProjection<IBreed>
{
    public static readonly Type PrimaryKeyType = typeof(BreedPrimaryKey);
    

#region Projection classes


    public class BreedIBreedProjection: IBreed, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<BreedPoco>, IProjection<IBreed>
    {


#region Init Properties
        public static void InitProperties(List<Property> properties)
        {
            properties.Add(
                new Property(
                    "Code", 
                    typeof(String),
                    GetCodeValue, 
                    SetCodeValue, 
                    target => ((IPoco)((BreedIBreedProjection)target)._projector).TouchProperty("Code"), 
                    false, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "Group", 
                    typeof(String),
                    GetGroupValue, 
                    SetGroupValue, 
                    target => ((IPoco)((BreedIBreedProjection)target)._projector).TouchProperty("Group"), 
                    false, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameEng", 
                    typeof(String),
                    GetNameEngValue, 
                    SetNameEngValue, 
                    target => ((IPoco)((BreedIBreedProjection)target)._projector).TouchProperty("NameEng"), 
                    true, 
                    false, 
                    null
                )
            );
            properties.Add(
                new Property(
                    "NameNat", 
                    typeof(String),
                    GetNameNatValue, 
                    SetNameNatValue, 
                    target => ((IPoco)((BreedIBreedProjection)target)._projector).TouchProperty("NameNat"), 
                    true, 
                    false, 
                    null
                )
            );
        }
#endregion Init Properties;




        private readonly BreedPoco _projector;


       public String Code 
        {
            get => _projector.Code!;
            set => _projector.Code = (String)value!;
        }

       public String Group 
        {
            get => _projector.Group!;
            set => _projector.Group = (String)value!;
        }

       public String? NameEng 
        {
            get => _projector.NameEng;
            set => _projector.NameEng = (String?)value;
        }

       public String? NameNat 
        {
            get => _projector.NameNat;
            set => _projector.NameNat = (String?)value;
        }


        internal BreedIBreedProjection(BreedPoco projector)
        {
            _projector = projector;
            _projector.PropertyChanged += (o, e) =>
            {
                _propertyChanged?.Invoke(this, e);
            };
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
            return obj is IProjection<BreedPoco> other && object.ReferenceEquals(_projector, other.As<BreedPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

        
#region Properties Accessors

        private static object? GetCodeValue(object target)
        {
            return ((BreedIBreedProjection)target)._projector.Code!;
        }

        private static void SetCodeValue(object target, object? value)
        {
             ((BreedIBreedProjection)target)._projector.Code = (String)value!;
        }

        private static object? GetGroupValue(object target)
        {
            return ((BreedIBreedProjection)target)._projector.Group!;
        }

        private static void SetGroupValue(object target, object? value)
        {
             ((BreedIBreedProjection)target)._projector.Group = (String)value!;
        }

        private static object? GetNameEngValue(object target)
        {
            return ((BreedIBreedProjection)target)._projector.NameEng;
        }

        private static void SetNameEngValue(object target, object? value)
        {
             ((BreedIBreedProjection)target)._projector.NameEng = (String?)value;
        }

        private static object? GetNameNatValue(object target)
        {
            return ((BreedIBreedProjection)target)._projector.NameNat;
        }

        private static void SetNameNatValue(object target, object? value)
        {
             ((BreedIBreedProjection)target)._projector.NameNat = (String?)value;
        }


#endregion Properties Accessors;



    }
#endregion Projection classes

    
#region Init Properties
    public static void InitProperties(List<Property> properties)
    {
        properties.Add(
            new Property(
                "Code", 
                typeof(String),
                GetCodeValue, 
                SetCodeValue, 
                target => ((IPoco)target).TouchProperty("Code"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "Group", 
                typeof(String),
                GetGroupValue, 
                SetGroupValue, 
                target => ((IPoco)target).TouchProperty("Group"), 
                false, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "NameEng", 
                typeof(String),
                GetNameEngValue, 
                SetNameEngValue, 
                target => ((IPoco)target).TouchProperty("NameEng"), 
                true, 
                false, 
                null
            )
        );
        properties.Add(
            new Property(
                "NameNat", 
                typeof(String),
                GetNameNatValue, 
                SetNameNatValue, 
                target => ((IPoco)target).TouchProperty("NameNat"), 
                true, 
                false, 
                null
            )
        );
    }
#endregion Init Properties;


    
#region Fields

    private String _code = default!;
    private bool _loaded_code = false;
    private String _group = default!;
    private bool _loaded_group = false;
    private String? _nameEng = default;
    private bool _loaded_nameEng = false;
    private String? _nameNat = default;
    private bool _loaded_nameNat = false;

#endregion Fields;

    
    
#region Projection Properties

    private BreedIBreedProjection? _asBreedIBreedProjection = null;

    private BreedIBreedProjection AsBreedIBreedProjection 
        {
            get
            {
                if(_asBreedIBreedProjection is null)
                {
                    _asBreedIBreedProjection = new BreedIBreedProjection(this);
                    ProjectionCreated(typeof(IBreed), _asBreedIBreedProjection);
                }
                return _asBreedIBreedProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

    public String Code 
    { 
        get => _code; 
        set
        {
            _code = value;
            _loaded_code = true;
        }
    }

    public String Group 
    { 
        get => _group; 
        set
        {
            _group = value;
            _loaded_group = true;
        }
    }

    public String? NameEng 
    { 
        get => _nameEng; 
        set
        {
            _nameEng = value;
            _loaded_nameEng = true;
        }
    }

    public String? NameNat 
    { 
        get => _nameNat; 
        set
        {
            _nameNat = value;
            _loaded_nameNat = true;
        }
    }

#endregion Properties;


    public BreedPoco(IServiceProvider services) : base(services) 
    { 
        _primaryKey = new BreedPrimaryKey(services);
        (_primaryKey as BreedPrimaryKey)!.Source = this;
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(IBreed))
        {
            return AsBreedIBreedProjection;
        }
        if(type == typeof(BreedPoco))
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
        
        if(type == typeof(IEntity))
        {
            return this;
        }
        if(type == typeof(EntityBase))
        {
            return this;
        }
        
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is BreedPoco other && object.ReferenceEquals(this, other);
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
        _loaded_code = false;
        _loaded_group = false;
        _loaded_nameEng = false;
        _loaded_nameNat = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(IBreed))
        {
            return _loaded_code
                && _loaded_group
                && _loaded_nameEng
                && _loaded_nameNat
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
            case "Code":
                return _loaded_code;
            case "Group":
                return _loaded_group;
            case "NameEng":
                return _loaded_nameEng;
            case "NameNat":
                return _loaded_nameNat;
            default:
                return false;
        }
    }

    void IPoco.TouchProperty(string property)
    {
        switch(property)
        {
            case "Code":
                _loaded_code = true;
                break;
            case "Group":
                _loaded_group = true;
                break;
            case "NameEng":
                _loaded_nameEng = true;
                break;
            case "NameNat":
                _loaded_nameNat = true;
                break;
        }
    }

#endregion IPoco;


    
#region Properties Accessors

    private static object? GetCodeValue(object target)
    {
        return ((BreedPoco)target).Code;
    }

    private static void SetCodeValue(object target, object? value)
    {
        ((BreedPoco)target).Code = (String)value!;

    }

    private static object? GetGroupValue(object target)
    {
        return ((BreedPoco)target).Group;
    }

    private static void SetGroupValue(object target, object? value)
    {
        ((BreedPoco)target).Group = (String)value!;

    }

    private static object? GetNameEngValue(object target)
    {
        return ((BreedPoco)target).NameEng;
    }

    private static void SetNameEngValue(object target, object? value)
    {
        ((BreedPoco)target).NameEng = (String)value!;

    }

    private static object? GetNameNatValue(object target)
    {
        return ((BreedPoco)target).NameNat;
    }

    private static void SetNameNatValue(object target, object? value)
    {
        ((BreedPoco)target).NameNat = (String)value!;

    }


#endregion Properties Accessors;


}