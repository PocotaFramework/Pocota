using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;

namespace CatsClient;

public class EditKindToStateConverter : MarkupExtension, IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if(value is EditKind editKind && parameter is string selector)
        {
            if(selector.StartsWith("True") || selector.StartsWith("False"))
            {
                if ("TrueIfReadOnly".Equals(selector))
                {
                    return editKind == EditKind.ReadOnly;
                }
                if ("TrueIfEditInline".Equals(selector))
                {
                    return editKind == EditKind.EditInline;
                }
                if ("TrueIfNotEditInline".Equals(selector))
                {
                    return editKind != EditKind.EditInline;
                }
                if ("FalseIfReadOnly".Equals(selector))
                {
                    return editKind != EditKind.ReadOnly;
                }
            }
            if(selector.StartsWith("Visible"))
            {
                if ("VisibleIfNotReadOnly".Equals(selector))
                {
                    return editKind != EditKind.ReadOnly ? Visibility.Visible : Visibility.Collapsed;
                }
                if ("VisibleIfReadOnly".Equals(selector))
                {
                    return editKind == EditKind.ReadOnly ? Visibility.Visible : Visibility.Collapsed;
                }
                if ("VisibleIfEditInline".Equals(selector))
                {
                    return editKind == EditKind.EditInline ? Visibility.Visible : Visibility.Collapsed;
                }
                if ("VisibleIfNotEditInline".Equals(selector))
                {
                    return editKind != EditKind.EditInline ? Visibility.Visible : Visibility.Collapsed;
                }
            }

        }
        throw new ArgumentException($"Unexpected argument: {nameof(parameter)}={parameter}");
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}
