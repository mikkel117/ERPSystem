using TECHCOOL.UI;
using SupremEPRSystemForRealBussiness.src.Menus;
using SupremEPRSystemForRealBussiness.src;
using SupremEPRSystemForRealBussiness.Data;

namespace SupremEPRSystemForRealBussiness;
class SupremEPRSystem
{
    static void Main(string[] args)
    {


        /*        Database.Instance.InsertCustomer(new Customer("lars", "hansen", new ContactInfo("7777777", "lars@hasen.dk"), new Address("somewere", "NotEvilTown", "NotEvilIsland", 8910, "NotKilledByEvilRapingRabbit"), ""));
                Database.Instance.InsertCustomer(new Customer("Bob", "hansen", new ContactInfo("255555", "bob@hasen.dk"), new Address("something", "EvilTown", "EvilIsland", 8900, "KilledByEvilRapingRabbit"), ""));*/
        Screen.Display(new MainMenu());
    }
}
