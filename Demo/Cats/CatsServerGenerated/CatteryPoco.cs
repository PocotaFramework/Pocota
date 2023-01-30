/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatteryPoco                            //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-30T18:35:33                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;

namespace CatsCommon.Model;

public class CatteryPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatteryPoco>, IProjection<ICattery>
{
    public static readonly Type PrimaryKeyType = typeof(CatteryPrimaryKey);
    

#region Projection classes


    public class CatteryICatteryProjection: ICattery, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatteryPoco>, IProjection<ICattery>
    {


#region Init Properties

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
            public bool IsSet(object target) => ((CatteryICatteryProjection)target)._projector._is_set_nameEng;
            public object? Get(object target) => ((CatteryICatteryProjection)target).NameEng;
            public void Touch(object target) => ((CatteryICatteryProjection)target)._projector._is_set_nameEng = true;
            public void Set(object target, object? value) => ((CatteryICatteryProjection)target).SetNameEng((String)value!);
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
            public bool IsSet(object target) => ((CatteryICatteryProjection)target)._projector._is_set_nameNat;
            public object? Get(object target) => ((CatteryICatteryProjection)target).NameNat;
            public void Touch(object target) => ((CatteryICatteryProjection)target)._projector._is_set_nameNat = true;
            public void Set(object target, object? value) => ((CatteryICatteryProjection)target).SetNameNat((String)value!);
        }

        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new NameEngProperty());
            properties.Add(new NameNatProperty());
        }

#endregion Init Properties;




        private readonly CatteryPoco _projector;


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


        internal CatteryICatteryProjection(CatteryPoco projector)
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
            return obj is IProjection<CatteryPoco> other && object.ReferenceEquals(_projector, other.As<CatteryPoco>());
        }

        public override int GetHashCode()
        {
            return _projector.GetHashCode();
        }

    }
#endregion Projection classes

    
#region Init Properties

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
        public bool IsSet(object target) => ((CatteryPoco)target)._is_set_nameEng;
        public object? Get(object target) => ((CatteryPoco)target).NameEng;
        public void Touch(object target) => ((CatteryPoco)target)._is_set_nameEng = true;
        public void Set(object target, object? value) => ((CatteryPoco)target).SetNameEng((String)value!);
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
        public bool IsSet(object target) => ((CatteryPoco)target)._is_set_nameNat;
        public object? Get(object target) => ((CatteryPoco)target).NameNat;
        public void Touch(object target) => ((CatteryPoco)target)._is_set_nameNat = true;
        public void Set(object target, object? value) => ((CatteryPoco)target).SetNameNat((String)value!);
    }

    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new NameEngProperty());
        properties.Add(new NameNatProperty());
    }

   public static NameEngProperty NameEngProp = new();
   public static NameNatProperty NameNatProp = new();
#endregion Init Properties;


    
#region Fields

    private String? _nameEng = default;
    private bool _is_set_nameEng = false;

    private String? _nameNat = default;
    private bool _is_set_nameNat = false;


#endregion Fields;

    
    
#region Projection Properties

    private CatteryICatteryProjection? _asCatteryICatteryProjection = null;

    private CatteryICatteryProjection AsCatteryICatteryProjection 
        {
            get
            {
                if(_asCatteryICatteryProjection is null)
                {
                    _asCatteryICatteryProjection = new CatteryICatteryProjection(this);
                }
                return _asCatteryICatteryProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

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


    public CatteryPoco(IServiceProvider services) : base(services) 
    { 
        _primaryKey = new CatteryPrimaryKey(services);
        (_primaryKey as CatteryPrimaryKey)!.Source = this;
    }

    
#region Methods
    public I? As<I>() where I : class
    {
        return (I?)As(typeof(I));
    }

    public object? As(Type type)
    {
        if(type == typeof(ICattery))
        {
            return AsCatteryICatteryProjection;
        }
        if(type == typeof(CatteryPoco))
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
        return obj is CatteryPoco other && object.ReferenceEquals(this, other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _is_set_nameEng = false;
        _nameEng = default!;
        _is_set_nameNat = false;
        _nameNat = default!;
    }

    bool IPoco.IsLoaded(Type @interface)
    {
        if(@interface == typeof(ICattery))
        {
            return true
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