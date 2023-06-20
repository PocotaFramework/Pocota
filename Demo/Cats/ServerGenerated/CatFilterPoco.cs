
///////////////////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                                    //
// Net.Leksi.Pocota.Demo.Cats.Common.CatFilterPoco                               //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-20T19:08:45                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatFilterPoco : Server.PocoBase, ICatFilter, Server.IPoco
{
    private BreedPoco? _breed;
    private PropertyAccessMode _accessModeBreed = PropertyAccessMode.Forbidden;
    private CatteryPoco? _cattery;
    private PropertyAccessMode _accessModeCattery = PropertyAccessMode.Forbidden;
    private DateOnly? _bornAfter;
    private PropertyAccessMode _accessModeBornAfter = PropertyAccessMode.Forbidden;
    private DateOnly? _bornBefore;
    private PropertyAccessMode _accessModeBornBefore = PropertyAccessMode.Forbidden;
    private String? _nameRegex;
    private PropertyAccessMode _accessModeNameRegex = PropertyAccessMode.Forbidden;
    private Gender? _gender;
    private PropertyAccessMode _accessModeGender = PropertyAccessMode.Forbidden;
    private CatPoco? _child;
    private PropertyAccessMode _accessModeChild = PropertyAccessMode.Forbidden;
    private CatPoco? _self;
    private PropertyAccessMode _accessModeSelf = PropertyAccessMode.Forbidden;
    private CatPoco? _mother;
    private PropertyAccessMode _accessModeMother = PropertyAccessMode.Forbidden;
    private CatPoco? _father;
    private PropertyAccessMode _accessModeFather = PropertyAccessMode.Forbidden;
    private CatPoco? _ancestor;
    private PropertyAccessMode _accessModeAncestor = PropertyAccessMode.Forbidden;
    private CatPoco? _descendant;
    private PropertyAccessMode _accessModeDescendant = PropertyAccessMode.Forbidden;
    private LitterPoco? _litter;
    private PropertyAccessMode _accessModeLitter = PropertyAccessMode.Forbidden;
    private String? _exteriorRegex;
    private PropertyAccessMode _accessModeExteriorRegex = PropertyAccessMode.Forbidden;
    private String? _titleRegex;
    private PropertyAccessMode _accessModeTitleRegex = PropertyAccessMode.Forbidden;
    public IBreed? Breed
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
    public ICattery? Cattery
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
    public DateOnly? BornAfter
    {
        get
        {
            if(_accessModeBornAfter is PropertyAccessMode.Forbidden)
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
            if(_accessModeBornBefore is PropertyAccessMode.Forbidden)
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
            if(_accessModeNameRegex is PropertyAccessMode.Forbidden)
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
    public ICat? Child
    {
        get
        {
            if(_accessModeChild is PropertyAccessMode.Forbidden)
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
            if(_accessModeSelf is PropertyAccessMode.Forbidden)
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
            if(_accessModeMother is PropertyAccessMode.Forbidden)
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
            if(_accessModeFather is PropertyAccessMode.Forbidden)
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
            if(_accessModeAncestor is PropertyAccessMode.Forbidden)
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
            if(_accessModeDescendant is PropertyAccessMode.Forbidden)
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
    public String? ExteriorRegex
    {
        get
        {
            if(_accessModeExteriorRegex is PropertyAccessMode.Forbidden)
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
            if(_accessModeTitleRegex is PropertyAccessMode.Forbidden)
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