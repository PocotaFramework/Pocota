namespace Net.Leksi.Pocota.Builder;

internal class Token
{
    internal TokenType TokenType { get; init; }
    internal string? Literal { get; init; }
    internal Token(TokenType tokenType, string? literal = null)
    {
        TokenType = tokenType;
        Literal = literal;
    }
    public override string ToString()
    {
        return TokenType.ToString() + (Literal is null ? string.Empty : ": " + Literal);
    }
}

