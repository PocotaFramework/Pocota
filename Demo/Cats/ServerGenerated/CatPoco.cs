
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatPoco                                     //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-18T19:12:59                                                        //
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
    public class PropertyClass: Property
    {
        public override string Name => string.Empty;
        public override Type Type => typeof(CatPoco);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            throw new InvalidOperationException();
        }
        protected override void SetValue(object target, object? value)
        {
            throw new InvalidOperationException();
        }
        public override object? GetValue(object target)
        {
            throw new InvalidOperationException();
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
        }
    }
    public class CatteryPropertyClass: Property
    {
        public override string Name => "Cattery";
        public override Type Type => typeof(CatteryPoco);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => true;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._catteryAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            CatteryPoco? value1 = value as CatteryPoco;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Cattery = value1!;
        }
        public override object? GetValue(object target)
        {
            return ((CatPoco)target).Cattery;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._catteryAccessMode  = mode;
            }
        }
    }
    public class NameNatPropertyClass: Property
    {
        public override string Name => "NameNat";
        public override Type Type => typeof(String);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._nameNatAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).NameNat = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatPoco)target).NameNat;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._nameNatAccessMode  = mode;
            }
        }
    }
    public class BreedPropertyClass: Property
    {
        public override string Name => "Breed";
        public override Type Type => typeof(BreedPoco);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._breedAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            BreedPoco? value1 = value as BreedPoco;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Breed = value1!;
        }
        public override object? GetValue(object target)
        {
            return ((CatPoco)target).Breed;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._breedAccessMode  = mode;
            }
        }
    }
    public class LitterWithCatsPropertyClass: Property
    {
        public override string Name => "LitterWithCats";
        public override Type Type => typeof(LitterWithCatsPoco);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => true;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._litterWithCatsAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            LitterWithCatsPoco? value1 = value as LitterWithCatsPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).LitterWithCats = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatPoco)target).LitterWithCats;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._litterWithCatsAccessMode  = mode;
            }
        }
    }
    public class NameEngPropertyClass: Property
    {
        public override string Name => "NameEng";
        public override Type Type => typeof(String);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._nameEngAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).NameEng = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatPoco)target).NameEng;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._nameEngAccessMode  = mode;
            }
        }
    }
    public class GenderPropertyClass: Property
    {
        public override string Name => "Gender";
        public override Type Type => typeof(Gender);
        public override bool IsNullable => false;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._genderAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            Gender? value1 = value as Gender?;
            if (value is {} && value1 is null || value is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Gender = (Gender)value1!;
        }
        public override object? GetValue(object target)
        {
            return ((CatPoco)target).Gender;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._genderAccessMode  = mode;
            }
        }
    }
    public class LitterPropertyClass: Property
    {
        public override string Name => "Litter";
        public override Type Type => typeof(LitterPoco);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => true;
        public override bool IsEntity => true;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._litterAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            LitterPoco? value1 = value as LitterPoco;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Litter = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatPoco)target).Litter;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._litterAccessMode  = mode;
            }
        }
    }
    public class ExteriorPropertyClass: Property
    {
        public override string Name => "Exterior";
        public override Type Type => typeof(String);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._exteriorAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Exterior = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatPoco)target).Exterior;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._exteriorAccessMode  = mode;
            }
        }
    }
    public class TitlePropertyClass: Property
    {
        public override string Name => "Title";
        public override Type Type => typeof(String);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._titleAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Title = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatPoco)target).Title;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
        {
            if(target is CatPoco target1)
            {
                target1._titleAccessMode  = mode;
            }
        }
    }
    public class DescriptionPropertyClass: Property
    {
        public override string Name => "Description";
        public override Type Type => typeof(String);
        public override bool IsNullable => true;
        public override bool IsReadOnly => false;
        public override bool IsPoco => false;
        public override bool IsEntity => false;
        public override bool IsList => false;
        public override bool IsKeyPart => false;
        public override bool IsExtender => false;
        public override Type? ItemType => null;
        public override PropertyAccessMode GetAccess(object target)
        {
            return target is CatPoco target1 ? target1._descriptionAccessMode : PropertyAccessMode.Denied;
        }
        protected override void SetValue(object target, object? value)
        {
            String? value1 = value as String;
            if (value is {} && value1 is null)
            {
                throw new InvalidCastException();
            }
            ((CatPoco)target).Description = value1;
        }
        public override object? GetValue(object target)
        {
            return ((CatPoco)target).Description;
        }
        protected override void SetAccess(object target, PropertyAccessMode mode)
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
    private PropertyAccessMode _catteryAccessMode = PropertyAccessMode.NotSet;
    private String? _nameNat = null;
    private PropertyAccessMode _nameNatAccessMode = PropertyAccessMode.NotSet;
    private BreedPoco _breed = null!;
    private PropertyAccessMode _breedAccessMode = PropertyAccessMode.NotSet;
    private LitterWithCatsPoco? _litterWithCats = null;
    private PropertyAccessMode _litterWithCatsAccessMode = PropertyAccessMode.NotSet;
    private String? _nameEng = null;
    private PropertyAccessMode _nameEngAccessMode = PropertyAccessMode.NotSet;
    private Gender _gender;
    private PropertyAccessMode _genderAccessMode = PropertyAccessMode.NotSet;
    private LitterPoco? _litter = null;
    private PropertyAccessMode _litterAccessMode = PropertyAccessMode.NotSet;
    private String? _exterior = null;
    private PropertyAccessMode _exteriorAccessMode = PropertyAccessMode.NotSet;
    private String? _title = null;
    private PropertyAccessMode _titleAccessMode = PropertyAccessMode.NotSet;
    private String? _description = null;
    private PropertyAccessMode _descriptionAccessMode = PropertyAccessMode.NotSet;
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
            if(_catteryAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _cattery;
        }
        set
        {
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
            if(_nameNatAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _nameNat;
        }
        set
        {
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
            if(_breedAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _breed;
        }
        set
        {
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
            if(_litterWithCatsAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _litterWithCats;
        }
        set
        {
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
            if(_nameEngAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _nameEng;
        }
        set
        {
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
            if(_genderAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _gender;
        }
        set
        {
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
            if(_litterAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _litter;
        }
        set
        {
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
            if(_exteriorAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _exterior;
        }
        set
        {
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
            if(_titleAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _title;
        }
        set
        {
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
            if(_descriptionAccessMode is PropertyAccessMode.NotSet)
            {
                throw new InvalidOperationException(s_notSet);
            }
            return _description;
        }
        set
        {
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