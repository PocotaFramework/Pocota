using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Markup.Primitives;

namespace Net.Leksi.Pocota.Client;

public class BindingProxy : Freezable
{
    public static readonly DependencyProperty DataProperty =
         DependencyProperty.Register("Data", typeof(object),
            typeof(BindingProxy));

    public static readonly DependencyProperty BindingPathsProperty =
         DependencyProperty.Register("BindingPaths", typeof(string),
            typeof(BindingProxy));

    public object? Data { get; set; }
    public string? BindingPaths { get; set; }

    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        if(GetValue(DataProperty) is object data && GetValue(BindingPathsProperty) is string bindingPaths)
        {
            MarkupObject markupObject = MarkupWriter.GetMarkupObjectFor(data);

            List<Binding> bindings = new();
            Queue<MarkupObject> queue = new();
            queue.Enqueue(markupObject);
            while (queue.TryDequeue(out MarkupObject? markup))
            {
                foreach (MarkupProperty? prop in markup.Properties)
                {
                    try
                    {
                        foreach (MarkupObject? item in prop.Items)
                        {
                            if (item.Instance is Binding binding)
                            {
                                bindings.Add(binding);
                            }
                            else if (!(item.Instance is TypeExtension))
                            {
                                queue.Enqueue(item);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            if(bindings.Count > 0)
            {
                Dictionary<string, string> replacements = bindingPaths.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(entry => entry.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                    .Where(entry => entry.Length == 2)
                    .ToDictionary(entry => entry[0], entry => entry[1]);
                foreach (var item in bindings)
                {
                    if(replacements.TryGetValue(item.Path.Path, out string? newPath))
                    {
                        item.Path.Path = newPath;
                    }
                    if (item.ConverterParameter is string converterParameter && replacements.TryGetValue(converterParameter, out string? newConverterParameter))
                    {
                        item.ConverterParameter = newConverterParameter;
                    }

                    Console.WriteLine($"binding: {item.Path.Path}, {item.ConverterParameter}");
                }
            }

        }
        base.OnPropertyChanged(e);
    }

    protected override Freezable CreateInstanceCore()
    {
        throw new NotImplementedException();
    }
}
