using System;
using System.Windows;
using System.Windows.Controls;

namespace Net.Leksi.Pocota.Client;

public class ViewTracedPocoDataTemplateSelector: DataTemplateSelector
{
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        Console.WriteLine($"{item}, {container}");
        return base.SelectTemplate(item, container);
    }
}
