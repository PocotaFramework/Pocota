using System.ComponentModel;
using System.Security.AccessControl;

namespace Net.Leksi.Pocota.Client;

public class PocoConverter: TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        Console.WriteLine($"CanConvertFrom {context}, {sourceType}");
        return base.CanConvertFrom(context, sourceType);
    }

    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        Console.WriteLine($"CanConvertTo {context}, {destinationType}");
        return base.CanConvertTo(context, destinationType);
    }
}