using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Markup.Primitives;
using System.Windows.Media;
using System.Xaml;

namespace Net.Leksi.Pocota.Client;

public class ParameterizedResourceExtension : MarkupExtension
{
    private readonly StaticResourceExtension _value;
    private readonly Dictionary<string, string> _replacements = new();
    private string? _replaces;
    private static readonly Dictionary<object, Stack<ParameterizedResourceExtension>> s_callStacks = new();
    private Stack<ParameterizedResourceExtension> _stack = null!;
    private readonly HashSet<object> _touchedProperties = new(ReferenceEqualityComparer.Instance);
    private string _indention = string.Empty;


    public string? Replaces 
    { 
        get => _replaces; 
        set 
        {
            if(!object.Equals(_replaces, value))
            {
                _replaces = value;
                _replacements.Clear();
                if (_replaces is { })
                {
                    foreach(
                        string[] ent in _replaces.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                            .Select(entry => entry.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                            .Where(entry => entry.Length == 2)
                    )
                    {
                        _replacements.TryAdd(ent[0], ent[1]);
                    }
                }
            }
        }
    }

    public bool Verbose { get; set; } = false;

    public ParameterizedResourceExtension(object key)
    {
        _value = new StaticResourceExtension(key);
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        object rootObject = serviceProvider.GetRequiredService<IRootObjectProvider>().RootObject;
        if (!s_callStacks.TryGetValue(rootObject, out _stack))
        {
            _stack = new Stack<ParameterizedResourceExtension>();
            s_callStacks.Add(rootObject, _stack);
        }

        if (Verbose)
        {
            _indention = string.Format($"{{0,{_stack.Count}}}", "").Replace(" ", "    ") + $"{_indention}({GetHashCode()}, {Thread.CurrentThread.ManagedThreadId})";
            Console.WriteLine($"{_indention}ProvideValue: {_value.ResourceKey}");
        }

        if (_stack.Count > 0)
        {
            foreach (ParameterizedResourceExtension resource in _stack)
            {
                if (!Verbose && resource.Verbose)
                {
                    Verbose = true;
                    _indention = string.Format($"{{0,{_stack.Count}}}", "").Replace(" ", "    ") + $"{_indention}({GetHashCode()}, {Thread.CurrentThread.ManagedThreadId})";
                    Console.WriteLine($"{_indention}ProvideValue: {_value.ResourceKey}");
                }
                foreach (string parameterName in resource._replacements.Keys)
                {
                    if(_replacements.TryAdd(parameterName, resource._replacements[parameterName]))
                    {
                        if (Verbose)
                        {
                            Console.WriteLine($"{_indention}from {resource._value.ResourceKey}: {parameterName}={resource._replacements[parameterName]}");
                        }
                    }
                }
            }
        }

        _stack.Push(this);

        object result = _value.ProvideValue(serviceProvider);
        Walk(result);
        
        _stack.Pop();
        if(_stack.Count == 0)
        {
            s_callStacks.Remove(rootObject);
        }

        if (Verbose)
        {
            Console.WriteLine($"{_indention}Provided: {_value.ResourceKey}");
        }
        return result;
    }

    private void Walk(object result)
    {
        if (result is DependencyObject dependencyObject)
        {
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(dependencyObject,
                    new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }))
            {
                if(pd.PropertyType == typeof(BindingBase) && pd.GetValue(dependencyObject) is Binding binding1)
                {
                    OnBinding(binding1, $"{pd.Name}(1)");
                }
                else
                {
                    DependencyPropertyDescriptor dpd =
                        DependencyPropertyDescriptor.FromProperty(pd);

                    if (dpd is { })
                    {
                        if (BindingOperations.GetBinding(dependencyObject, dpd.DependencyProperty) is Binding binding)
                        {
                            OnBinding(binding, $"{dpd.Name}(2)");
                        }
                    }
                }
            }
            if(dependencyObject is Visual)
            {
                int childrenCount = VisualTreeHelper.GetChildrenCount(dependencyObject);
                if (childrenCount > 0)
                {
                    for (int i = 0; i < childrenCount; i++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);
                        if (_touchedProperties.Add(child))
                        {
                            Walk(child);
                        }
                    }
                }
            }
        }
        if(result is { } && MarkupWriter.GetMarkupObjectFor(result) is MarkupObject markupObject)
        {
            WalkMarkup(markupObject);
        }
    }

    private void WalkMarkup(MarkupObject markupObject)
    {
        foreach (MarkupProperty? prop in markupObject.Properties)
        {
            if (_touchedProperties.Add(prop.Value))
            {
                try
                {
                    foreach (MarkupObject? item in prop.Items)
                    {
                        if (item.Instance is Binding binding)
                        {
                            OnBinding(binding, $"{prop.Name}(3)");
                        }
                        else if (!(item.Instance is TypeExtension))
                        {
                            Walk(item.Instance);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if(ex is InvalidOperationException)
                    {
                        throw;
                    }
                }
            }
        }
    }

    private void OnBinding(Binding binding, string propertyName)
    {
        if (
            _touchedProperties.Add(binding) 
            && (
                (
                    binding.Path.Path is { } 
                    && binding.Path.Path.StartsWith('$')
                )
                || (
                    binding.ConverterParameter is string s
                    && s.StartsWith('$')
                )
            )
        )
        {
            if (Verbose)
            {
                Console.WriteLine($"{_indention}{_value.ResourceKey}> {binding.Path.Path}, {binding.ConverterParameter}");
            }
            if (binding.Path.Path is { } && binding.Path.Path.StartsWith('$'))
            {
                if(_replacements.TryGetValue(binding.Path.Path, out string? newPath))
                {
                    binding.Path.Path = newPath;
                }
                else if(_stack.Count == 1)
                {
                    throw new InvalidOperationException($"Path parameter is not provided: {binding.Path.Path} at {_value.ResourceKey}");
                }
            }
            if (binding.ConverterParameter is string converterParameter && converterParameter.StartsWith('$'))
            {
                if (_replacements.TryGetValue(converterParameter, out string? newConverterParameter))
                {
                    binding.ConverterParameter = newConverterParameter;
                }
                else if (_stack.Count == 1)
                {
                    throw new InvalidOperationException($"ConverterParameter parameter is not provided: {converterParameter} at {_value.ResourceKey}");
                }
            }
            if (Verbose)
            {
                Console.WriteLine($"{_indention}{_value.ResourceKey}# {binding.Path.Path}, {binding.ConverterParameter}");
            }
        }
    }
}
