using PartyProject.Entities;
using PartyProject.Database;
using Microsoft.Data.Sqlite;

namespace PartyProject;

class Program
{
    public static void Main()
    {
        DatabaseConfig config = new("database.db");
        DatabaseManager manager = new(config);
        if (!manager.CheckExistTable("Friends"))
        {
            manager.CreateInsertUpdateDeleteTable(CreateTables.CreateNameTable("Friends"));
        }

        // CalculationProject calculation = new();
    }
}
