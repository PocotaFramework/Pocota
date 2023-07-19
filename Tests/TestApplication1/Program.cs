using Microsoft.Extensions.DependencyInjection.Extensions;
using Net.Leksi.Pocota.Server;
using NUnit.Framework;
using System.Diagnostics;

namespace TestApplication1;

public class Tests
{

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.AutoFlush = true;
    }

    [Test]
    public void Test1()
    {
        using ServerWrapper server = new(Array.Empty<string>());

        server.AfterConfigureBuilder = builder =>
        {
            builder.Services.RemoveAll<ICoreTelemetry>();
            builder.Services.AddSingleton<ICoreTelemetry, CoreTelemetry1>();
        };

        server.Start();

        server.Stop();

    }
}

internal class CoreTelemetry1 : ICoreTelemetry
{
    public void Receive(Dictionary<string, object> telemetry)
    {
        if (telemetry.TryGetValue("_actualTypes", out object? obj1) && obj1 is Dictionary<Type, Type> actualTypes)
        {
            Console.WriteLine("_actualTypes:");
            foreach (var item in actualTypes)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        if (telemetry.TryGetValue("_primaryKeyTypesByType", out object? obj2) && obj2 is Dictionary<Type, Type> primaryKeyTypesByType)
        {
            Console.WriteLine("_primaryKeyTypesByType:");
            foreach (var item in primaryKeyTypesByType)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        if (telemetry.TryGetValue("_accessManagerTypesByType", out object? obj3) && obj3 is Dictionary<Type, Type> accessManagerTypesByType)
        {
            Console.WriteLine("_accessManagerTypesByType:");
            foreach (var item in accessManagerTypesByType)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}