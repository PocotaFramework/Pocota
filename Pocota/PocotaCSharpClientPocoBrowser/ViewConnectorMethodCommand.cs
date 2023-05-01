using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Windows.Input;

namespace Net.Leksi.Pocota.Client;

public class ViewConnectorMethodCommand : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add
        {
            CommandManager.RequerySuggested += value;
        }
        remove
        {
            CommandManager.RequerySuggested -= value;
        }
    }

    private readonly IServiceProvider _services;

    public ViewConnectorMethodCommand(IServiceProvider services)
    {
        _services = services;
    }

    public bool CanExecute(object? parameter)
    {
        return parameter is object[] parameters 
            && parameters.Length > 1
            && parameters[0] is MethodInfo method 
            && typeof(Connector).IsAssignableFrom(method.DeclaringType) 
            && parameters[1] is Connector;
    }

    public void Execute(object? parameter)
    {
        if (parameter is object[] parameters
            && parameters.Length > 1
            && parameters[0] is MethodInfo method
            && typeof(Connector).IsAssignableFrom(method.DeclaringType)
            && parameters[1] is Connector connector)
        {
            ViewConnectorMethod view = _services.GetRequiredService<ViewConnectorMethod>();
            view.Method = method;
            view.Connector = connector;
            _services.GetRequiredService<PocotaClientBrowser>().AddView(view);
            view.Show();
        }
    }

}
