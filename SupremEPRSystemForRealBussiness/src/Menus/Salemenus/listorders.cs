using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class listorders : Screen
    {
        public override string Title { get; set; } = " Sales Menu ";


        protected override void Draw()
        {
            Clear(this);
            ListPage<SalesOrder> listPage = new ListPage<SalesOrder>();
            listPage.AddColumn("Order:", "Orderid");
            listPage.Add(Data.Database.Instance.salesOrders);
            SalesOrder selected = listPage.Select();
        }
    }
}
