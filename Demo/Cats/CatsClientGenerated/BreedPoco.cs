/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.BreedPoco                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-12T18:26:08                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.ComponentModel;

namespace CatsCommon.Model;

public class BreedPoco: EntityBase, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<BreedPoco>, IProjection<IBreed>
{

    #region Projection classes

    public class BreedIBreedProjection: IBreed, INotifyPropertyChanged, IProjection<IEntity>, IProjection<EntityBase>, IProjection<IPoco>, IProjection<PocoBase>, IProjection, IProjection<BreedPoco>, IProjection<IBreed>
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
            public bool IsValueSet(object target) =>  ((BreedIBreedProjection)target)._projector._is_set_code;
            public object? GetValue(object target)
            {
                return ((BreedIBreedProjection)target)._projector.Code!;
            }
            public void TouchValue(object target)
            {
                ((IPoco)((BreedIBreedProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
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
            public bool IsValueSet(object target) =>  ((BreedIBreedProjection)target)._projector._is_set_group;
            public object? GetValue(object target)
            {
                return ((BreedIBreedProjection)target)._projector.Group!;
            }
            public void TouchValue(object target)
            {
                ((IPoco)((BreedIBreedProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
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
            public bool IsValueSet(object target) =>  ((BreedIBreedProjection)target)._projector._is_set_nameEng;
            public object? GetValue(object target)
            {
                return ((BreedIBreedProjection)target)._projector.NameEng;
            }
            public void TouchValue(object target)
            {
                ((IPoco)((BreedIBreedProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
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
            public bool IsValueSet(object target) =>  ((BreedIBreedProjection)target)._projector._is_set_nameNat;
            public object? GetValue(object target)
            {
                return ((BreedIBreedProjection)target)._projector.NameNat;
            }
            public void TouchValue(object target)
            {
                ((IPoco)((BreedIBreedProjection)target)._projector).TouchProperty(Name);
            }
            public void SetValue(object target, object? value)
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


        private event PropertyChangedEventHandler? _propertyChanged;


            public event PropertyChangedEventHandler? PropertyChanged
            {
                add
                {
                    _propertyChanged += value;
                }

                remove
                {
                    _propertyChanged -= value;
                }
            }


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
        public bool IsValueSet(object target) =>  ((BreedPoco)target)._is_set_code;
        public object? GetValue(object target)
        {
            return ((BreedPoco)target).Code;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((BreedPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
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
        public bool IsValueSet(object target) =>  ((BreedPoco)target)._is_set_group;
        public object? GetValue(object target)
        {
            return ((BreedPoco)target).Group;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((BreedPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
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
        public bool IsValueSet(object target) =>  ((BreedPoco)target)._is_set_nameEng;
        public object? GetValue(object target)
        {
            return ((BreedPoco)target).NameEng;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((BreedPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
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
        public bool IsValueSet(object target) =>  ((BreedPoco)target)._is_set_nameNat;
        public object? GetValue(object target)
        {
            return ((BreedPoco)target).NameNat;
        }
        public void TouchValue(object target)
        {
            ((IPoco)((BreedPoco)target)).TouchProperty(Name);
        }
        public void SetValue(object target, object? value)
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

    public virtual String Code
    {
        get => _code;
        set
        {
            if(_code != value)
            {
                object oldValue = _code;
                _code = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String Group
    {
        get => _group;
        set
        {
            if(_group != value)
            {
                object oldValue = _group;
                _group = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? NameEng
    {
        get => _nameEng;
        set
        {
            if(_nameEng != value)
            {
                object? oldValue = _nameEng;
                _nameEng = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

    public virtual String? NameNat
    {
        get => _nameNat;
        set
        {
            if(_nameNat != value)
            {
                object? oldValue = _nameNat;
                _nameNat = value;
                OnPocoChanged(oldValue, value);
                OnPropertyChanged();
            }
        }
    }

#endregion Properties;


    public BreedPoco(IServiceProvider services) : base(services) 
    { 
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


    
#region Collections

    protected override bool IsCollectionChanged(string property)
    {
        switch(property)
        {
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
    }

    protected override void AcceptCollectionsChanges()
    {
    }
    
#endregion Collections;


    
#region Poco Changed



#endregion Poco Changed;



}




