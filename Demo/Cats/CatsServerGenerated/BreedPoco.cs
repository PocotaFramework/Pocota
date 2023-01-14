/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.BreedPoco                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-14T20:09:42                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Model;

public class BreedPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<BreedPoco>, IProjection<IBreed>
{
    public static readonly Type PrimaryKeyType = typeof(BreedPrimaryKey);
    

#region Projection classes


    public class BreedIBreedProjection: IBreed, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<BreedPoco>, IProjection<IBreed>
    {


#region Init Properties

        public class CodeProperty: IProperty
        {
            public string Name => "Code";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((BreedIBreedProjection)target)._projector._is_set_code;
            public object? Get(object target)
            {
                return ((BreedIBreedProjection)target)._projector.Code!;
            }
            public void Touch(object target)
            {
                ((BreedIBreedProjection)target)._projector.TouchCode();
            }
            public void Set(object target, object? value)
            {
                ((BreedIBreedProjection)target)._projector.Code = (String)value!;
            }
        }
        public class GroupProperty: IProperty
        {
            public string Name => "Group";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((BreedIBreedProjection)target)._projector._is_set_group;
            public object? Get(object target)
            {
                return ((BreedIBreedProjection)target)._projector.Group!;
            }
            public void Touch(object target)
            {
                ((BreedIBreedProjection)target)._projector.TouchGroup();
            }
            public void Set(object target, object? value)
            {
                ((BreedIBreedProjection)target)._projector.Group = (String)value!;
            }
        }
        public class NameEngProperty: IProperty
        {
            public string Name => "NameEng";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((BreedIBreedProjection)target)._projector._is_set_nameEng;
            public object? Get(object target)
            {
                return ((BreedIBreedProjection)target)._projector.NameEng;
            }
            public void Touch(object target)
            {
                ((BreedIBreedProjection)target)._projector.TouchNameEng();
            }
            public void Set(object target, object? value)
            {
                ((BreedIBreedProjection)target)._projector.NameEng = (String)value!;
            }
        }
        public class NameNatProperty: IProperty
        {
            public string Name => "NameNat";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) =>  ((BreedIBreedProjection)target)._projector._is_set_nameNat;
            public object? Get(object target)
            {
                return ((BreedIBreedProjection)target)._projector.NameNat;
            }
            public void Touch(object target)
            {
                ((BreedIBreedProjection)target)._projector.TouchNameNat();
            }
            public void Set(object target, object? value)
            {
                ((BreedIBreedProjection)target)._projector.NameNat = (String)value!;
            }
        }
        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new CodeProperty());
            properties.Add(new GroupProperty());
            properties.Add(new NameEngProperty());
            properties.Add(new NameNatProperty());
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


    }
#endregion Projection classes

    
#region Init Properties

    public class CodeProperty: IProperty
    {
        public string Name => "Code";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((BreedPoco)target)._is_set_code;
        public object? Get(object target)
        {
            return ((BreedPoco)target).Code;
        }
        public void Touch(object target)
        {
            ((BreedPoco)target).TouchCode();
        }
        public void Set(object target, object? value)
        {
            ((BreedPoco)target).Code = (String)value!;
        }
    }
    public class GroupProperty: IProperty
    {
        public string Name => "Group";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((BreedPoco)target)._is_set_group;
        public object? Get(object target)
        {
            return ((BreedPoco)target).Group;
        }
        public void Touch(object target)
        {
            ((BreedPoco)target).TouchGroup();
        }
        public void Set(object target, object? value)
        {
            ((BreedPoco)target).Group = (String)value!;
        }
    }
    public class NameEngProperty: IProperty
    {
        public string Name => "NameEng";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((BreedPoco)target)._is_set_nameEng;
        public object? Get(object target)
        {
            return ((BreedPoco)target).NameEng;
        }
        public void Touch(object target)
        {
            ((BreedPoco)target).TouchNameEng();
        }
        public void Set(object target, object? value)
        {
            ((BreedPoco)target).NameEng = (String)value!;
        }
    }
    public class NameNatProperty: IProperty
    {
        public string Name => "NameNat";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) =>  ((BreedPoco)target)._is_set_nameNat;
        public object? Get(object target)
        {
            return ((BreedPoco)target).NameNat;
        }
        public void Touch(object target)
        {
            ((BreedPoco)target).TouchNameNat();
        }
        public void Set(object target, object? value)
        {
            ((BreedPoco)target).NameNat = (String)value!;
        }
    }
    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new CodeProperty());
        properties.Add(new GroupProperty());
        properties.Add(new NameEngProperty());
        properties.Add(new NameNatProperty());
    }

       internal static CodeProperty CodeProp = new();
       internal static GroupProperty GroupProp = new();
       internal static NameEngProperty NameEngProp = new();
       internal static NameNatProperty NameNatProp = new();
#endregion Init Properties;


    
#region Fields

    private String _code = default!;
    private bool _is_set_code = false;
    private String _group = default!;
    private bool _is_set_group = false;
    private String? _nameEng = default;
    private bool _is_set_nameEng = false;
    private String? _nameNat = default;
    private bool _is_set_nameNat = false;

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
        get => !_is_set_code ? throw new InvalidOperationException("The property Code is not set!") : _code; 
        set
        {
            _code = value;
            _is_set_code = true;
        }
    }

    public String Group 
    { 
        get => !_is_set_group ? throw new InvalidOperationException("The property Group is not set!") : _group; 
        set
        {
            _group = value;
            _is_set_group = true;
        }
    }

    public String? NameEng 
    { 
        get => !_is_set_nameEng ? throw new InvalidOperationException("The property NameEng is not set!") : _nameEng; 
        set
        {
            _nameEng = value;
            _is_set_nameEng = true;
        }
    }

    public String? NameNat 
    { 
        get => !_is_set_nameNat ? throw new InvalidOperationException("The property NameNat is not set!") : _nameNat; 
        set
        {
            _nameNat = value;
            _is_set_nameNat = true;
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

    public void TouchCode()
    {
        _is_set_code = true;
    }
    public void TouchGroup()
    {
        _is_set_group = true;
    }
    public void TouchNameEng()
    {
        _is_set_nameEng = true;
    }
    public void TouchNameNat()
    {
        _is_set_nameNat = true;
    }


    private void ProjectionCreated(Type @interface, IProjection projection)
    {
        OnProjectionCreated(@interface, projection);
    }

#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _is_set_code = false;
        _is_set_group = false;
        _is_set_nameEng = false;
        _is_set_nameNat = false;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(IBreed))
        {
            return true
                && _is_set_code
                && _is_set_group
                && _is_set_nameEng
                && _is_set_nameNat
            ;
        }
        return false;
    }

    bool IPoco.IsLoaded<T>()
    {
        return ((IPoco)this).IsLoaded(typeof(T));
    }

#endregion IPoco;


}