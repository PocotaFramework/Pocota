
///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterPoco                                      //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-27T18:03:13.                                                           //
// Modifying this file will break the program!                                       //
///////////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;

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
    public class IdFemalePropertyClass: Property
    {
        public override string Name => "IdFemale";
        public override Type Type => typeof(Int32);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
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
            return ((LitterPrimaryKey)((LitterPoco)target).PrimaryKey).IdFemale;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
        }
    }
    public class IdFemaleCatteryPropertyClass: Property
    {
        public override string Name => "IdFemaleCattery";
        public override Type Type => typeof(Int32);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
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
            return ((LitterPrimaryKey)((LitterPoco)target).PrimaryKey).IdFemaleCattery;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
        }
    }
    public class IdLitterPropertyClass: Property
    {
        public override string Name => "IdLitter";
        public override Type Type => typeof(Int32);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
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
            return ((LitterPrimaryKey)((LitterPoco)target).PrimaryKey).IdLitter;
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
    public class CatsPropertyClass: Property
    {
        public override string Name => "Cats";
        public override Type Type => typeof(List<CatPoco>);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => true;
        public override bool IsKeyPart => false;
        public override Type? ItemType => typeof(CatPoco);
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is LitterPoco target1 ? target1._catsAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            IList<CatPoco>? value1 = value as IList<CatPoco>;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterPoco)target).Cats = value1!;
        }
        public override object? GetValue(object target)
        {
            return ((LitterPoco)target).Cats;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterPoco target1)
            {
                target1._catsAccessMode  = mode;
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
    #endregion Property classes

    #region Property fields
    public static PropertyClass s_Property = new();
    public static IdFemalePropertyClass s_IdFemaleProperty = new();
    public static IdFemaleCatteryPropertyClass s_IdFemaleCatteryProperty = new();
    public static IdLitterPropertyClass s_IdLitterProperty = new();
    public static OrderPropertyClass s_OrderProperty = new();
    public static FemalePropertyClass s_FemaleProperty = new();
    public static MalePropertyClass s_MaleProperty = new();
    public static CatsPropertyClass s_CatsProperty = new();
    public static DatePropertyClass s_DateProperty = new();
    #endregion Property fields

    #region fields
    private Int32 _order;
    private PropertyAccessMode _orderAccessMode = PropertyAccessMode.NotSet;
    private CatPoco _female = null!;
    private PropertyAccessMode _femaleAccessMode = PropertyAccessMode.NotSet;
    private CatPoco? _male = null;
    private PropertyAccessMode _maleAccessMode = PropertyAccessMode.NotSet;
    private IList<CatPoco> _cats = null!;
    private IList<ICat> _catsProxy = null!;
    private PropertyAccessMode _catsAccessMode = PropertyAccessMode.NotSet;
    private DateOnly _date;
    private PropertyAccessMode _dateAccessMode = PropertyAccessMode.NotSet;

    private readonly PrimaryKeyClass _primaryKey;

    #endregion fields

    #region properties

    public override IPrimaryKey PrimaryKey => _primaryKey;

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
    public IList<CatPoco> Cats
    {
        get
        {
            if(_catsAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _cats;
        }
        set
        {
            if(_catsAccessMode is not PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_alreadySet);
            }
            _catsAccessMode = PropertyAccessMode.Full;
            _cats = value;
            _catsProxy = new ListProxy<CatPoco, ICat>(_cats);
        }
    }
    IList<ICat> ILitter.Cats
    {
        get
        {
            return _catsProxy;
        }
       set
        {
            _catsProxy = value;
            _cats = new ListProxy<ICat, CatPoco>(_catsProxy);
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
    #endregion properties

    public LitterPoco(IServiceProvider services) : base(services)
    {
        _primaryKey = new(this);
    }

}