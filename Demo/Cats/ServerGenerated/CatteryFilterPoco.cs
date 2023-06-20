
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.CatteryFilterPoco                           //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-20T19:08:45                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatteryFilterPoco : Server.PocoBase, ICatteryFilter, Server.IPoco
{
    private String? _searchRegex;
    private PropertyAccessMode _accessModeSearchRegex = PropertyAccessMode.Forbidden;
    public String? SearchRegex
    {
        get
        {
            if(_accessModeSearchRegex is PropertyAccessMode.Forbidden)
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