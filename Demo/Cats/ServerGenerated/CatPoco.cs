
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.CatPoco                                     //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-20T19:08:45                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatPoco : Server.PocoBase, ICat, IEntity
{
    private CatteryPoco _cattery;
    private PropertyAccessMode _accessModeCattery = PropertyAccessMode.Forbidden;
    private String? _nameNat;
    private PropertyAccessMode _accessModeNameNat = PropertyAccessMode.Forbidden;
    private String? _nameEng;
    private PropertyAccessMode _accessModeNameEng = PropertyAccessMode.Forbidden;
    private Gender _gender;
    private PropertyAccessMode _accessModeGender = PropertyAccessMode.Forbidden;
    private BreedPoco _breed;
    private PropertyAccessMode _accessModeBreed = PropertyAccessMode.Forbidden;
    private LitterPoco? _litter;
    private PropertyAccessMode _accessModeLitter = PropertyAccessMode.Forbidden;
    private String? _exterior;
    private PropertyAccessMode _accessModeExterior = PropertyAccessMode.Forbidden;
    private String? _title;
    private PropertyAccessMode _accessModeTitle = PropertyAccessMode.Forbidden;
    private String? _description;
    private PropertyAccessMode _accessModeDescription = PropertyAccessMode.Forbidden;
    public ICattery Cattery
    {
        get
        {
            if(_accessModeCattery is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _cattery;
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
    public Gender Gender
    {
        get
        {
            if(_accessModeGender is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _gender;
        }
        set
        {

        }
    }
    public IBreed Breed
    {
        get
        {
            if(_accessModeBreed is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _breed;
        }
        set
        {

        }
    }
    public ILitter? Litter
    {
        get
        {
            if(_accessModeLitter is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _litter;
        }
        set
        {

        }
    }
    public String? Exterior
    {
        get
        {
            if(_accessModeExterior is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _exterior;
        }
        set
        {

        }
    }
    public String? Title
    {
        get
        {
            if(_accessModeTitle is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _title;
        }
        set
        {

        }
    }
    public String? Description
    {
        get
        {
            if(_accessModeDescription is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _description;
        }
        set
        {

        }
    }
}