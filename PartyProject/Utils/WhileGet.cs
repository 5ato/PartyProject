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

    public static string WhileGetResultPath(out string path)
    {
        while (!string.IsNullOrWhiteSpace(path = Console.ReadLine()!) || !Directory.Exists(path))
        {
            Console.WriteLine("Введите заново");
        }
        return path;
    }

    public static void GetName(out string name)
    {
        while (string.IsNullOrWhiteSpace(name = Console.ReadLine()!))
        {
            Console.WriteLine("Напишите заного");
        }
    }
}
