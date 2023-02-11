using System.Collections.Immutable;

namespace Net.Leksi.Pocota.Client;

public interface IEntity: IPoco
{
    IEnumerable<string> KeyNames { get; }
    ImmutableArray<object>? PrimaryKey { get; }
    void Create();
    void Delete();
    void Undelete();
}
