﻿using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class SalesMenu : Screen
    {
        public override string Title { get; set; } = " Sales Menu ";
        protected override void Draw()
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            listPage.Add(new MenuData("New SalesOrders"));
            listPage.Add(new MenuData("List of Orders"));
            listPage.Add(new MenuData("Third Sales Task"));
            listPage.AddColumn("Options", "Title");

            MenuData selected = listPage.Select();
            switch (selected.Title)
            {
                case ("New SalesOrders"):
                    CreateOrder createOrder = new();
                    Screen.Display(createOrder);
                    break;
            }
        }
    }
}