using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class StorageMenu : Screen
    {
        public override string Title { get; set; } = " Storage Menu ";
        protected override void Draw()
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            listPage.Add(new MenuData("First"));
            listPage.Add(new MenuData("Second"));
            listPage.Add(new MenuData("Third"));
            listPage.AddColumn("Todo", "Title");
            MenuData selected = listPage.Select();
        }
    }
}

