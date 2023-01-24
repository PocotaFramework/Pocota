using CatsCommon.Model;
using Microsoft.Extensions.DependencyInjection;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CatsClient;

public class PasteParentCommand : ICommand
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

    public PasteParentCommand(IServiceProvider services)
    {
        _services = services;
    }

    public bool CanExecute(object? parameter)
    {
        object?[] values = parameter as object?[] ?? new object?[] { parameter };
        return Enumerable.Range(0, values.Length).All(i => IsTrue(values, i));

        
    }

    private bool IsTrue(object?[] values, int i)
    {
        switch (i)
        {
            case 0:
                if (
                    values[i] is IProjection<ICat> proj
                    && proj.As<ICat>() is ICat cat
                )
                {
                    IEntity[]? references = _services.GetRequiredService<CopyEntitiesReferencesCommand>().PasteEntitiesReferences();
                    return
                        references is { }
                        && references.Length == 1
                        && references[0] is IProjection<ICat> proj1
                        && proj1.As<ICat>() is ICat cat1
                        && (
                            (
                                (cat.Gender is CatsCommon.Gender.Female || cat.Gender is CatsCommon.Gender.FemaleCastrate)
                                && (cat1.Gender is CatsCommon.Gender.Male || cat1.Gender is CatsCommon.Gender.MaleCastrate)
                            )
                            || (
                                (cat.Gender is CatsCommon.Gender.Male || cat.Gender is CatsCommon.Gender.MaleCastrate)
                                && (cat1.Gender is CatsCommon.Gender.Female || cat1.Gender is CatsCommon.Gender.FemaleCastrate)
                            )
                        )
                    ;
                }
                return false;
            default:
                return values[i] is bool res && res;
        }
    }

    public void Execute(object? parameter)
    {
        if (CanExecute(parameter))
        {
            object?[] values = parameter as object?[] ?? new object?[] { parameter };
            IEntity[]? references = _services.GetRequiredService<CopyEntitiesReferencesCommand>().PasteEntitiesReferences();
        }
    }
}
