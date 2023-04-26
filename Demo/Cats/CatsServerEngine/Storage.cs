using CatsCommon;
using CatsCommon.Filters;
using Microsoft.Extensions.Logging;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CatsServerEngine;

internal class Storage : IStorage
{
    private readonly string _connectionString;
    private readonly IServiceProvider _services;
    private readonly IPocoContext _pocoContext;
    private readonly ILogger? _logger;

    public Storage(IServiceProvider services, string connectionString)
    {
        _connectionString = connectionString;
        _services = services;
        _pocoContext = services.GetRequiredService<IPocoContext>();
        _logger = _services.GetService<ILoggerFactory>()?.CreateLogger(GetType().Name);
    }

    public DbDataReader GetBreeds(IBreedFilter? filterObject)
    {
        SqlConnection conn = new(_connectionString);
        conn.Open();

        SqlCommand sqlCommand = new("select IdBreed, IdGroup, NameEng, NameNat from Breeds", conn);

        return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
    }

    public DbDataReader GetCatteries(ICatteryFilter? filter)
    {
        SqlConnection conn = new(_connectionString);
        conn.Open();

        SqlCommand sqlCommand = new("select IdCattery, NameEng, NameNat from Catteries", conn);

        return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
    }

    public DbDataReader GetCats(ICatFilter? filter)
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

