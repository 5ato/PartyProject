namespace PartyProject.Utils;

class WhileGet
{
    public static void GetAnswerChoice(out string answer)
    {
        while (string.IsNullOrWhiteSpace(answer = Console.ReadLine()!) || !CheckYesOrNo(answer))
        {
            Console.WriteLine("Напишите заного");
        }
    }

    public static bool CheckYesOrNo(string word)
    {
        return "да нет + -".Contains(word, StringComparison.OrdinalIgnoreCase);
    }
    
    public static bool CheckYes(string word)
    {
        return "да +".Contains(word, StringComparison.OrdinalIgnoreCase);
    }

    public static void GetName(out string name)
    {
        while (string.IsNullOrWhiteSpace(name = Console.ReadLine()!))
        {
            Console.WriteLine("Напишите заного");
        }
    }
}
