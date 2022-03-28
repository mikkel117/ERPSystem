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

            listPage.AddColumn("Menu Selection", "Title");

            MenuData selected = listPage.Select();

            methodSelection(selected.Title);
        }

        private void methodSelection(string title)
        {
            var methodList = new Dictionary<string, Delegate>();
            methodList["First Sales Task"] = new Func<string>(firstSalesTask);
            methodList["Second Sales Task"] = new Func<string>(secondSalesTask);
            methodList["Third Sales Task"] = new Func<string>(thirdSalesTask);

            Console.WriteLine(methodList[title].DynamicInvoke());
        }

        private string firstSalesTask()
        {
            return "First Sales Task Selected";
        }

        private string secondSalesTask()
        {
            return "Second Sales Task Selected";
        }

        private string thirdSalesTask()
        {
            return "Third Sales Task Selected";
        }
    }
}
