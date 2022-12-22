using CatsCommon.Filters;
using CatsCommon.Model;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;

namespace CatsClient;

public class CatToInfoTextConverter : MarkupExtension, IMultiValueConverter
{
    public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        object? filter = values?[0];
        PropertyInfo? prop = values is { } && values.Length > 1 && values[1] is string propName ? typeof(ICatFilter).GetProperty(propName) : null;
        if (filter is { } && prop is { } && prop.GetValue(filter) is ICat cat && cat.NameNat is { })
        {
            FlowDocument flowDocument = new FlowDocument();
            Paragraph p = new(new Run(cat.NameNat));
            p.FontSize = 12;
            p.LineHeight = 6;
            flowDocument.Blocks.Add(p);
            if(cat.Litter is { })
            {
                p = new(new Run(cat.Litter.Date.ToString()));
                p.FontSize = 12;
                p.LineHeight = 6;
                flowDocument.Blocks.Add(p);
            }
            p = new(new Run(cat.Gender.ToString()));
            p.FontSize = 12;
            p.LineHeight = 6;
            flowDocument.Blocks.Add(p);
            p = new(new Run(cat.Cattery.NameNat));
            p.FontSize = 12;
            p.LineHeight = 6;
            flowDocument.Blocks.Add(p);
            p = new(new Hyperlink(new Span(new Run("Просмотр"))));
            p.FontSize = 12;
            p.LineHeight = 6;
            flowDocument.Blocks.Add(p);

            return flowDocument;
        }
        return null;
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
