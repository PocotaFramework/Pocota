using CatsContract;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using System;
using System.Windows.Input;

namespace CatsClient;

public abstract class CatsCrudCommand : CrudCommand
{
    public override event EventHandler? CanExecuteChanged
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

    protected readonly CatsConnector _connector;

    public CatsCrudCommand(IServiceProvider services):base(services) 
    {
        _connector = _services.GetRequiredService<CatsConnector>();
    }
}
