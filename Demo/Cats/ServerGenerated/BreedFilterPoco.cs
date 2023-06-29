
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.BreedFilterPoco                             //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-29T10:49:35                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class BreedFilterPoco : Pocota.Server.PocoBase, IBreedFilter
{
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