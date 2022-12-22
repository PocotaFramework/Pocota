using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace CatsClient;

public class MultipleAndConverter : MarkupExtension, IMultiValueConverter
{
    private static readonly Lazy<MultipleAndConverter> _converter = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if(values.All(x => x is bool))
        {
            return values.All(v => (bool)v);
        }
        return false;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return _converter.Value;
    }
}
