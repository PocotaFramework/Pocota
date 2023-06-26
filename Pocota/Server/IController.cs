namespace Net.Leksi.Pocota.Server;

public interface IController
{
    [ExpectedOutputType(typeof(IList<IEntity>))]
    void Update();
}
