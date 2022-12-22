using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Input;

namespace CatsClient;

public class StopGetCatsCommand : ICommand
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


    private bool _canExecute = false;
    private readonly IServiceProvider _services;

    public bool CanExecuteValue {
        get => _canExecute;
        set 
        {
            _canExecute = value;
        } 
    }

    public StopGetCatsCommand(IServiceProvider services)
    {
        _services = services;
    }


    public bool CanExecute(object? parameter)
    {
        return CanExecuteValue;
    }

    public void Execute(object? parameter)
    {
        _services.GetRequiredService<MainWindow>().CancellationTokenSource.Cancel();
    }
}
