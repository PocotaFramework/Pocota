namespace EFLearning;

public class CompanyImpl : Company
{
    public override int Id { get; set; }
    public override string Name { get; set; }
    public override string Code { get; set; }
    public override User Director { get; set; }
}
