using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddScoped<Test>();
    services.AddScoped<Test1>();
}).Build();

Test test = host.Services.GetRequiredService<Test>();
Test1 test1 = host.Services.GetRequiredService<Test1>();

Console.WriteLine(test.ToString());
test.Show();

public class Test
{
    private readonly IServiceProvider _services;
    public Test(IServiceProvider services)
    {
        _services = services;
    }

    public void Show()
    {
        Console.WriteLine(_services.CreateScope().ServiceProvider.GetRequiredService<Test>().ToString());
    }

    public override string ToString()
    {
        return $"<{_services.GetHashCode()}, {GetHashCode()}>";
    }
}

public class Test1
{
    private readonly IServiceProvider _services;
    public Test1(IServiceProvider services)
    {
        _services = services;
    }

    public void Show()
    {
        Console.WriteLine(_services.CreateScope().ServiceProvider.GetRequiredService<Test>().ToString());
    }

    public override string ToString()
    {
        return $"<{_services.GetHashCode()}, {GetHashCode()}>";
    }
}
