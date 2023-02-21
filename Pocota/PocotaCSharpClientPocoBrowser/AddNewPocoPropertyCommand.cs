using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Input;

namespace Net.Leksi.Pocota.Client;

public class AddNewPocoPropertyCommand : ICommand
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

    public AddNewPocoPropertyCommand(IServiceProvider services)
    {
        _services = services;
    }

    public bool CanExecute(object? parameter)
    {
        return parameter is PropertyValueHolder;
    }

    public void Execute(object? parameter)
    {
        if (parameter is PropertyValueHolder pvh)
        {
            pvh.Current = _services.GetRequiredService(pvh.Type);
        }
    }
}
