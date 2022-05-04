using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src
{
    class editedorder : Screen
    {
        public override string Title { get; set; } = "Sales Editor";
        private SalesOrder S;
        bool dontdraw = false;

        public editedorder(SalesOrder s)
        {
            S = s;
            
            Console.WriteLine("F1 Edit infomation");
            Console.WriteLine("F2 Edit Content");
            ConsoleKey input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.F1:
                    Console.Clear();
                    break;
                case ConsoleKey.F2:
                    Console.Clear();
                    dontdraw = true;
                    break;
            }
            
        }
        protected override void Draw()
        {
            if (!dontdraw)
            {
                Clear(this);
                Form<SalesOrder> editor = new Form<SalesOrder>();
                editor.TextBox("CustomerName", "Name");
                editor.TextBox("Street", "street");
                editor.TextBox("Country", "country");
                editor.TextBox("Statues", "OrderStatus");
                editor.Edit(S);
            }
            else
            {
                contet();
            }

        }
        void contet()
        {
            Clear(this);
            Console.WriteLine("F7 Delete orderline");
            Console.WriteLine("Add order Line");
            ListPage<OrderLine> listPage = new();
            listPage.Add(S.OrderLines);
            listPage.AddColumn("OrderLineId", "Id");
            listPage.AddColumn("Product", "Name");
            listPage.AddColumn("Amount", "Amount");
            listPage.AddColumn("Price", "totalprice");
            OrderLine sel = listPage.Select();
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.F7)
            {
                Data.Database.Instance.GetProductByID(sel.);
                S.price = -sel.totalprice;

            }
        }
    }
}