    public DbDataReader GetLitter(IPrimaryKey? primaryKey)
    {
        SqlConnection conn = new(_connectionString);
        conn.Open();

        SqlCommand sqlCommand = new();

        StringBuilder sb = new(@"SELECT IdLitter, IdFemale, IdFemaleCattery, IdMale, IdMaleCattery, Date
            FROM Litters");


        if (primaryKey is { })
        {
            sb.Append(" where IdLitter=@IdLitter and IdFemale=@IdFemale and IdFemaleCattery=@IdFemaleCattery");
            sqlCommand.Parameters.AddWithValue("IdLitter", primaryKey["IdLitter"]!);
            sqlCommand.Parameters.AddWithValue("IdFemale", primaryKey["IdFemale"]!);
            sqlCommand.Parameters.AddWithValue("IdFemaleCattery", primaryKey["IdFemaleCattery"]!);
        }

        sqlCommand.CommandText = sb.ToString();
        sqlCommand.Connection = conn;


        return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

    }

    public DbDataReader GetLitters(ILitterFilter filter)
    {
        SqlConnection conn = new(_connectionString);
        conn.Open();

        SqlCommand sqlCommand = new();

        StringBuilder sb = new(@"SELECT Litters.IdLitter, Litters.IdFemale, Litters.IdFemaleCattery, Litters.IdMale, Litters.IdMaleCattery, Litters.Date,
            Mom.NameNat MomNameNat, Mom.NameEng MomNameEng, Mom.Exterior MomExterior, Mom.Title MomTitle, 
            Mom.IdBreed MomIdBreed, Mom.IdGroup MomIdGroup, 
            Mom.IdLitter MomIdLitter, Mom.IdMother MomIdMother, Mom.IdMotherCattery MomIdMotherCattery, MomLitter.Date MomBirthDate,
            MomBreed.NameNat MomBreedNameNat, MomBreed.NameEng MomBreedNameEng, 
            MomCattery.NameNat MomCatteryNameNat, MomCattery.NameEng MomCatteryNameEng, 
            Dad.NameNat DadNameNat, Dad.NameEng DadNameEng, Dad.Exterior DadExterior, Dad.Title DadTitle, 
            Dad.IdBreed DadIdBreed, Dad.IdGroup DadIdGroup, 
            Dad.IdLitter DadIdLitter, Dad.IdMother DadIdMother, Dad.IdMotherCattery DadIdMotherCattery, DadLitter.Date DadBirthDate,
            DadBreed.NameNat DadBreedNameNat, DadBreed.NameEng DadBreedNameEng,
            DadCattery.NameNat DadCatteryNameNat, DadCattery.NameEng DadCatteryNameEng
            FROM Litters
                left join Cats as Mom on Litters.IdFemale=Mom.IdCat and Litters.IdFemaleCattery=Mom.IdCattery
                left join Cats as Dad on Litters.IdMale=Dad.IdCat and Litters.IdMaleCattery=Dad.IdCattery
                left join Breeds as MomBreed on MomBreed.IdBreed=Mom.IdBreed and MomBreed.IdGroup=Mom.IdGroup
                left join Breeds as DadBreed on DadBreed.IdBreed=Dad.IdBreed and DadBreed.IdGroup=Dad.IdGroup
                left join Catteries as MomCattery on MomCattery.IdCattery=Mom.IdCattery
                left join Catteries as DadCattery on DadCattery.IdCattery=Dad.IdCattery and DadBreed.IdGroup=Dad.IdGroup
                left join Litters as MomLitter on MomLitter.IdLitter=Mom.IdLitter and MomLitter.IdFemale=Mom.IdMother and MomLitter.IdFemaleCattery=Mom.IdMotherCattery
                left join Litters as DadLitter on DadLitter.IdLitter=Dad.IdLitter and DadLitter.IdFemale=Dad.IdMother and DadLitter.IdFemaleCattery=Dad.IdMotherCattery
");


        if (filter.Female is { } || filter.Male is { })
        {
            sb.Append(" where ");
            if (filter.Female is { })
            {
                IPrimaryKey primaryKey = ((IProjection)filter.Female).As<IEntity>()!.PrimaryKey;
                sb.Append("Litters.IdFemale=@IdFemale and Litters.IdFemaleCattery=@IdFemaleCattery");
                sqlCommand.Parameters.AddWithValue("IdFemale", primaryKey["IdCat"]!);
                sqlCommand.Parameters.AddWithValue("IdFemaleCattery", primaryKey["IdCattery"]!);
            }
            if (filter.Female is { } && filter.Male is { })
            {
                sb.Append(" and ");
            }
            if (filter.Male is { })
            {
                IPrimaryKey primaryKey = ((IProjection)filter.Male).As<IEntity>()!.PrimaryKey;
                sb.Append("Litters.IdMale=@IdMale and Litters.IdMaleCattery=@IdMaleCattery");
                sqlCommand.Parameters.AddWithValue("IdMale", primaryKey["IdCat"]!);
                sqlCommand.Parameters.AddWithValue("IdMaleCattery", primaryKey["IdCattery"]!);
            }
        }

        sqlCommand.CommandText = sb.ToString();
        sqlCommand.Connection = conn;


        return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

    }

    public DbDataReader GetExteriors()
    {
        SqlConnection conn = new(_connectionString);
        conn.Open();

        SqlCommand sqlCommand = new();

        StringBuilder sb = new(@"SELECT distinct Exterior
            FROM Cats");


        sqlCommand.CommandText = sb.ToString();
        sqlCommand.Connection = conn;


        return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
    }

    public DbDataReader GetTitles()
    {
        SqlConnection conn = new(_connectionString);
        conn.Open();

        SqlCommand sqlCommand = new();

        StringBuilder sb = new(@"SELECT distinct Title
            FROM Cats");


        sqlCommand.CommandText = sb.ToString();
        sqlCommand.Connection = conn;


        return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
    }

    public DbDataReader GetCat(IPrimaryKey? primaryKey)
    {
        SqlConnection conn = new(_connectionString);
        conn.Open();

        SqlCommand sqlCommand = new();

        StringBuilder sb = new(@"
SELECT Cats.IdCat, Cats.IdCattery, Cats.IdBreed, Cats.IdGroup, Cats.IdLitter, Cats.IdMother, Cats.IdMotherCattery, Litters.Date,
            Cats.Gender, Cats.NameEng, Cats.NameNat, 
	        Cats.OwnerInfo, Cats.Exterior, Cats.Title,
            Catteries.NameEng CatteryNameEng, Catteries.NameNat CatteryNameNat,
            Breeds.NameEng BreedNameEng, Breeds.NameNat BreedNameNat,
			Mom.NameNat MomNameNat, Mom.NameEng MomNameEng, MomCattery.NameNat MomCatteryNameNat, MomCattery.NameEng MomCatteryNameEng,
                Mom.Exterior MomExterior, Mom.Title MomTitle, 
                Mom.Gender MomGender, 
                Mom.OwnerInfo MomOwnerInfo,
				MomBreed.IdBreed MomIdBreed, MomBreed.IdGroup MomIdGroup, 
				MomBreed.NameNat MomBreedNameNat, MomBreed.NameEng MomBreedNameEng, 
				MomLitter.IdLitter MomIdLitter, MomLitter.IdFemale MomIdMother, MomLitter.IdFemaleCattery MomIdMotherCattery, MomLitter.Date MomDate,
            Dad.IdCat IdFather, Dad.IdCattery IdFatherCattery,
			Dad.NameNat DadNameNat, Dad.NameEng DadNameEng, DadCattery.NameNat DadCatteryNameNat, DadCattery.NameEng DadCatteryNameEng,
                Dad.Exterior DadExterior, Dad.Title DadTitle, 
                Dad.Gender DadGender, 
                Dad.OwnerInfo DadOwnerInfo,
				DadBreed.IdBreed DadIdBreed, DadBreed.IdGroup DadIdGroup, 
				DadBreed.NameNat DadBreedNameNat, DadBreed.NameEng DadBreedNameEng, 
				DadLitter.IdLitter DadIdLitter, DadLitter.IdFemale DadIdMother, DadLitter.IdFemaleCattery DadIdMotherCattery, DadLitter.Date DadDate
            FROM Cats 
                join Catteries on Catteries.IdCattery=Cats.IdCattery 
                join Breeds on Breeds.IdBreed=Cats.IdBreed and Breeds.IdGroup=Cats.IdGroup
                left join Litters on Cats.IdLitter=Litters.IdLitter and Cats.IdMother=Litters.IdFemale and Cats.IdMotherCattery=Litters.IdFemaleCattery
				left join Cats as Mom on Litters.IdFemale=Mom.IdCat and Litters.IdFemaleCattery=Mom.IdCattery
				left join Catteries as MomCattery on MomCattery.IdCattery=Mom.IdCattery
				left join Breeds as MomBreed on MomBreed.IdBreed=Mom.IdBreed and MomBreed.IdGroup=Mom.IdGroup
				left join Litters as MomLitter on MomLitter.IdLitter=Mom.IdLitter and MomLitter.IdFemale=Mom.IdMother and MomLitter.IdFemaleCattery=Mom.IdMotherCattery
				left join Cats as Dad on Litters.IdMale=Dad.IdCat and Litters.IdMaleCattery=Dad.IdCattery
				left join Catteries as DadCattery on DadCattery.IdCattery=Dad.IdCattery
				left join Breeds as DadBreed on DadBreed.IdBreed=Dad.IdBreed and DadBreed.IdGroup=Dad.IdGroup
				left join Litters as DadLitter on DadLitter.IdLitter=Dad.IdLitter and DadLitter.IdFemale=Dad.IdMother and DadLitter.IdFemaleCattery=Dad.IdMotherCattery
            WHERE Cats.IdCat=@IdCat and Cats.IdCattery=@IdCattery
");
        sqlCommand.Parameters.AddWithValue("IdCat", primaryKey["IdCat"]!);
        sqlCommand.Parameters.AddWithValue("IdCattery", primaryKey["IdCattery"]!);



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
            IPrimaryKey primaryKeyBreed = ((IProjection)filterObject.Breed).As<IEntity>()!.PrimaryKey;
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
            IPrimaryKey primaryKeyCattery = ((IProjection)filterObject.Cattery).As<IEntity>()!.PrimaryKey;
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
            IPrimaryKey primaryKeySelf = ((IProjection)filterObject.Self).As<IEntity>()!.PrimaryKey;
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
            IPrimaryKey primaryKeyMother = ((IProjection)filterObject.Mother).As<IEntity>()!.PrimaryKey;
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
            IPrimaryKey primaryKeyFather = ((IProjection)filterObject.Father).As<IEntity>()!.PrimaryKey;
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
            IPrimaryKey primaryKeyLitter = ((IProjection)filterObject.Litter).As<IEntity>()!.PrimaryKey;
            sqlCommand.Parameters.AddWithValue("IdLitter", primaryKeyLitter["IdLitter"]);
            sqlCommand.Parameters.AddWithValue("IdFemale", primaryKeyLitter["IdFemale"]);
            sqlCommand.Parameters.AddWithValue("IdFemaleCattery", primaryKeyLitter["IdFemaleCattery"]);
        }
        if (sbWhere.Length > 0)
        {
            sb.Append(" WHERE ").Append(sbWhere);
        }

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

    private void InstallDatabase(string db)
    {
        SqlConnection conn = new(_connectionString.Replace($"Database={db}", "Database=master"));
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"CREATE DATABASE {db}", conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"SET LANGUAGE English; RESTORE DATABASE {db} FROM DISK = '{db}.bak';";
            for (int i = 0; i < 2; ++i)
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    string pattern = @$"Cannot open backup device '(.+?{Regex.Escape(new string(Path.DirectorySeparatorChar, 1))}{db}.bak)'\.";
                    Match m = Regex.Match(ex.Message, pattern);
                    if (i == 0 && m.Success)
                    {
                        File.Copy($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Database{Path.DirectorySeparatorChar}{db}.bak", m.Groups[1].Captures[0].Value);
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
