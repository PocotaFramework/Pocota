using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Markup.Primitives;
using System.Windows.Media;
using XamlParseException = System.Windows.Markup.XamlParseException;

namespace Net.Leksi.Pocota.Client;

public class ParameterizedResourceExtension : MarkupExtension
{
    private const string s_indentionStep = "  ";
    private StaticResourceExtension _value = null!;
    private readonly Dictionary<string, string> _replacements = new();
    private readonly Dictionary<string, string> _defaults = new();
    private object? _replaces;
    private object? _defaultsString;
    private static readonly Stack<ParameterizedResourceExtension> s_callStacks = new();
    private string _indention = string.Empty;
    private string _prompt = string.Empty;
    private readonly HashSet<object> _seenObjects = new(ReferenceEqualityComparer.Instance);
    private IServiceProvider _services = null!;

    public object? Replaces
    {
        get => _replaces;
        set
        {
            if (!object.Equals(_replaces, value))
            {
                _replaces = value;
                _replacements.Clear();
                if (_replaces is string str)
                {
                    foreach (
                        string[] ent in str.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                            .Select(entry => entry.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                            .Where(entry => entry.Length == 2)
                    )
                    {
                        _replacements.TryAdd(ent[0], ent[1]);
                    }
                }
                else if (_replaces is object[] arr)
                {
                    foreach (
                        string[]? ent in arr.Select(entry => entry.ToString()?.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                            .Where(entry => entry is { } && entry.Length == 2)
                    )
                    {
                        if(ent is { })
                        {
                            _replacements.TryAdd(ent[0], ent[1]);
                        }
                    }
                }
            }
        }
    }

    public object? Defaults
    {
        get => _defaultsString;
        set
        {
            if (!object.Equals(_defaultsString, value))
            {
                _defaultsString = value;
                _defaults.Clear();
                if (_defaultsString is string str)
                {
                    foreach (
                        string[] ent in str.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                            .Select(entry => entry.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                            .Where(entry => entry.Length == 2)
                    )
                    {
                        _defaults.TryAdd(ent[0], ent[1]);
                    }
                }
                else if (_defaultsString is object[] arr)
                {
                    foreach (
                        string[]? ent in arr.Select(entry => entry.ToString()?.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                            .Where(entry => entry is { } && entry.Length == 2)
                    )
                    {
                        if (ent is { })
                        {
                            _defaults.TryAdd(ent[0], ent[1]);
                        }
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

    public override object? ProvideValue(IServiceProvider serviceProvider)
    {
        _indention = string.Format($"{{0,{s_callStacks.Count}}}", "").Replace(" ", s_indentionStep);
        _prompt = $"{_indention}[{_value.ResourceKey}{(string.IsNullOrEmpty(At) ? string.Empty : $"@{At}")}]";


        if (Verbose > 0)
        {
            Console.WriteLine($"{_prompt} < ProvideValue >");
            foreach (string parameterName in _replacements.Keys)
            {
                Console.WriteLine($"{_prompt} < {parameterName}={_replacements[parameterName]} (from {nameof(Replaces)}) >");
            }
        }

        if (s_callStacks.Count > 0)
        {
            foreach (ParameterizedResourceExtension resource in s_callStacks)
            {
                if (Verbose == 0 && resource.Verbose > 0)
                {
                    Console.WriteLine($"{_prompt} < ProvideValue >");
                    foreach (string parameterName in _replacements.Keys)
                    {
                        Console.WriteLine($"{_prompt} < {parameterName}={_replacements[parameterName]} (from {nameof(Replaces)}) >");
                    }
                }
                if (Strict && !resource.Strict)
                {
                    Strict = false;
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
                            Console.WriteLine($"{_prompt} < {parameterName}={resource._replacements[parameterName]} (from {resource._value.ResourceKey}) >");
                        }
                    }
                }
                _services = resource._services;
            }
        }
        else
        {
            _services = serviceProvider;
        }


        s_callStacks.Push(this);

        bool properKey = true;

        if (_value.ResourceKey.ToString()!.StartsWith('$'))
        {
            if (Verbose > 0)
            {
                Console.Write($"{_indention}< ResourceKey: {_value.ResourceKey}");
            }
            properKey = false;
            if (_replacements.TryGetValue(_value.ResourceKey.ToString()!, out string? newKey))
            {
                _value = new StaticResourceExtension(newKey);
                _prompt = $"{_indention}[{_value.ResourceKey}{(string.IsNullOrEmpty(At) ? string.Empty : $"@{At}")}]";

                properKey = true;
                if (Verbose > 0)
                {
                    Console.WriteLine($" -> {_value.ResourceKey} >");
                }
            }
            else if (Strict)
            {
                throw new System.Windows.Markup.XamlParseException($"ResourceKey parameter is not provided: {_value.ResourceKey.ToString()}!");
            }
            else if (Verbose > 0)
            {
                Console.WriteLine($" - is not provided! >");
            }
        }

        if (properKey)
        {
            object result = _value.ProvideValue(_services);

            List<string> route = new();
            WalkMarkup(MarkupWriter.GetMarkupObjectFor(result), route);

            s_callStacks.Pop();

            if (Verbose > 0)
            {
                Console.WriteLine($"{_prompt} < Done >");
            }
            return result;
        }

        return null;

    }

    private void WalkMarkup(MarkupObject mo, List<string> route)
    {
        if (_seenObjects.Add(mo.Instance))
        {
            if (mo.Instance is DependencyObject dependencyObject)
            {
                foreach (
                    PropertyDescriptor pd in TypeDescriptor.GetProperties(
                        dependencyObject, new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }
                    )
                )
                {
                    bool isBinding = false;

                    if (pd.GetValue(dependencyObject) is object value)
                    {
                        if (pd.PropertyType == typeof(BindingBase))
                        {
                            isBinding = true;
                            if (value is Binding binding)
                            {
                                OnBinding(binding, route);
                            }
                            else if (value is MultiBinding multiBinding)
                            {
                                OnBinding(multiBinding, route);
                            }
                        }
                    }
                    if (!isBinding)
                    {
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
                            else if (BindingOperations.GetMultiBinding(dependencyObject, dpd.DependencyProperty) is MultiBinding multiBinding)
                            {
                                route.Add(pd.Name);
                                OnBinding(multiBinding, route);
                                route.RemoveAt(route.Count - 1);
                            }
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
                    if (Verbose > 1)
                    {
                        Console.WriteLine($"{_prompt} {prop.PropertyType} {string.Join('/', route)}");
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
        if (bindingBase is Binding binding)
        {
            if (binding.Path is { } && binding.Path.Path is { } && binding.Path.Path.StartsWith('$'))
            {
                if (Verbose > 0)
                {
                    Console.Write($"{_prompt} {string.Join('/', route)} < Path: {binding.Path.Path}");
                }
                if (_replacements.TryGetValue(binding.Path.Path, out string? newPath))
                {
                    binding.Path.Path = newPath;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {binding.Path.Path} (from {nameof(Replaces)}) >");
                    }
                }
                else if (_defaults.TryGetValue(binding.Path.Path, out string? defaultPath))
                {
                    binding.Path.Path = defaultPath;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {binding.Path.Path} (from {nameof(Defaults)}) >");
                    }
                }
                else if (Strict)
                {
                    throw new XamlParseException($"Path parameter is not provided: {binding.Path.Path} at {_value.ResourceKey}");
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
                    Console.Write($"{_prompt} {string.Join('/', route)} < ConverterParameter: {binding.ConverterParameter}");
                }
                if (_replacements.TryGetValue(converterParameter, out string? newConverterParameter))
                {
                    binding.ConverterParameter = newConverterParameter;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {binding.ConverterParameter} (from {nameof(Replaces)}) >");
                    }
                }
                else if (_defaults.TryGetValue(converterParameter, out string? defaultConverterParameter))
                {
                    binding.ConverterParameter = defaultConverterParameter;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {binding.ConverterParameter} (from {nameof(Defaults)}) >");
                    }
                }
                else if (Strict)
                {
                    throw new XamlParseException($"ConverterParameter parameter is not provided: {converterParameter} at {_value.ResourceKey}");
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
                    Console.Write($"{_prompt} {string.Join('/', route)} < XPath: {binding.XPath}");
                }
                if (_replacements.TryGetValue(xPath, out string? newXPath))
                {
                    binding.XPath = newXPath;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {binding.XPath} (from {nameof(Replaces)}) >");
                    }
                }
                else if (_defaults.TryGetValue(xPath, out string? defaultXPath))
                {
                    binding.XPath = defaultXPath;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {binding.XPath} (from {nameof(Defaults)}) >");
                    }
                }
                else if (Strict)
                {
                    throw new XamlParseException($"XPath parameter is not provided: {xPath} at {_value.ResourceKey}");
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
                    Console.Write($"{_prompt} {string.Join('/', route)} < ElementName: {binding.ElementName}");
                }
                if (_replacements.TryGetValue(elementName, out string? newElementName))
                {
                    binding.ElementName = newElementName;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {binding.ElementName} (from {nameof(Replaces)}) >");
                    }
                }
                else if (_defaults.TryGetValue(elementName, out string? defaultElementName))
                {
                    binding.ElementName = defaultElementName;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {binding.ElementName} (from {nameof(Defaults)}) >");
                    }
                }
                else if (Strict)
                {
                    throw new XamlParseException($"ElementName parameter is not provided: {elementName} at {_value.ResourceKey}");
                }
                else if (Verbose > 0)
                {
                    Console.WriteLine($" - is not provided! >");
                }
            }
        }
        else if (bindingBase is MultiBinding multiBinding)
        {
            if (multiBinding.ConverterParameter is string converterParameter && converterParameter.StartsWith('$'))
            {
                if (Verbose > 0)
                {
                    Console.Write($"{_prompt} {string.Join('/', route)} < ConverterParameter: {multiBinding.ConverterParameter}");
                }
                if (_replacements.TryGetValue(converterParameter, out string? newConverterParameter))
                {
                    multiBinding.ConverterParameter = newConverterParameter;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {multiBinding.ConverterParameter} (from {nameof(Replaces)}) >");
                    }
                }
                else if (_defaults.TryGetValue(converterParameter, out string? defaultConverterParameter))
                {
                    multiBinding.ConverterParameter = defaultConverterParameter;
                    if (Verbose > 0)
                    {
                        Console.WriteLine($" -> {multiBinding.ConverterParameter} (from {nameof(Defaults)}) >");
                    }
                }
                else if (Strict)
                {
                    throw new XamlParseException($"ConverterParameter parameter is not provided: {converterParameter} at {_value.ResourceKey}");
                }
                else if (Verbose > 0)
                {
                    Console.WriteLine($" - is not provided! >");
                }
            }
            foreach (Binding bindingItem in multiBinding.Bindings)
            {
                OnBinding(bindingItem, route);
            }
        }
    }
}
