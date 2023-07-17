
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterWithCatsPoco                          //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-17T18:27:20                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
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
    public class StringsPropertyClass: Property
    {
        public override string Name => "Strings";
        public override Type Type => typeof(List<String>);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => true;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => typeof(String);
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is LitterWithCatsPoco target1 ? target1._stringsAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            IList<String>? value1 = value as IList<String>;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterWithCatsPoco)target).Strings = value1!;
        }
        public override object? GetValue(object target)
        {
            return ((LitterWithCatsPoco)target).Strings;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterWithCatsPoco target1)
            {
                target1._stringsAccessMode  = mode;
            }
        }
    }
    public class ListsPropertyClass: Property
    {
        public override string Name => "Lists";
        public override Type Type => typeof(List<IList<String>>);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => true;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => typeof(IList<String>);
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is LitterWithCatsPoco target1 ? target1._listsAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            IList<IList<String>>? value1 = value as IList<IList<String>>;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterWithCatsPoco)target).Lists = value1!;
        }
        public override object? GetValue(object target)
        {
            return ((LitterWithCatsPoco)target).Lists;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterWithCatsPoco target1)
            {
                target1._listsAccessMode  = mode;
            }
        }
    }
    public class CatFilterPropertyClass: Property
    {
        public override string Name => "CatFilter";
        public override Type Type => typeof(CatFilterPoco);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is LitterWithCatsPoco target1 ? target1._catFilterAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatFilterPoco? value1 = value as CatFilterPoco;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterWithCatsPoco)target).CatFilter = value1!;
        }
        public override object? GetValue(object target)
        {
            return ((LitterWithCatsPoco)target).CatFilter;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterWithCatsPoco target1)
            {
                target1._catFilterAccessMode  = mode;
            }
        }
    }
    #endregion Property classes

    #region Property fields
    public static PropertyClass s_Property = new();
    public static CatsPropertyClass s_CatsProperty = new();
    public static StringsPropertyClass s_StringsProperty = new();
    public static ListsPropertyClass s_ListsProperty = new();
    public static CatFilterPropertyClass s_CatFilterProperty = new();
    #endregion Property fields

    #region fields
    private IList<CatPoco> _cats = null!;
    private IList<ICat> _catsProxy = null!;
    private PropertyAccessMode _catsAccessMode = PropertyAccessMode.NotSet;
    private IList<String> _strings = null!;
    private PropertyAccessMode _stringsAccessMode = PropertyAccessMode.NotSet;
    private IList<IList<String>> _lists = null!;
    private PropertyAccessMode _listsAccessMode = PropertyAccessMode.NotSet;
    private CatFilterPoco _catFilter = null!;
    private PropertyAccessMode _catFilterAccessMode = PropertyAccessMode.NotSet;
    #endregion fields

    public IPrimaryKey PrimaryKey { get; init; }

    public LitterWithCatsPoco(IServiceProvider services) : base(services)
    {
        PrimaryKey = _services.GetRequiredService<IPrimaryKey<ILitter>>();
    }

    #region properties
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
    public IList<String> Strings
    {
        get
        {
            if(_stringsAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _strings;
        }
        set
        {
            _stringsAccessMode = PropertyAccessMode.Full;
            _strings = value;
        }
    }
    IList<String> ILitterWithCats.Strings
    {
        get
        {
            return Strings;
        }
       set
        {
            Strings = value;
        }
    }
    public IList<IList<String>> Lists
    {
        get
        {
            if(_listsAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _lists;
        }
        set
        {
            _listsAccessMode = PropertyAccessMode.Full;
            _lists = value;
        }
    }
    IList<IList<String>> ILitterWithCats.Lists
    {
        get
        {
            return Lists;
        }
       set
        {
            Lists = value;
        }
    }
    public CatFilterPoco CatFilter
    {
        get
        {
            if(_catFilterAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _catFilter;
        }
        set
        {
            _catFilterAccessMode = PropertyAccessMode.Full;
            _catFilter = value;
        }
    }
    ICatFilter ILitterWithCats.CatFilter
    {
        get
        {
            return CatFilter;
        }
       set
        {
            CatFilter = (value as CatFilterPoco)!;
        }
    }
    #endregion properties
}