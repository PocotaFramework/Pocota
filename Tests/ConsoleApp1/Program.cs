using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Demo.Cats.Server;
using Net.Leksi.Pocota.Server;

int n = 100000000;
HashSet<Type> entityTypes = new() { 
    typeof(Cat),  typeof(CatPoco), typeof(ICat),
    typeof(BreedPoco), typeof(IBreed),
    typeof(CatteryPoco), typeof(ICattery),
    typeof(LitterPoco), typeof(ILitter),
};
List<Type> typesList = new()
{
    typeof(Cat),  typeof(CatPoco), typeof(ICat),
    typeof(BreedPoco), typeof(IBreed),
    typeof(CatteryPoco), typeof(ICattery),
    typeof(LitterPoco), typeof(ILitter),
    typeof(CatFilterPoco), typeof(ICatFilter),
    typeof(BreedFilterPoco), typeof(IBreedFilter),
    typeof(CatteryFilterPoco), typeof(ICatteryFilter),
    typeof(LitterWithCatsPoco), typeof(ILitterWithCats),
    typeof(LitterFilterPoco), typeof(ILitterFilter),
};
DateTime start = DateTime.Now;
for (int i = 0; i < n; ++i)
{

    if (typeof(IEntity).IsAssignableFrom(typesList[i % typesList.Count]))
    {

    }
}
Console.WriteLine($"Elapsed: {DateTime.Now - start}");
start = DateTime.Now;
for (int i = 0; i < n; ++i)
{
    if (entityTypes.Contains(typesList[i % typesList.Count]))
    {

    }
}
Console.WriteLine($"Elapsed: {DateTime.Now - start}");

