using System.Collections;
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

    public override DataTemplate? SelectTemplate(object item, DependencyObject container)
    {
        if(item is PropertyValueHolder pvh)
        {
            if (typeof(IList).IsAssignableFrom(pvh.Type))
            {
                if(Collection is { })
                {
                    return Collection;
                }
            }
            if(pvh.IsPoco)
            {
                if(Poco is { })
                {
                    return Poco;
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
            return Value;
        }
        return base.SelectTemplate(item, container);
    }
}
