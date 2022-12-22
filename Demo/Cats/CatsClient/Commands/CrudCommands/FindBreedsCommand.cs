using CatsCommon.Filters;
using CatsCommon.Model;
using System;

namespace CatsClient;

public class FindBreedsCommand : FindItemsCommand<IBreed, IBreedFilter>
{
    public FindBreedsCommand(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _find = _connector.FindBreedsAsync!;
    }
}