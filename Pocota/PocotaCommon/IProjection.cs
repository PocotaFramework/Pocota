namespace Net.Leksi.Pocota.Common;

public interface IProjection
{
    I? As<I>() where I : class;
    object? As(Type type);
    int HashCode();
}
