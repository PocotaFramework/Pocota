
///////////////////////////////////////////////////////////////////////////////////////
// Net.Leksi.Pocota.Demo.Cats.Common.BreedAllowAccessManager                         //
// was generated automatically from Net.Leksi.Pocota.Demo.Cats.Contract.ICatContract //
// at 2023-07-24T18:11:45.                                                           //
// Modifying this file will break the program!                                       //
///////////////////////////////////////////////////////////////////////////////////////

using Net.Leksi.Pocota.Server;

namespace Net.Leksi.Pocota.Demo.Cats.Common;

public class BreedAllowAccessManager : IBreedAccessManager 
{
    public void Confirm(PropertyUse propertyUse, object? value, Action<object?> onConfirm) 
    {
        onConfirm?.Invoke(value);
    }
}
