using Net.Leksi.Pocota;

namespace Contract1;

public class Contract1 : Contract
{
    public override string Version => string.Empty;

    public override string RoutePrefix => string.Empty;

    public override void ConfigurePocos()
    {
        Entity<Entity1>();
        Entity<Entity2>().PrimaryKey(o => new object[] { o.Id1, o.Id2 });
    }
}
