using PartyProject.Entities;

namespace PartyProject.Utils;

public class Conditions
{
    public static bool CheckYesOrNo(string word)
    {
        return "да нет + -".Contains(word, StringComparison.OrdinalIgnoreCase);
    }
    
    public static bool CheckYes(string word)
    {
        return "да +".Contains(word, StringComparison.OrdinalIgnoreCase);
    }

    public static bool CheckNo(string word)
    {
        return "нет -".Contains(word, StringComparison.OrdinalIgnoreCase);
    }
}
