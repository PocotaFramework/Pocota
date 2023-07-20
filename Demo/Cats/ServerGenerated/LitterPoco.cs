
///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterPoco                                      //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-20T17:48:18.                                                           //
// Modifying this file will break the program!                                       //
///////////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterPoco : EntityBase, ILitter
{
    #region PrimaryKey    
    public class PrimaryKeyClass: LitterPrimaryKey
    {
        private readonly LitterPoco _owner;
        public override object? this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                       return ((CatPrimaryKey)_owner.Female.PrimaryKey).IdCat;
                    case 1:
                       return ((CatPrimaryKey)_owner.Female.PrimaryKey).IdCattery;
                    case 2:
                       return _owner._order;
                    default:
                        return base[index];
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        Int32? value0 = value as Int32?;
                        if (value is null || value0 is null)
                        {
                            throw new InvalidCastException();
                        }
                        ((CatPrimaryKey)_owner.Female.PrimaryKey).IdCat = (Int32)value0!;
                        break;
                    case 1:
                        Int32? value1 = value as Int32?;
                        if (value is null || value1 is null)
                        {
                            throw new InvalidCastException();
                        }
                        ((CatPrimaryKey)_owner.Female.PrimaryKey).IdCattery = (Int32)value1!;
                        break;
                    case 2:
                        Int32? value2 = value as Int32?;
                        if (value is null || value2 is null)
                        {
                            throw new InvalidCastException();
                        }
                        _owner.Order = (Int32)value2!;
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
                    case "IdFemale":
                       return ((CatPrimaryKey)_owner.Female.PrimaryKey).IdCat;
                    case "IdFemaleCattery":
                       return ((CatPrimaryKey)_owner.Female.PrimaryKey).IdCattery;
                    case "IdLitter":
                       return _owner._order;
                    default:
                        return base[name];
                }
            }
            set
            {
                switch(name)
                {
                    case "IdFemale":
                        Int32? value0 = value as Int32?;
                        if (value is null || value0 is null)
                        {
                            throw new InvalidCastException();
                        }
                        ((CatPrimaryKey)_owner.Female.PrimaryKey).IdCat = (Int32)value0!;
                        break;
                    case "IdFemaleCattery":
                        Int32? value1 = value as Int32?;
                        if (value is null || value1 is null)
                        {
                            throw new InvalidCastException();
                        }
                        ((CatPrimaryKey)_owner.Female.PrimaryKey).IdCattery = (Int32)value1!;
                        break;
                    case "IdLitter":
                        Int32? value2 = value as Int32?;
                        if (value is null || value2 is null)
                        {
                            throw new InvalidCastException();
                        }   
                        _owner.Order = (Int32)value2!;
                        break;
                    default:
                        base[name] = value;
                        break;
                }
            }
        }
        public override Int32? IdFemale 
        {
            get
            {
                       return ((CatPrimaryKey)_owner.Female.PrimaryKey).IdCat;
            }
            set
            {
                Int32? value1 = value as Int32?;
                if (value is null || value1 is null)
                {
                    throw new InvalidCastException();
                }
                ((CatPrimaryKey)_owner.Female.PrimaryKey).IdCat = (Int32)value1!;
            }
        }
        public override Int32? IdFemaleCattery 
        {
            get
            {
                       return ((CatPrimaryKey)_owner.Female.PrimaryKey).IdCattery;
            }
            set
            {
                Int32? value1 = value as Int32?;
                if (value is null || value1 is null)
                {
                    throw new InvalidCastException();
                }
                ((CatPrimaryKey)_owner.Female.PrimaryKey).IdCattery = (Int32)value1!;
            }
        }
        
        public override bool IsAssigned 
        {
            get
            {
                return s_FemaleProperty.GetAccess(_owner) is not PropertyAccessMode.Denied 
                    && s_FemaleProperty.GetAccess(_owner) is not PropertyAccessMode.Denied 
                    && s_OrderProperty.GetAccess(_owner) is not PropertyAccessMode.Denied 
                    && base.IsAssigned;
            }
        }
        
        internal PrimaryKeyClass(LitterPoco owner)
        {
            _owner = owner;
        }
    }
    #endregion PrimaryKey  

    #region Property classes
    public class PropertyClass: Property
    {
        public override string Name => string.Empty;
        public override Type Type => typeof(LitterPoco);
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
    public class OrderPropertyClass: Property
    {
        public override string Name => "Order";
        public override Type Type => typeof(Int32);
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
            return target is LitterPoco target1 ? target1._orderAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            Int32? value1 = value as Int32?;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterPoco)target).Order = (Int32)value1!;
        }
        public override object? GetValue(object target)
        {
            return ((LitterPoco)target).Order;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterPoco target1)
            {
                target1._orderAccessMode  = mode;
            }
        }
    }
    public class FemalePropertyClass: Property
    {
        public override string Name => "Female";
        public override Type Type => typeof(CatPoco);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => true;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is LitterPoco target1 ? target1._femaleAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterPoco)target).Female = value1!;
        }
        public override object? GetValue(object target)
        {
            return ((LitterPoco)target).Female;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterPoco target1)
            {
                target1._femaleAccessMode  = mode;
            }
        }
    }
    public class DatePropertyClass: Property
    {
        public override string Name => "Date";
        public override Type Type => typeof(DateOnly);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is LitterPoco target1 ? target1._dateAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            DateOnly? value1 = value as DateOnly?;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterPoco)target).Date = (DateOnly)value1!;
        }
        public override object? GetValue(object target)
        {
            return ((LitterPoco)target).Date;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterPoco target1)
            {
                target1._dateAccessMode  = mode;
            }
        }
    }
    public class MalePropertyClass: Property
    {
        public override string Name => "Male";
        public override Type Type => typeof(CatPoco);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is LitterPoco target1 ? target1._maleAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((LitterPoco)target).Male = value1;
        }
        public override object? GetValue(object target)
        {
            return ((LitterPoco)target).Male;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterPoco target1)
            {
                target1._maleAccessMode  = mode;
            }
        }
    }
    #endregion Property classes

    #region Property fields
    public static PropertyClass s_Property = new();
    public static OrderPropertyClass s_OrderProperty = new();
    public static FemalePropertyClass s_FemaleProperty = new();
    public static DatePropertyClass s_DateProperty = new();
    public static MalePropertyClass s_MaleProperty = new();
    #endregion Property fields

    #region fields
    private Int32 _order;
    private PropertyAccessMode _orderAccessMode = PropertyAccessMode.NotSet;
    private CatPoco _female = null!;
    private PropertyAccessMode _femaleAccessMode = PropertyAccessMode.NotSet;
    private DateOnly _date;
    private PropertyAccessMode _dateAccessMode = PropertyAccessMode.NotSet;
    private CatPoco? _male = null;
    private PropertyAccessMode _maleAccessMode = PropertyAccessMode.NotSet;
    #endregion fields

    private readonly PrimaryKeyClass _primaryKey;
    public override IPrimaryKey PrimaryKey => _primaryKey;

    public LitterPoco(IServiceProvider services) : base(services)
    {
        _primaryKey = new(this);
    }

    #region properties
    public Int32 Order
    {
        get
        {
            if(_orderAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _order;
        }
        set
        {
            if(_orderAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            OnPropertyIsSet();
            _orderAccessMode = PropertyAccessMode.Full;
            _order = value;
        }
    }
    Int32 ILitter.Order
    {
        get
        {
            return Order;
        }
       set
        {
            Order = value;
        }
    }
    public CatPoco Female
    {
        get
        {
            if(_femaleAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _female;
        }
        set
        {
            if(_femaleAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            OnPropertyIsSet();
            _femaleAccessMode = PropertyAccessMode.Full;
            _female = value;
        }
    }
    ICat ILitter.Female
    {
        get
        {
            return Female;
        }
       set
        {
            Female = (value as CatPoco)!;
        }
    }
    public DateOnly Date
    {
        get
        {
            if(_dateAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _date;
        }
        set
        {
            if(_dateAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            OnPropertyIsSet();
            _dateAccessMode = PropertyAccessMode.Full;
            _date = value;
        }
    }
    DateOnly ILitter.Date
    {
        get
        {
            return Date;
        }
       set
        {
            Date = value;
        }
    }
    public CatPoco? Male
    {
        get
        {
            if(_maleAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _male;
        }
        set
        {
            if(_maleAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            OnPropertyIsSet();
            _maleAccessMode = PropertyAccessMode.Full;
            _male = value;
        }
    }
    ICat? ILitter.Male
    {
        get
        {
            return Male;
        }
       set
        {
            Male = (value as CatPoco)!;
        }
    }
    #endregion properties
}