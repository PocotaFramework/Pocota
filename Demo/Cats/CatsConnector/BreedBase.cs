
//------------------------------
// Client implementation
// CatsCommon.Model.BreedBase
// (Generated automatically 2022-12-13T18:47:10)
//------------------------------

using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;

namespace CatsCommon.Model;

public class BreedBase: EntityBase, IProjector
{
    
    private String _code = default!;
    private String _group = default!;
    private String? _nameEng = default;
    private String? _nameNat = default;

    
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


