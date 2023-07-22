
///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.BreedPoco                                       //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-22T09:17:59.                                                           //
// Modifying this file will break the program!                                       //
///////////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class BreedPoco : EntityBase, IBreed
{
    #region PrimaryKey    
    public class PrimaryKeyClass: BreedPrimaryKey
    {
        private readonly BreedPoco _owner;
        public override object? this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                       return _owner._code;
                    case 1:
                       return _owner._group;
                    default:
                        return base[index];
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        String value0 = value as String;
                        if (value is null || value0 is null)
                        {
                            throw new InvalidCastException();
                        }
                        _owner.Code = (String)value0!;
                        break;
                    case 1:
                        String value1 = value as String;
                        if (value is null || value1 is null)
                        {
                            throw new InvalidCastException();
                        }
                        _owner.Group = (String)value1!;
                        break;
                    default:
                        base[index] = value;
                        break;
                }
            }
        }
        public override object? this[string name]
        {
            get
            {
                switch (name)
                {
                    case "IdBreed":
                       return _owner._code;
                    case "IdGroup":
                       return _owner._group;
                    default:
                        return base[name];
                }
            }
            set
            {
                switch(name)
                {
                    case "IdBreed":
                        String value0 = value as String;
                        if (value is null || value0 is null)
                        {
                            throw new InvalidCastException();
                        }   
                        _owner.Code = (String)value0!;
                        break;
                    case "IdGroup":
                        String value1 = value as String;
                        if (value is null || value1 is null)
                        {
                            throw new InvalidCastException();
                        }   
                        _owner.Group = (String)value1!;
                        break;
                    default:
                        base[name] = value;
                        break;
                }
            }
        }
        
        public override bool IsAssigned 
        {
            get
            {
                return s_CodeProperty.GetAccess(_owner) is not PropertyAccessMode.Denied 
                    && s_GroupProperty.GetAccess(_owner) is not PropertyAccessMode.Denied 
                    && base.IsAssigned;
            }
        }
        
        internal PrimaryKeyClass(BreedPoco owner)
        {
            _owner = owner;
        }
    }
    #endregion PrimaryKey  

    #region Property classes
    public class PropertyClass: Property
    {
        public override string Name => string.Empty;
        public override Type Type => typeof(BreedPoco);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            throw new InvalidOperationException();
        }
        protected override void SetValue(object target, object? value)
        {
            throw new InvalidOperationException();
        }
        public override object? GetValue(object target)
        {
            throw new InvalidOperationException();
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
        }
    }
    public class CodePropertyClass: Property
    {
        public override string Name => "Code";
        public override Type Type => typeof(String);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => true;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is BreedPoco target1 ? target1._codeAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((BreedPoco)target).Code = value1!;
        }
        public override object? GetValue(object target)
        {
            return ((BreedPoco)target).Code;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is BreedPoco target1)
            {
                target1._codeAccessMode  = mode;
            }
        }
    }
    public class GroupPropertyClass: Property
    {
        public override string Name => "Group";
        public override Type Type => typeof(String);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => true;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is BreedPoco target1 ? target1._groupAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((BreedPoco)target).Group = value1!;
        }
        public override object? GetValue(object target)
        {
            return ((BreedPoco)target).Group;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is BreedPoco target1)
            {
                target1._groupAccessMode  = mode;
            }
        }
    }
    public class NameNatPropertyClass: Property
    {
        public override string Name => "NameNat";
        public override Type Type => typeof(String);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is BreedPoco target1 ? target1._nameNatAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((BreedPoco)target).NameNat = value1;
        }
        public override object? GetValue(object target)
        {
            return ((BreedPoco)target).NameNat;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is BreedPoco target1)
            {
                target1._nameNatAccessMode  = mode;
            }
        }
    }
    public class NameEngPropertyClass: Property
    {
        public override string Name => "NameEng";
        public override Type Type => typeof(String);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is BreedPoco target1 ? target1._nameEngAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((BreedPoco)target).NameEng = value1;
        }
        public override object? GetValue(object target)
        {
            return ((BreedPoco)target).NameEng;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is BreedPoco target1)
            {
                target1._nameEngAccessMode  = mode;
            }
        }
    }
    #endregion Property classes

    #region Property fields
    public static PropertyClass s_Property = new();
    public static CodePropertyClass s_CodeProperty = new();
    public static GroupPropertyClass s_GroupProperty = new();
    public static NameNatPropertyClass s_NameNatProperty = new();
    public static NameEngPropertyClass s_NameEngProperty = new();
    #endregion Property fields

    #region fields
    private String _code = null!;
    private PropertyAccessMode _codeAccessMode = PropertyAccessMode.NotSet;
    private String _group = null!;
    private PropertyAccessMode _groupAccessMode = PropertyAccessMode.NotSet;
    private String? _nameNat = null;
    private PropertyAccessMode _nameNatAccessMode = PropertyAccessMode.NotSet;
    private String? _nameEng = null;
    private PropertyAccessMode _nameEngAccessMode = PropertyAccessMode.NotSet;
    #endregion fields

    private readonly PrimaryKeyClass _primaryKey;
    public override IPrimaryKey PrimaryKey => _primaryKey;

    public BreedPoco(IServiceProvider services) : base(services)
    {
        _primaryKey = new(this);
    }

    #region properties
    public String Code
    {
        get
        {
            if(_codeAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _code;
        }
        set
        {
            if(_codeAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            OnPropertyIsSet();
            _codeAccessMode = PropertyAccessMode.Full;
            _code = value;
        }
    }
    String IBreed.Code
    {
        get
        {
            return Code;
        }
       set
        {
            Code = value;
        }
    }
    public String Group
    {
        get
        {
            if(_groupAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _group;
        }
        set
        {
            if(_groupAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            OnPropertyIsSet();
            _groupAccessMode = PropertyAccessMode.Full;
            _group = value;
        }
    }
    String IBreed.Group
    {
        get
        {
            return Group;
        }
       set
        {
            Group = value;
        }
    }
    public String? NameNat
    {
        get
        {
            if(_nameNatAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _nameNat;
        }
        set
        {
            if(_nameNatAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            OnPropertyIsSet();
            _nameNatAccessMode = PropertyAccessMode.Full;
            _nameNat = value;
        }
    }
    String? IBreed.NameNat
    {
        get
        {
            return NameNat;
        }
       set
        {
            NameNat = value;
        }
    }
    public String? NameEng
    {
        get
        {
            if(_nameEngAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _nameEng;
        }
        set
        {
            if(_nameEngAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            OnPropertyIsSet();
            _nameEngAccessMode = PropertyAccessMode.Full;
            _nameEng = value;
        }
    }
    String? IBreed.NameEng
    {
        get
        {
            return NameEng;
        }
       set
        {
            NameEng = value;
        }
    }
    #endregion properties
}