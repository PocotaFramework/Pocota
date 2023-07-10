
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatPoco                                     //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-10T19:45:04                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatPoco : EntityBase, ICat
{
    #region PrimaryKey    
    public class PrimaryKeyClass: CatPrimaryKey
    {
        private readonly CatPoco _owner;
        public override object? this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1:
                       return ((CatteryPrimaryKey)_owner.Cattery.PrimaryKey).IdCattery;
                    default:
                        return base[index];
                }
            }
            set
            {
                if (!_owner.IsUnderConstruction)
                {
                    throw new InvalidOperationException();
                }
                switch (index)
                {
                    case 1:
                        Int32? value1 = value as Int32?;
                        if (value is null || value1 is null)
                        {
                            throw new InvalidCastException();
                        }
                        ((CatteryPrimaryKey)_owner.Cattery.PrimaryKey).IdCattery = (Int32)value1!;
                        break;
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
                switch (name)
                {
                    case "IdCattery":
                       return ((CatteryPrimaryKey)_owner.Cattery.PrimaryKey).IdCattery;
                    default:
                        return base[name];
                }
            }
            set
            {
                if (!_owner.IsUnderConstruction)
                {
                    throw new InvalidOperationException();
                }
                switch(name)
                {
                    case "IdCattery":
                        Int32? value1 = value as Int32?;
                        if (value is null || value1 is null)
                        {
                            throw new InvalidCastException();
                        }
                        ((CatteryPrimaryKey)_owner.Cattery.PrimaryKey).IdCattery = (Int32)value1!;
                        break;
                    default:
                        base[name] = value;
                        break;
                }
            }
        }
        public override Int32? IdCattery 
        {
            get
            {
                       return ((CatteryPrimaryKey)_owner.Cattery.PrimaryKey).IdCattery;
            }
            set
            {
                if (!_owner.IsUnderConstruction)
                {
                    throw new InvalidCastException();
                }
                Int32? value1 = value as Int32?;
                if (value is null || value1 is null)
                {
                    throw new InvalidCastException();
                }
                ((CatteryPrimaryKey)_owner.Cattery.PrimaryKey).IdCattery = (Int32)value1!;
            }
        }
        
        public override bool IsAssigned 
        {
            get
            {
                return s_CatteryProperty.GetAccess(_owner) is not PropertyAccessMode.Denied 
                    && base.IsAssigned;
            }
        }
        
        internal PrimaryKeyClass(CatPoco owner)
        {
            _owner = owner;
        }
    }
    #endregion PrimaryKey  

    #region Property classes
    public class PropertyClass: IProperty
    {
        public string Name => string.Empty;
        public Type Type => typeof(CatPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            throw new InvalidOperationException();
        }
        public object? GetValue(object target)
        {
            throw new InvalidOperationException();
        }
        public PropertyAccessMode GetAccess(object target)
        {
            throw new InvalidOperationException();
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
        }
    }
    public class CatteryPropertyClass: IProperty
    {
        public string Name => "Cattery";
        public Type Type => typeof(CatteryPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public bool IsKeyPart => true;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            CatteryPoco? value1 = value as CatteryPoco;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Cattery = value1!;
        }
        public object? GetValue(object target)
        {
            return ((CatPoco)target).Cattery;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._catteryAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._catteryAccessMode  = mode;
            }
        }
    }
    public class NameNatPropertyClass: IProperty
    {
        public string Name => "NameNat";
        public Type Type => typeof(String);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).NameNat = value1;
        }
        public object? GetValue(object target)
        {
            return ((CatPoco)target).NameNat;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._nameNatAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._nameNatAccessMode  = mode;
            }
        }
    }
    public class BreedPropertyClass: IProperty
    {
        public string Name => "Breed";
        public Type Type => typeof(BreedPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            BreedPoco? value1 = value as BreedPoco;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Breed = value1!;
        }
        public object? GetValue(object target)
        {
            return ((CatPoco)target).Breed;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._breedAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._breedAccessMode  = mode;
            }
        }
    }
    public class LitterWithCatsPropertyClass: IProperty
    {
        public string Name => "LitterWithCats";
        public Type Type => typeof(LitterWithCatsPoco);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => false;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => true;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            LitterWithCatsPoco? value1 = value as LitterWithCatsPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).LitterWithCats = value1;
        }
        public object? GetValue(object target)
        {
            return ((CatPoco)target).LitterWithCats;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._litterWithCatsAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._litterWithCatsAccessMode  = mode;
            }
        }
    }
    public class NameEngPropertyClass: IProperty
    {
        public string Name => "NameEng";
        public Type Type => typeof(String);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).NameEng = value1;
        }
        public object? GetValue(object target)
        {
            return ((CatPoco)target).NameEng;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._nameEngAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._nameEngAccessMode  = mode;
            }
        }
    }
    public class GenderPropertyClass: IProperty
    {
        public string Name => "Gender";
        public Type Type => typeof(Gender);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            Gender? value1 = value as Gender?;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Gender = (Gender)value1!;
        }
        public object? GetValue(object target)
        {
            return ((CatPoco)target).Gender;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._genderAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._genderAccessMode  = mode;
            }
        }
    }
    public class LitterPropertyClass: IProperty
    {
        public string Name => "Litter";
        public Type Type => typeof(LitterPoco);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            LitterPoco? value1 = value as LitterPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Litter = value1;
        }
        public object? GetValue(object target)
        {
            return ((CatPoco)target).Litter;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._litterAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._litterAccessMode  = mode;
            }
        }
    }
    public class ExteriorPropertyClass: IProperty
    {
        public string Name => "Exterior";
        public Type Type => typeof(String);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Exterior = value1;
        }
        public object? GetValue(object target)
        {
            return ((CatPoco)target).Exterior;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._exteriorAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._exteriorAccessMode  = mode;
            }
        }
    }
    public class TitlePropertyClass: IProperty
    {
        public string Name => "Title";
        public Type Type => typeof(String);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Title = value1;
        }
        public object? GetValue(object target)
        {
            return ((CatPoco)target).Title;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._titleAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._titleAccessMode  = mode;
            }
        }
    }
    public class DescriptionPropertyClass: IProperty
    {
        public string Name => "Description";
        public Type Type => typeof(String);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public bool IsKeyPart => false;
        public bool IsExtender => false;
        public Type? ItemType => null;
        public void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Description = value1;
        }
        public object? GetValue(object target)
        {
            return ((CatPoco)target).Description;
        }
        public PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._descriptionAccessMode : PropertyAccessMode.Denied;
        }
        public void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._descriptionAccessMode  = mode;
            }
        }
    }
    #endregion Property classes

    #region Property fields
    public static PropertyClass s_Property = new();
    public static CatteryPropertyClass s_CatteryProperty = new();
    public static NameNatPropertyClass s_NameNatProperty = new();
    public static BreedPropertyClass s_BreedProperty = new();
    public static LitterWithCatsPropertyClass s_LitterWithCatsProperty = new();
    public static NameEngPropertyClass s_NameEngProperty = new();
    public static GenderPropertyClass s_GenderProperty = new();
    public static LitterPropertyClass s_LitterProperty = new();
    public static ExteriorPropertyClass s_ExteriorProperty = new();
    public static TitlePropertyClass s_TitleProperty = new();
    public static DescriptionPropertyClass s_DescriptionProperty = new();
    #endregion Property fields

    #region fields
    private CatteryPoco _cattery = null!;
    private PropertyAccessMode _catteryAccessMode = PropertyAccessMode.Denied;
    private String? _nameNat = null;
    private PropertyAccessMode _nameNatAccessMode = PropertyAccessMode.Denied;
    private BreedPoco _breed = null!;
    private PropertyAccessMode _breedAccessMode = PropertyAccessMode.Denied;
    private LitterWithCatsPoco? _litterWithCats = null;
    private PropertyAccessMode _litterWithCatsAccessMode = PropertyAccessMode.Denied;
    private String? _nameEng = null;
    private PropertyAccessMode _nameEngAccessMode = PropertyAccessMode.Denied;
    private Gender _gender;
    private PropertyAccessMode _genderAccessMode = PropertyAccessMode.Denied;
    private LitterPoco? _litter = null;
    private PropertyAccessMode _litterAccessMode = PropertyAccessMode.Denied;
    private String? _exterior = null;
    private PropertyAccessMode _exteriorAccessMode = PropertyAccessMode.Denied;
    private String? _title = null;
    private PropertyAccessMode _titleAccessMode = PropertyAccessMode.Denied;
    private String? _description = null;
    private PropertyAccessMode _descriptionAccessMode = PropertyAccessMode.Denied;
    #endregion fields

    private readonly PrimaryKeyClass _primaryKey;
    public override IPrimaryKey PrimaryKey => _primaryKey;

    public CatPoco(IServiceProvider services) : base(services)
    {
        _primaryKey = new(this);
    }

    #region properties
    public CatteryPoco Cattery
    {
        get
        {
            if(_catteryAccessMode is PropertyAccessMode.Denied)
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
            if(_nameNatAccessMode is PropertyAccessMode.Denied)
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
    public BreedPoco Breed
    {
        get
        {
            if(_breedAccessMode is PropertyAccessMode.Denied)
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
    public LitterWithCatsPoco? LitterWithCats
    {
        get
        {
            if(_litterWithCatsAccessMode is PropertyAccessMode.Denied)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            return _litterWithCats;
        }
        set
        {
            if(!IsUnderConstruction && _litterWithCatsAccessMode is not PropertyAccessMode.Full)
            {
                throw new InvalidOperationException(s_noAccess);
            }
            _litterWithCatsAccessMode = PropertyAccessMode.Full;
            _litterWithCats = value;
        }
    }
    ILitterWithCats? ICat.LitterWithCats
    {
        get
        {
            return LitterWithCats;
        }
       set
        {
            LitterWithCats = (value as LitterWithCatsPoco)!;
        }
    }
    public String? NameEng
    {
        get
        {
            if(_nameEngAccessMode is PropertyAccessMode.Denied)
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
            if(_genderAccessMode is PropertyAccessMode.Denied)
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
    public LitterPoco? Litter
    {
        get
        {
            if(_litterAccessMode is PropertyAccessMode.Denied)
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
            if(_exteriorAccessMode is PropertyAccessMode.Denied)
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
            if(_titleAccessMode is PropertyAccessMode.Denied)
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
            if(_descriptionAccessMode is PropertyAccessMode.Denied)
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
    #endregion properties
}