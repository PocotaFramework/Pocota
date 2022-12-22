using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CatsClient;

public partial class ServerDialog : Window
{
    public ServerDialog()
    {
        InitializeComponent();
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        DataContext = Owner;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        BindingExpression be = Address.GetBindingExpression(TextBox.TextProperty);
        be.UpdateSource();
        DialogResult = true;
    }
}
