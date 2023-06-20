
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.CatPoco                                     //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-20T22:04:33                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatPoco : Server.PocoBase, ICat, IEntity
{
    private CatteryPoco _cattery;
    private PropertyAccessMode _catteryAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameNat;
    private PropertyAccessMode _nameNatAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameEng;
    private PropertyAccessMode _nameEngAccessMode = PropertyAccessMode.Forbidden;
    private Gender _gender;
    private PropertyAccessMode _genderAccessMode = PropertyAccessMode.Forbidden;
    private BreedPoco _breed;
    private PropertyAccessMode _breedAccessMode = PropertyAccessMode.Forbidden;
    private LitterPoco? _litter;
    private PropertyAccessMode _litterAccessMode = PropertyAccessMode.Forbidden;
    private String? _exterior;
    private PropertyAccessMode _exteriorAccessMode = PropertyAccessMode.Forbidden;
    private String? _title;
    private PropertyAccessMode _titleAccessMode = PropertyAccessMode.Forbidden;
    private String? _description;
    private PropertyAccessMode _descriptionAccessMode = PropertyAccessMode.Forbidden;
    public ICattery Cattery
    {
        get
        {
            if(_catteryAccessMode is PropertyAccessMode.Forbidden)
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
    public Gender Gender
    {
        get
        {
            if(_genderAccessMode is PropertyAccessMode.Forbidden)
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
            if(_breedAccessMode is PropertyAccessMode.Forbidden)
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
            if(_litterAccessMode is PropertyAccessMode.Forbidden)
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
            if(_exteriorAccessMode is PropertyAccessMode.Forbidden)
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
            if(_titleAccessMode is PropertyAccessMode.Forbidden)
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
            if(_descriptionAccessMode is PropertyAccessMode.Forbidden)
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