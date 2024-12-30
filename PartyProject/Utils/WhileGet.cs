using PartyProject.Entities;

namespace PartyProject.Utils;

class WhileGet
{
    public static void GetAnswerChoice(out string answer)
    {
        while (string.IsNullOrWhiteSpace(answer = Console.ReadLine()!) || !Conditions.CheckYesOrNo(answer))
        {
            Console.WriteLine("Напишите заново");
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
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out number) && number > 0)
                break;
            Console.WriteLine("Введите заново");
        }
    }

    public static bool WhileGetCost(out int number)
    {
        number = 0;
        string input;
        while (!Conditions.CheckNo(input = Console.ReadLine()!))
        {
            if (int.TryParse(input, out number) && number > 0)
                return true;
            Console.WriteLine("Введите заново");
        }

        number = 0;
        return false;
    }

    public static void WhileGetResultPath(out string path)
    {
        while (string.IsNullOrWhiteSpace(path = Console.ReadLine()!) || !Directory.Exists(path))
        {
            Console.WriteLine("Введите заново");
        }
    }

    public static void GetName(out string name)
    {
        while (string.IsNullOrWhiteSpace(name = Console.ReadLine()!))
        {
            Console.WriteLine("Напишите заново");
        }
    }

    public static void GetFileName(out string name)
    {
        while (string.IsNullOrWhiteSpace(name = Console.ReadLine()!))
        {
            Console.WriteLine("Напишите заново");
        }
        if (!Path.HasExtension(name) || Path.GetExtension(name) != ".txt")
        {
            name = Path.ChangeExtension(name, ".txt");
        }
    }

    public static string GetWhoClose(ListFriends listFriends)
    {
        string name;
        while (string.IsNullOrWhiteSpace(name = Console.ReadLine()!) || !listFriends.Friends.Exists(f => f.Name == name))
        {
            Console.WriteLine("Напишите заново, возможно этого человека не было в заведении");
        }
        return name;
    }
}
