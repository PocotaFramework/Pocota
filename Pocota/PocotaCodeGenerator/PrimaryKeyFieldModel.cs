namespace Net.Leksi.Pocota.Common
{
    public class PrimaryKeyFieldModel
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? Property { get; set; } = null;
        public string? KeyReference { get; set; } = null;
        public string? PropertyType { get; set; } = null;
        public string? KeyType { get; set; } = null;
    }
}
