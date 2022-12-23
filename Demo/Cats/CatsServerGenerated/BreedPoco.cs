/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.BreedPoco                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-23T18:45:23                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Model;

public class BreedPoco: EntityBase, IPoco, IProjection, IProjection<BreedPoco>, IProjection<IBreed>
{
    public static readonly Type PrimaryKeyType = typeof(BreedPrimaryKey);
    

#region Projection classes


    public class BreedIBreedProjection: IBreed, IPoco, IProjection, IProjection<BreedPoco>, IProjection<IBreed>
    {

        public IProjection Projector { get; init; }


        public String Code 
        {
            get => ((BreedPoco)Projector).Code!;
            set => ((BreedPoco)Projector).Code = value;
        }

        public String Group 
        {
            get => ((BreedPoco)Projector).Group!;
            set => ((BreedPoco)Projector).Group = value;
        }

        public String? NameEng 
        {
            get => ((BreedPoco)Projector).NameEng;
            set => ((BreedPoco)Projector).NameEng = value;
        }

        public String? NameNat 
        {
            get => ((BreedPoco)Projector).NameNat;
            set => ((BreedPoco)Projector).NameNat = value;
        }


        internal BreedIBreedProjection(IProjection projector)
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
            return obj is IProjection<BreedPoco> other && object.ReferenceEquals(Projector, other.Projector);
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
                "Code", 
                typeof(String),
                GetCodeValue, 
                SetCodeValue, 
                target => ((IPoco)target).TouchProperty("Code"), 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IBreed, String>()
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
                false            
            )
            .AddPropertyType<IBreed, String>()
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
                false            
            )
            .AddPropertyType<IBreed, String>()
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
                false            
            )
            .AddPropertyType<IBreed, String>()
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

    private BreedIBreedProjection AsBreedIBreedProjection => _asBreedIBreedProjection ??= new(this);

#endregion Projection Properties;

    
    
#region Properties

    public IProjection Projector => this;

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
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<BreedPoco> other && object.ReferenceEquals(this, other.Projector);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
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