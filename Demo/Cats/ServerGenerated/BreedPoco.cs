
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.BreedPoco                                   //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-02T16:37:21                                                        //
///////////////////////////////////////////////////////////////////////////////////

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
                switch(index)
                {
                    case 0:
                       return _owner.Code;
                    case 1:
                       return _owner.Group;
                    default:
                        return base[index];
                }
            }
            set
            {
                if(!_owner.IsUnderConstruction)
                {
                    throw new InvalidOperationException();
                }
                switch(index)
                {
                    case 0:
                        String value0 = value as String;
                        if(value is {} && value0 is null)
                        {
                            throw new InvalidCastException();
                        }
                            _owner.Code = (String)value0!;
                        break;
                    case 1:
                        String value1 = value as String;
                        if(value is {} && value1 is null)
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
                switch(name)
                {
                    case "IdBreed":
                       return _owner.Code;
                    case "IdGroup":
                       return _owner.Group;
                    default:
                        return base[name];
                }
            }
            set
            {
                if(!_owner.IsUnderConstruction)
                {
                    throw new InvalidOperationException();
                }
                switch(name)
                {
                    case "IdBreed":
                        String value0 = value as String;
                        if(value is {} && value0 is null)
                        {
                            throw new InvalidCastException();
                        }   
                        _owner.Code = (String)value0!;
                        break;
                    case "IdGroup":
                        String value1 = value as String;
                        if(value is {} && value1 is null)
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
        internal PrimaryKeyClass(BreedPoco owner)
        {
            _owner = owner;
        }
    }
    #endregion PrimaryKey  

    #region Property classes
    public class PropertyClass: IProperty
    {
        public string Name => string.Empty;
        public Type Type => typeof(BreedPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            throw new InvalidOperationException();
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
        }
    }
    public class CodePropertyClass: IProperty
    {
        public string Name => "Code";
        public Type Type => typeof(String);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is BreedPoco obj1 ? obj1._codeAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is BreedPoco obj1)
            {
                obj1._codeAccessMode  = mode;
            }
        }
    }
    public class GroupPropertyClass: IProperty
    {
        public string Name => "Group";
        public Type Type => typeof(String);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is BreedPoco obj1 ? obj1._groupAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is BreedPoco obj1)
            {
                obj1._groupAccessMode  = mode;
            }
        }
    }
    public class NameNatPropertyClass: IProperty
    {
        public string Name => "NameNat";
        public Type Type => typeof(String);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is BreedPoco obj1 ? obj1._nameNatAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is BreedPoco obj1)
            {
                obj1._nameNatAccessMode  = mode;
            }
        }
    }
    public class NameEngPropertyClass: IProperty
    {
        public string Name => "NameEng";
        public Type Type => typeof(String);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is BreedPoco obj1 ? obj1._nameEngAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is BreedPoco obj1)
            {
                obj1._nameEngAccessMode  = mode;
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
    private PropertyAccessMode _codeAccessMode = PropertyAccessMode.Forbidden;
    private String _group = null!;
    private PropertyAccessMode _groupAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameNat = null;
    private PropertyAccessMode _nameNatAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameEng = null;
    private PropertyAccessMode _nameEngAccessMode = PropertyAccessMode.Forbidden;
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
            if(_codeAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _code;
        }
        set
        {
            if(!IsUnderConstruction && _codeAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
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
            if(_groupAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _group;
        }
        set
        {
            if(!IsUnderConstruction && _groupAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
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
            if(_nameNatAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _nameNat;
        }
        set
        {
            if(!IsUnderConstruction && _nameNatAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
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
            if(_nameEngAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _nameEng;
        }
        set
        {
            if(!IsUnderConstruction && _nameEngAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
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