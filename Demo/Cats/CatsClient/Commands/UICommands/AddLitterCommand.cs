using CatsCommon;
using CatsCommon.Model;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using System;
using System.Windows.Input;

namespace CatsClient;

public class AddLitterCommand : ICommand
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

    public AddLitterCommand(IServiceProvider services)
    {
        _services = services;
    }

    public bool CanExecute(object? parameter)
    {
        return parameter is ICat;
    }

    public void Execute(object? parameter)
    {
        if(parameter is ICat cat)
        {
            _services.GetRequiredService<MainWindow>().Dispatcher.Invoke(
                () => 
                {
                    ILitter newLitter = _services.GetRequiredService<ILitter>();
                    ((IEntity)newLitter).Create();

                    if (cat.Gender is Gender.Female || cat.Gender is Gender.FemaleCastrate)
                    {
                        newLitter.Female = cat;
                    }
                    else
                    {
                        newLitter.Male = cat;
                    }
                    newLitter.Date = DateOnly.FromDateTime(DateTime.Now);
                }
            );

            
        }
    }
}
