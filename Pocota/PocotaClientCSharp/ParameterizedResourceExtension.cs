using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Diagnostics;
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

        _indention = string.Format($"{{0,{_stack.Count}}}", "").Replace(" ", "    ");

        if (_stack.Count > 0)
        {
            foreach (ParameterizedResourceExtension resource in _stack)
            {
                if (!Verbose && resource.Verbose)
                {
                    Verbose = true;
                    _indention = string.Format($"{{0,{_stack.Count}}}", "").Replace(" ", "    ");
                    Console.WriteLine($"{_indention}ProvideValue: {_value.ResourceKey}");
                }
                foreach (string parameterName in resource._replacements.Keys)
                {
                    if (_replacements.TryAdd(parameterName, resource._replacements[parameterName]))
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
        Console.WriteLine($"{_indention}ProvideValue: {_value.ResourceKey}");

        BindingDiagnostics.BindingFailed += BindingDiagnostics_BindingFailed;

        object result = _value.ProvideValue(serviceProvider);

        //Walk3(result, 1);

        _stack.Pop();
        if (_stack.Count == 0)
        {
            s_callStacks.Remove(rootObject);
        }
        return result;
    }

    private void BindingDiagnostics_BindingFailed(object? sender, BindingFailedEventArgs e)
    {
        Console.WriteLine(e);
    }

    private void Walk3(object result, int level)
    {
        string indention = string.Format($"{_indention}{{0,{level}}}", "").Replace(" ", "  ");
        Console.WriteLine($"{indention}{result}");

        if (result is DependencyObject dObj)
        {
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(dObj,
                    new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }))
            {
                if (pd.GetValue(dObj) is object value)
                {
                    if (pd.PropertyType == typeof(BindingBase) && value is Binding binding1)
                    {
                        OnBinding(binding1, $"{pd.Name}(1)");
                    }
                }
                DependencyPropertyDescriptor dpd =
                    DependencyPropertyDescriptor.FromProperty(pd);

                if (dpd is { })
                {
                    if (BindingOperations.GetBinding(dObj, dpd.DependencyProperty) is Binding binding2)
                    {
                        OnBinding(binding2, $"{dpd.Name}");
                    }
                }
            }
            if (dObj is Visual)
            {
                int childrenCount = VisualTreeHelper.GetChildrenCount(dObj);
                if (childrenCount > 0)
                {
                    for (int i = 0; i < childrenCount; i++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(dObj, i);
                        if (_touchedProperties.Add(child))
                        {
                            Walk3(child, level + 1);
                        }
                    }
                }
            }
        }
        else if(result is FrameworkTemplate template)
        {
            Walk3(template.VisualTree, level);
        }
        else
        {

        }
    }

    private void Walk2(MarkupObject markupObject, int level)
    {
        if(markupObject.Instance is Binding binding)
        {
            OnBinding(binding, string.Empty);
        }
        else
        {
            string indention = string.Format($"{_indention}{{0,{level}}}", "").Replace(" ", "  ");
            if (markupObject.Instance is DependencyObject dObj)
            {
                foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(dObj,
                        new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }))
                {
                    if (pd.GetValue(dObj) is object value)
                    {
                        if (pd.PropertyType == typeof(BindingBase) && value is Binding binding1)
                        {
                            OnBinding(binding1, $"{pd.Name}(1)");
                        }
                    }
                    DependencyPropertyDescriptor dpd =
                        DependencyPropertyDescriptor.FromProperty(pd);

                    if (dpd is { })
                    {
                        if (BindingOperations.GetBinding(dObj, dpd.DependencyProperty) is Binding binding2)
                        {
                            OnBinding(binding2, $"{dpd.Name}");
                        }
                    }
                }
                if (dObj is Visual)
                {
                    int childrenCount = VisualTreeHelper.GetChildrenCount(dObj);
                    if (childrenCount > 0)
                    {
                        for (int i = 0; i < childrenCount; i++)
                        {
                            DependencyObject child = VisualTreeHelper.GetChild(dObj, i);
                            if (_touchedProperties.Add(child))
                            {
                                Console.WriteLine($"{indention}  {child}");
                                Walk2(MarkupWriter.GetMarkupObjectFor(child), level + 1);
                            }
                        }
                    }
                }
            }
            foreach (var prop in markupObject.Properties)
            {
                try
                {
                    if (
                        prop is { }
                        && prop.Value is { }
                        && prop.PropertyType != typeof(ResourceDictionary)
                        && prop.PropertyType != typeof(TemplateContent)
                        && prop.PropertyType != typeof(Type)
                        && _touchedProperties.Add(prop.Value)
                    )
                    {
                        Console.WriteLine($"{indention}{prop.Name}, {prop.Value}");
                        if (prop.Value is IList)
                        {
                            foreach (var item in (IList)prop.Value)
                            {
                                if (
                                    item is { }
                                    && item is not ResourceDictionary
                                    && item is not TemplateContent
                                    && item is not Type
                                    && _touchedProperties.Add(item)
                                )
                                {
                                    Console.WriteLine($"{indention}  {item}");
                                    Walk2(MarkupWriter.GetMarkupObjectFor(item), level + 1);
                                }
                            }
                        }
                        else
                        {
                            Walk2(MarkupWriter.GetMarkupObjectFor(prop.Value), level + 1);
                        }

                    }
                }
                catch (NullReferenceException) { }
            }
        }
    }

    public /*override */object ProvideValue1(IServiceProvider serviceProvider)
    {
        object rootObject = serviceProvider.GetRequiredService<IRootObjectProvider>().RootObject;
        if (!s_callStacks.TryGetValue(rootObject, out _stack))
        {
            _stack = new Stack<ParameterizedResourceExtension>();
            s_callStacks.Add(rootObject, _stack);
        }

        if (Verbose)
        {
            _indention = string.Format($"{{0,{_stack.Count}}}", "").Replace(" ", "    ");
            Console.WriteLine($"{_indention}ProvideValue: {_value.ResourceKey}");
        }

        if (_stack.Count > 0)
        {
            foreach (ParameterizedResourceExtension resource in _stack)
            {
                if (!Verbose && resource.Verbose)
                {
                    Verbose = true;
                    _indention = string.Format($"{{0,{_stack.Count}}}", "").Replace(" ", "    ");
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


        if(rootObject is Window window)
        {
            object v = window.FindResource(_value.ResourceKey);
            Console.WriteLine(v);
        }


        //Walk(result);
        
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
                if (pd.GetValue(dependencyObject) is object value)
                {
                    if (pd.PropertyType == typeof(BindingBase) && value is Binding binding1)
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
            }
            if (dependencyObject is Visual)
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
            foreach(var child in LogicalTreeHelper.GetChildren(dependencyObject))
            {
                if (_touchedProperties.Add(child))
                {
                    Walk(child);
                }
            }
        }
        if (result is { } && MarkupWriter.GetMarkupObjectFor(result) is MarkupObject markupObject)
        {
            WalkMarkup(markupObject);
        }
    }

    private void Walk1(object result)
    {
        if (result is DependencyObject dependencyObject)
        {
            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(dependencyObject,
                    new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }))
            {
                if(pd.GetValue(dependencyObject) is object value)
                {
                    if (pd.PropertyType == typeof(BindingBase) && value is Binding binding1)
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
                    if (value is not ValueType && _touchedProperties.Add(value))
                    {
                        Walk(value);
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
        if (_touchedProperties.Add(binding))
        {
            if (binding.Path.Path is { } && binding.Path.Path.StartsWith('$'))
            {
                if (Verbose)
                {
                    Console.Write($"{_indention}{_value.ResourceKey}> Path: {binding.Path.Path}");
                }
                if (_replacements.TryGetValue(binding.Path.Path, out string? newPath))
                {
                    binding.Path.Path = newPath;
                }
                else if(_stack.Count == 1)
                {
                    throw new InvalidOperationException($"Path parameter is not provided: {binding.Path.Path} at {_value.ResourceKey}");
                }
                if (Verbose)
                {
                    Console.WriteLine($" -> {binding.Path.Path}");
                }
            }
            if (binding.ConverterParameter is string converterParameter && converterParameter.StartsWith('$'))
            {
                if (Verbose)
                {
                    Console.Write($"{_indention}{_value.ResourceKey}> ConverterParameter: {binding.ConverterParameter}");
                }
                if (_replacements.TryGetValue(converterParameter, out string? newConverterParameter))
                {
                    binding.ConverterParameter = newConverterParameter;
                }
                else if (_stack.Count == 1)
                {
                    throw new InvalidOperationException($"ConverterParameter parameter is not provided: {converterParameter} at {_value.ResourceKey}");
                }
                if (Verbose)
                {
                    Console.WriteLine($" -> {binding.ConverterParameter}");
                }
            }
            if (binding.XPath is string xPath && xPath.StartsWith('$'))
            {
                if (Verbose)
                {
                    Console.Write($"{_indention}{_value.ResourceKey}> XPath: {binding.XPath}");
                }
                if (_replacements.TryGetValue(xPath, out string? newXPath))
                {
                    binding.XPath = newXPath;
                }
                else if (_stack.Count == 1)
                {
                    throw new InvalidOperationException($"XPath parameter is not provided: {xPath} at {_value.ResourceKey}");
                }
                if (Verbose)
                {
                    Console.WriteLine($" -> {binding.XPath}");
                }
            }
            if (binding.ElementName is string elementName && elementName.StartsWith('$'))
            {
                if (Verbose)
                {
                    Console.Write($"{_indention}{_value.ResourceKey}> ElementName: {binding.ElementName}");
                }
                if (_replacements.TryGetValue(elementName, out string? newElementName))
                {
                    binding.ElementName = newElementName;
                }
                else if (_stack.Count == 1)
                {
                    throw new InvalidOperationException($"ElementName parameter is not provided: {elementName} at {_value.ResourceKey}");
                }
                if (Verbose)
                {
                    Console.WriteLine($" -> {binding.ElementName}");
                }
            }
        }
    }
}
