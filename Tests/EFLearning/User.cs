namespace EFLearning;

public abstract class User
{
    public abstract int Id { get; set; }
    public abstract string? Name { get; set; }
    public abstract int Age { get; set; }
    public abstract User? Manager { get; set; }
    public abstract Company? Company { get; set; }
}