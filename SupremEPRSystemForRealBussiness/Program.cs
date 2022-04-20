using TECHCOOL.UI;
using SupremEPRSystemForRealBussiness.src.Menus;
using SupremEPRSystemForRealBussiness.src;
using SupremEPRSystemForRealBussiness.Data;

namespace SupremEPRSystemForRealBussiness;
class SupremEPRSystem
{
    static void Main(string[] args)
    {
        
        
        Database.Instance.InsertCustomer(new Customer("lars", "hansen", new ContactInfo("7777777", "lars@hasen.dk"), new Address("somewere", "NotEvilTown", "NotEvilIsland", 8910, "NotKilledByEvilRapingRabbit"), "male"));
        Database.Instance.InsertCustomer(new Customer("Bob", "hansen", new ContactInfo("255555", "bob@hasen.dk"), new Address("something", "EvilTown", "EvilIsland", 8900, "KilledByEvilRapingRabbit"), "male"));
         Database.Instance.InsertProduct(new Product("Apple inc", "4R10H", 200, 50, "big mac", 10, "", "big mac`s new Apple inc is only for 99.95"));
        Database.Instance.InsertProduct(new Product("Apple inc2", "4R10H", 99.95, 25, "big mac", 500, "", "big mac`s new Apple inc is only for 99.95"));
        Screen.Display(new MainMenu());
    }
}
