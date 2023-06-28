using System.Data.SqlClient;
using System.Reflection;
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
