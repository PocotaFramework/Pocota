using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Windows.Input;
using System.Windows.Markup;

namespace CatsClient;

public class CancelChangesCommand : MarkupExtension, ICommand
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

    public bool CanExecute(object? parameter)
    {
        return parameter is object[] values
            && values[0] is IProjection<IPoco> proj
            && proj.As<IPoco>() is IPoco poco
            && poco.PocoState is PocoState pocoState
            && pocoState is not PocoState.Unchanged
            && pocoState is not PocoState.Created
            && (
                values.Length == 1 
                || (
                    values[1] is bool edit
                    && edit
                )
            );
    }

    public void Execute(object? parameter)
    {
        if (
            CanExecute(parameter) 
            && parameter is object[] values
            && values[0] is IProjection<IEntity> proj
            && proj.As<IEntity>() is IEntity entity
        )
        {
            entity.CancelChanges();
        }
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return new CancelChangesCommand();
    }
}
