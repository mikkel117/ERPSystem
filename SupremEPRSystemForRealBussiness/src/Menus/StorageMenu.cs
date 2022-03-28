using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class StorageMenu : Screen
    {
        public override string Title { get; set; } = "[ Storage Menu ]";
        protected override void Draw()
        {
            Clear(this);

            ListPage<MenuData> listPage = new ListPage<MenuData>();
            listPage.Add(new MenuData("First Storage Task"));
            listPage.Add(new MenuData("Second Storage Task"));
            listPage.Add(new MenuData("Third Storage Task"));

            listPage.AddColumn("Menu Selection", "Title");

            MenuData selected = listPage.Select();

            methodSelection(selected.Title);
        }

        private void methodSelection(string title)
        {
            var methodList = new Dictionary<string, Delegate>();
            methodList["First Storage Task"] = new Func<string>(firstStorageTask);
            methodList["Second Storage Task"] = new Func<string>(secondStorageTask);
            methodList["Third Storage Task"] = new Func<string>(thirdStorageTask);

            Console.WriteLine(methodList[title].DynamicInvoke());
        }

        private string firstStorageTask()
        {
            return "First Storage Task Selected";
        }

        private string secondStorageTask()
        {
            return "Second Storage Task Selected";
        }

        private string thirdStorageTask()
        {
            return "Third Storage Task Selected";
        }
    }
}

