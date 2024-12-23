using Microsoft.Data.Sqlite;

namespace PartyProject.Database;

public record DatabaseConfig
(
    string FileName, 
    string Mode = "ReadWriteCreate", 
    string Cache = "Default",
    bool ForeignKeys = true
)
{
    public string GenerateStringConfig()
    {
        return @$"
        Filename={FileName};
        Mode={Mode};
        Cache={Cache};
        Foreign Keys={ForeignKeys};";
    }
}

public class DatabaseManager : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly DatabaseConfig _databaseConfig;

    public DatabaseManager(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        _connection = new SqliteConnection(_databaseConfig.GenerateStringConfig());
        try
        {
            _connection.Open();
        } catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public void CreateInsertUpdateDeleteTable(SqliteCommand command)
    {
        command.Connection = _connection;
        command.ExecuteNonQuery();
    }

    public SqliteDataReader SelectTable(SqliteCommand command)
    {
        command.Connection = _connection;
        return command.ExecuteReader();
    }

    public bool CheckExistTable(string fileName)
    {
        SqliteCommand command = CreateTables.CheckExistTable();
        command.Connection = _connection;
        command.Parameters.AddWithValue("@tableName", fileName);
        return (long)command.ExecuteScalar()! == 1;
    }

    public void Dispose()
    {
        _connection.Dispose();
    }
}