using CatsCommon.Model;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CatsClient;

public class AddCatCommand : ICommand
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

    public AddCatCommand(IServiceProvider services)
    {
        _services = services;
    }

    public bool CanExecute(object? parameter)
    {
        object?[] values = parameter as object?[] ?? new object?[] { parameter };
        return values.Length >= 1 && Enumerable.Range(0, values.Length).All(i => IsTrue(values, i));
    }

    public void Execute(object? parameter)
    {
        if (CanExecute(parameter))
        {
            object?[] values = parameter as object?[] ?? new object?[] { parameter };
            if(values[0] is IList<ILitter> litters)
            {
                _services.GetRequiredService<MainWindow>().Dispatcher.Invoke(() => 
                {
                    ICat cat = _services.GetRequiredService<ICat>();
                    ((IProjection)cat).As<IEntity>()!.Create();
                    cat.Litter = litters[0];
                });
            }
        }
    }

    private bool IsTrue(object?[] values, int i)
    {
        switch (i)
        {
            case 0:
                return values[i] is IList<ILitter> litters && litters.Count == 1;
            default:
                return values[i] is bool res && res;

        }
    }
}
