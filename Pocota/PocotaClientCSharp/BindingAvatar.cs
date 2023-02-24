using System;
using System.Windows;

namespace Net.Leksi.Pocota.Client;

public class BindingAvatar : Freezable
{
    private object? _driver;
    private object? _avatar;

    public static readonly DependencyProperty DriverProperty =
         DependencyProperty.Register("Driver", typeof(object),
            typeof(BindingAvatar));

    public static readonly DependencyProperty AvatarProperty =
         DependencyProperty.Register("Avatar", typeof(object),
            typeof(BindingAvatar));

    public object? Driver { get; set; }
    public object? Avatar => _avatar;

    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        if(e.Property == DriverProperty)
        {
            _driver = e.NewValue;
            _avatar = e.NewValue;
        }
        base.OnPropertyChanged(e);
    }

    protected override Freezable CreateInstanceCore()
    {
        throw new NotImplementedException();
    }
}
