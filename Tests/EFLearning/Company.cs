namespace EFLearning;

public abstract class Company
{
    public abstract int Id { get; set; }
    public abstract string Name { get; set; }
    public abstract string Code { get; set; }
    public abstract User Director { get; set; }
}
