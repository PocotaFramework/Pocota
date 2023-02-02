using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Windows;
using System.Windows.Input;

namespace Net.Leksi.Pocota.Client;

public class CancelChangesCommand : ICommand
{
    public Action<Action>? DispatcherWrapper { get; set; }

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
        return parameter is { } 
            && (
                (parameter is object[] values && values.Length > 0)
                || (values = new object[] { parameter }) == values
            )
            && values[0] is IProjection<IPoco> proj
            && proj.As<IPoco>() is IPoco poco
            && poco.PocoState is PocoState pocoState
            && pocoState is not PocoState.Unchanged
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
            parameter is { }
            && CanExecute(parameter) 
            && (parameter is object[] values || (values = new object[] { parameter }) == values)
            && values[0] is IProjection<IPoco> proj
            && proj.As<IPoco>() is IPoco poco
        )
        {
            try
            {
                if(DispatcherWrapper is { })
                {
                    DispatcherWrapper.Invoke(() =>
                    {
                        poco.CancelChanges();
                    });
                }
                else
                {
                    poco.CancelChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}
