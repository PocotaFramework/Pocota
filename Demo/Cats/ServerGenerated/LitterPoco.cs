
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterPoco                                  //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-03T18:35:50                                                        //
///////////////////////////////////////////////////////////////////////////////////

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
                       return _owner.Order;
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
                       return _owner.Order;
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
                if (!_owner.IsUnderConstruction)
                {
                    throw new InvalidCastException();
                }
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
                if (!_owner.IsUnderConstruction)
                {
                    throw new InvalidCastException();
                }
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
    public class PropertyClass: IProperty
    {
        public string Name => string.Empty;
        public Type Type => typeof(LitterPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
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
    public class OrderPropertyClass: IProperty
    {
        public string Name => "Order";
        public Type Type => typeof(Int32);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            Int32? value1 = value as Int32?;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterPoco)target).Order = (Int32)value1!;
        }
        public object? GetValue(object target)
        {
            return ((LitterPoco)target).Order;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is LitterPoco target1 ? target1._orderAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterPoco target1)
            {
                target1._orderAccessMode  = mode;
            }
        }
    }
    public class FemalePropertyClass: IProperty
    {
        public string Name => "Female";
        public Type Type => typeof(CatPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterPoco)target).Female = value1!;
        }
        public object? GetValue(object target)
        {
            return ((LitterPoco)target).Female;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is LitterPoco target1 ? target1._femaleAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterPoco target1)
            {
                target1._femaleAccessMode  = mode;
            }
        }
    }
    public class DatePropertyClass: IProperty
    {
        public string Name => "Date";
        public Type Type => typeof(DateOnly);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            DateOnly? value1 = value as DateOnly?;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterPoco)target).Date = (DateOnly)value1!;
        }
        public object? GetValue(object target)
        {
            return ((LitterPoco)target).Date;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is LitterPoco target1 ? target1._dateAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterPoco target1)
            {
                target1._dateAccessMode  = mode;
            }
        }
    }
    public class MalePropertyClass: IProperty
    {
        public string Name => "Male";
        public Type Type => typeof(CatPoco);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            CatPoco? value1 = value as CatPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((LitterPoco)target).Male = value1;
        }
        public object? GetValue(object target)
        {
            return ((LitterPoco)target).Male;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is LitterPoco target1 ? target1._maleAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
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
    private PropertyAccessMode _orderAccessMode = PropertyAccessMode.Denied;
    private CatPoco _female = null!;
    private PropertyAccessMode _femaleAccessMode = PropertyAccessMode.Denied;
    private DateOnly _date;
    private PropertyAccessMode _dateAccessMode = PropertyAccessMode.Denied;
    private CatPoco? _male = null;
    private PropertyAccessMode _maleAccessMode = PropertyAccessMode.Denied;
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
            if(_orderAccessMode is PropertyAccessMode.Denied)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _order;
        }
        set
        {
            if(!IsUnderConstruction && _orderAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
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
            if(_femaleAccessMode is PropertyAccessMode.Denied)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _female;
        }
        set
        {
            if(!IsUnderConstruction && _femaleAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
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
            if(_dateAccessMode is PropertyAccessMode.Denied)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _date;
        }
        set
        {
            if(!IsUnderConstruction && _dateAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
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
            if(_maleAccessMode is PropertyAccessMode.Denied)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _male;
        }
        set
        {
            if(!IsUnderConstruction && _maleAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
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