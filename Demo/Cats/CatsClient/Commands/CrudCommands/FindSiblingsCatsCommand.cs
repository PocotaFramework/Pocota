using CatsCommon.Filters;
using CatsCommon.Model;
using System;

namespace CatsClient.Commands;

public class FindSiblingsCatsCommand : FindItemsCommand<ICatWithSiblings, ICatFilter>
{
    public FindSiblingsCatsCommand(IServiceProvider services) : base(services)
    {
        _find = (filter, context) => _connector.FindLittersWithCatsAsync(filter, context!);
    }
}
