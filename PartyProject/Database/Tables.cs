using Microsoft.Data.Sqlite;

namespace PartyProject.Database;

public class CreateTables
{
    public static SqliteCommand CheckExistTable()
    {
        return new SqliteCommand(@"
            SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name=@tableName");
    }
    public static SqliteCommand CreateFriendsTable()
    {
        return new SqliteCommand("CREATE TABLE Friends(name STRING NOT NULL PRIMARY KEY UNIQUE)");
    }

    public static SqliteCommand CreateEstablishmentsTable()
    {
        return new SqliteCommand("CREATE TABLE Establishments(name STRING NOT NULL PRIMARY KEY UNIQUE)");
    }
}

public class SelectTables
{
    public static SqliteCommand SelectAllNameFriends()
    {
        return new SqliteCommand("SELECT name FROM Friends");
    }

    public static SqliteCommand SelectAllEstablishmentsFriends()
    {
        return new SqliteCommand("SELECT name FROM Establishments");
    }
}

public class InsertTables
{
    public static SqliteCommand InsertName(string joinName)
    {
        return new SqliteCommand($"INSERT INTO Friends (name) VALUES {joinName}");
    }
}