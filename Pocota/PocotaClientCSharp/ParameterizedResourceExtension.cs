using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Markup.Primitives;
using System.Xaml;

namespace Net.Leksi.Pocota.Client;

public class ParameterizedResourceExtension : MarkupExtension
{
    private readonly StaticResourceExtension _value;
    private readonly Dictionary<string, string> _replacements = new();
    private string? _replaces;
    private static readonly Dictionary<object, Stack<ParameterizedResourceExtension>> s_callStacks = new();
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

    public ParameterizedResourceExtension(object key)
    {
        _value = new StaticResourceExtension(key);
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        object rootObject = serviceProvider.GetRequiredService<IRootObjectProvider>().RootObject;
        Stack<ParameterizedResourceExtension>? stack = null;
        if (!s_callStacks.TryGetValue(rootObject, out stack))
        {
            stack = new Stack<ParameterizedResourceExtension>();
            s_callStacks.Add(rootObject, stack);
        }

        _indention = string.Format($"{{0,{stack.Count}}}", "").Replace(" ", "    ");
        Console.WriteLine($"{_indention}ProvideValue: {_value.ResourceKey}");

        if (stack.Count > 0)
        {
            foreach (ParameterizedResourceExtension resource in stack)
            {
                Console.WriteLine($"{_indention}copy replaces from {resource._value.ResourceKey}");
                foreach (string parameterName in resource._replacements.Keys)
                {
                    if (_replacements.TryAdd(parameterName, resource._replacements[parameterName]))
                    {
                        Console.WriteLine($"{_indention}{parameterName}={resource._replacements[parameterName]}");
                    }
                }
            }
        }

        stack.Push(this);

        object result = _value.ProvideValue(serviceProvider);
        Console.WriteLine($"{_indention}{result}: {result.GetHashCode()}");
        MarkupObject markupObject = MarkupWriter.GetMarkupObjectFor(result);

        WalkMarkup(markupObject);

        stack.Pop();
        return result;
    }

    private void WalkMarkup(MarkupObject markupObject)
    {
        foreach (MarkupProperty? prop in markupObject.Properties)
        {
            try
            {
                foreach (MarkupObject? item in prop.Items)
                {
                    if (item.Instance is Binding binding)
                    {
                        OnBinding(binding);
                    }
                    else if (!(item.Instance is TypeExtension))
                    {
                        WalkMarkup(item);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }

    private void OnBinding(Binding binding)
    {
        Console.WriteLine($"{_indention}>{_value.ResourceKey}: {binding.Path.Path}, {binding.ConverterParameter}");
        if (binding.Path.Path is { } && _replacements.TryGetValue(binding.Path.Path, out string? newPath))
        {
            binding.Path.Path = newPath;
        }
        if (binding.ConverterParameter is string converterParameter && _replacements.TryGetValue(converterParameter, out string? newConverterParameter))
        {
            binding.ConverterParameter = newConverterParameter;
        }
        Console.WriteLine($"{_indention}<{_value.ResourceKey}: {binding.Path.Path}, {binding.ConverterParameter}");
    }
}
