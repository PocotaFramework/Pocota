using CatsCommon;
using CatsCommon.Filters;
using CatsCommon.Model;
using Net.Leksi.Pocota.Common.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CatsClient;

public class SetCatFilterCommand : ICommand
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

    private static readonly string[] s_selectors = new[] 
    {
        "AsDescendant",
        "AsAncestor",
        "AsLitter",
        "AsChild",
        "AsParent",
        "AsSelf"
    };

    public bool CanExecute(object? parameter)
    {
        object?[] values = parameter as object?[] ?? new object?[] { parameter };
        return values.Length >= 3 && Enumerable.Range(0, values.Length).All(i => IsTrue(values, i));
    }

    private bool IsTrue(object?[] values, int i)
    {
        switch (i)
        {
            case 0:
                return values[i] is IProjection<ICat> || (values[i] is IList<ILitter> litters && litters.Count == 1);
            case 1:
                return (values[0] is IProjection<ICat> && s_selectors.Contains(values[i])) 
                    || (values[0] is IList<ILitter> && "AsLitter".Equals(values[i]));
            case 2:
                return values[i] is IProjection<ICatFilter>;
            default:
                return values[i] is bool res && res;
        }
    }

    public void Execute(object? parameter)
    {
        if (CanExecute(parameter))
        {
            object?[] values = parameter as object?[] ?? new object?[] { parameter };
            if(values[2] is IProjection<ICatFilter> proj1 && proj1.As<ICatFilter>() is ICatFilter filter)
            {
                if (values[0] is IProjection<ICat> proj && proj.As<ICat>() is ICat cat)
                {
                    switch (values[1])
                    {
                        case "AsDescendant":
                            filter.Descendant = cat;
                            break;
                        case "AsAncestor":
                            filter.Ancestor = cat;
                            break;
                        case "AsLitter":
                            filter.Litter = cat.Litter;
                            break;
                        case "AsChild":
                            filter.Child = cat;
                            break;
                        case "AsParent":
                            if (cat.Gender is Gender.Female || cat.Gender is Gender.FemaleCastrate)
                            {
                                filter.Mother = cat;
                            }
                            else
                            {
                                filter.Father = cat;
                            }
                            break;
                        case "AsSelf":
                            filter.Self = cat;
                            break;
                    }
                }
                else if(values[0] is IList<ILitter> litters && "AsLitter".Equals(values[1]))
                {
                    filter.Litter = litters[0];
                }
            }
        }
    }
}
