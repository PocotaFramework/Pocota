
//------------------------------
// Client implementation
// CatsCommon.Model.CatBase
// (Generated automatically 2022-12-13T18:47:10)
//------------------------------

using CatsCommon;
using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.ObjectModel;

namespace CatsCommon.Model;

public class CatBase: EntityBase, IProjector
{
    
    private CatteryBase _cattery = default!;
    private String? _nameNat = default;
    private String? _nameEng = default;
    private Gender _gender = default!;
    private BreedBase _breed = default!;
    private LitterBase? _litter = default;
    private String? _exterior = default;
    private String? _title = default;
    private String? _description = default;
    private readonly ObservableCollection<LitterBase> _litters = new();
    private readonly List<LitterBase> _initial_litters = new();

    
    protected override bool IsCollectionChanged(string property)
    {
        switch(property)
        {
            case "Litters":
                return !Enumerable.SequenceEqual(
                        _litters.OrderBy(o => o.GetHashCode()), 
                        _initial_litters.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
        for(int i = _litters.Count - 1; i >= 0; --i)
        {
            if (!_initial_litters.Contains(_litters[i]))
            {
                _litters.RemoveAt(i);
            }
        }
        foreach(var item in _initial_litters)
        {
            if(!_litters.Contains(item))
            {
                _litters.Add(item);
            }
        }
    }

    protected override void AcceptCollectionsChanges()
    {
        if(_modified is null || !_modified.ContainsKey("Litters"))
        {
            _initial_litters.Clear();
            _initial_litters.AddRange(_litters);
        }
    }

}


