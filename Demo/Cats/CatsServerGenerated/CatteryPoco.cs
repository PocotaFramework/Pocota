/////////////////////////////////////////////////////////////
// Server Poco Implementation                              //
// CatsCommon.Model.CatteryPoco                            //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-12T18:26:07                                  //
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
            public Type Type => typeof(String);
            public Type? ItemType => null;
            public bool IsValueSet(object target) =>  ((CatteryICatteryProjection)target)._projector._is_set_nameEng;
            public object? GetValue(object target)
            {
                return ((CatteryICatteryProjection)target)._projector.NameEng;
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatteryICatteryProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatteryICatteryProjection)target)._projector.NameEng = (String)value!;
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
            public bool IsValueSet(object target) =>  ((CatteryICatteryProjection)target)._projector._is_set_nameNat;
            public object? GetValue(object target)
            {
                return ((CatteryICatteryProjection)target)._projector.NameNat;
            }
            public void TouchValue(object target)
            {
                ((IPoco)((CatteryICatteryProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
            {
                ((CatteryICatteryProjection)target)._projector.NameNat = (String)value!;
            }
        }
        public static void InitProperties(List<IProperty> properties)
        {
            properties.Add(new NameEngProperty());
            properties.Add(new NameNatProperty());
        }

#endregion Init Properties;




        private readonly CatteryPoco _projector;


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
        public Type Type => typeof(String);
        public Type? ItemType => null;
        public bool IsValueSet(object target) =>  ((CatteryPoco)target)._is_set_nameEng;
        public object? GetValue(object target)
        {
            return ((CatteryPoco)target).NameEng;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatteryPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatteryPoco)target).NameEng = (String)value!;
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
        public bool IsValueSet(object target) =>  ((CatteryPoco)target)._is_set_nameNat;
        public object? GetValue(object target)
        {
            return ((CatteryPoco)target).NameNat;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((CatteryPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
        {
            ((CatteryPoco)target).NameNat = (String)value!;
        }
    }
    public static void InitProperties(List<IProperty> properties)
    {
        properties.Add(new NameEngProperty());
        properties.Add(new NameNatProperty());
    }

       internal static NameEngProperty NameEngProp = new();
       internal static NameNatProperty NameNatProp = new();
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
                    ProjectionCreated(typeof(ICattery), _asCatteryICatteryProjection);
                }
                return _asCatteryICatteryProjection;
            }
        }

#endregion Projection Properties;

    
    
#region Properties

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


    private void ProjectionCreated(Type @interface, IProjection projection)
    {
        OnProjectionCreated(@interface, projection);
    }

#endregion Methods;


    
#region IPoco

    void IPoco.Clear()
    {
        _is_set_nameEng = false;
        _is_set_nameNat = false;
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

    bool IPoco.IsPropertySet(string property)
    {
        switch(property)
        {
            case "NameEng":
                return _is_set_nameEng;
            case "NameNat":
                return _is_set_nameNat;
            default:
                return false;
        }
    }

    void IPoco.TouchProperty(string property)
    {
        switch(property)
        {
            case "NameEng":
                _is_set_nameEng = true;
                break;
            case "NameNat":
                _is_set_nameNat = true;
                break;
        }
    }

#endregion IPoco;


}