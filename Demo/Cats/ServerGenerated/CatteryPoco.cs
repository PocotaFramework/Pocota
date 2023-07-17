
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatteryPoco                                 //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-17T18:27:20                                                        //
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
    public class PropertyClass: Property
    {
        public override string Name => string.Empty;
        public override Type Type => typeof(CatteryPoco);
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
            return target is CatteryPoco target1 ? target1._nameEngAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatteryPoco)target).NameEng = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatteryPoco)target).NameEng;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatteryPoco target1)
            {
                target1._nameEngAccessMode  = mode;
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
            return target is CatteryPoco target1 ? target1._nameNatAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatteryPoco)target).NameNat = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatteryPoco)target).NameNat;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
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
    private PropertyAccessMode _nameEngAccessMode = PropertyAccessMode.NotSet;
    private String? _nameNat = null;
    private PropertyAccessMode _nameNatAccessMode = PropertyAccessMode.NotSet;
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
            if(_nameEngAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _nameEng;
        }
        set
        {
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
            if(_nameNatAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _nameNat;
        }
        set
        {
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