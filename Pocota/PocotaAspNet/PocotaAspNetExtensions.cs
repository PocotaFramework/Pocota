namespace Net.Leksi.Pocota.Asp;

public static class PocotaAspNetExtensions
{
    public static WebApplication UsePocotaExceptionsHandler(this WebApplication app)
    {
        Middleware.UsePocotaExceptionsHandler(app);
        return app;
    }
}
