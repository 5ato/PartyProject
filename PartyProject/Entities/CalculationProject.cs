using PartyProject.Utils;

namespace PartyProject.Entities;

class CalculationProject
{
    public string PartyName;
    public DateTime PartyDate;
    public string ResultPath;
    public string ResultName;

    public CalculationProject()
    {
        Console.WriteLine("Напишите название вашей тусы");
        WhileGet.GetName(out PartyName);

        Console.WriteLine("Напишите дату вашей тусы");
        WhileGet.WhileGetDate(out PartyDate);

        Console.WriteLine("Напишите путь куда сохранять результат");
        WhileGet.WhileGetResultPath(out ResultPath);

        Console.WriteLine("Напишите название вашего файла");
        WhileGet.GetName(out ResultName);
    }
}