
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatPoco                                     //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-29T10:52:36                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatPoco : EntityBase, ICat
{
    public class PrimaryKeyClass: CatPrimaryKey
    {
        private readonly CatPoco _owner;
        public override object? this[int index]
        {
            get
            {
                switch(index)
                {
                    case 1:
                        return _owner.Cattery.PrimaryKey.IdCattery;
                    default:
                        return base[index];
                }
            }
            set
            {
                if(!_owner.IsUnderConstruction)
                {
                    throw new InvalidOperationException();
                }
                switch(index)
                {
                    case 1:
                        throw new InvalidOperationException();
                    default:
                        base[index] = value;
                        break;
                }
            }
        }
        public override object? this[string name]
        {
            get
            {
                switch(name)
                {
                    case "IdCattery":
                        return _owner.Cattery.PrimaryKey.IdCattery;
                    default:
                        return base[name];
                }
            }
            set
            {
                if(!_owner.IsUnderConstruction)
                {
                    throw new InvalidOperationException();
                }
                switch(name)
                {
                    case "IdCattery":
                        throw new InvalidOperationException();
                    default:
                        base[name] = value;
                        break;
                }
            }
        }
        public override Int32? IdCattery 
        {
            get => _owner.Cattery.PrimaryKey.IdCattery;
            set
            {
                throw new InvalidOperationException();
            }
        }
        internal PrimaryKeyClass(CatPoco owner)
        {
            _owner = owner;
        }
    }

    public PrimaryKeyClass PrimaryKey { get; init; }
    private CatteryPoco _cattery = null!;
    private PropertyAccessMode _catteryAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameNat = null;
    private PropertyAccessMode _nameNatAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameEng = null;
    private PropertyAccessMode _nameEngAccessMode = PropertyAccessMode.Forbidden;
    private Gender _gender;
    private PropertyAccessMode _genderAccessMode = PropertyAccessMode.Forbidden;
    private BreedPoco _breed = null!;
    private PropertyAccessMode _breedAccessMode = PropertyAccessMode.Forbidden;
    private LitterPoco? _litter = null;
    private PropertyAccessMode _litterAccessMode = PropertyAccessMode.Forbidden;
    private String? _exterior = null;
    private PropertyAccessMode _exteriorAccessMode = PropertyAccessMode.Forbidden;
    private String? _title = null;
    private PropertyAccessMode _titleAccessMode = PropertyAccessMode.Forbidden;
    private String? _description = null;
    private PropertyAccessMode _descriptionAccessMode = PropertyAccessMode.Forbidden;

    public CatPoco()
    {
        PrimaryKey = new(this);
    }

    public CatteryPoco Cattery
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
    ICattery ICat.Cattery
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
    String? ICat.NameNat
    {
        get
        {
            return NameNat;
        }
       set
        {
            NameNat = value;
        }
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
    String? ICat.NameEng
    {
        get
        {
            return NameEng;
        }
       set
        {
            NameEng = value;
        }
    }
    public Gender Gender
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
    Gender ICat.Gender
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
    public BreedPoco Breed
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
    IBreed ICat.Breed
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
    ILitter? ICat.Litter
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
    public String? Exterior
    {
        get
        {
            if(_exteriorAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _exterior;
        }
        set
        {
            if(!IsUnderConstruction && _exteriorAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _exteriorAccessMode = PropertyAccessMode.Full;
            _exterior = value;
        }
    }
    String? ICat.Exterior
    {
        get
        {
            return Exterior;
        }
       set
        {
            Exterior = value;
        }
    }
    public String? Title
    {
        get
        {
            if(_titleAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _title;
        }
        set
        {
            if(!IsUnderConstruction && _titleAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _titleAccessMode = PropertyAccessMode.Full;
            _title = value;
        }
    }
    String? ICat.Title
    {
        get
        {
            return Title;
        }
       set
        {
            Title = value;
        }
    }
    public String? Description
    {
        get
        {
            if(_descriptionAccessMode is PropertyAccessMode.Forbidden)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _description;
        }
        set
        {
            if(!IsUnderConstruction && _descriptionAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _descriptionAccessMode = PropertyAccessMode.Full;
            _description = value;
        }
    }
    String? ICat.Description
    {
        get
        {
            return Description;
        }
       set
        {
            Description = value;
        }
    }
}