using System.Windows;

namespace Net.Leksi.Pocota.Client;

public class BindingProxy : Freezable
{
    public static readonly DependencyProperty DataProperty =
         DependencyProperty.Register("Data", typeof(object),
            typeof(BindingProxy));

    public object Data
    {
        get => GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }

    protected override Freezable CreateInstanceCore()
    {
        return new BindingProxy();
    }
}
