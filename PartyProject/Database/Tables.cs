using Microsoft.Data.Sqlite;

namespace PartyProject.Database;

public class CreateTables
{
    public static SqliteCommand CheckExistTable()
    {
        return new SqliteCommand(@"
            SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name=@tableName");
    }
    public static SqliteCommand CreateNameTable(string tableName)
    {
        return new SqliteCommand($"CREATE TABLE {tableName}(name STRING NOT NULL PRIMARY KEY UNIQUE)");
    }
}