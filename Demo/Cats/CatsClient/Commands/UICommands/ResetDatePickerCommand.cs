using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace CatsClient;

public class ResetDatePickerCommand : ICommand
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
        return true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is DatePicker datePicker)
        {
            datePicker.SelectedDate = null;
        }
    }

}
