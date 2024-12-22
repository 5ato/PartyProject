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

public class DatabaseManager
{
    private readonly SqliteConnection Connection;
    private readonly DatabaseConfig DatabaseConfig;

    public DatabaseManager(DatabaseConfig databaseConfig)
    {
        DatabaseConfig = databaseConfig;
        Connection = new SqliteConnection(DatabaseConfig.GenerateStringConfig());
        try
        {
            Connection.Open();
        } catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public void CreateInsertUpdateDeleteTable(SqliteCommand command)
    {
        command.Connection = Connection;
        command.ExecuteNonQuery();
    }

    public SqliteDataReader SelectTable(SqliteCommand command)
    {
        command.Connection = Connection;
        return command.ExecuteReader();
    }

    public bool CheckExistTable(string fileName)
    {
        SqliteCommand command = CreateTables.CheckExistTable();
        command.Connection = Connection;
        command.Parameters.AddWithValue("@tableName", fileName);
        return (long)command.ExecuteScalar()! == 1;
    }
}