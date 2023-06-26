
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatFilterPoco                               //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-26T18:05:25                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatFilterPoco : Server.PocoBase, ICatFilter
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
    IBreed? ICatFilter.Breed
    {
        get
        {
            return Breed;
        }
       set
        {
            Breed = (value as BreedPoco)!;
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
    ICattery? ICatFilter.Cattery
    {
        get
        {
            return Cattery;
        }
       set
        {
            Cattery = (value as CatteryPoco)!;
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
    DateOnly? ICatFilter.BornAfter
    {
        get
        {
            return BornAfter;
        }
       set
        {
            BornAfter = value;
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
    DateOnly? ICatFilter.BornBefore
    {
        get
        {
            return BornBefore;
        }
       set
        {
            BornBefore = value;
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
    String? ICatFilter.NameRegex
    {
        get
        {
            return NameRegex;
        }
       set
        {
            NameRegex = value;
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
    Gender? ICatFilter.Gender
    {
        get
        {
            return Gender;
        }
       set
        {
            Gender = value;
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
    ICat? ICatFilter.Child
    {
        get
        {
            return Child;
        }
       set
        {
            Child = (value as CatPoco)!;
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
    ICat? ICatFilter.Self
    {
        get
        {
            return Self;
        }
       set
        {
            Self = (value as CatPoco)!;
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
    ICat? ICatFilter.Mother
    {
        get
        {
            return Mother;
        }
       set
        {
            Mother = (value as CatPoco)!;
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
    ICat? ICatFilter.Father
    {
        get
        {
            return Father;
        }
       set
        {
            Father = (value as CatPoco)!;
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
    ICat? ICatFilter.Ancestor
    {
        get
        {
            return Ancestor;
        }
       set
        {
            Ancestor = (value as CatPoco)!;
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
    ICat? ICatFilter.Descendant
    {
        get
        {
            return Descendant;
        }
       set
        {
            Descendant = (value as CatPoco)!;
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
    ILitter? ICatFilter.Litter
    {
        get
        {
            return Litter;
        }
       set
        {
            Litter = (value as LitterPoco)!;
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
    String? ICatFilter.ExteriorRegex
    {
        get
        {
            return ExteriorRegex;
        }
       set
        {
            ExteriorRegex = value;
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
    String? ICatFilter.TitleRegex
    {
        get
        {
            return TitleRegex;
        }
       set
        {
            TitleRegex = value;
        }
    }
}