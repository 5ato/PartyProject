using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
using PartyProject.Database;
using PartyProject.Utils;

namespace PartyProject.Entities;

public record Establishment
{
    public string Name;
    public ListFriends ListFriends;
    public int Check;
    public string WhoClose;
    public Establishment(DatabaseManager manager, ListFriends listFriends)
    {
        Name = GetEstablismentFromDB(manager);
        if (string.IsNullOrWhiteSpace(Name))
        {
            Console.WriteLine("Напишите название заведения");
            WhileGet.GetName(out Name);
        }

        Console.WriteLine("Напишите общую сумму чека на данное заведение");
        WhileGet.WhileGetNumber(out Check);

        ListFriends = WhoWasInEstablishment(listFriends);

        Console.WriteLine("Напишите кто должен закрыть счёт");
        WhoClose = WhileGet.GetWhoClose(ListFriends);
    }

    private static ListFriends WhoWasInEstablishment(ListFriends listFriends)
    {
        List<Friend> friends = [];
        foreach (Friend friend in listFriends.Friends)
        {
            Console.WriteLine($"Этот бибизьян -> {friend.Name} был на в заведении?(напишите сумму на которую он обожрался или поставьте - если его не было)");
            if (WhileGet.WhileGetCost(out int number))
                friends.Add(new Friend(friend.Name, number));
        }
        return new ListFriends(friends);
    }

    private static string GetEstablismentFromDB(DatabaseManager manager)
    {
        SqliteDataReader resultExecute = manager.SelectTable(SelectTables.SelectAllEstablishmentsFriends());
        string result = string.Empty;
        if (resultExecute.HasRows)
        {
            while (resultExecute.Read())
            {
                Console.WriteLine("Далее вам будет предоставлен список заведений в которых вы раньше были напишите + или - для выбора");
                WhileGet.GetAnswerChoice(out string answer);
                if (Conditions.CheckYes(answer))
                {
                    result = resultExecute[0].ToString()!;
                    break;
                }
            }
        }
        return result;
    }
}

public class ListEstablishment
{
    public List<Establishment> Establishments = [];
}