﻿using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Net.Leksi.Pocota.Server;

public class PocotaCore : PocotaCoreBase
{
    private readonly ConditionalWeakTable<JsonSerializerOptions, PocoTraversalContext> _pocoJsonContexts = new();
    private readonly Dictionary<Type, object> _probePlaceholders = new();
    private readonly Dictionary<Type, object> _skipPlaceholders = new();

    public bool IsEntity(Type type)
    {
        return typeof(IEntity).IsAssignableFrom(GetActualType(type));
    }

    internal static void Configure(
            IServiceCollection services,
            Action<IServiceCollection>? configureServices = null,
            Action<IJsonSerializerConfiguration>? configureJson = null
        )
    {
        PocotaCore core = new();
        core._services = services;
        ServiceCollectionWrapper serviceDescriptors = new(core);
        configureServices?.Invoke(serviceDescriptors);
        List<ServiceDescriptor> primaryKeysDescriptors = new();
        foreach (ServiceDescriptor item in services)
        {
            if (core.GetActualType(item.ServiceType) is Type actualType && typeof(IEntity).IsAssignableFrom(actualType))
            {
                Type primaryKeyType = (Type)actualType.GetField("PrimaryKeyType")!.GetValue(null)!;
                Type serviceType = typeof(IPrimaryKey<>).MakeGenericType(item.ServiceType);
                if (serviceType.IsAssignableFrom(primaryKeyType))
                {
                    primaryKeysDescriptors.Add(new ServiceDescriptor(typeof(IPrimaryKey<>).MakeGenericType(item.ServiceType), primaryKeyType, ServiceLifetime.Transient));
                }
            }
        }
        foreach (ServiceDescriptor item in primaryKeysDescriptors)
        {
            services.Add(item);
        }
        configureJson?.Invoke(core);
        core._services = null;
        services.AddScoped<IPocoContext, PocoContext>();
        services.AddSingleton(core);
        services.AddTransient<IPocoTraversalContext, PocoTraversalContext>();
        services.AddTransient<PocoTraversalConverterFactory>();
        services.AddTransient<BuildingContext>();
        services.AddTransient<BuildingScript>();
        //foreach (ServiceDescriptor item in services)
        //{
        //    Console.WriteLine(item);
        //}
    }

    internal void AddPocoJsonContext(JsonSerializerOptions options, PocoTraversalContext context)
    {
        _pocoJsonContexts.AddOrUpdate(options, context);
    }

    internal bool TryGetPocoJsonContext(JsonSerializerOptions options, out PocoTraversalContext? context)
    {
        return _pocoJsonContexts.TryGetValue(options, out context);
    }

    internal object? GetProbePlaceholder(Type type, Func<object> supplier)
    {
        return GetPlaceholder(type, supplier, _probePlaceholders);
    }

    internal object? GetSkipPlaceholder(Type type, Func<object> supplier)
    {
        return GetPlaceholder(type, supplier, _skipPlaceholders);
    }

    internal new HashSet<Type>? GetJsonConverters(Type target)
    {
        return base.GetJsonConverters(target);
    }

    private object? GetPlaceholder(Type type, Func<object> supplier, Dictionary<Type, object> placeholders)
    {
        object? placeholder = null;
        if (!placeholders.TryGetValue(type, out placeholder))
        {
            lock (placeholders)
            {

                if (!placeholders.TryGetValue(type, out placeholder))
                {
                    Type? actualType = null;
                    bool isList = false;

                    if (GetActualType(type) is Type tmpType)
                    {
                        actualType = tmpType;
                    }
                    else if (
                        type.IsGenericType
                        && (
                            typeof(IList).IsAssignableFrom(type)
                            || typeof(IList<>).MakeGenericType(type.GetGenericArguments()[0]).IsAssignableFrom(type)
                        )
                        && GetActualType(type.GetGenericArguments()[0]) is Type itemType
                    )
                    {
                        isList = true;
                        actualType = typeof(List<>).MakeGenericType(type.GetGenericArguments()[0]);
                    }
                    else
                    {
                        return null;
                    }
                    if (!placeholders.TryGetValue(actualType, out placeholder))
                    {
                        if (isList)
                        {
                            placeholder = Activator.CreateInstance(actualType);
                        }
                        else
                        {
                            placeholder = supplier?.Invoke();
                            if (placeholder is IProjection projection1)
                            {
                                placeholder = projection1.As<IPoco>()!;
                            }
                        }
                        if (placeholders is { })
                        {
                            placeholders.Add(actualType, placeholder!);
                            if(type != actualType)
                            {
                                placeholders.Add(type, placeholder!);
                            }
                        }
                    }
                    else
                    {
                        placeholders.Add(type, placeholder!);
                    }
                }
            }
        }
        if (placeholder is IProjection projection)
        {
            return projection.As(type);
        }
        return placeholder;
    }

}
