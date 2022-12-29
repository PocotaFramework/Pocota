using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CatsClient;

public class PocoStateConverter : MarkupExtension, IValueConverter
{
    private static readonly Lazy<PocoStateConverter> s_converter = new();
    
    internal static EnumConverter Converter { get; private set; } = new ()
    {
        {PocoState.Unchanged, "Исходный" },
        {PocoState.Created, "Создан" },
        {PocoState.Modified, "Изменён" },
        {PocoState.Deleted, "Удалён" },
    };

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is { })
        {
            if (value is PocoState)
            {
                return Converter.Convert(value, targetType, parameter, culture);
            }
            if (value is IProjection<IPoco> projection && projection.As<IPoco>() is IPoco poco)
            {
                return Converter.Convert(poco.PocoState, targetType, parameter, culture);
            }
            throw new NotImplementedException();
        }
        return PocoState.Unchanged;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return s_converter.Value;
    }
}

