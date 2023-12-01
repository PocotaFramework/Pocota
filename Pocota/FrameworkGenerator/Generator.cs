﻿using Net.Leksi.E6dWebApp;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Reflection;
using System.Text;

namespace Net.Leksi.Pocota;

public class Generator: Runner
{
    private Contract _contract = null!;
    public static Generator Create(FrameworkGeneratorOptions options)
    {
        Generator generator = new() 
        { 
            _contract = options.Contract
        };

        generator.ProcessContract();

        return generator;
    }
    private Generator() { }
    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddSingleton(this);
    }
    protected override void ConfigureApplication(WebApplication app)
    {
        app.MapRazorPages();
    }
    private void ProcessContract()
    {
        Start();

        IConnector connector = GetConnector();

        using (Project contractProcessor = Project.Create(new ProjectOptions { 
            Name = "ContractProcessor"
        }))
        {
            StringBuilder sb = new();
            if(typeof(Contract).Namespace is { })
            {
                sb.AppendLine($"using {_contract.GetType().Namespace};");
            }
            sb.Append($@"using System;
public class Contract1: {_contract.GetType().Name}
{{
    public Contract1(IServiceProvider serviceProvider)
    {{
        _serviceProvider = serviceProvider;
    }}
}}
");
            contractProcessor.AddReference(Assembly.GetAssembly(_contract.GetType())!.Location);
            File.WriteAllText(Path.Combine(contractProcessor.ProjectDir, "Contract.cs"), sb.ToString());
            contractProcessor.Compile();
        }

        Stop();
    }
}
