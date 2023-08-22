namespace Net.Leksi.Pocota.Server;

public class PocoHeart
{
    protected readonly IServiceProvider _serviceProvider;

    public PocoHeart(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
}
