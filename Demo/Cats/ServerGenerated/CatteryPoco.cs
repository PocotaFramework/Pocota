
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatteryPoco                                 //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-29T17:39:46                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatteryPoco : EntityBase, ICattery
{
    public class PrimaryKeyClass: CatteryPrimaryKey
    {
        private readonly CatteryPoco _owner;
        public override object? this[int index]
        {
            get
            {
                switch(index)
                {
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
                    default:
                        base[name] = value;
                        break;
                }
            }
        }
        internal PrimaryKeyClass(CatteryPoco owner)
        {
            _owner = owner;
        }
    }

    public class PropertyClass: IProperty
    {
        public string Name => string.Empty;
        public Type Type => typeof(CatteryPoco);
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
            return obj is CatteryPoco obj1 ? obj1._nameEngAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatteryPoco obj1)
            {
                obj1._nameEngAccessMode  = mode;
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
            return obj is CatteryPoco obj1 ? obj1._nameNatAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatteryPoco obj1)
            {
                obj1._nameNatAccessMode  = mode;
            }
        }
    }

    public static PropertyClass s_Property = new();
    public static NameEngPropertyClass s_NameEngProperty = new();
    public static NameNatPropertyClass s_NameNatProperty = new();

    private String? _nameEng = null;
    private PropertyAccessMode _nameEngAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameNat = null;
    private PropertyAccessMode _nameNatAccessMode = PropertyAccessMode.Forbidden;

    public PrimaryKeyClass PrimaryKey { get; init; }

    public CatteryPoco()
    {
        PrimaryKey = new(this);
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
    String? ICattery.NameEng
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
    String? ICattery.NameNat
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
}