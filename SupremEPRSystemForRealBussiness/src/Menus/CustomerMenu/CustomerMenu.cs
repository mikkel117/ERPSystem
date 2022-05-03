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
            listPage.Add(new MenuData("Add Customer"));
            listPage.Add(new MenuData("List of Customers"));
            listPage.AddColumn("Todo", "Title"); //TODO: change the menu title

            MenuData selected = listPage.Select();
            if (selected != null)
            {
                switch (selected.Title)
                {
                    case ("Add Customer"):
                        CreateCustomer menucc = new();
                        Screen.Display(menucc);
                        break;
                    case ("List of Customers"):
                        ListofCustomers menuloc = new ListofCustomers();
                        Screen.Display(menuloc);
                        break;

                }
            }

        }



    }
}
