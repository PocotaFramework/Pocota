namespace Net.Leksi.Pocota.Common.Generic;

public interface IProjection<T>: IProjector
{
    T Projector { get; }
}
