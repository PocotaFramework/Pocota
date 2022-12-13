
//------------------------------
// Client implementation
// CatsCommon.Filters.CatteryFilterBase
// (Generated automatically 2022-12-13T18:47:10)
//------------------------------

using CatsCommon.Filters;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;

namespace CatsCommon.Filters;

public class CatteryFilterBase: EnvelopeBase, IProjector
{
    
    private String? _searchRegex = default;

    
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


