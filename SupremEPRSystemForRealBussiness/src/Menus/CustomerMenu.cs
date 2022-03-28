using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class CustomerMenu : Screen
    {
        public override string Title { get; set; } = "[ Customer Menu ]";

        protected override void Draw()
        {
            Clear(this);

            ListPage<MenuData> listPage = new ListPage<MenuData>();
            listPage.Add(new MenuData("First Customer Task"));
            listPage.Add(new MenuData("Second Customer Task"));
            listPage.Add(new MenuData("Third Customer Task"));

            listPage.AddColumn("Menu Selection", "Title");

            MenuData selected = listPage.Select();

            methodSelection(selected.Title);
        }

        private void methodSelection(string title)
        {
            var methodList = new Dictionary<string, Delegate>();
            methodList["First Customer Task"] = new Func<string>(firstCustomerTask);
            methodList["Second Customer Task"] = new Func<string>(secondCustomerTask);
            methodList["Third Customer Task"] = new Func<string>(thirdCustomerTask);

            Console.WriteLine(methodList[title].DynamicInvoke());
        }

        private string firstCustomerTask()
        {
            return "First Customer Task Selected";
        }

        private string secondCustomerTask()
        {
            return "Second Customer Task Selected";
        }

        private string thirdCustomerTask()
        {
            return "Third Customer Task Selected";
        }
    }
}
