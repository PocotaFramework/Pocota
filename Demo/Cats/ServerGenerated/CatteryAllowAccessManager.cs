
///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.CatteryAllowAccessManager                       //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-25T17:11:02.                                                           //
// Modifying this file will break the program!                                       //
///////////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class CatteryAllowAccessManager : ICatteryAccessManager 
{
    public void Confirm(PropertyUse propertyUse, object? value, Action<object?> onConfirm) 
    {
        onConfirm?.Invoke(value);
    }
}
