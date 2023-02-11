/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.BreedPoco                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-02-11T12:23:45                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;
using System.Linq;

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
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => true;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((BreedIBreedProjection)target)._projector._is_set_code;
            public object? Get(object target) => ((BreedIBreedProjection)target).Code;
            public void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_code = true;
            public void Set(object target, object? value) => ((BreedIBreedProjection)target).SetCode((String)value!);
        }

        public class GroupProperty: IProperty
        {
            public string Name => "Group";
            public bool IsReadOnly => false;
            public bool IsNullable => false;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => true;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((BreedIBreedProjection)target)._projector._is_set_group;
            public object? Get(object target) => ((BreedIBreedProjection)target).Group;
            public void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_group = true;
            public void Set(object target, object? value) => ((BreedIBreedProjection)target).SetGroup((String)value!);
        }

        public class NameEngProperty: IProperty
        {
            public string Name => "NameEng";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((BreedIBreedProjection)target)._projector._is_set_nameEng;
            public object? Get(object target) => ((BreedIBreedProjection)target).NameEng;
            public void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_nameEng = true;
            public void Set(object target, object? value) => ((BreedIBreedProjection)target).SetNameEng((String)value!);
        }

        public class NameNatProperty: IProperty
        {
            public string Name => "NameNat";
            public bool IsReadOnly => false;
            public bool IsNullable => true;
            public bool IsCollection =>  false;
            public bool IsPoco =>  false;
            public bool IsEntity => false;
            public bool IsKeyPart => false;
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsSet(object target) => ((BreedIBreedProjection)target)._projector._is_set_nameNat;
            public object? Get(object target) => ((BreedIBreedProjection)target).NameNat;
            public void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_nameNat = true;
            public void Set(object target, object? value) => ((BreedIBreedProjection)target).SetNameNat((String)value!);
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


        private void SetCode(String value)
        {
            _projector.SetCode((String)value!);
        }
        public String Code 
        {
            get => _projector.Code!;
            set => _projector.Code = (String)value!;
        }

        private void SetGroup(String value)
        {
            _projector.SetGroup((String)value!);
        }
        public String Group 
        {
            get => _projector.Group!;
            set => _projector.Group = (String)value!;
        }

        private void SetNameEng(String? value)
        {
            _projector.SetNameEng((String?)value);
        }
        public String? NameEng 
        {
            get => _projector.NameEng;
            set => _projector.NameEng = (String?)value;
        }

        private void SetNameNat(String? value)
        {
            _projector.SetNameNat((String?)value);
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
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => true;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((BreedPoco)target)._is_set_code;
        public object? Get(object target) => ((BreedPoco)target).Code;
        public void Touch(object target) => ((BreedPoco)target)._is_set_code = true;
        public void Set(object target, object? value) => ((BreedPoco)target).SetCode((String)value!);
    }

    public class GroupProperty: IProperty
    {
        public string Name => "Group";
        public bool IsReadOnly => false;
        public bool IsNullable => false;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => true;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((BreedPoco)target)._is_set_group;
        public object? Get(object target) => ((BreedPoco)target).Group;
        public void Touch(object target) => ((BreedPoco)target)._is_set_group = true;
        public void Set(object target, object? value) => ((BreedPoco)target).SetGroup((String)value!);
    }

    public class NameEngProperty: IProperty
    {
        public string Name => "NameEng";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((BreedPoco)target)._is_set_nameEng;
        public object? Get(object target) => ((BreedPoco)target).NameEng;
        public void Touch(object target) => ((BreedPoco)target)._is_set_nameEng = true;
        public void Set(object target, object? value) => ((BreedPoco)target).SetNameEng((String)value!);
    }

    public class NameNatProperty: IProperty
    {
        public string Name => "NameNat";
        public bool IsReadOnly => false;
        public bool IsNullable => true;
        public bool IsCollection =>  false;
        public bool IsPoco =>  false;
        public bool IsEntity => false;
        public bool IsKeyPart => false;
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsSet(object target) => ((BreedPoco)target)._is_set_nameNat;
        public object? Get(object target) => ((BreedPoco)target).NameNat;
        public void Touch(object target) => ((BreedPoco)target)._is_set_nameNat = true;
        public void Set(object target, object? value) => ((BreedPoco)target).SetNameNat((String)value!);
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new CodeProperty());
        properties.Add(new GroupProperty());
        properties.Add(new NameEngProperty());
        properties.Add(new NameNatProperty());
    }

   public static CodeProperty CodeProp = new();
   public static GroupProperty GroupProp = new();
   public static NameEngProperty NameEngProp = new();
   public static NameNatProperty NameNatProp = new();
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
                }
                return _asBreedIBreedProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

    private void SetCode(String value)
    { 
        _code = value;
        _is_set_code = true;
    }
    public String Code 
    { 
        get => !_is_set_code ? throw new PropertyNotSetException(nameof(Code)) : _code; 
        set => SetCode(value);
    }

    private void SetGroup(String value)
    { 
        _group = value;
        _is_set_group = true;
    }
    public String Group 
    { 
        get => !_is_set_group ? throw new PropertyNotSetException(nameof(Group)) : _group; 
        set => SetGroup(value);
    }

    private void SetNameEng(String? value)
    { 
        _nameEng = value;
        _is_set_nameEng = true;
    }
    public String? NameEng 
    { 
        get => !_is_set_nameEng ? throw new PropertyNotSetException(nameof(NameEng)) : _nameEng; 
        set => SetNameEng(value);
    }

    private void SetNameNat(String? value)
    { 
        _nameNat = value;
        _is_set_nameNat = true;
    }
    public String? NameNat 
    { 
        get => !_is_set_nameNat ? throw new PropertyNotSetException(nameof(NameNat)) : _nameNat; 
        set => SetNameNat(value);
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
        if(type == GetType())
        {
            return this;
        }
        return null;
    }

    public override bool Equals(object? obj)
    {
        return obj is IProjection<BreedPoco> other && object.ReferenceEquals(this, other.As<BreedPoco>());
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _is_set_code = false;
        _code = default!;
        _is_set_group = false;
        _group = default!;
        _is_set_nameEng = false;
        _nameEng = default!;
        _is_set_nameNat = false;
        _nameNat = default!;
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