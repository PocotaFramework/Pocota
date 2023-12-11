namespace Net.Leksi.Pocota;

public interface IPocoContext
{
    ProcessingStage ProcessingStage { get; }
    T GetEntity<T>(IEnumerable<object> primaryKey) where T: class;
}
