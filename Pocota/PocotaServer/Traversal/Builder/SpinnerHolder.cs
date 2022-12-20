using System.Data.Common;

namespace Net.Leksi.Pocota.Traversal.Builder;

internal class SpinnerHolder
{
    internal int Level { get; set; }
    internal int PathPrefixLength { get; set; } = 0;
    internal IEnumerator<DbDataReader?> Spinner { get; set; } = null!;
    internal BuildingScript? Script { get; set; }
}
