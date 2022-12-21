namespace Net.Leksi.Pocota.Common;

public interface IProjector
{
    I? As<I>() where I : class;
    object? As(Type type);
}
