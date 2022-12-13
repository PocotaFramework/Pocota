namespace Net.Leksi.Pocota.Common;

public interface IProjector
{
    I? As<I>();
    object? As(Type type);
}
