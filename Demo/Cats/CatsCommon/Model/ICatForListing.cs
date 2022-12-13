namespace CatsCommon.Model;

public interface ICatForListing
{
    string? NameNat { get; }
    string? NameEng { get; }
    Gender Gender { get; }
    ICattery Cattery { get; }
    IBreed Breed { get; }
    ILitterForCat? Litter { get; }
    public string? Exterior { get; }
    public string? Description { get; }
    public string? Title { get; }
}
