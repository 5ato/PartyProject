namespace PartyProject;

class Program
{
    public static void Main()
    {
        DateTime partyDate = WhileGetDate();
        string partyName = WhileGetName();
    }

    public static DateTime WhileGetDate()
    {
        DateTime result;
        while (!DateTime.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Введите заново");
        }
        return result;
    }

    public static string WhileGetName()
    {
        string result;
        while (!string.IsNullOrWhiteSpace(result = Console.ReadLine()!))
        {
            Console.WriteLine("Введите заново");
        }
        return result!;
    }
}



class CalculationProject
{

}
