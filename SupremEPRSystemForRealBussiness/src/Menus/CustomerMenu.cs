﻿using TECHCOOL.UI;

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
            listPage.Add(new MenuData("Second Customer Task"));
            listPage.Add(new MenuData("Third Customer Task"));
            listPage.AddColumn("Todo", "Title"); //TODO: change the menu title

            MenuData selected = listPage.Select();
            switch (selected.Title)
            {
                case ("Add Customer"):
                    CreateCustomer test = new();
                    Screen.Display(test);
                    break;
            }

        }



    }
}
