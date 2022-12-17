using CatsCommon;
using CatsCommon.Model;

namespace CatsServerMisc;

public class Cat : ICat
{
    public string? NameNat { get; set; }
    public string? NameEng { get; set; }
    public Gender Gender { get; set; }
    public IBreed Breed { get; set; }
    public ICattery Cattery { get; set; }
    public ILitter? Litter { get; set; }
    public string? Exterior { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public IList<ILitter> Litters { get; set; }
}
