using System.Text;
using Microsoft.Data.Sqlite;
using PartyProject.Database;

namespace PartyProject.Entities;

public record struct Friend(string Name);

public class ListFriends
{
    public List<Friend> Friends = [];

    public ListFriends(DatabaseManager manager)
    {
        GetListFriendsDatabase(manager);
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
            GetAnswerWhoWas(out string answer);
            if (CheckYes(answer))
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
            GetNewName(out string name);
            if (name == "-")
                break;
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
    
    private static void GetAnswerWhoWas(out string answer)
    {
        while (string.IsNullOrWhiteSpace(answer = Console.ReadLine()!) || !CheckYesOrNo(answer))
        {
            Console.WriteLine("Напишите заного");
        }
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

    private static void GetNewName(out string name)
    {
        while (string.IsNullOrWhiteSpace(name = Console.ReadLine()!))
        {
            Console.WriteLine("Напишите заного");
        }
    }

    private static bool CheckYesOrNo(string word)
    {
        return "да нет + -".Contains(word, StringComparison.OrdinalIgnoreCase);
    }
    
    private static bool CheckYes(string word)
    {
        return "да +".Contains(word, StringComparison.OrdinalIgnoreCase);
    }
}
