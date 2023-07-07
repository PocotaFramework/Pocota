
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.BreedFilterPoco                             //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-07T17:04:43                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class BreedFilterPoco : Pocota.Server.PocoBase, IBreedFilter
{

    #region Property classes
    public class PropertyClass: IProperty
    {
        public string Name => string.Empty;
        public Type Type => typeof(BreedFilterPoco);
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
    public class SearchRegexPropertyClass: IProperty
    {
        public string Name => "SearchRegex";
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
            ((BreedFilterPoco)target).SearchRegex = value1;
        }
        public object? GetValue(object target)
        {
            return ((BreedFilterPoco)target).SearchRegex;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is BreedFilterPoco target1 ? target1._searchRegexAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is BreedFilterPoco target1)
            {
                target1._searchRegexAccessMode  = mode;
            }
        }
    }
    #endregion Property classes

    #region Property fields
    public static PropertyClass s_Property = new();
    public static SearchRegexPropertyClass s_SearchRegexProperty = new();
    #endregion Property fields

    #region fields
    private String? _searchRegex = null;
    private PropertyAccessMode _searchRegexAccessMode = PropertyAccessMode.Denied;
    #endregion fields


    public BreedFilterPoco(IServiceProvider services) : base(services)
    {
    }

    #region properties
    public String? SearchRegex
    {
        get
        {
            if(_searchRegexAccessMode is PropertyAccessMode.Denied)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _searchRegex;
        }
        set
        {
            if(!IsUnderConstruction && _searchRegexAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _searchRegexAccessMode = PropertyAccessMode.Full;
            _searchRegex = value;
        }
    }
    String? IBreedFilter.SearchRegex
    {
        get
        {
            return SearchRegex;
        }
       set
        {
            SearchRegex = value;
        }
    }
    #endregion properties
}