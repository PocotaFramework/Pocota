namespace Net.Leksi.Pocota.ORMGenerator;

public class DataTypeModel
{
    public string Name { get; set; } = null!;
    public int Size { get; set; } = 0;
    public List<string>? Check { get; set; }
}
