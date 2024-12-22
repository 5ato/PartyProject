namespace PartyProject.Entities;

class CalculationProject
{
    public string PartyName;
    public DateTime PartyDate;
    public string ResultPath;
    public string ResultName;

    public CalculationProject()
    {
        PartyName = WhileGetName();
        PartyDate = WhileGetDate();
        ResultPath = WhileGetResultPath();
        ResultName = WhileGetResultName();
    }

    private static DateTime WhileGetDate()
    {
        Console.WriteLine("Напишите дату вашей тусы");
        DateTime result;
        while (!DateTime.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Введите заново");
        }
        return result;
    }

    private static string WhileGetName()
    {
        Console.WriteLine("Напишите название вашей тусы");
        string result;
        while (!string.IsNullOrWhiteSpace(result = Console.ReadLine()!))
        {
            Console.WriteLine("Введите заново");
        }
        return result!;
    }

    private static string WhileGetResultPath()
    {
        Console.WriteLine("Напишите путь куда сохранять результат");
        string result;
        while (!string.IsNullOrWhiteSpace(result = Console.ReadLine()!) || !Directory.Exists(result))
        {
            Console.WriteLine("Введите заново");
        }
        return result!;
    }

    private static string WhileGetResultName()
    {
        Console.WriteLine("Напишите название вашего файла");
        string result;
        while (!string.IsNullOrWhiteSpace(result = Console.ReadLine()!))
        {
            Console.WriteLine("Введите заново");
        }
        return result!;
    }
}