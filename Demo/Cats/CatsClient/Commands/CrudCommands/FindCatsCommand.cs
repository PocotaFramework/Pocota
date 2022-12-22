using CatsCommon.Filters;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Client.Crud;
using System;

namespace CatsClient;

public class FindCatsCommand : FindItemsCommand<ICatForListing, ICatFilter>
{
    public FindCatsCommand(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _find = (filter, options) => _connector.FindCatsAsync(filter, options!);
        //Executing += FindCatsCommand_Executing;
        //Executed += FindCatsCommand_Executed;
    }

    private void FindCatsCommand_Executed(object sender, CrudCommandExecutedEventArgs args)
    {
        if (args.CallContext!.CommandParameter is FindItemsCommand<ICatForListing, ICatFilter>.Parameter parameter && parameter.Target is DoubleBufferingCollection<ICatForListing> smooth)
        {
            smooth.Align();
            parameter.Target = smooth.Target;
        }
    }

    private void FindCatsCommand_Executing(object sender, CrudCommandExecutingEventArgs args)
    {
        if (args.CallContext!.CommandParameter is FindItemsCommand<ICatForListing, ICatFilter>.Parameter parameter)
        {
            parameter.Target = new DoubleBufferingCollection<ICatForListing>(parameter.Target);
        }
    }

    protected override void DoExecute(ApiCallContext callContext)
    {
        base.DoExecute(callContext);
    }
}