using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Net.Leksi.Pocota.Client;

public class ViewTracedPocoDataTemplateSelector: DataTemplateSelector
{
    public DataTemplate? Poco { get; set; }
    public DataTemplate? Value { get; set; }
    public DataTemplate? Collection { get; set; }

    public override DataTemplate? SelectTemplate(object item, DependencyObject container)
    {
        if(item is PropertyValueHolder pvh)
        {
            if (typeof(IList).IsAssignableFrom(pvh.Type))
            {
                return Collection;
            }
            if(pvh.IsPoco)
            {
                return Poco;
            }
            return Value;
        }
        return base.SelectTemplate(item, container);
    }
}
