﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class listorders : Screen
    {
        public override string Title { get; set; } = " List of Orders";


        protected override void Draw()
        {
            Clear(this);

            ListPage<SalesOrder> listPage = new ListPage<SalesOrder>();
            Console.WriteLine("F2 Opret ny order");
            listPage.AddKey(ConsoleKey.F2, neworder);
            listPage.AddColumn("Order", "Orderid");
            listPage.AddColumn("Name", "Name");
            listPage.AddColumn("CustomerId", "CustomerId");
            listPage.AddColumn("Dato", "TimeStamp");
            listPage.AddColumn("Price", "price");
            listPage.Add(Data.Database.Instance.salesOrders);
            if(Data.Database.Instance.salesOrders.Count != 0)
            {
                SalesOrder selected = listPage.Select();
                orderdetails(selected);
            }
            else
            {
                neworder(new());
            }
            
            
        }
        void orderdetails(SalesOrder sel)
        {
            bool editable = false;
            Quit();
            if(sel.OrderStatus == "Payment Pending")
            {

                Console.WriteLine("F7 Edit");
                editable = true;
            }
            Console.WriteLine("OrderDetails");
            Console.WriteLine("============================================");
            Console.Clear();
            Console.WriteLine("Customer details");
            Console.WriteLine(Builder.CustomerString(sel.Customer, "Contact"));
            Console.WriteLine(Builder.CustomerString(sel.Customer, "FullName"));
            Console.WriteLine(Builder.saleorders(sel));
            Draw();

        }
        void neworder(SalesOrder _)
        {
            Quit();
            CreateOrder createOrder = new CreateOrder();
            Screen.Display(createOrder);
        }
    }
}
