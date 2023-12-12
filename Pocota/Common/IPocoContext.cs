namespace Net.Leksi.Pocota;

public interface IPocoContext
{
    ProcessingStage ProcessingStage { get; }
    bool TryFindEntity<T>(IEnumerable<object> primaryKey, out T obj) where T: class;
}
