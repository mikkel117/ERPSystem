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
            listPage.Add(new MenuData("First Storage Task"));
            listPage.Add(new MenuData("Second Storage Task"));
            listPage.Add(new MenuData("Third Storage Task"));
            listPage.AddColumn("Todo", "Title");
            MenuData selected = listPage.Select();
        }
    }
}

