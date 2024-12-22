using Microsoft.Data.Sqlite;

namespace PartyProject.Database;

record DatabaseConfig
(
    string FileName, 
    string Mode = "ReadWriteCreate", 
    string Cache = "Default",
    bool ForeignKeys = true
)
{
    public string GenerateStringConfig()
    {
        return $"Filename={FileName};Mode={Mode};Cache={Cache};Foreign Keys={ForeignKeys}";
    }
}

class DatabaseManager(DatabaseConfig databaseConfig)
{
    private readonly DatabaseConfig DatabaseConfig = databaseConfig;

    public void ExecuteQueries(SqliteCommand command)
    {
        using var connection = new SqliteConnection(DatabaseConfig.GenerateStringConfig());
        connection.Open();
        ExecuteQuery(command, connection);
        connection.Close();

    }

    public void ExecuteQueries(params SqliteCommand[] commands)
    {
        using var connection = new SqliteConnection(DatabaseConfig.GenerateStringConfig());
        connection.Open();
        foreach (SqliteCommand command in commands)
        {
            ExecuteQuery(command, connection);
        }
        connection.Close();
    }

    private static void ExecuteQuery(SqliteCommand command, SqliteConnection connection)
    {
        command.Connection = connection;
        if (CheckNonQuery(command.CommandText))
            command.ExecuteNonQuery();
        else
            command.ExecuteReader();
    }

    public static bool CheckNonQuery(string query)
    {
        string[] splitQuery = query.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] nonQueryCommands = ["update", "insert", "delete", "create"];
        foreach (string command in splitQuery)
        {
            if (nonQueryCommands.Contains(command))
                return true;
        }
        return false;
    }
}