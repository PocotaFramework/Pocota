using System.Windows.Input;
using System;

namespace Net.Leksi.Pocota.Client;

public class ClearPocoPropertyCommand: ICommand
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

    public ClearPocoPropertyCommand(IServiceProvider services)
    {
        _services = services;
    }

    public bool CanExecute(object? parameter)
    {
        return parameter is PropertyValueHolder;
    }

    public void Execute(object? parameter)
    {
        if(parameter is PropertyValueHolder pvh)
        {
            pvh.Current = default;
        }
    }
}
