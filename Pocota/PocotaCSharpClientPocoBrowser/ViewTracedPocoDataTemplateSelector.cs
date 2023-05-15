using Net.Leksi.WpfMarkup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Net.Leksi.Pocota.Client;

public class ViewTracedPocoDataTemplateSelector: DataTemplateSelector
{
    public DataTemplate? Poco { get; set; }
    public DataTemplate? Value { get; set; }
    public DataTemplate? Collection { get; set; }
    public DataTemplate? Bool { get; set; }
    public DataTemplate? Enum { get; set; }
    public DataTemplate? TimeSpan { get; set; }
    public DataTemplate? DateTime { get; set; }
    public DataTemplate? DateOnly { get; set; }
    public DataTemplate? TimeOnly { get; set; }
    public DataTemplate? ReadOnlyValue { get; set; }

    public override DataTemplate? SelectTemplate(object item, DependencyObject container)
    {
        
        if(item is PropertyValueHolder pvh)
        {
            if(
                pvh.KeyPart is { } 
                && container is ContentPresenter cp 
                && cp.FindResource("PocoState") is BindingProxy bp 
                && bp.Value is not PocoState.Created
            )
            {
                if (ReadOnlyValue is { })
                {
                    return ReadOnlyValue;
                }
            }
            else
            {
                if (
                    typeof(IList).IsAssignableFrom(pvh.Type) 
                    || (
                        pvh.Type.IsGenericType 
                        && typeof(IList<>).IsAssignableFrom(pvh.Type.GetGenericTypeDefinition())
                    )
                )
                {
                    if (Collection is { })
                    {
                        return Collection;
                    }
                }
                if (pvh.IsPoco)
                {
                    if (Poco is { })
                    {
                        return Poco;
                    }
                }
                if (pvh.IsReadOnly)
                {
                    if (ReadOnlyValue is { })
                    {
                        return ReadOnlyValue;
                    }
                }
                if (pvh.Type == typeof(bool))
                {
                    if (Bool is { })
                    {
                        return Bool;
                    }
                }
                if (pvh.Type.IsEnum)
                {
                    if (Enum is { })
                    {
                        return Enum;
                    }
                }
                if (typeof(TimeSpan).IsAssignableFrom(pvh.Type))
                {
                    if (TimeSpan is { })
                    {
                        return TimeSpan;
                    }
                }
                if (typeof(DateTime).IsAssignableFrom(pvh.Type))
                {
                    if (DateTime is { })
                    {
                        return DateTime;
                    }
                }
                if (typeof(DateOnly).IsAssignableFrom(pvh.Type))
                {
                    if (DateOnly is { })
                    {
                        return DateOnly;
                    }
                }
                if (typeof(TimeOnly).IsAssignableFrom(pvh.Type))
                {
                    if (TimeOnly is { })
                    {
                        return TimeOnly;
                    }
                }
                if (Value is { })
                {
                    return Value;
                }
            }
        }
        return base.SelectTemplate(item, container);
    }
}
