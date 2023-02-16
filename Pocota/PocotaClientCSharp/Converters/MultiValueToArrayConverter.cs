using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace Net.Leksi.Pocota.Client;

public class MultiValueToArrayConverter : MarkupExtension, IMultiValueConverter
{
    private readonly Lazy<MultiValueToArrayConverter> _converter = new();
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return values.ToArray();
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        return ((object[])value).ToArray();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return _converter.Value;
    }
}
