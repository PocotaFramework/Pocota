
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.BreedPoco                                   //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-20T22:04:33                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class BreedPoco : Server.PocoBase, IBreed, IEntity
{
    private String _code;
    private PropertyAccessMode _codeAccessMode = PropertyAccessMode.Forbidden;
    private String _group;
    private PropertyAccessMode _groupAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameEng;
    private PropertyAccessMode _nameEngAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameNat;
    private PropertyAccessMode _nameNatAccessMode = PropertyAccessMode.Forbidden;
    public String Code
    {
        get
        {
            if(_codeAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _code;
        }
        set
        {

        }
    }
    public String Group
    {
        get
        {
            if(_groupAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _group;
        }
        set
        {

        }
    }
    public String? NameEng
    {
        get
        {
            if(_nameEngAccessMode is PropertyAccessMode.Forbidden)
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
            if(_nameNatAccessMode is PropertyAccessMode.Forbidden)
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