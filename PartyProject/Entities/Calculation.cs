namespace PartyProject.Entities;

class Calculation(ListEstablishment establishment)
{
    public ListEstablishment Establishments = establishment;

    public Dictionary<string, Dictionary<string, int>> GetWhoCreditor()
    {
        Dictionary<string, Dictionary<string, int>> result = [];
        foreach (Establishment establishment in Establishments.Establishments)
        {
            string WhoClose = establishment.WhoClose;
            foreach (Friend friend in establishment.ListFriends.Friends)
            {
                if (WhoClose == friend.Name)
                    continue;
                if (!result.ContainsKey(friend.Name))
                    result.Add(friend.Name, new Dictionary<string, int> {{WhoClose, friend.Wasted}});
                else if (CheckFriendInValues(result, friend.Name))
                {
                    if (result[WhoClose][friend.Name] < friend.Wasted)
                    {
                        int temp = result[WhoClose][friend.Name];
                        result[WhoClose].Clear();
                        result[friend.Name].Add(WhoClose, friend.Wasted - temp);
                    } else if (result[WhoClose][friend.Name] == friend.Wasted)
                    {
                        result[WhoClose].Clear();
                    } else
                    {
                        result[WhoClose][friend.Name] -= friend.Wasted;
                    }
                }
                else
                {
                    if (!result[friend.Name].ContainsKey(WhoClose))
                        result[friend.Name].Add(WhoClose, friend.Wasted);
                    else
                        result[friend.Name][WhoClose] += friend.Wasted;
                }
            }
        }
        return result;
    }

    private static bool CheckFriendInValues(Dictionary<string, Dictionary<string, int>> check, string friend)
    {
        foreach (string keys in check.Keys)
        {
            if (check[keys].ContainsKey(friend))
                return true;
        }
        return false;
    }
}
