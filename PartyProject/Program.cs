using PartyProject.Entities;
using PartyProject.Database;

namespace PartyProject;

class Program
{
    public static void Main()
    {
        DatabaseConfig config = new("database.db");
        DatabaseManager manager = new(config);
        if (!manager.CheckExistTable("Friends") && !manager.CheckExistTable("Establishments"))
        {
            manager.CreateInsertUpdateDeleteTable(CreateTables.CreateFriendsTable());
            manager.CreateInsertUpdateDeleteTable(CreateTables.CreateEstablishmentsTable());
        }

        // CalculationProject calculation = new();
        ListFriends friends = new(manager);
        friends.CheckWhoWasInParty();
        friends.AddNewFreinds(manager);
        Establishments establishment = new(manager);
    }
}
