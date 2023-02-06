/////////////////////////////////////////////////////////////
// Client Poco Implementation                              //
// CatsCommon.Model.BreedPoco                              //
// Generated automatically from CatsContract.ICatsContract //
// at 2023-02-06T18:22:36                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.ComponentModel;
using System.Linq;

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
            public override bool IsSet(object target) => ((BreedIBreedProjection)target)._projector.IsCodeSet();
            public override object? Get(object target) => ((BreedIBreedProjection)target).Code;
            public override void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_code = true;
            public override void Set(object target, object? value) => ((BreedIBreedProjection)target).SetCode((String)value!);
            public override bool IsModified(object target) => ((BreedIBreedProjection)target)._projector.IsCodeModified();
            public override bool IsInitial(object target) => ((BreedIBreedProjection)target)._projector.IsCodeInitial();
            public override void CancelChange(object target) => ((BreedIBreedProjection)target)._projector.CodeCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((BreedIBreedProjection)target)._projector._initial_code : default!;
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
            public override bool IsSet(object target) => ((BreedIBreedProjection)target)._projector.IsGroupSet();
            public override object? Get(object target) => ((BreedIBreedProjection)target).Group;
            public override void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_group = true;
            public override void Set(object target, object? value) => ((BreedIBreedProjection)target).SetGroup((String)value!);
            public override bool IsModified(object target) => ((BreedIBreedProjection)target)._projector.IsGroupModified();
            public override bool IsInitial(object target) => ((BreedIBreedProjection)target)._projector.IsGroupInitial();
            public override void CancelChange(object target) => ((BreedIBreedProjection)target)._projector.GroupCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((BreedIBreedProjection)target)._projector._initial_group : default!;
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
            public override bool IsSet(object target) => ((BreedIBreedProjection)target)._projector.IsNameEngSet();
            public override object? Get(object target) => ((BreedIBreedProjection)target).NameEng;
            public override void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_nameEng = true;
            public override void Set(object target, object? value) => ((BreedIBreedProjection)target).SetNameEng((String)value!);
            public override bool IsModified(object target) => ((BreedIBreedProjection)target)._projector.IsNameEngModified();
            public override bool IsInitial(object target) => ((BreedIBreedProjection)target)._projector.IsNameEngInitial();
            public override void CancelChange(object target) => ((BreedIBreedProjection)target)._projector.NameEngCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((BreedIBreedProjection)target)._projector._initial_nameEng : default!;
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
            public override bool IsSet(object target) => ((BreedIBreedProjection)target)._projector.IsNameNatSet();
            public override object? Get(object target) => ((BreedIBreedProjection)target).NameNat;
            public override void Touch(object target) => ((BreedIBreedProjection)target)._projector._is_set_nameNat = true;
            public override void Set(object target, object? value) => ((BreedIBreedProjection)target).SetNameNat((String)value!);
            public override bool IsModified(object target) => ((BreedIBreedProjection)target)._projector.IsNameNatModified();
            public override bool IsInitial(object target) => ((BreedIBreedProjection)target)._projector.IsNameNatInitial();
            public override void CancelChange(object target) => ((BreedIBreedProjection)target)._projector.NameNatCancelChange();
            public override void AcceptChange(object target) => throw new InvalidOperationException();
            public override object? GetInitial(object target) => IsSet(target) ? ((BreedIBreedProjection)target)._projector._initial_nameNat : default!;
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
        public override bool IsSet(object target) => ((BreedPoco)target).IsCodeSet();
        public override object? Get(object target) => ((BreedPoco)target).Code;
        public override void Touch(object target) => ((BreedPoco)target)._is_set_code = true;
        public override void Set(object target, object? value) => ((BreedPoco)target).SetCode((String)value!);
        public override bool IsModified(object target) => ((BreedPoco)target).IsCodeModified();
        public override bool IsInitial(object target) => ((BreedPoco)target).IsCodeInitial();
        public override void CancelChange(object target) => ((BreedPoco)target).CodeCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => IsSet(target) ? ((BreedPoco)target)._initial_code : default!;
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
        public override bool IsSet(object target) => ((BreedPoco)target).IsGroupSet();
        public override object? Get(object target) => ((BreedPoco)target).Group;
        public override void Touch(object target) => ((BreedPoco)target)._is_set_group = true;
        public override void Set(object target, object? value) => ((BreedPoco)target).SetGroup((String)value!);
        public override bool IsModified(object target) => ((BreedPoco)target).IsGroupModified();
        public override bool IsInitial(object target) => ((BreedPoco)target).IsGroupInitial();
        public override void CancelChange(object target) => ((BreedPoco)target).GroupCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => IsSet(target) ? ((BreedPoco)target)._initial_group : default!;
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
        public override bool IsSet(object target) => ((BreedPoco)target).IsNameEngSet();
        public override object? Get(object target) => ((BreedPoco)target).NameEng;
        public override void Touch(object target) => ((BreedPoco)target)._is_set_nameEng = true;
        public override void Set(object target, object? value) => ((BreedPoco)target).SetNameEng((String)value!);
        public override bool IsModified(object target) => ((BreedPoco)target).IsNameEngModified();
        public override bool IsInitial(object target) => ((BreedPoco)target).IsNameEngInitial();
        public override void CancelChange(object target) => ((BreedPoco)target).NameEngCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => IsSet(target) ? ((BreedPoco)target)._initial_nameEng : default!;
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
        public override bool IsSet(object target) => ((BreedPoco)target).IsNameNatSet();
        public override object? Get(object target) => ((BreedPoco)target).NameNat;
        public override void Touch(object target) => ((BreedPoco)target)._is_set_nameNat = true;
        public override void Set(object target, object? value) => ((BreedPoco)target).SetNameNat((String)value!);
        public override bool IsModified(object target) => ((BreedPoco)target).IsNameNatModified();
        public override bool IsInitial(object target) => ((BreedPoco)target).IsNameNatInitial();
        public override void CancelChange(object target) => ((BreedPoco)target).NameNatCancelChange();
        public override void AcceptChange(object target) => throw new InvalidOperationException();
        public override object? GetInitial(object target) => IsSet(target) ? ((BreedPoco)target)._initial_nameNat : default!;
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
                }
                return _asBreedIBreedProjection;
            }
        }

