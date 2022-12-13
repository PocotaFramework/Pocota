
//------------------------------
// Client implementation
// CatsCommon.Filters.CatFilterBase
// (Generated automatically 2022-12-13T18:47:10)
//------------------------------

using CatsCommon;
using CatsCommon.Filters;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;

namespace CatsCommon.Filters;

public class CatFilterBase: EnvelopeBase, IProjector
{
    
    private BreedBase? _breed = default;
    private CatteryBase? _cattery = default;
    private DateOnly? _bornAfter = default;
    private DateOnly? _bornBefore = default;
    private String? _nameRegex = default;
    private Gender? _gender = default;
    private CatBase? _child = default;
    private CatBase? _self = default;
    private CatBase? _mother = default;
    private CatBase? _father = default;
    private CatBase? _ancestor = default;
    private CatBase? _descendant = default;
    private LitterBase? _litter = default;
    private String? _exteriorRegex = default;
    private String? _titleRegex = default;

    
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


