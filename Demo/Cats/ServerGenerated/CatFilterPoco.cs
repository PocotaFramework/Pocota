
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.CatFilterPoco                               //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-20T22:04:33                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatFilterPoco : Server.PocoBase, ICatFilter, Server.IPoco
{
    private BreedPoco? _breed;
    private PropertyAccessMode _breedAccessMode = PropertyAccessMode.Forbidden;
    private CatteryPoco? _cattery;
    private PropertyAccessMode _catteryAccessMode = PropertyAccessMode.Forbidden;
    private DateOnly? _bornAfter;
    private PropertyAccessMode _bornAfterAccessMode = PropertyAccessMode.Forbidden;
    private DateOnly? _bornBefore;
    private PropertyAccessMode _bornBeforeAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameRegex;
    private PropertyAccessMode _nameRegexAccessMode = PropertyAccessMode.Forbidden;
    private Gender? _gender;
    private PropertyAccessMode _genderAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _child;
    private PropertyAccessMode _childAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _self;
    private PropertyAccessMode _selfAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _mother;
    private PropertyAccessMode _motherAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _father;
    private PropertyAccessMode _fatherAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _ancestor;
    private PropertyAccessMode _ancestorAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _descendant;
    private PropertyAccessMode _descendantAccessMode = PropertyAccessMode.Forbidden;
    private LitterPoco? _litter;
    private PropertyAccessMode _litterAccessMode = PropertyAccessMode.Forbidden;
    private String? _exteriorRegex;
    private PropertyAccessMode _exteriorRegexAccessMode = PropertyAccessMode.Forbidden;
    private String? _titleRegex;
    private PropertyAccessMode _titleRegexAccessMode = PropertyAccessMode.Forbidden;
    public IBreed? Breed
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
    public ICattery? Cattery
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
    public DateOnly? BornAfter
    {
        get
        {
            if(_bornAfterAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _bornAfter;
        }
        set
        {

        }
    }
    public DateOnly? BornBefore
    {
        get
        {
            if(_bornBeforeAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _bornBefore;
        }
        set
        {

        }
    }
    public String? NameRegex
    {
        get
        {
            if(_nameRegexAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _nameRegex;
        }
        set
        {

        }
    }
    public Gender? Gender
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
    public ICat? Child
    {
        get
        {
            if(_childAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _child;
        }
        set
        {

        }
    }
    public ICat? Self
    {
        get
        {
            if(_selfAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _self;
        }
        set
        {

        }
    }
    public ICat? Mother
    {
        get
        {
            if(_motherAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _mother;
        }
        set
        {

        }
    }
    public ICat? Father
    {
        get
        {
            if(_fatherAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _father;
        }
        set
        {

        }
    }
    public ICat? Ancestor
    {
        get
        {
            if(_ancestorAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _ancestor;
        }
        set
        {

        }
    }
    public ICat? Descendant
    {
        get
        {
            if(_descendantAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _descendant;
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
    public String? ExteriorRegex
    {
        get
        {
            if(_exteriorRegexAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _exteriorRegex;
        }
        set
        {

        }
    }
    public String? TitleRegex
    {
        get
        {
            if(_titleRegexAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException("Forbidden");
            }
            return _titleRegex;
        }
        set
        {

        }
    }
}