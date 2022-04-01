using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class CustomerMenu : Screen
    {
        public override string Title { get; set; } = " Customer Menu ";



        protected override void Draw()
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            listPage.Add(new MenuData("First Customer Task"));
            listPage.Add(new MenuData("Second Customer Task"));
            listPage.Add(new MenuData("Third Customer Task"));
            listPage.AddColumn("Todo", "Title");

            MenuData selected = listPage.Select();
        }


    }
}
