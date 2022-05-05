using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupremEPRSystemForRealBussiness.src.Menus;
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
            bool edit = true;
            OrderLine sel;
            while (edit)
            {
                Clear(this);
                Console.WriteLine("F7 Delete orderline");
                Console.WriteLine("F5 Add order Line");
                ListPage<OrderLine> listPage = new();
                listPage.Add(S.OrderLines);
                listPage.AddKey(ConsoleKey.F5, neworderline);
                listPage.AddKey(ConsoleKey.F7, removeorderline);
                listPage.AddColumn("OrderLineId", "Id");
                listPage.AddColumn("Product", "Name");
                listPage.AddColumn("Amount", "Amount");
                listPage.AddColumn("Price", "totalprice");
                try
                {
                    sel = listPage.Select();
                }catch { }
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                {
                    edit = false;
                    Console.Clear();
                    Quit();
                }
            }
            void removeorderline(OrderLine sel)
            {
                Data.Database.Instance.GetProductByID(sel.ProductID).Stock = +sel.Amount;
                S.price = -sel.totalprice;
                S.OrderLines.Remove(sel);
                if (S.OrderLines.Count == 0)
                {
                    Data.Database.Instance.salesOrders.Remove(S);
                    Quit();
                    Console.Clear();
                    listorders listorders = new();
                    Screen.Display(listorders);
                }
                else
                {
                    Console.Clear();
                    Quit();
                    Draw();
                }
            }
            void neworderline(OrderLine _)
            {
                CreateOrderLines createOrderLines = new();
                OrderLine line = createOrderLines.test();
                S.OrderLines.Add(line);
                S.totalPrice =+ line.totalprice;
                Data.Database.Instance.GetProductByID(line.ProductID).Stock = Data.Database.Instance.GetProductByID(line.ProductID).Stock - line.Amount; 
                Quit();
                Console.Clear();
                Draw();
            }
        }
    }
}
