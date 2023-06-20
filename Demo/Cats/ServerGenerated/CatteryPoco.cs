
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.CatteryPoco                                 //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-20T19:08:45                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatteryPoco : Server.PocoBase, ICattery, IEntity
{
    private String? _nameEng;
    private PropertyAccessMode _accessModeNameEng = PropertyAccessMode.Forbidden;
    private String? _nameNat;
    private PropertyAccessMode _accessModeNameNat = PropertyAccessMode.Forbidden;
    public String? NameEng
    {
        get
        {
            if(_accessModeNameEng is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _nameEng;
        }
        set
        {

        }
    }
    public String? NameNat
    {
        get
        {
            if(_accessModeNameNat is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _nameNat;
        }
        set
        {

        }
    }
}