namespace Net.Leksi.Pocota.Common;

public interface IProjection
{
    IProjection Projector { get; }
    I? As<I>() where I : class;
    object? As(Type type);
}
