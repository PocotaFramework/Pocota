namespace Net.Leksi.Pocota.Common
{
    internal class AttributeModel
    {
        private const string Attribute = "Attribute";
        private const string Comma = ", ";
        private const string Equal = "=";
        private const string LeftParen = "(";
        private const string RightParen = ")";

        internal string Name { get; set; } = null!;

        internal Dictionary<string, string> Properties { get; init; } = new();

        public override string ToString()
        {
            string result = (Name.EndsWith(Attribute) ? Name.Substring(0, Name.Length - Attribute.Length) : Name)
                + (
                    (Properties.Count > 0 ? LeftParen + string.Join(Comma, Properties.Select(
                        p => (p.Key[0] == '!' ? string.Empty : p.Key + Equal)
                             + p.Value
                        )
                ) + RightParen : string.Empty)
            );
            return result;
        }

    }
}