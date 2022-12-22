using CatsCommon.Filters;
using CatsCommon.Model;
using System;

namespace CatsClient;

public class FindCatteriesCommand : FindItemsCommand<ICattery, ICatteryFilter>
{
    public FindCatteriesCommand(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _find = _connector.FindCatteriesAsync!;
    }
}