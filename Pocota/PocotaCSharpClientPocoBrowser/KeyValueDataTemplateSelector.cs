using Net.Leksi.WpfMarkup;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Net.Leksi.Pocota.Client;

internal class KeyValueDataTemplateSelector: DataTemplateSelector
{
    public DataTemplate? View { get; set; }
    public DataTemplate? Edit { get; set; }
    public bool IsEditing { get; set; } = false;

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        if(IsEditing && container is ContentPresenter cp && cp.FindResource("PocoState") is BindingProxy bp && bp.Value is PocoState.Uncertain && Edit is { })
        {
            return Edit;
        }
        if(View is { })
        {
            return View;
        }
        return base.SelectTemplate(item, container);
    }
}
