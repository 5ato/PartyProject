using System.Text;
using PartyProject.Entities;

namespace PartyProject.Utils;

class Writer(
    string path, 
    string name, 
    CalculationProject project, 
    ListEstablishment listEstablishment,
    Calculation calculation)
{
    public string ResultPath = Path.Combine(path, name);
    public CalculationProject Project = project;
    public ListEstablishment ListEstablishment = listEstablishment;
    public Calculation Calculation = calculation;

    public void Write()
    {
        using StreamWriter sw = new(ResultPath);
        sw.Write(WriteHead());
        sw.Write(WriteWhoCost());
        sw.Write(WriteCreditor());
    }

    public string WriteHead()
    {
        return $"===={Project.PartyName}====\n{Project.PartyDate.Date}\n\n";
    }

    public string WriteWhoCost()
    {
        StringBuilder result = new();
        foreach (Establishment establishment in ListEstablishment.Establishments)
        {
            result.Append($"===={establishment.Name}====\n");
            result.Append($"Общий счёт: {establishment.TotalCheck}\n");
            result.Append($"Кто закрыл счёт: {establishment.WhoClose}\n");

            var friends = establishment.ListFriends.Friends;
            for (int i = 0; i < friends.Count; i++)
            {
                var friend = friends[i];
                result.Append($"{i + 1}. {friend.Name}: {friend.Wasted}\n");
            }
        }
        result.Append("===============\n\n");
        return result.ToString();
    }

    public string WriteCreditor()
    {
        StringBuilder result = new("====Расчёт====");
        Dictionary<string, Dictionary<string, int>> debtCalculation = Calculation.GetWhoCreditor();
        foreach (string debtor in debtCalculation.Keys)
        {
            foreach(string creditor in debtCalculation[debtor].Keys)
            {
                result.Append($"{debtor} => {creditor}: {debtCalculation[debtor][creditor]}\n");
            }
        }
        result.Append('\n');
        return result.ToString();
    }
}