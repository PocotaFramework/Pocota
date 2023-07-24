
///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterWithCatsPoco                              //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-24T18:11:46.                                                           //
// Modifying this file will break the program!                                       //
///////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;
using System.Collections.Generic;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterWithCatsPoco : Pocota.Server.PocoBase, ILitterWithCats
{

    #region Property classes
    public class PropertyClass: Property
    {
        public override string Name => string.Empty;
        public override Type Type => typeof(LitterWithCatsPoco);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => true;
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
            return ((LitterWithCatsPoco)target).Core.Order;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
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
            return ((LitterWithCatsPoco)target).Core.Female;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
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
            throw new InvalidOperationException();
        }
        protected override void SetValue(object target, object? value)
        {
            throw new InvalidOperationException();
        }
        public override object? GetValue(object target)
        {
            return ((LitterWithCatsPoco)target).Core.Male;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
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
            throw new InvalidOperationException();
        }
        protected override void SetValue(object target, object? value)
        {
            throw new InvalidOperationException();
        }
        public override object? GetValue(object target)
        {
            return ((LitterWithCatsPoco)target).Core.Date;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
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
        public override bool IsExtender => false;
        public override Type? ItemType => typeof(CatPoco);
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is LitterWithCatsPoco target1 ? target1._catsAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            IList<CatPoco>? value1 = value as IList<CatPoco>;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterWithCatsPoco)target).Cats = value1!;
        }
        public override object? GetValue(object target)
        {
            return ((LitterWithCatsPoco)target).Cats;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterWithCatsPoco target1)
            {
                target1._catsAccessMode  = mode;
            }
        }
    }
    #endregion Property classes

    #region Property fields
    public static PropertyClass s_Property = new();
    public static OrderPropertyClass s_OrderProperty = new();
    public static FemalePropertyClass s_FemaleProperty = new();
    public static MalePropertyClass s_MaleProperty = new();
    public static DatePropertyClass s_DateProperty = new();
    public static CatsPropertyClass s_CatsProperty = new();
    #endregion Property fields

    #region fields
    private IList<CatPoco> _cats = null!;
    private IList<ICat> _catsProxy = null!;
    private PropertyAccessMode _catsAccessMode = PropertyAccessMode.NotSet;

    private ILitter? _core = null;

    #endregion fields

    #region properties

    public IPrimaryKey? PrimaryKey => ((EntityBase)Core)?.PrimaryKey;
    public ILitter Core 
    {
        get => _core; 
        set {
            if(_core is null && value is {})
            {
                _core = value;
            }
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
    IList<ICat> ILitterWithCats.Cats
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
    #endregion properties

    public LitterWithCatsPoco(IServiceProvider services) : base(services)
    {
    }

}