using CatsCommon;

namespace CatsCommon.Model;

public interface ICat
{
    string? NameNat { get; set; }
    string? NameEng { get; set; }
    Gender Gender { get; set; }
    IBreed Breed { get; set; }
    ICattery Cattery { get; set; }
    ILitter? Litter { get; set; }
    string? Exterior { get; set; }
    string? Title { get; set; }
    string? Description { get; set; }
    IList<ILitter> Litters { get; set; }
}