namespace CatsCommon.Model;

public interface ICatWithSiblings
{
    ILitterWithCats? Litter { get; set; }
}
