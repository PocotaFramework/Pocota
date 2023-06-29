
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatFilterPoco                               //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-29T21:14:15                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatFilterPoco : Pocota.Server.PocoBase, ICatFilter
{
    public class PropertyClass: IProperty
    {
        public string Name => string.Empty;
        public Type Type => typeof(CatFilterPoco);
        public bool IsNullable => false;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            throw new InvalidOperationException();
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            throw new InvalidOperationException();
        }
    }
    public class BreedPropertyClass: IProperty
    {
        public string Name => "Breed";
        public Type Type => typeof(BreedPoco);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._breedAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._breedAccessMode  = mode;
            }
        }
    }
    public class CatteryPropertyClass: IProperty
    {
        public string Name => "Cattery";
        public Type Type => typeof(CatteryPoco);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._catteryAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._catteryAccessMode  = mode;
            }
        }
    }
    public class BornAfterPropertyClass: IProperty
    {
        public string Name => "BornAfter";
        public Type Type => typeof(DateOnly);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._bornAfterAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._bornAfterAccessMode  = mode;
            }
        }
    }
    public class BornBeforePropertyClass: IProperty
    {
        public string Name => "BornBefore";
        public Type Type => typeof(DateOnly);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._bornBeforeAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._bornBeforeAccessMode  = mode;
            }
        }
    }
    public class NameRegexPropertyClass: IProperty
    {
        public string Name => "NameRegex";
        public Type Type => typeof(String);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._nameRegexAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._nameRegexAccessMode  = mode;
            }
        }
    }
    public class GenderPropertyClass: IProperty
    {
        public string Name => "Gender";
        public Type Type => typeof(Gender);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._genderAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._genderAccessMode  = mode;
            }
        }
    }
    public class ChildPropertyClass: IProperty
    {
        public string Name => "Child";
        public Type Type => typeof(CatPoco);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._childAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._childAccessMode  = mode;
            }
        }
    }
    public class SelfPropertyClass: IProperty
    {
        public string Name => "Self";
        public Type Type => typeof(CatPoco);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._selfAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._selfAccessMode  = mode;
            }
        }
    }
    public class MotherPropertyClass: IProperty
    {
        public string Name => "Mother";
        public Type Type => typeof(CatPoco);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._motherAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._motherAccessMode  = mode;
            }
        }
    }
    public class FatherPropertyClass: IProperty
    {
        public string Name => "Father";
        public Type Type => typeof(CatPoco);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._fatherAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._fatherAccessMode  = mode;
            }
        }
    }
    public class AncestorPropertyClass: IProperty
    {
        public string Name => "Ancestor";
        public Type Type => typeof(CatPoco);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._ancestorAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._ancestorAccessMode  = mode;
            }
        }
    }
    public class DescendantPropertyClass: IProperty
    {
        public string Name => "Descendant";
        public Type Type => typeof(CatPoco);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => true;
        public bool IsEntity => true;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._descendantAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._descendantAccessMode  = mode;
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
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._litterAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._litterAccessMode  = mode;
            }
        }
    }
    public class ExteriorRegexPropertyClass: IProperty
    {
        public string Name => "ExteriorRegex";
        public Type Type => typeof(String);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._exteriorRegexAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._exteriorRegexAccessMode  = mode;
            }
        }
    }
    public class TitleRegexPropertyClass: IProperty
    {
        public string Name => "TitleRegex";
        public Type Type => typeof(String);
        public bool IsNullable => true;
        public bool IsReadOnly => false;
        public bool IsPoco => false;
        public bool IsEntity => false;
        public bool IsList => false;
        public Type? ItemType => null;
        public PropertyAccessMode GetAccess(object obj)
        {
            return obj is CatFilterPoco obj1 ? obj1._titleRegexAccessMode : PropertyAccessMode.Forbidden;
        }
        public void SetAccess(object obj, PropertyAccessMode mode)
        {
            if(obj is CatFilterPoco obj1)
            {
                obj1._titleRegexAccessMode  = mode;
            }
        }
    }

    public static PropertyClass s_Property = new();
    public static BreedPropertyClass s_BreedProperty = new();
    public static CatteryPropertyClass s_CatteryProperty = new();
    public static BornAfterPropertyClass s_BornAfterProperty = new();
    public static BornBeforePropertyClass s_BornBeforeProperty = new();
    public static NameRegexPropertyClass s_NameRegexProperty = new();
    public static GenderPropertyClass s_GenderProperty = new();
    public static ChildPropertyClass s_ChildProperty = new();
    public static SelfPropertyClass s_SelfProperty = new();
    public static MotherPropertyClass s_MotherProperty = new();
    public static FatherPropertyClass s_FatherProperty = new();
    public static AncestorPropertyClass s_AncestorProperty = new();
    public static DescendantPropertyClass s_DescendantProperty = new();
    public static LitterPropertyClass s_LitterProperty = new();
    public static ExteriorRegexPropertyClass s_ExteriorRegexProperty = new();
    public static TitleRegexPropertyClass s_TitleRegexProperty = new();

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