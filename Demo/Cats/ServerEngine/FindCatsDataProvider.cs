using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Server;
using System.Data.Common;

namespace Net.Leksi.Pocota.Demo.Cats.Server;

public class FindCatsDataProvider : DataProvider
{
    private ICatFilter? _filter = null;
    private Func<ICatFilter?, DbDataReader?>? _getDataReader = null;
    private readonly IStorage _storage;
    private DbDataReader? _dataReader = null;

    public override object? this[string path]
    {
        get
        {
            return DateTime.Now;
            return DataProviderResponse.Miss;
        }
    }

    internal ICatFilter? Filter 
    { 
        get => _filter; 
        set
        {
            if(_dataReader is null && value is { })
            {
                _filter = value;
                if (_filter.Descendant is null && _filter.Ancestor is null)
                {
                    _getDataReader = _storage.SelectCats;
                }
            }
        }
    }

    public FindCatsDataProvider(IServiceProvider services): base(services) 
    { 
        _storage = _services.GetRequiredService<IStorage>();
    }

    public override bool Read()
    {
        if(_dataReader is null)
        {
            if (_filter is null)
            {
                _getDataReader = _storage.SelectCats;
            }
            if (_getDataReader is { })
            {
                _dataReader = _getDataReader.Invoke(_filter);
            }
        }
        if (_dataReader is { })
        {
            if (_dataReader!.Read())
            {
                return true;
            }
            if (!_dataReader!.IsClosed)
            {
                _dataReader!.Close();
            }
        }
        return false;
    }
}
