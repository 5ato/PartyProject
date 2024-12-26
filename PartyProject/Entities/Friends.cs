using System.Text;
using Microsoft.Data.Sqlite;
using PartyProject.Database;
using PartyProject.Utils;

namespace PartyProject.Entities;

public record struct Friend(string Name, int Wasted = 0);

public class ListFriends
{
    public List<Friend> Friends = [];

    public ListFriends(DatabaseManager manager)
    {
        GetListFriendsDatabase(manager);
    }

    public ListFriends(List<Friend> friends)
    {
        Friends = friends;
    }

    private void GetListFriendsDatabase(DatabaseManager manager)
    {
        SqliteDataReader resultExecute = manager.SelectTable(SelectTables.SelectAllNameFriends());
        if (resultExecute.HasRows)
        {
            while (resultExecute.Read())
            {
                Friends.Add(new Friend(resultExecute[0].ToString()!));
            }
        }
    }

    public void CheckWhoWasInParty()
    {
        List<Friend> result = [];
        foreach (Friend friend in Friends)
        {
            Console.WriteLine($"Ваш друг {friend.Name} был на тусе?(напишите + или -)");
            WhileGet.GetAnswerChoice(out string answer);
            if (Conditions.CheckYes(answer))
                result.Add(friend);
        }
        Friends = result;
    }

    public void AddNewFreinds(DatabaseManager manager)
    {
        Console.WriteLine("Добавьте новых друзей(напишите - если не хотите никого добавлять или если мало друзей))))");
        List<Friend> temp = [];
        while (Friends.Count < 100)
        {
            WhileGet.GetName(out string name);
            if (name == "-")
                return;
            Friend newFreind = new(name);
            if (Friends.Contains(newFreind))
            {
                Console.WriteLine("Вы уже добавляли этого кентика");
            }
            else
            {
                Friends.Add(newFreind);
                temp.Add(newFreind);
            }
        }
        manager.CreateInsertUpdateDeleteTable(InsertTables.InsertName(ConvertString(temp)));
    }

    public static string ConvertString(List<Friend> friends)
    {
        StringBuilder result = new();
        foreach (Friend friend in friends)
        {
            result.Append($"('{friend.Name}')");
            if (friend != friends[^1])
                result.Append(", ");
        }
        return result.ToString();
    }
}
