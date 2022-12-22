using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace CatsClient;

public class ResetComboBoxCommand : ICommand
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
        if (parameter is FrameworkElement element)
        {
            string name = element.Name.Substring("Control".Length);
            if (element.FindName($"Select{name}") is ComboBox select)
            {
                if(select.Visibility is Visibility.Visible)
                {
                    if(element.FindName($"{name}Regex") is TextBox regex && !string.IsNullOrEmpty(regex.Text))
                    {
                        regex.Text = String.Empty;
                        regex.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                        if (element.FindName($"Find{name}") is Button find && find.Command.CanExecute(find.CommandParameter))
                        {
                            find.Command.Execute(find.CommandParameter);
                        }
                    }
                    else
                    {
                        select.SelectedIndex = -1;
                    }
                } else if(
                    element.FindName($"{name}Regex") is TextBox regex
                    && element.FindName($"Find{name}") is Button find
                    && element.FindName($"Filter{name}") is FrameworkElement filter
                )
                {
                    select.Visibility = Visibility.Visible;
                    regex.Visibility = Visibility.Collapsed;
                    find.Visibility = Visibility.Collapsed;
                    filter.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
