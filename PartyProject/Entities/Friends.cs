using Microsoft.Data.Sqlite;

namespace PartyProject.Entities;

public class Friend(string name)
{
    public string Name = name;
}

public class ListFriends(params Friend[] friends)
{
    public SqliteCommand GetListFriendsDatabase()
    {
        SqliteCommand command = new();
        command.CommandText = "SELECT * from ";
        return new SqliteCommand();
    }
}
