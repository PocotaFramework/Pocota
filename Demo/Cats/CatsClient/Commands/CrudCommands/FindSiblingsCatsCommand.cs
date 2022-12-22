using CatsCommon.Filters;
using CatsCommon.Model;
using System;

namespace CatsClient.Commands;

public class FindSiblingsCatsCommand : FindItemsCommand<ILitterWithCats, ICatFilter>
{
    public FindSiblingsCatsCommand(IServiceProvider services) : base(services)
    {
        _find = (filter, context) => _connector.FindLittersWithCatsAsync(filter, context!);
    }
}
