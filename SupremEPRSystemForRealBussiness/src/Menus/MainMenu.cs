using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class MainMenu : Screen
    {
        public override string Title { get; set; } = "[ Enterprice Resource Planning ]";


        protected override void Draw()
        {
            Clear(this);

            Menu menu = new Menu();

            menu.Add(new CustomerMenu());
            menu.Add(new SalesMenu());
            menu.Add(new StorageMenu());
            menu.Add(new CompanyMenu());
            menu.Start(this);
        }
    }
}
