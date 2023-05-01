/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatteryPoco                            //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-05-01T17:02:05                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using Net.Leksi.Pocota.Server;
using System;
using System.Linq;

namespace CatsCommon.Model;

public class CatteryPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IPoco, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatteryPoco>, IProjection<ICattery>
{
    public static readonly Type PrimaryKeyType = typeof(CatteryPrimaryKey);
    

#region Projection classes


    public class CatteryICatteryProjection: ICattery, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<CatteryPoco>, IProjection<ICattery>
    {


#region Init Properties

        public class NameEngProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatteryICatteryProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((CatteryICatteryProjection)target).NameEng;
            public override void Touch(object target) => ((CatteryICatteryProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((CatteryICatteryProjection)target).SetNameEng(value is null ? null : Convert<String>(value));
        }

        public class NameNatProperty: Net.Leksi.Pocota.Common.Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override string? KeyPart => null;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((CatteryICatteryProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((CatteryICatteryProjection)target).NameNat;
            public override void Touch(object target) => ((CatteryICatteryProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((CatteryICatteryProjection)target).SetNameNat(value is null ? null : Convert<String>(value));
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

    public class NameEngProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "NameEng";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatteryPoco)target)._is_set_nameEng;
        public override object? Get(object target) => ((CatteryPoco)target).NameEng;
        public override void Touch(object target) => ((CatteryPoco)target)._is_set_nameEng = true;
        public override void Set(object target, object? value) => ((CatteryPoco)target).SetNameEng(value is null ? null : Convert<String>(value));
    }

    public class NameNatProperty: Net.Leksi.Pocota.Common.Property
    {
        public override string Name => "NameNat";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override string? KeyPart => null;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((CatteryPoco)target)._is_set_nameNat;
        public override object? Get(object target) => ((CatteryPoco)target).NameNat;
        public override void Touch(object target) => ((CatteryPoco)target)._is_set_nameNat = true;
        public override void Set(object target, object? value) => ((CatteryPoco)target).SetNameNat(value is null ? null : Convert<String>(value));
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
        return obj is IProjection<CatteryPoco> other && object.ReferenceEquals(this, other.As<CatteryPoco>());
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