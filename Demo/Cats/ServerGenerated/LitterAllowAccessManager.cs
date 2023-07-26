
///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.LitterAllowAccessManager                        //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-26T13:07:15.                                                           //
// Modifying this file will break the program!                                       //
///////////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class LitterAllowAccessManager : ILitterAccessManager 
{
    public void Confirm(PropertyUse propertyUse, object? value, Action<object?> onConfirm) 
    {
        onConfirm?.Invoke(value);
    }
}
