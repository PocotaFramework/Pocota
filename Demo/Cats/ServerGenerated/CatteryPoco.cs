
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.CatteryPoco                                 //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-22T12:27:06                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatteryPoco : EntityBase
{
    private String? _nameEng = null;
    private PropertyAccessMode _nameEngAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameNat = null;
    private PropertyAccessMode _nameNatAccessMode = PropertyAccessMode.Forbidden;

    public CatteryPoco()
    {
    }

    public String? NameEng
    {
        get
        {
            if(_nameEngAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _nameEng;
        }
        set
        {
            if(!IsUnderConstruction && _nameEngAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _nameEngAccessMode = PropertyAccessMode.Full;
            _nameEng = value;
        }
    }
    public String? NameNat
    {
        get
        {
            if(_nameNatAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _nameNat;
        }
        set
        {
            if(!IsUnderConstruction && _nameNatAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _nameNatAccessMode = PropertyAccessMode.Full;
            _nameNat = value;
        }
    }
}