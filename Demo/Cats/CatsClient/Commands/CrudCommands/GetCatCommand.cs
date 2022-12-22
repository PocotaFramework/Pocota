using CatsCommon.Model;
using System;

namespace CatsClient;

public class GetCatCommand : GetItemCommand<ICat>
{
    public GetCatCommand(IServiceProvider services) : base(services)
    {
        _get =  _connector.GetCatAsync!;
    }
}
