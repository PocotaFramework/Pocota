
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.CatteryFilterPoco                           //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-20T22:04:33                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatteryFilterPoco : Server.PocoBase, ICatteryFilter, Server.IPoco
{
    private String? _searchRegex;
    private PropertyAccessMode _searchRegexAccessMode = PropertyAccessMode.Forbidden;
    public String? SearchRegex
    {
        get
        {
            if(_searchRegexAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _searchRegex;
        }
        set
        {

        }
    }
}