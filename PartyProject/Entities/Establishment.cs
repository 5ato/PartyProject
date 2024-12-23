using Microsoft.Data.Sqlite;
using PartyProject.Database;
using PartyProject.Utils;

namespace PartyProject.Entities;

public class Establishments
{
    public string Name;
    public Establishments(DatabaseManager manager)
    {
        Name = GetEstablismentFromDB(manager);
        if (string.IsNullOrWhiteSpace(Name))
        {
            Console.WriteLine("Напишите название заведения");
            WhileGet.GetName(out Name);
        }
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