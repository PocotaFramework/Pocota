
//------------------------------
// Client implementation
// CatsCommon.Filters.LitterFilterBase
// (Generated automatically 2022-12-13T18:47:10)
//------------------------------

using CatsCommon.Filters;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;

namespace CatsCommon.Filters;

public class LitterFilterBase: EnvelopeBase, IProjector
{
    
    private CatBase _female = default!;
    private CatBase _male = default!;

    
    protected override bool IsCollectionChanged(string property)
    {
        switch(property)
        {
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
    }

    protected override void AcceptCollectionsChanges()
    {
    }

}


