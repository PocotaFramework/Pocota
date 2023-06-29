
///////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatteryPoco                                 //
// Generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-06-29T10:52:36                                                        //
///////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatteryPoco : EntityBase, ICattery
{
    public class PrimaryKeyClass: CatteryPrimaryKey
    {
        private readonly CatteryPoco _owner;
        public override object? this[int index]
        {
            get
            {
                switch(index)
                {
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
                    default:
                        base[name] = value;
                        break;
                }
            }
        }
        internal PrimaryKeyClass(CatteryPoco owner)
        {
            _owner = owner;
        }
    }

    public PrimaryKeyClass PrimaryKey { get; init; }
    private String? _nameEng = null;
    private PropertyAccessMode _nameEngAccessMode = PropertyAccessMode.Forbidden;
    private String? _nameNat = null;
    private PropertyAccessMode _nameNatAccessMode = PropertyAccessMode.Forbidden;

    public CatteryPoco()
    {
        PrimaryKey = new(this);
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
    String? ICattery.NameEng
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
    String? ICattery.NameNat
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
}