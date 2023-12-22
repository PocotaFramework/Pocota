using System.Reflection;

namespace Net.Leksi.Pocota.ORMGenerator;

public class Options
{
    public Contract Contract { get; set; } = null!;
    public Assembly ServerAssembly { get; set; } = null!;
    public Dialect Dialect { get; set; } = Dialect.MSSql;
    public string ORMProjectDir { get; set; } = null!;
}
