using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class SalesMenu : Screen
    {
        public override string Title { get; set; } = "[ Sales Menu ]";
        protected override void Draw()
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            listPage.Add(new MenuData("First Sales Task"));
            listPage.Add(new MenuData("Second Sales Task"));
            listPage.Add(new MenuData("Third Sales Task"));

            listPage.AddColumn("Sales Management", "Title");

            MenuData selected = listPage.Select();
        }
    }
}
