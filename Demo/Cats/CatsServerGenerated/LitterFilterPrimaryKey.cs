/////////////////////////////////////////////////////////////
// Server Poco Primary Key                                 //
// CatsCommon.Filters.LitterFilterPrimaryKey               //
// Generated automatically from CatsContract.ICatsContract //
// at 2022-12-19T16:40:25                                  //
/////////////////////////////////////////////////////////////


using Net.Leksi.Pocota.Server.Generic;
    
namespace CatsCommon.Filters;

public class LitterFilterPrimaryKey: IPrimaryKey<LitterFilterBase>
{
    private static string[] s_names = new string[] {  };

    internal LitterFilterBase? Source { get; init; }


    public object? this[int index]
    {
        get => this[s_names[index]];
        set => this[s_names[index]] = value;
    }

    public object? this[string name]
    {
        get 
        {
            switch(name)
            {
                default:
                    throw new IndexOutOfRangeException($"{name}");
            }
        }
        set 
        {
            switch(name)
            {
                default:
                    throw new IndexOutOfRangeException($"{name}");
            }
        }
    }



    public LitterFilterPrimaryKey(LitterFilterBase? source)
    {
        Source = source;
    }
}