#endregion Projection Properties;


    
#region Properties

    private void SetCode(String value)
    {
        if(_code != value)
        {
            lock(_lock)
            {
                if(_code != value  && (IsBeingPopulated || IsCodeSet()))
                {
                    int selector = 0;
                    if (!IsBeingPopulated || IsCodeInitial())
                    {
                        _code = value!;
                    }
                    if ((IsBeingPopulated && (selector = 1) == selector)  || (((IEntity)this).PocoState is PocoState.Created && (selector = 2) == selector))
                    {
                        if(selector == 1)
                        {
                            _initial_code = value!;
                        }
                        _is_set_code = true;
                    }
                    OnPocoChanged(CodeProp);
                    OnPropertyChanged(nameof(Code));
                }
            }
        }
    }
    

    public virtual String Code
    {
        get => !IsCodeSet() ? default! : _code;
        set => SetCode(value);
    }

    private void SetGroup(String value)
    {
        if(_group != value)
        {
            lock(_lock)
            {
                if(_group != value  && (IsBeingPopulated || IsGroupSet()))
                {
                    int selector = 0;
                    if (!IsBeingPopulated || IsGroupInitial())
                    {
                        _group = value!;
                    }
                    if ((IsBeingPopulated && (selector = 1) == selector)  || (((IEntity)this).PocoState is PocoState.Created && (selector = 2) == selector))
                    {
                        if(selector == 1)
                        {
                            _initial_group = value!;
                        }
                        _is_set_group = true;
                    }
                    OnPocoChanged(GroupProp);
                    OnPropertyChanged(nameof(Group));
                }
            }
        }
    }
    

    public virtual String Group
    {
        get => !IsGroupSet() ? default! : _group;
        set => SetGroup(value);
    }

    private void SetNameEng(String? value)
    {
        if(_nameEng != value)
        {
            lock(_lock)
            {
                if(_nameEng != value  && (IsBeingPopulated || IsNameEngSet()))
                {
                    int selector = 0;
                    if (!IsBeingPopulated || IsNameEngInitial())
                    {
                        _nameEng = value;
                    }
                    if ((IsBeingPopulated && (selector = 1) == selector)  || (((IEntity)this).PocoState is PocoState.Created && (selector = 2) == selector))
                    {
                        if(selector == 1)
                        {
                            _initial_nameEng = value;
                        }
                        _is_set_nameEng = true;
                    }
                    OnPocoChanged(NameEngProp);
                    OnPropertyChanged(nameof(NameEng));
                }
            }
        }
    }
    

    public virtual String? NameEng
    {
        get => !IsNameEngSet() ? default! : _nameEng;
        set => SetNameEng(value);
    }

    private void SetNameNat(String? value)
    {
        if(_nameNat != value)
        {
            lock(_lock)
            {
                if(_nameNat != value  && (IsBeingPopulated || IsNameNatSet()))
                {
                    int selector = 0;
                    if (!IsBeingPopulated || IsNameNatInitial())
                    {
                        _nameNat = value;
                    }
                    if ((IsBeingPopulated && (selector = 1) == selector)  || (((IEntity)this).PocoState is PocoState.Created && (selector = 2) == selector))
                    {
                        if(selector == 1)
                        {
                            _initial_nameNat = value;
                        }
                        _is_set_nameNat = true;
                    }
                    OnPocoChanged(NameNatProp);
                    OnPropertyChanged(nameof(NameNat));
                }
            }
        }
    }
    

    public virtual String? NameNat
    {
        get => !IsNameNatSet() ? default! : _nameNat;
        set => SetNameNat(value);
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
        if(type == GetType())
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


#endregion Methods;


    
#region Poco Changed


    private bool IsCodeInitial() => _initial_code == _code;

    private bool IsCodeModified() => _is_set_code 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsCodeInitial();

    private bool IsCodeSet() => _is_set_code || ((IEntity)this).PocoState is PocoState.Created;

    private void CodeCancelChange()
    {
        Code = _initial_code;

    }



    private bool IsGroupInitial() => _initial_group == _group;

    private bool IsGroupModified() => _is_set_group 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsGroupInitial();

    private bool IsGroupSet() => _is_set_group || ((IEntity)this).PocoState is PocoState.Created;

    private void GroupCancelChange()
    {
        Group = _initial_group;

    }



    private bool IsNameEngInitial() => _initial_nameEng == _nameEng;

    private bool IsNameEngModified() => _is_set_nameEng 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameEngInitial();

    private bool IsNameEngSet() => _is_set_nameEng || ((IEntity)this).PocoState is PocoState.Created;

    private void NameEngCancelChange()
    {
        NameEng = _initial_nameEng;

    }



    private bool IsNameNatInitial() => _initial_nameNat == _nameNat;

    private bool IsNameNatModified() => _is_set_nameNat 
        && ((IPoco)this).PocoState is PocoState.Modified
                && !IsNameNatInitial();

    private bool IsNameNatSet() => _is_set_nameNat || ((IEntity)this).PocoState is PocoState.Created;

    private void NameNatCancelChange()
    {
        NameNat = _initial_nameNat;

    }




#endregion Poco Changed;


}




