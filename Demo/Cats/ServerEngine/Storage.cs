using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Demo.Cats.Common;
using Net.Leksi.Pocota.Server;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Demo.Cats.Server;

public class Storage : IStorage
{
    private readonly string _connectionString;
    private readonly IServiceProvider _services;
    private readonly ILogger? _logger;

    public Storage(IServiceProvider services, string connectionString)
    {
        _connectionString = connectionString;
        _services = services;
        _logger = _services.GetService<ILoggerFactory>()?.CreateLogger(GetType().Name);
    }

    public void CheckDatabase()
    {
        Match m = Regex.Match(_connectionString, "Database=([^;]+)(;|$)");
        string db = m.Success ? m.Groups[1].Captures[0].Value : string.Empty;
        _logger?.LogInformation($"Checking Database '{db}' ...");
        SqlConnection conn = new(_connectionString);
        try
        {
            conn.Open();
            _logger?.LogInformation("OK");
        }
        catch (SqlException ex)
        {
            if (!"00000000-0000-0000-0000-000000000000".Equals(ex.ClientConnectionId) && ex.Server is { })
            {
                InstallDatabase(db);
            }
            else
            {
                _logger?.LogCritical(ex.Message);
                throw;
            }
        }
    }

    public DbDataReader? SelectCats(ICatFilter? filter)
    {
        SqlConnection conn = new(_connectionString);
        conn.Open();

        SqlCommand sqlCommand = new();

        StringBuilder sb = new(@"
SELECT Cats.IdCat, Cats.IdCattery, Cats.IdBreed, Cats.IdGroup, Cats.IdLitter, Cats.IdMother, Cats.IdMotherCattery, 
            Litters.Date, Litters.IdMale IdFather, Litters.IdMaleCattery IdFatherCattery,
            Cats.Gender, Cats.NameEng, Cats.NameNat, 
	        Cats.OwnerInfo, Cats.Exterior, Cats.Title,
            Catteries.NameEng CatteryNameEng, Catteries.NameNat CatteryNameNat,
            Breeds.NameEng BreedNameEng, Breeds.NameNat BreedNameNat
            FROM Cats 
                join Catteries on Catteries.IdCattery=Cats.IdCattery 
                join Breeds on Breeds.IdBreed=Cats.IdBreed and Breeds.IdGroup=Cats.IdGroup
                left join Litters on Cats.IdLitter=Litters.IdLitter and Cats.IdMother=Litters.IdFemale and Cats.IdMotherCattery=Litters.IdFemaleCattery
");


        if (filter is { })
        {
            ApplyCatListFilter(filter, sqlCommand, sb);
        }

        sqlCommand.CommandText = sb.ToString();

        sqlCommand.Connection = conn;

        return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
    }

    private void ApplyCatListFilter(ICatFilter filterObject, SqlCommand sqlCommand, StringBuilder sb)
    {
        StringBuilder sbWhere = new();
        if (filterObject.Breed is { })
        {
            if (sbWhere.Length > 0)
            {
                sbWhere.Append(" AND ");
            }
            sbWhere.Append("Cats.IdBreed=@IdBreed AND Cats.IdGroup=@IdGroup");
            IPrimaryKey primaryKeyBreed = ((IEntity)filterObject.Breed).PrimaryKey;
            sqlCommand.Parameters.AddWithValue("IdBreed", primaryKeyBreed["IdBreed"]!);
            sqlCommand.Parameters.AddWithValue("IdGroup", primaryKeyBreed["IdGroup"]!);
        }
        if (filterObject.Cattery is { })
        {
            if (sbWhere.Length > 0)
            {
                sbWhere.Append(" AND ");
            }
            sbWhere.Append("Cats.IdCattery=@IDCattery");
            IPrimaryKey primaryKeyCattery = ((IEntity)filterObject.Cattery).PrimaryKey;
            sqlCommand.Parameters.AddWithValue("IdCattery", primaryKeyCattery["IdCattery"]!);
        }
        if (filterObject.BornAfter is { })
        {
            if (sbWhere.Length > 0)
            {
                sbWhere.Append(" AND ");
            }
            sbWhere.Append("Litters.Date>=@BornAfter");
            sqlCommand.Parameters.AddWithValue("BornAfter", filterObject.BornAfter?.ToString("yyyy-MM-dd"));
        }
        if (filterObject.BornBefore is { })
        {
            if (sbWhere.Length > 0)
            {
                sbWhere.Append(" AND ");
            }
            sbWhere.Append("Litters.Date<=@BornBefore");
            sqlCommand.Parameters.AddWithValue("BornBefore", filterObject.BornBefore?.ToString("yyyy-MM-dd"));
        }
        if (filterObject.Gender is { })
        {
            if (sbWhere.Length > 0)
            {
                sbWhere.Append(" AND ");
            }
            sbWhere.Append("Cats.Gender=@Gender");
            sqlCommand.Parameters.AddWithValue("Gender", filterObject.Gender switch { Gender.Male => "M", Gender.Female => "F", Gender.FemaleCastrate => "FC", _ => "MC" });
        }
        if (filterObject.Self is { })
        {
            if (sbWhere.Length > 0)
            {
                sbWhere.Append(" AND ");
            }
            sbWhere.Append("Cats.IdCat=@IdCat AND Cats.IdCattery=@IdCattery");
            IPrimaryKey primaryKeySelf = ((IEntity)filterObject.Self).PrimaryKey;
            sqlCommand.Parameters.AddWithValue("IdCat", primaryKeySelf["IdCat"]);
            sqlCommand.Parameters.AddWithValue("IdCattery", primaryKeySelf["IdCattery"]);
        }
        if (filterObject.Mother is { })
        {
            if (sbWhere.Length > 0)
            {
                sbWhere.Append(" AND ");
            }
            sbWhere.Append("Cats.IdMother=@IdMother AND Cats.IdMotherCattery=@IdMotherCattery");
            IPrimaryKey primaryKeyMother = ((IEntity)filterObject.Mother).PrimaryKey;
            sqlCommand.Parameters.AddWithValue("IdMother", primaryKeyMother["IdCat"]);
            sqlCommand.Parameters.AddWithValue("IdMotherCattery", primaryKeyMother["IdCattery"]);
        }
        if (filterObject.Father is { })
        {
            if (sbWhere.Length > 0)
            {
                sbWhere.Append(" AND ");
            }
            sbWhere.Append("Cats.IdLitter is not null AND Litters.IdMale=@IdFather AND  Litters.IdMaleCattery=@IdFatherCattery");
            IPrimaryKey primaryKeyFather = ((IEntity)filterObject.Father).PrimaryKey;
            sqlCommand.Parameters.AddWithValue("IdFather", primaryKeyFather["IdCat"]);
            sqlCommand.Parameters.AddWithValue("IdFatherCattery", primaryKeyFather["IdCattery"]);
        }
        if (filterObject.Litter is { })
        {
            if (sbWhere.Length > 0)
            {
                sbWhere.Append(" AND ");
            }
            sbWhere.Append("Cats.IdLitter is not null AND Litters.IdLitter=@IdLitter AND Litters.IdFemale=@IdFemale AND  Litters.IdFemaleCattery=@IdFemaleCattery");
            IPrimaryKey primaryKeyLitter = ((IEntity)filterObject.Litter).PrimaryKey;
            sqlCommand.Parameters.AddWithValue("IdLitter", primaryKeyLitter["IdLitter"]);
            sqlCommand.Parameters.AddWithValue("IdFemale", primaryKeyLitter["IdFemale"]);
            sqlCommand.Parameters.AddWithValue("IdFemaleCattery", primaryKeyLitter["IdFemaleCattery"]);
        }
        if (sbWhere.Length > 0)
        {
            sb.Append(" WHERE ").Append(sbWhere);
        }

    }

    private void InstallDatabase(string db)
    {
        SqlConnection conn = new(_connectionString.Replace($"Database={db}", "Database=master"));
        string dataDir = string.Empty;
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"SET LANGUAGE English; RESTORE DATABASE {db} FROM DISK = 'Felisita1.bak' WITH MOVE 'Felisita' TO '{dataDir}{db}.mdf', MOVE 'Felisita_Log' TO '{dataDir}{db}_log.mdf';", conn);
            for (int i = 0; i < 2; ++i)
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    string pattern = @$"Cannot open backup device '(.+?{Regex.Escape(new string(Path.DirectorySeparatorChar, 1))})Felisita1.bak'\.";
                    Match m = Regex.Match(ex.Message, pattern);
                    if (i == 0 && m.Success)
                    {
                        dataDir = m.Groups[1].Captures[0].Value;
                        File.Copy($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Database{Path.DirectorySeparatorChar}Felisita.bak", $"{dataDir}Felisita1.bak");
                        dataDir = dataDir.Replace("Backup", "DATA");
                        cmd.CommandText = $"SET LANGUAGE English; RESTORE DATABASE {db} FROM DISK = 'Felisita1.bak' WITH MOVE 'Felisita' TO '{dataDir}{db}.mdf', MOVE 'Felisita_Log' TO '{dataDir}{db}_log.mdf';";
                    }
                    else
                    {
                        _logger?.LogCritical(ex.Message);
                        throw;
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            _logger?.LogCritical(ex.Message);
            throw;
        }
    }

}
