using TECHCOOL.UI;
using SupremEPRSystemForRealBussiness.src;
using SupremEPRSystemForRealBussiness.Data;
using SupremEPRSystemForRealBussiness.src.Menus;

namespace SupremEPRSystemForRealBussiness;
class SupremEPRSystem
{
    static void Main(string[] args)
    {
        Database.Instance.InsertProduct(new Product("Apple inc", "4R10H", 200, 50, "big mac", 10, "big mac`s new Apple inc is only for 99.95"));
        Database.Instance.InsertProduct(new Product("Apple inc2", "4R10H", 99.95, 25, "big mac", 500, "big mac`s new Apple inc is only for 99.95"));
        Screen.Display(new MainMenu());

    }
}