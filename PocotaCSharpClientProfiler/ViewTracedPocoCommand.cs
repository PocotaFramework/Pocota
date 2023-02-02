using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Input;

namespace Net.Leksi.Pocota.Client;

public class ViewTracedPocoCommand : ICommand
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

    public ViewTracedPocoCommand(IServiceProvider services)
    {
        _services= services;
    }

    public bool CanExecute(object? parameter)
    {
        return parameter is { } 
            && (
                (parameter is object[] values && values.Length > 0)
                || (values = new object[] { parameter }) == values
            )
            && values[0] is WeakReference<IPoco> wr
            && wr.TryGetTarget(out IPoco? poco)
            && poco.PocoState is not PocoState.Finalized
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
            && values[0] is WeakReference<IPoco> wr
            && wr.TryGetTarget(out IPoco? poco)
            && poco.PocoState is not PocoState.Finalized
        )
        {
            try
            {
                _services.GetRequiredService<TracedPocos>().Dispatcher.Invoke(() =>
                {
                    ViewTracedPoco view = _services.GetRequiredService<ViewTracedPoco>();
                    _services.GetRequiredService<TracedPocos>().AddView(view);
                    view.Source = (PocoBase)poco;
                    view.Show();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}
