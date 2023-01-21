/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.BreedPoco                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-01-21T15:08:49                                  //
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
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => true;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((BreedIBreedProjection)target)._projector._is_set_code;
            public override object? Get(object target) => ((BreedIBreedProjection)target).Code;
            public override void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_code = true;
            public override void Unset(object target)
            {
                ((BreedIBreedProjection)target)._projector._is_set_code = false;
                ((BreedIBreedProjection)target)._projector._code = default!;
            }
            public override void Set(object target, object? value) => ((BreedIBreedProjection)target).Code = (String)value!;
            public override bool IsModified(object target) => ((BreedIBreedProjection)target)._projector.IsCodeModified();
            public override bool IsInitial(object target) => ((BreedIBreedProjection)target)._projector.IsCodeInitial();
            public override void CancelChange(object target) => ((BreedIBreedProjection)target)._projector.CodeCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class GroupProperty: Property
        {
            public override string Name => "Group";
            public override bool IsReadOnly => false;
            public override bool IsNullable => false;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => true;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((BreedIBreedProjection)target)._projector._is_set_group;
            public override object? Get(object target) => ((BreedIBreedProjection)target).Group;
            public override void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_group = true;
            public override void Unset(object target)
            {
                ((BreedIBreedProjection)target)._projector._is_set_group = false;
                ((BreedIBreedProjection)target)._projector._group = default!;
            }
            public override void Set(object target, object? value) => ((BreedIBreedProjection)target).Group = (String)value!;
            public override bool IsModified(object target) => ((BreedIBreedProjection)target)._projector.IsGroupModified();
            public override bool IsInitial(object target) => ((BreedIBreedProjection)target)._projector.IsGroupInitial();
            public override void CancelChange(object target) => ((BreedIBreedProjection)target)._projector.GroupCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class NameEngProperty: Property
        {
            public override string Name => "NameEng";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((BreedIBreedProjection)target)._projector._is_set_nameEng;
            public override object? Get(object target) => ((BreedIBreedProjection)target).NameEng;
            public override void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_nameEng = true;
            public override void Unset(object target)
            {
                ((BreedIBreedProjection)target)._projector._is_set_nameEng = false;
                ((BreedIBreedProjection)target)._projector._nameEng = default!;
            }
            public override void Set(object target, object? value) => ((BreedIBreedProjection)target).NameEng = (String)value!;
            public override bool IsModified(object target) => ((BreedIBreedProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((BreedIBreedProjection)target)._projector.IsNameEngInitial();
            public override void CancelChange(object target) => ((BreedIBreedProjection)target)._projector.NameEngCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
        }

        public class NameNatProperty: Property
        {
            public override string Name => "NameNat";
            public override bool IsReadOnly => false;
            public override bool IsNullable => true;
            public override bool IsCollection =>  false;
            public override bool IsPoco =>  false;
            public override bool IsEntity => false;
            public override bool IsKeyPart => false;
            public override Type Type => typeof(String);
            public override Type? ItemType => null;
            public override bool IsSet(object target) => ((BreedIBreedProjection)target)._projector._is_set_nameNat;
            public override object? Get(object target) => ((BreedIBreedProjection)target).NameNat;
            public override void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_nameNat = true;
            public override void Unset(object target)
            {
                ((BreedIBreedProjection)target)._projector._is_set_nameNat = false;
                ((BreedIBreedProjection)target)._projector._nameNat = default!;
            }
            public override void Set(object target, object? value) => ((BreedIBreedProjection)target).NameNat = (String)value!;
            public override bool IsModified(object target) => ((BreedIBreedProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((BreedIBreedProjection)target)._projector.IsNameNatInitial();
            public override void CancelChange(object target) => ((BreedIBreedProjection)target)._projector.NameNatCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => throw new InvalidOperationException();
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
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => true;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((BreedPoco)target)._is_set_code;
        public override object? Get(object target) => ((BreedPoco)target).Code;
        public override void Touch(object target) => ((BreedPoco)target)._is_set_code = true;
        public override void Unset(object target)
        {
            ((BreedPoco)target)._is_set_code = false;
            ((BreedPoco)target)._code = default!;
        }
        public override void Set(object target, object? value) => ((BreedPoco)target).Code = (String)value!;
        public override bool IsModified(object target) => ((BreedPoco)target).IsCodeModified();
        public override bool IsInitial(object target) => ((BreedPoco)target).IsCodeInitial();
        public override void CancelChange(object target) => ((BreedPoco)target).CodeCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class GroupProperty: Property
    {
        public override string Name => "Group";
        public override bool IsReadOnly => false;
        public override bool IsNullable => false;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => true;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((BreedPoco)target)._is_set_group;
        public override object? Get(object target) => ((BreedPoco)target).Group;
        public override void Touch(object target) => ((BreedPoco)target)._is_set_group = true;
        public override void Unset(object target)
        {
            ((BreedPoco)target)._is_set_group = false;
            ((BreedPoco)target)._group = default!;
        }
        public override void Set(object target, object? value) => ((BreedPoco)target).Group = (String)value!;
        public override bool IsModified(object target) => ((BreedPoco)target).IsGroupModified();
        public override bool IsInitial(object target) => ((BreedPoco)target).IsGroupInitial();
        public override void CancelChange(object target) => ((BreedPoco)target).GroupCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class NameEngProperty: Property
    {
        public override string Name => "NameEng";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((BreedPoco)target)._is_set_nameEng;
        public override object? Get(object target) => ((BreedPoco)target).NameEng;
        public override void Touch(object target) => ((BreedPoco)target)._is_set_nameEng = true;
        public override void Unset(object target)
        {
            ((BreedPoco)target)._is_set_nameEng = false;
            ((BreedPoco)target)._nameEng = default!;
        }
        public override void Set(object target, object? value) => ((BreedPoco)target).NameEng = (String)value!;
        public override bool IsModified(object target) => ((BreedPoco)target).IsNameEngModified();
        public override bool IsInitial(object target) => ((BreedPoco)target).IsNameEngInitial();
        public override void CancelChange(object target) => ((BreedPoco)target).NameEngCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
    }

    public class NameNatProperty: Property
    {
        public override string Name => "NameNat";
        public override bool IsReadOnly => false;
        public override bool IsNullable => true;
        public override bool IsCollection =>  false;
        public override bool IsPoco =>  false;
        public override bool IsEntity => false;
        public override bool IsKeyPart => false;
        public override Type Type => typeof(String);
        public override Type? ItemType => null;
        public override bool IsSet(object target) => ((BreedPoco)target)._is_set_nameNat;
        public override object? Get(object target) => ((BreedPoco)target).NameNat;
        public override void Touch(object target) => ((BreedPoco)target)._is_set_nameNat = true;
        public override void Unset(object target)
        {
            ((BreedPoco)target)._is_set_nameNat = false;
            ((BreedPoco)target)._nameNat = default!;
        }
        public override void Set(object target, object? value) => ((BreedPoco)target).NameNat = (String)value!;
        public override bool IsModified(object target) => ((BreedPoco)target).IsNameNatModified();
        public override bool IsInitial(object target) => ((BreedPoco)target).IsNameNatInitial();
        public override void CancelChange(object target) => ((BreedPoco)target).NameNatCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => throw new InvalidOperationException();
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
    private String _initial_code = default!;
    private bool _is_set_code = false;
    
    private String _group = default!;
    private String _initial_group = default!;
    private bool _is_set_group = false;
    
    private String? _nameEng = default;
    private String? _initial_nameEng = default!;
    private bool _is_set_nameEng = false;
    
    private String? _nameNat = default;
    private String? _initial_nameNat = default!;
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
        get => !_is_set_code ? default! : _code;
        set
        {
            if(_code != value)
            {
                lock(_lock)
                {
                    if(_code != value  && (IsBeingPopulated || _is_set_code))
                    {
                        if (!IsBeingPopulated || IsCodeInitial())
                        {
                            _code = value;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_code = value;
                            _is_set_code = true;
                        }
                        OnPocoChanged(CodeProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String Group
    {
        get => !_is_set_group ? default! : _group;
        set
        {
            if(_group != value)
            {
                lock(_lock)
                {
                    if(_group != value  && (IsBeingPopulated || _is_set_group))
                    {
                        if (!IsBeingPopulated || IsGroupInitial())
                        {
                            _group = value;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_group = value;
                            _is_set_group = true;
                        }
                        OnPocoChanged(GroupProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? NameEng
    {
        get => !_is_set_nameEng ? default! : _nameEng;
        set
        {
            if(_nameEng != value)
            {
                lock(_lock)
                {
                    if(_nameEng != value  && (IsBeingPopulated || _is_set_nameEng))
                    {
                        if (!IsBeingPopulated || IsNameEngInitial())
                        {
                            _nameEng = value;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_nameEng = value;
                            _is_set_nameEng = true;
                        }
                        OnPocoChanged(NameEngProp);
                        OnPropertyChanged();
                    }
                }
            }
        }
    }

    public virtual String? NameNat
    {
        get => !_is_set_nameNat ? default! : _nameNat;
        set
        {
            if(_nameNat != value)
            {
                lock(_lock)
                {
                    if(_nameNat != value  && (IsBeingPopulated || _is_set_nameNat))
                    {
                        if (!IsBeingPopulated || IsNameNatInitial())
                        {
                            _nameNat = value;
                        }
                        if (IsBeingPopulated)
                        {
                            _initial_nameNat = value;
                            _is_set_nameNat = true;
                        }
                        OnPocoChanged(NameNatProp);
                        OnPropertyChanged();
                    }
                }
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


    
#region Poco Changed


    private bool IsCodeInitial() => _initial_code == _code;

    private bool IsCodeModified() => _is_set_code 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCodeInitial();

    private void CodeCancelChange()
    {
        _code = _initial_code;

        OnPocoChanged(CodeProp);
        OnPropertyChanged("Code");

    }



    private bool IsGroupInitial() => _initial_group == _group;

    private bool IsGroupModified() => _is_set_group 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsGroupInitial();

    private void GroupCancelChange()
    {
        _group = _initial_group;

        OnPocoChanged(GroupProp);
        OnPropertyChanged("Group");

    }



    private bool IsNameEngInitial() => _initial_nameEng == _nameEng;

    private bool IsNameEngModified() => _is_set_nameEng 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameEngInitial();

    private void NameEngCancelChange()
    {
        _nameEng = _initial_nameEng;

        OnPocoChanged(NameEngProp);
        OnPropertyChanged("NameEng");

    }



    private bool IsNameNatInitial() => _initial_nameNat == _nameNat;

    private bool IsNameNatModified() => _is_set_nameNat 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameNatInitial();

    private void NameNatCancelChange()
    {
        _nameNat = _initial_nameNat;

        OnPocoChanged(NameNatProp);
        OnPropertyChanged("NameNat");

    }




#endregion Poco Changed;


}




