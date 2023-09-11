using Microsoft.EntityFrameworkCore.Storage;

namespace EFLearning;

public class UserImpl : User
{
    public override int Id { get; set; }
    public override string? Name { get; set; }
    public override int Age { get; set; }
    public override User? Manager { get; set; }
    public override Company? Company { get; set; }
}
