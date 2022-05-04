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
                    Draw();
                    break;
                case ConsoleKey.F2:
                    Console.Clear();
                    Console.WriteLine("Not implemented yet");
                    Console.ReadLine();
                    break;
            }
            
        }
        protected override void Draw()
        {
            Clear(this);
            Form<SalesOrder> editor = new Form<SalesOrder>();
            editor.TextBox("CustomerName", "Name");
            editor.TextBox("Street", "street");
            editor.TextBox("Country", "country");
            editor.TextBox("Statues", "OrderStatus");
            editor.Edit(S);
        }
    }
}
