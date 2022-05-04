using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src
{
    class editedinfo : Screen
    {
        public override string Title { get; set; } = "Sales Editor";
        private SalesOrder S;

        public editedinfo(SalesOrder s)
        {
            string option1 = "Infomation";
            string option2 = "OrderContent";
            S = s;
            ListPage<string> listPage = new ListPage<string>(); 
            listPage.Add(option1);
            listPage.Add(option2);
            string sel = listPage.Select();
            if(sel == option1)
            {
                Draw();
            }
            
        }
        protected override void Draw()
        {
            Clear(this);
            Form<SalesOrder> editor = new Form<SalesOrder>();
            editor.TextBox("CustomerName", "Name");
            editor.DoubleBox("Street", "street");
            editor.DoubleBox("Country", "Country");
            editor.IntBox("Statues", "OrderStatus");
            editor.Edit(S);
        }
    }
}
