using PartyProject.Entities;

namespace PartyProject.Utils;

class WhileGet
{
    public static void GetAnswerChoice(out string answer)
    {
        while (string.IsNullOrWhiteSpace(answer = Console.ReadLine()!) || !Conditions.CheckYesOrNo(answer))
        {
            Console.WriteLine("Напишите заного");
        }
    }

    public static void WhileGetDate(out DateTime dateTime)
    {
        while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
        {
            Console.WriteLine("Введите заново");
        }
    }

    public static void WhileGetNumber(out int number)
    {
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Введите заново");
        }
    }

    public static bool WhileGetCost(out int number)
    {
        string input;
        while (!int.TryParse(input = Console.ReadLine()!, out number))
        {
            if (Conditions.CheckNo(input))
                break;
            Console.WriteLine("Введите заново");
        }
        return !Conditions.CheckNo(input);
    }

    public static void WhileGetResultPath(out string path)
    {
        while (!string.IsNullOrWhiteSpace(path = Console.ReadLine()!) || !Directory.Exists(path))
        {
            Console.WriteLine("Введите заново");
        }
    }

    public static void GetName(out string name)
    {
        while (string.IsNullOrWhiteSpace(name = Console.ReadLine()!))
        {
            Console.WriteLine("Напишите заного");
        }
    }

    public static string GetWhoClose(ListFriends listFriends)
    {
        string name;
        while (string.IsNullOrWhiteSpace(name = Console.ReadLine()!) || !listFriends.Friends.Exists(f => f.Name == name))
        {
            Console.WriteLine("Напишите заного, возможно этого человека не было в заведении");
        }
        return name;
    }
}
