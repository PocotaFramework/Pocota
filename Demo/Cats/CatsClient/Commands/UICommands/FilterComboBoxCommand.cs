using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CatsClient;

public class FilterComboBoxCommand : ICommand
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
        if(parameter is { })
        {
            if (parameter is FrameworkElement element)
            {
                string name = element.Name.Substring("Control".Length);
                object obj = element.FindName($"Find{name}");
                return element.FindName($"Find{name}") is Button findButton && findButton.Visibility is Visibility.Collapsed;
            }
        }
        return false;
    }

    public void Execute(object? parameter)
    {
        if (parameter is FrameworkElement element)
        {
            string name = element.Name.Substring("Control".Length);
            if(
                element.FindName($"Select{name}") is FrameworkElement select
                && element.FindName($"{name}Regex") is FrameworkElement regex
                && element.FindName($"Find{name}") is FrameworkElement find
                && element.FindName($"Filter{name}") is FrameworkElement filter
            )
            {
                select.Visibility = Visibility.Collapsed;
                regex.Visibility = Visibility.Visible;
                find.Visibility = Visibility.Visible;
                filter.Visibility = Visibility.Collapsed;
                regex.Focus();
            }
        }
    }

}
