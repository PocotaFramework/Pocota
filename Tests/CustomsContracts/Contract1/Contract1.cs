using Net.Leksi.Pocota;

namespace Contract1;

public class Contract1 : Contract
{
    public override string RoutePrefix => string.Empty;

    public override void ConfigurePocos()
    {
        Entity<Entity1>().PrimaryKey(o => new object[] { o.Entity2 }); ;
        Entity<Entity2>().PrimaryKey(o => new object[] { o.Id1, o.Id2 });
    }
}
