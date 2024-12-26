using PartyProject.Entities;
using PartyProject.Database;
using PartyProject.Utils;

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
        
        ListEstablishment establishments = new();
        string input;
        while (establishments.Establishments.Count == 0 || !Conditions.CheckNo(input = Console.ReadLine()))
        {
            establishments.Establishments.Add(new Establishment(manager, friends));
            Console.WriteLine("У вас были ещё заведения куда вы заходили?(напишите - если нет)");
        }
        Calculation calculation = new(establishments);
        calculation.GetWhoCreditor();
    }
}
