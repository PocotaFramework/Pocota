
//------------------------------
// Client implementation
// CatsCommon.Model.LitterBase
// (Generated automatically 2022-12-13T18:47:10)
//------------------------------

using CatsCommon.Model;
using Net.Leksi.Pocota.Client;
using Net.Leksi.Pocota.Common;
using System;
using System.Collections.ObjectModel;

namespace CatsCommon.Model;

public class LitterBase: EntityBase, IProjector
{
    
    private Int32 _order = default!;
    private CatBase _female = default!;
    private DateOnly _date = default!;
    private CatBase? _male = default;
    private readonly ObservableCollection<CatBase> _cats = new();
    private readonly List<CatBase> _initial_cats = new();
    private readonly ObservableCollection<String> _strings = new();
    private readonly List<String> _initial_strings = new();

    
    protected override bool IsCollectionChanged(string property)
    {
        switch(property)
        {
            case "Cats":
                return !Enumerable.SequenceEqual(
                        _cats.OrderBy(o => o.GetHashCode()), 
                        _initial_cats.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            case "Strings":
                return !Enumerable.SequenceEqual(
                        _strings.OrderBy(o => o.GetHashCode()), 
                        _initial_strings.OrderBy(o => o.GetHashCode()),
                        ReferenceEqualityComparer.Instance
                    );
            default:
                return false;
        }
    }

    protected override void CancelCollectionsChanges()
    {
        for(int i = _cats.Count - 1; i >= 0; --i)
        {
            if (!_initial_cats.Contains(_cats[i]))
            {
                _cats.RemoveAt(i);
            }
        }
        foreach(var item in _initial_cats)
        {
            if(!_cats.Contains(item))
            {
                _cats.Add(item);
            }
        }
        for(int i = _strings.Count - 1; i >= 0; --i)
        {
            if (!_initial_strings.Contains(_strings[i]))
            {
                _strings.RemoveAt(i);
            }
        }
        foreach(var item in _initial_strings)
        {
            if(!_strings.Contains(item))
            {
                _strings.Add(item);
            }
        }
    }

    protected override void AcceptCollectionsChanges()
    {
        if(_modified is null || !_modified.ContainsKey("Cats"))
        {
            _initial_cats.Clear();
            _initial_cats.AddRange(_cats);
        }
        if(_modified is null || !_modified.ContainsKey("Strings"))
        {
            _initial_strings.Clear();
            _initial_strings.AddRange(_strings);
        }
    }

}


