using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CatsClient;

public class FilteredListToTextConverter : MarkupExtension, IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        string header = values[0].ToString()!;
        int allCount = (int)values[1];
        int count = (int)values[2];
        if(count < allCount)
        {
            return $"{header} (фильтр: {count}/{allCount})";
        }
        return header;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}
