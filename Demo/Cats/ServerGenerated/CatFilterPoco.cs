
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatFilterPoco                               //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-23T18:37:26                                                        //
///////////////////////////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatFilterPoco : Server.PocoBase
{
    private BreedPoco? _breed = null;
    private PropertyAccessMode _breedAccessMode = PropertyAccessMode.Forbidden;
    private CatteryPoco? _cattery = null;
    private PropertyAccessMode _catteryAccessMode = PropertyAccessMode.Forbidden;
    private DateOnly? _bornAfter = null;
    private PropertyAccessMode _bornAfterAccessMode = PropertyAccessMode.Forbidden;
    private DateOnly? _bornBefore = null;
    private PropertyAccessMode _bornBeforeAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameRegex = null;
    private PropertyAccessMode _nameRegexAccessMode = PropertyAccessMode.Forbidden;
    private Gender? _gender = null;
    private PropertyAccessMode _genderAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _child = null;
    private PropertyAccessMode _childAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _self = null;
    private PropertyAccessMode _selfAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _mother = null;
    private PropertyAccessMode _motherAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _father = null;
    private PropertyAccessMode _fatherAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _ancestor = null;
    private PropertyAccessMode _ancestorAccessMode = PropertyAccessMode.Forbidden;
    private CatPoco? _descendant = null;
    private PropertyAccessMode _descendantAccessMode = PropertyAccessMode.Forbidden;
    private LitterPoco? _litter = null;
    private PropertyAccessMode _litterAccessMode = PropertyAccessMode.Forbidden;
    private String? _exteriorRegex = null;
    private PropertyAccessMode _exteriorRegexAccessMode = PropertyAccessMode.Forbidden;
    private String? _titleRegex = null;
    private PropertyAccessMode _titleRegexAccessMode = PropertyAccessMode.Forbidden;

    public CatFilterPoco()
    {
    }

    public BreedPoco? Breed
    {
        get
        {
            if(_breedAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _breed;
        }
        set
        {
            if(!IsUnderConstruction && _breedAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _breedAccessMode = PropertyAccessMode.Full;
            _breed = value;
        }
    }
    public CatteryPoco? Cattery
    {
        get
        {
            if(_catteryAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _cattery;
        }
        set
        {
            if(!IsUnderConstruction && _catteryAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _catteryAccessMode = PropertyAccessMode.Full;
            _cattery = value;
        }
    }
    public DateOnly? BornAfter
    {
        get
        {
            if(_bornAfterAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _bornAfter;
        }
        set
        {
            if(!IsUnderConstruction && _bornAfterAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _bornAfterAccessMode = PropertyAccessMode.Full;
            _bornAfter = value;
        }
    }
    public DateOnly? BornBefore
    {
        get
        {
            if(_bornBeforeAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _bornBefore;
        }
        set
        {
            if(!IsUnderConstruction && _bornBeforeAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _bornBeforeAccessMode = PropertyAccessMode.Full;
            _bornBefore = value;
        }
    }
    public String? NameRegex
    {
        get
        {
            if(_nameRegexAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _nameRegex;
        }
        set
        {
            if(!IsUnderConstruction && _nameRegexAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _nameRegexAccessMode = PropertyAccessMode.Full;
            _nameRegex = value;
        }
    }
    public Gender? Gender
    {
        get
        {
            if(_genderAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _gender;
        }
        set
        {
            if(!IsUnderConstruction && _genderAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _genderAccessMode = PropertyAccessMode.Full;
            _gender = value;
        }
    }
    public CatPoco? Child
    {
        get
        {
            if(_childAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _child;
        }
        set
        {
            if(!IsUnderConstruction && _childAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _childAccessMode = PropertyAccessMode.Full;
            _child = value;
        }
    }
    public CatPoco? Self
    {
        get
        {
            if(_selfAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _self;
        }
        set
        {
            if(!IsUnderConstruction && _selfAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _selfAccessMode = PropertyAccessMode.Full;
            _self = value;
        }
    }
    public CatPoco? Mother
    {
        get
        {
            if(_motherAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _mother;
        }
        set
        {
            if(!IsUnderConstruction && _motherAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _motherAccessMode = PropertyAccessMode.Full;
            _mother = value;
        }
    }
    public CatPoco? Father
    {
        get
        {
            if(_fatherAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _father;
        }
        set
        {
            if(!IsUnderConstruction && _fatherAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _fatherAccessMode = PropertyAccessMode.Full;
            _father = value;
        }
    }
    public CatPoco? Ancestor
    {
        get
        {
            if(_ancestorAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _ancestor;
        }
        set
        {
            if(!IsUnderConstruction && _ancestorAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _ancestorAccessMode = PropertyAccessMode.Full;
            _ancestor = value;
        }
    }
    public CatPoco? Descendant
    {
        get
        {
            if(_descendantAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _descendant;
        }
        set
        {
            if(!IsUnderConstruction && _descendantAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _descendantAccessMode = PropertyAccessMode.Full;
            _descendant = value;
        }
    }
    public LitterPoco? Litter
    {
        get
        {
            if(_litterAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _litter;
        }
        set
        {
            if(!IsUnderConstruction && _litterAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _litterAccessMode = PropertyAccessMode.Full;
            _litter = value;
        }
    }
    public String? ExteriorRegex
    {
        get
        {
            if(_exteriorRegexAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _exteriorRegex;
        }
        set
        {
            if(!IsUnderConstruction && _exteriorRegexAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _exteriorRegexAccessMode = PropertyAccessMode.Full;
            _exteriorRegex = value;
        }
    }
    public String? TitleRegex
    {
        get
        {
            if(_titleRegexAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _titleRegex;
        }
        set
        {
            if(!IsUnderConstruction && _titleRegexAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _titleRegexAccessMode = PropertyAccessMode.Full;
            _titleRegex = value;
        }
    }
}