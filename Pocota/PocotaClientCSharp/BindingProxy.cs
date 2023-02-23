using System;
using System.Windows;

namespace Net.Leksi.Pocota.Client;

public class BindingProxy : Freezable
{
    public static readonly DependencyProperty DataProperty =
         DependencyProperty.Register("Data", typeof(object),
            typeof(BindingProxy));

    public object? Data { get; set; }

    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        if(e.NewValue is { })
        {
            //Console.WriteLine(e.NewValue.GetType());
        }
        base.OnPropertyChanged(e);
    }

    protected override Freezable CreateInstanceCore()
    {
        throw new NotImplementedException();
    }
}
