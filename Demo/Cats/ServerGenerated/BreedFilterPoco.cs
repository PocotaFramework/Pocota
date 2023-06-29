
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.BreedFilterPoco                             //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-29T18:36:47                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class BreedFilterPoco : Pocota.Server.PocoBase, IBreedFilter
{
    public class PropertyClass: IProperty
    {
        public string Name => string.Empty;
        public Type Type => typeof(BreedFilterPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => false;
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
    public class SearchRegexPropertyClass: IProperty
    {
        public string Name => "SearchRegex";
        public Type Type => typeof(String);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is BreedFilterPoco obj1 ? obj1._searchRegexAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is BreedFilterPoco obj1)
            {
                obj1._searchRegexAccessMode  = mode;
            }
        }
    }

    public static PropertyClass s_Property = new();
    public static SearchRegexPropertyClass s_SearchRegexProperty = new();

    private String? _searchRegex = null;
    private PropertyAccessMode _searchRegexAccessMode = PropertyAccessMode.Forbidden;


    public BreedFilterPoco()
    {
    }

    public String? SearchRegex
    {
        get
        {
            if(_searchRegexAccessMode is PropertyAccessMode.Forbidden)
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
}