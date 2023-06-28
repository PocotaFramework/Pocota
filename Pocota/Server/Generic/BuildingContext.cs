namespace Net.Leksi.Pocota.Server.Generic;

public class BuildingContext<T>: BindingContext where T : class
{
    private readonly IServiceProvider _services;

    public T? Value { get; set; }

    public BuildingContext(IServiceProvider services)
    {
        _services = services;
    }

    public override void Process(PocoBase poco)
    {
        Value = poco as T;
        if(poco is { } && Value is null)
        {
            throw new InvalidCastException();
        }
    }
}
