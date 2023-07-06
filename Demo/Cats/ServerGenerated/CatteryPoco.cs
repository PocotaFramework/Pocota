
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatteryPoco                                 //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-06T21:11:09                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatteryPoco : EntityBase, ICattery
{
    #region PrimaryKey    
    public class PrimaryKeyClass: CatteryPrimaryKey
    {
        private readonly CatteryPoco _owner;
        public override object? this[int index]
        {
            get
            {
                switch (index)
                {
                    default:
                        return base[index];
                }
            }
            set
            {
                if (!_owner.IsUnderConstruction)
                {
                    throw new InvalidOperationException();
                }
                switch (index)
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
                switch (name)
                {
                    default:
                        return base[name];
                }
            }
            set
            {
                if (!_owner.IsUnderConstruction)
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
        
        public override bool IsAssigned 
        {
            get
            {
                return base.IsAssigned;
            }
        }
        
        internal PrimaryKeyClass(CatteryPoco owner)
        {
            _owner = owner;
        }
    }
    #endregion PrimaryKey  

    #region Property classes
    public class PropertyClass: IProperty
    {
        public string Name => string.Empty;
        public Type Type => typeof(CatteryPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            throw new InvalidOperationException();
        }
        public object? GetValue(object target)
        {
            throw new InvalidOperationException();
        }
        public PropertyAccessMode GetAccess(object target)
        {
            throw new InvalidOperationException();
        }
        public void SetAccess(object target, PropertyAccessMode mode)
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
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatteryPoco)target).NameEng = value1;
        }
        public object? GetValue(object target)
        {
            return ((CatteryPoco)target).NameEng;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is CatteryPoco target1 ? target1._nameEngAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatteryPoco target1)
            {
                target1._nameEngAccessMode  = mode;
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
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatteryPoco)target).NameNat = value1;
        }
        public object? GetValue(object target)
        {
            return ((CatteryPoco)target).NameNat;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is CatteryPoco target1 ? target1._nameNatAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatteryPoco target1)
            {
                target1._nameNatAccessMode  = mode;
            }
        }
    }
    #endregion Property classes

    #region Property fields
    public static PropertyClass s_Property = new();
    public static NameEngPropertyClass s_NameEngProperty = new();
    public static NameNatPropertyClass s_NameNatProperty = new();
    #endregion Property fields

    #region fields
    private String? _nameEng = null;
    private PropertyAccessMode _nameEngAccessMode = PropertyAccessMode.Denied;
    private String? _nameNat = null;
    private PropertyAccessMode _nameNatAccessMode = PropertyAccessMode.Denied;
    #endregion fields

    private readonly PrimaryKeyClass _primaryKey;
    public override IPrimaryKey PrimaryKey => _primaryKey;

    public CatteryPoco(IServiceProvider services) : base(services)
    {
        _primaryKey = new(this);
    }

    #region properties
    public String? NameEng
    {
        get
        {
            if(_nameEngAccessMode is PropertyAccessMode.Denied)
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
            if(_nameNatAccessMode is PropertyAccessMode.Denied)
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
    #endregion properties
}