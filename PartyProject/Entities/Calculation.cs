namespace PartyProject.Entities;

public class Calculation(ListEstablishment establishments)
{
    private readonly ListEstablishment Establishments = establishments;


    public Dictionary<string, Dictionary<string, int>> GetWhoCreditor()
    {
        var debts = new Dictionary<string, Dictionary<string, int>>();

        foreach (var establishment in Establishments.Establishments)
        {
            ProcessEstablishmentDebts(establishment, debts);
        }

        return debts;
    }

    private static void ProcessEstablishmentDebts(
        Establishment establishment, 
        Dictionary<string, Dictionary<string, int>> debts)
    {
        var payer = establishment.WhoClose;

        foreach (var friend in establishment.ListFriends.Friends)
        {
            if (friend.Name == payer) continue;
            
            UpdateDebts(debts, payer, friend);
        }
    }

    private static void UpdateDebts(
        Dictionary<string, Dictionary<string, int>> debts,
        string payer,
        Friend friend)
    {
        if (IsDebtorToSomeone(debts, friend.Name))
        {
            HandleExistingDebt(debts, payer, friend);
        }
        else
        {
            AddNewDebt(debts, payer, friend);
        }
    }

    private static void HandleExistingDebt(
        Dictionary<string, Dictionary<string, int>> debts,
        string payer,
        Friend friend)
    {
        var existingDebt = debts[payer][friend.Name];

        if (existingDebt < friend.Wasted)
        {
            TransferDebt(debts, payer, friend, existingDebt);
        }
        else if (existingDebt == friend.Wasted)
        {
            debts.Remove(payer);
        }
        else
        {
            debts[payer][friend.Name] -= friend.Wasted;
        }
    }

    private static void TransferDebt(
        Dictionary<string, Dictionary<string, int>> debts,
        string payer,
        Friend friend,
        int existingDebt)
    {
        var remainingDebt = friend.Wasted - existingDebt;

        if (debts[payer].Count == 1)
            debts.Remove(payer);
        else
            debts[payer].Clear();

        if (!debts.ContainsKey(friend.Name))
            debts[friend.Name] = new Dictionary<string, int>();

        if (!debts[friend.Name].ContainsKey(payer))
            debts[friend.Name][payer] = remainingDebt;
        else
            debts[friend.Name][payer] += remainingDebt;
    }

    private static void AddNewDebt(
        Dictionary<string, Dictionary<string, int>> debts,
        string payer,
        Friend friend)
    {
        if (!debts.ContainsKey(friend.Name))
        {
            debts[friend.Name] = new Dictionary<string, int> { { payer, friend.Wasted } };
        }
        else
        {
            if (!debts[friend.Name].ContainsKey(payer))
                debts[friend.Name][payer] = friend.Wasted;
            else
                debts[friend.Name][payer] += friend.Wasted;
        }
    }

    private static bool IsDebtorToSomeone(
        Dictionary<string, Dictionary<string, int>> debts,
        string friendName)
    {
        return debts.Values.Any(innerDict => innerDict.ContainsKey(friendName));
    }
}