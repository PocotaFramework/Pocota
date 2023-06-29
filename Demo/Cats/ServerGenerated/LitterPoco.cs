
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterPoco                                  //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-29T16:58:28                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterPoco : EntityBase, ILitter
{
    public class PrimaryKeyClass: LitterPrimaryKey
    {
        private readonly LitterPoco _owner;
        public override object? this[int index]
        {
            get
            {
                switch(index)
                {
                    case 0:
                        return _owner.Female.PrimaryKey.IdCat;
                    case 1:
                        return _owner.Female.PrimaryKey.IdCattery;
                    case 2:
                        return _owner.Order;
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
                        throw new InvalidOperationException();
                    case 1:
                        throw new InvalidOperationException();
                    case 2:
                        Int32? value2 = value as Int32?;
                        if(value is {} && value2 is null)
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
                switch(name)
                {
                    case "IdFemale":
                        return _owner.Female.PrimaryKey.IdCat;
                    case "IdFemaleCattery":
                        return _owner.Female.PrimaryKey.IdCattery;
                    case "IdLitter":
                        return _owner.Order;
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
                    case "IdFemale":
                        throw new InvalidOperationException();
                    case "IdFemaleCattery":
                        throw new InvalidOperationException();
                    case "IdLitter":
                        Int32? value2 = value as Int32?;
                        if(value is {} && value2 is null)
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
            get => _owner.Female.PrimaryKey.IdCat;
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override Int32? IdFemaleCattery 
        {
            get => _owner.Female.PrimaryKey.IdCattery;
            set
            {
                throw new InvalidOperationException();
            }
        }
        public override Int32? IdLitter 
        {
            get => _owner.Order;
            set
            {
                if(!_owner.IsUnderConstruction)
                {
                    throw new InvalidOperationException();
                }
                Int32? value1 = value as Int32?;
                if(value is {} && value1 is null)
                {
                    throw new InvalidCastException();
                }
                _owner.Order = (Int32)value1!;
            }
        }
        internal PrimaryKeyClass(LitterPoco owner)
        {
            _owner = owner;
        }
    }

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
        public PropertyAccessMode GetAccess(object obj)
        {
            throw new InvalidOperationException();
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
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
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is LitterPoco obj1 ? obj1._orderAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is LitterPoco obj1)
            {
                obj1._orderAccessMode  = mode;
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
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is LitterPoco obj1 ? obj1._femaleAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is LitterPoco obj1)
            {
                obj1._femaleAccessMode  = mode;
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
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is LitterPoco obj1 ? obj1._dateAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is LitterPoco obj1)
            {
                obj1._dateAccessMode  = mode;
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
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is LitterPoco obj1 ? obj1._maleAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is LitterPoco obj1)
            {
                obj1._maleAccessMode  = mode;
            }
        }
    }

    public static PropertyClass s_Property = new();
    public static OrderPropertyClass s_OrderProperty = new();
    public static FemalePropertyClass s_FemaleProperty = new();
    public static DatePropertyClass s_DateProperty = new();
    public static MalePropertyClass s_MaleProperty = new();

    private Int32 _order;
    private PropertyAccessMode _orderAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco _female = null!;
    private PropertyAccessMode _femaleAccessMode = PropertyAccessMode.Forbidden;
    private DateOnly _date;
    private PropertyAccessMode _dateAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _male = null;
    private PropertyAccessMode _maleAccessMode = PropertyAccessMode.Forbidden;

    public PrimaryKeyClass PrimaryKey { get; init; }

    public LitterPoco()
    {
        PrimaryKey = new(this);
    }

    public Int32 Order
    {
        get
        {
            if(_orderAccessMode is PropertyAccessMode.Forbidden)
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
            if(_femaleAccessMode is PropertyAccessMode.Forbidden)
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
            if(_dateAccessMode is PropertyAccessMode.Forbidden)
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
            if(_maleAccessMode is PropertyAccessMode.Forbidden)
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
}