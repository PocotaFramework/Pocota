/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.BreedPoco                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-17T15:18:11                                  //
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

        public class CodeProperty: Property
        {
            public override string Name => "Code";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((BreedIBreedProjection)target)._projector._is_set_code;
            public override object? Get(object target) => ((BreedIBreedProjection)target)._projector.Code!;
            public override void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_code = true;
            public override void Set(object target, object? value) => ((BreedIBreedProjection)target)._projector.Code = (String)value!;
            public override bool IsModified(object target) => ((BreedIBreedProjection)target)._projector.IsCodeModified();
            public override bool IsInitial(object target) => ((BreedIBreedProjection)target)._projector.IsCodeInitial();
            public override int Position => 0;
        }

        public class GroupProperty: Property
        {
            public override string Name => "Group";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((BreedIBreedProjection)target)._projector._is_set_group;
            public override object? Get(object target) => ((BreedIBreedProjection)target)._projector.Group!;
            public override void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_group = true;
            public override void Set(object target, object? value) => ((BreedIBreedProjection)target)._projector.Group = (String)value!;
            public override bool IsModified(object target) => ((BreedIBreedProjection)target)._projector.IsGroupModified();
            public override bool IsInitial(object target) => ((BreedIBreedProjection)target)._projector.IsGroupInitial();
            public override int Position => 1;
        }

        public class NameEngProperty: Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((BreedIBreedProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((BreedIBreedProjection)target)._projector.NameEng;
            public override void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((BreedIBreedProjection)target)._projector.NameEng = (String)value!;
            public override bool IsModified(object target) => ((BreedIBreedProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((BreedIBreedProjection)target)._projector.IsNameEngInitial();
            public override int Position => 2;
        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) =>  ((BreedIBreedProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((BreedIBreedProjection)target)._projector.NameNat;
            public override void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((BreedIBreedProjection)target)._projector.NameNat = (String)value!;
            public override bool IsModified(object target) => ((BreedIBreedProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((BreedIBreedProjection)target)._projector.IsNameNatInitial();
            public override int Position => 3;
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

    public class CodeProperty: Property
    {
        public override string Name => "Code";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((BreedPoco)target)._is_set_code;
        public override object? Get(object target) => ((BreedPoco)target).Code;
        public override void Touch(object target) => ((BreedPoco)target)._is_set_code = true;
        public override void Set(object target, object? value) => ((BreedPoco)target).Code = (String)value!;
        public override bool IsModified(object target) => ((BreedPoco)target).IsCodeModified();
        public override bool IsInitial(object target) => ((BreedPoco)target).IsCodeInitial();
        public override int Position => 0;
    }

    public class GroupProperty: Property
    {
        public override string Name => "Group";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((BreedPoco)target)._is_set_group;
        public override object? Get(object target) => ((BreedPoco)target).Group;
        public override void Touch(object target) => ((BreedPoco)target)._is_set_group = true;
        public override void Set(object target, object? value) => ((BreedPoco)target).Group = (String)value!;
        public override bool IsModified(object target) => ((BreedPoco)target).IsGroupModified();
        public override bool IsInitial(object target) => ((BreedPoco)target).IsGroupInitial();
        public override int Position => 1;
    }

    public class NameEngProperty: Property
    {
        public override string Name => "NameEng";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((BreedPoco)target)._is_set_nameEng;
        public override object? Get(object target) => ((BreedPoco)target).NameEng;
        public override void Touch(object target) => ((BreedPoco)target)._is_set_nameEng = true;
        public override void Set(object target, object? value) => ((BreedPoco)target).NameEng = (String)value!;
        public override bool IsModified(object target) => ((BreedPoco)target).IsNameEngModified();
        public override bool IsInitial(object target) => ((BreedPoco)target).IsNameEngInitial();
        public override int Position => 2;
    }

    public class NameNatProperty: Property
    {
        public override string Name => "NameNat";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) =>  ((BreedPoco)target)._is_set_nameNat;
        public override object? Get(object target) => ((BreedPoco)target).NameNat;
        public override void Touch(object target) => ((BreedPoco)target)._is_set_nameNat = true;
        public override void Set(object target, object? value) => ((BreedPoco)target).NameNat = (String)value!;
        public override bool IsModified(object target) => ((BreedPoco)target).IsNameNatModified();
        public override bool IsInitial(object target) => ((BreedPoco)target).IsNameNatInitial();
        public override int Position => 3;
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
    private String?_initial_code = default;
    private bool _is_set_code = false;
    private String _group = default!;
    private String?_initial_group = default;
    private bool _is_set_group = false;
    private String? _nameEng = default;
    private String?_initial_nameEng = default;
    private bool _is_set_nameEng = false;
    private String? _nameNat = default;
    private String?_initial_nameNat = default;
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
        get => _is_set_code ? _code : default!;
        set
        {
            if(_code != value)
            {
                lock(_lock)
                {
                    if(_code != value  && (IsBeingPopulated || _is_set_code))
                    {
                        _code = value;
                        if (IsBeingPopulated)
                        {
                            _initial_code = value;
                        }
                        OnPocoChanged(s_codeProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String Group
    {
        get => _is_set_group ? _group : default!;
        set
        {
            if(_group != value)
            {
                lock(_lock)
                {
                    if(_group != value  && (IsBeingPopulated || _is_set_group))
                    {
                        _group = value;
                        if (IsBeingPopulated)
                        {
                            _initial_group = value;
                        }
                        OnPocoChanged(s_groupProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? NameEng
    {
        get => _is_set_nameEng ? _nameEng : default!;
        set
        {
            if(_nameEng != value)
            {
                lock(_lock)
                {
                    if(_nameEng != value  && (IsBeingPopulated || _is_set_nameEng))
                    {
                        _nameEng = value;
                        if (IsBeingPopulated)
                        {
                            _initial_nameEng = value;
                        }
                        OnPocoChanged(s_nameEngProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? NameNat
    {
        get => _is_set_nameNat ? _nameNat : default!;
        set
        {
            if(_nameNat != value)
            {
                lock(_lock)
                {
                    if(_nameNat != value  && (IsBeingPopulated || _is_set_nameNat))
                    {
                        _nameNat = value;
                        if (IsBeingPopulated)
                        {
                            _initial_nameNat = value;
                        }
                        OnPocoChanged(s_nameNatProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

#endregion Properties;


    public BreedPoco(IServiceProvider services) : base(services) 
    { 
        _propertiesCount = 4;
        _modifiedProperties = new int[_propertiesCount];
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

    protected override void CancelCollectionsChanges()
    {
    }

    protected override void AcceptCollectionsChanges()
    {
    }
    
#endregion Collections;


    
#region Poco Changed


    private bool IsCodeInitial() => _initial_code != _code;

    private bool IsCodeModified() => _is_set_code 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCodeInitial();

    private bool IsGroupInitial() => _initial_group != _group;

    private bool IsGroupModified() => _is_set_group 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsGroupInitial();

    private bool IsNameEngInitial() => _initial_nameEng != _nameEng;

    private bool IsNameEngModified() => _is_set_nameEng 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameEngInitial();

    private bool IsNameNatInitial() => _initial_nameNat != _nameNat;

    private bool IsNameNatModified() => _is_set_nameNat 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameNatInitial();


#endregion Poco Changed;



}




