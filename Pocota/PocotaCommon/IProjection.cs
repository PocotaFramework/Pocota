namespace Net.Leksi.Pocota.Common;

public interface IProjection<T>
{
    T Projector { get; }
}
