﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Markup.Primitives;
using System.Windows.Media;
using System.Xaml;

namespace Net.Leksi.Pocota.Client;

public class ParameterizedResourceExtension : MarkupExtension
{
    private const string s_indentionStep = "  ";
    private readonly StaticResourceExtension _value;
    private readonly Dictionary<string, string> _replacements = new();
    private string? _replaces;
    private static readonly Dictionary<object, Stack<ParameterizedResourceExtension>> s_callStacks = new();
    private Stack<ParameterizedResourceExtension> _stack = null!;
    private string _indention = string.Empty;
    private readonly HashSet<object> _seenObjects = new(ReferenceEqualityComparer.Instance);

    public string? Replaces
    {
        get => _replaces;
        set
        {
            if (!object.Equals(_replaces, value))
            {
                _replaces = value;
                _replacements.Clear();
                if (_replaces is { })
                {
                    foreach (
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

    public string At { get; set; } = string.Empty;

    public int Verbose { get; set; } = 0;

    public bool Strict { get; set; } = true;

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

        _indention = string.Format($"{{0,{_stack.Count}}}", "").Replace(" ", s_indentionStep) + $"[{_value.ResourceKey}{(string.IsNullOrEmpty(At) ? string.Empty : $"@{At}")}]";


        if (Verbose > 0)
        {
            Console.WriteLine($"{_indention} < ProvideValue >");
            foreach (string parameterName in _replacements.Keys)
            {
                Console.WriteLine($"{_indention} < {parameterName}={_replacements[parameterName]} (from {nameof(Replaces)}) >");
            }
        }

        if (_stack.Count > 0)
        {
            foreach (ParameterizedResourceExtension resource in _stack)
            {
                if(Verbose == 0 && resource.Verbose > 0)
                {
                    Console.WriteLine($"{_indention} < ProvideValue >");
                    foreach (string parameterName in _replacements.Keys)
                    {
                        Console.WriteLine($"{_indention} < {parameterName}={_replacements[parameterName]} (from {nameof(Replaces)}) >");
                    }
                }
                if (Verbose < resource.Verbose)
                {
                    Verbose = resource.Verbose;
                }
                foreach (string parameterName in resource._replacements.Keys)
                {
                    if (_replacements.TryAdd(parameterName, resource._replacements[parameterName]))
                    {
                        if (Verbose > 0)
                        {
                            Console.WriteLine($"{_indention} < {parameterName}={resource._replacements[parameterName]} (from {resource._value.ResourceKey}) >");
                        }
                    }
                }
            }
        }

        _stack.Push(this);

        object result = _value.ProvideValue(serviceProvider);

        List<string> route = new();
        WalkMarkup(MarkupWriter.GetMarkupObjectFor(result), route);

        _stack.Pop();
        if (_stack.Count == 0)
        {
            s_callStacks.Remove(rootObject);
        }

        if (Verbose > 0)
        {
            Console.WriteLine($"{_indention} < Done >");
        }
        return result;
    }

    private void WalkMarkup(MarkupObject mo, List<string> route)
    {
        if (_seenObjects.Add(mo.Instance))
        {
            if(mo.Instance is DependencyObject dependencyObject)
            {
                foreach (
                    PropertyDescriptor pd in TypeDescriptor.GetProperties(
                        dependencyObject, new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }
                    )
                )
                {
                    if (pd.GetValue(dependencyObject) is object value)
                    {
                        if (pd.PropertyType == typeof(BindingBase) && value is Binding binding)
                        {
                            OnBinding(binding, route);
                        }
                    }
                    DependencyPropertyDescriptor dpd =
                        DependencyPropertyDescriptor.FromProperty(pd);

                    if (dpd is { })
                    {
                        if (BindingOperations.GetBinding(dependencyObject, dpd.DependencyProperty) is Binding binding1)
                        {
                            route.Add(pd.Name);
                            OnBinding(binding1, route);
                            route.RemoveAt(route.Count - 1);
                        }
                        else if(BindingOperations.GetMultiBinding(dependencyObject, dpd.DependencyProperty) is MultiBinding multiBinding)
                        {
                            route.Add(pd.Name);
                            OnBinding(multiBinding, route);
                            route.RemoveAt(route.Count - 1);
                        }
                    }
                }
                if (dependencyObject is Visual visual)
                {
                    int childrenCount = VisualTreeHelper.GetChildrenCount(visual);
                    if (childrenCount > 0)
                    {
                        for (int i = 0; i < childrenCount; ++i)
                        {
                            DependencyObject child = VisualTreeHelper.GetChild(visual, i);
                            route.Add(child.GetType().ToString());
                            WalkMarkup(MarkupWriter.GetMarkupObjectFor(child), route);
                            route.RemoveAt(route.Count - 1);
                        }
                    }
                }
            }
            foreach (var prop in mo.Properties)
            {
                if (prop.PropertyType == typeof(BindingBase))
                {
                    OnBinding((BindingBase)prop.Value, route);
                }
                else
                {
                    route.Add(prop.Name);
                    if(Verbose > 1)
                    {
                        Console.WriteLine($"{_indention} {string.Join('/', route)}");
                    }
                    if (prop.DependencyProperty is { })
                    {
                        if (BindingOperations.GetBinding((DependencyObject)mo.Instance, prop.DependencyProperty) is Binding binding)
                        {
                            OnBinding(binding, route);
                        }
                        else if (BindingOperations.GetMultiBinding((DependencyObject)mo.Instance, prop.DependencyProperty) is MultiBinding multiBinding)
                        {
                            OnBinding(multiBinding, route);
                        }
                    }
                    try
                    {
                        if (prop.IsComposite)
                        {
                            foreach (var item in prop.Items)
                            {
                                WalkMarkup(item, route);
                            }
                        }
                    }
                    catch (NullReferenceException)
                    {
                    }
                    route.RemoveAt(route.Count - 1);
                }
            }
        }
    }

    private void OnBinding(BindingBase bindingBase, List<string> route)
    {
        if(bindingBase is Binding binding)
        {
            if (binding.Path is { } && binding.Path.Path is { } && binding.Path.Path.StartsWith('$'))
            {
                if (Verbose > 0)
                {
                    Console.Write($"{_indention} {string.Join('/', route)} < Path: {binding.Path.Path}");
                }
                if (_replacements.TryGetValue(binding.Path.Path, out string? newPath))
                {
                    binding.Path.Path = newPath;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {binding.Path.Path} >");
                    }
                }
                else if (Strict)
                {
                    throw new System.Windows.Markup.XamlParseException($"Path parameter is not provided: {binding.Path.Path} at {_value.ResourceKey}");
                }
                else if (Verbose > 0)
                {
                    Console.WriteLine($" - is not provided! >");
                }
            }
            if (binding.ConverterParameter is string converterParameter && converterParameter.StartsWith('$'))
            {
                if (Verbose > 0)
                {
                    Console.Write($"{_indention} {string.Join('/', route)} < ConverterParameter: {binding.ConverterParameter}");
                }
                if (_replacements.TryGetValue(converterParameter, out string? newConverterParameter))
                {
                    binding.ConverterParameter = newConverterParameter;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {binding.ConverterParameter} >");
                    }
                }
                else if (Strict)
                {
                    throw new System.Windows.Markup.XamlParseException($"ConverterParameter parameter is not provided: {converterParameter} at {_value.ResourceKey}");
                }
                else if (Verbose > 0)
                {
                    Console.WriteLine($" - is not provided! >");
                }
            }
            if (binding.XPath is string xPath && xPath.StartsWith('$'))
            {
                if (Verbose > 0)
                {
                    Console.Write($"{_indention} {string.Join('/', route)} < XPath: {binding.XPath}");
                }
                if (_replacements.TryGetValue(xPath, out string? newXPath))
                {
                    binding.XPath = newXPath;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {binding.XPath} >");
                    }
                }
                else if (Strict)
                {
                    throw new System.Windows.Markup.XamlParseException($"XPath parameter is not provided: {xPath} at {_value.ResourceKey}");
                }
                else if (Verbose > 0)
                {
                    Console.WriteLine($" - is not provided! >");
                }
            }
            if (binding.ElementName is string elementName && elementName.StartsWith('$'))
            {
                if (Verbose > 0)
                {
                    Console.Write($"{_indention} {string.Join('/', route)} < ElementName: {binding.ElementName}");
                }
                if (_replacements.TryGetValue(elementName, out string? newElementName))
                {
                    binding.ElementName = newElementName;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {binding.ElementName} >");
                    }
                }
                else if (Strict)
                {
                    throw new System.Windows.Markup.XamlParseException($"ElementName parameter is not provided: {elementName} at {_value.ResourceKey}");
                }
                else if (Verbose > 0)
                {
                    Console.WriteLine($" - is not provided! >");
                }
            }
        }
        else if(bindingBase is MultiBinding multiBinding)
        {
            if (multiBinding.ConverterParameter is string converterParameter && converterParameter.StartsWith('$'))
            {
                if (Verbose > 0)
                {
                    Console.Write($"{_indention} {string.Join('/', route)} < ConverterParameter: {multiBinding.ConverterParameter}");
                }
                if (_replacements.TryGetValue(converterParameter, out string? newConverterParameter))
                {
                    multiBinding.ConverterParameter = newConverterParameter;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {multiBinding.ConverterParameter} >");
                    }
                }
                else if (Strict)
                {
                    throw new System.Windows.Markup.XamlParseException($"ConverterParameter parameter is not provided: {converterParameter} at {_value.ResourceKey}");
                }
                else if (Verbose > 0)
                {
                    Console.WriteLine($" - is not provided! >");
                }
            }
            foreach(Binding bindingItem in multiBinding.Bindings)
            {
                OnBinding(bindingItem, route);
            }
        }
    }
}
