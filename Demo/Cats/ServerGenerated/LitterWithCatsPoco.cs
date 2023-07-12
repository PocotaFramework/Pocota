
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterWithCatsPoco                          //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-12T12:56:10                                                        //
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
    public class PropertyClass: IProperty
    {
        public string Name => string.Empty;
        public Type Type => typeof(LitterWithCatsPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => false;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => true;
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
    public class CatsPropertyClass: IProperty
    {
        public string Name => "Cats";
        public Type Type => typeof(List<CatPoco>);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => true;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => typeof(CatPoco);
        public void SetValue(object target, object? value)
        {
            IList<CatPoco>? value1 = value as IList<CatPoco>;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterWithCatsPoco)target).Cats = value1!;
        }
        public object? GetValue(object target)
        {
            return ((LitterWithCatsPoco)target).Cats;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is LitterWithCatsPoco target1 ? target1._catsAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterWithCatsPoco target1)
            {
                target1._catsAccessMode  = mode;
            }
        }
    }
    public class StringsPropertyClass: IProperty
    {
        public string Name => "Strings";
        public Type Type => typeof(List<String>);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => true;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => typeof(String);
        public void SetValue(object target, object? value)
        {
            IList<String>? value1 = value as IList<String>;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterWithCatsPoco)target).Strings = value1!;
        }
        public object? GetValue(object target)
        {
            return ((LitterWithCatsPoco)target).Strings;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is LitterWithCatsPoco target1 ? target1._stringsAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterWithCatsPoco target1)
            {
                target1._stringsAccessMode  = mode;
            }
        }
    }
    public class ListsPropertyClass: IProperty
    {
        public string Name => "Lists";
        public Type Type => typeof(List<IList<String>>);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => true;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => typeof(IList<String>);
        public void SetValue(object target, object? value)
        {
            IList<IList<String>>? value1 = value as IList<IList<String>>;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterWithCatsPoco)target).Lists = value1!;
        }
        public object? GetValue(object target)
        {
            return ((LitterWithCatsPoco)target).Lists;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is LitterWithCatsPoco target1 ? target1._listsAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is LitterWithCatsPoco target1)
            {
                target1._listsAccessMode  = mode;
            }
        }
    }
    public class CatFilterPropertyClass: IProperty
    {
        public string Name => "CatFilter";
        public Type Type => typeof(CatFilterPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => false;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            CatFilterPoco? value1 = value as CatFilterPoco;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((LitterWithCatsPoco)target).CatFilter = value1!;
        }
        public object? GetValue(object target)
        {
            return ((LitterWithCatsPoco)target).CatFilter;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is LitterWithCatsPoco target1 ? target1._catFilterAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
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
    private PropertyAccessMode _catsAccessMode = PropertyAccessMode.Denied;
    private IList<String> _strings = null!;
    private PropertyAccessMode _stringsAccessMode = PropertyAccessMode.Denied;
    private IList<IList<String>> _lists = null!;
    private PropertyAccessMode _listsAccessMode = PropertyAccessMode.Denied;
    private CatFilterPoco _catFilter = null!;
    private PropertyAccessMode _catFilterAccessMode = PropertyAccessMode.Denied;
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
            if(_catsAccessMode is PropertyAccessMode.Denied)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _cats;
        }
        set
        {
            if(!IsUnderConstruction && _catsAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
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
    public IList<String> Strings
    {
        get
        {
            if(_stringsAccessMode is PropertyAccessMode.Denied)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _strings;
        }
        set
        {
            if(!IsUnderConstruction && _stringsAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
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
            if(_listsAccessMode is PropertyAccessMode.Denied)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _lists;
        }
        set
        {
            if(!IsUnderConstruction && _listsAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
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
            if(_catFilterAccessMode is PropertyAccessMode.Denied)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _catFilter;
        }
        set
        {
            if(!IsUnderConstruction && _catFilterAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
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