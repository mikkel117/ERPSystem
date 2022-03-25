using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class CompanyMenu : Screen
    {
        public override string Title { get; set; } = " Company Menu ";

        protected override void Draw()
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            listPage.Add(new MenuData("Firmaopsætninger"));
            listPage.Add(new MenuData("Firma Info"));
            listPage.Add(new MenuData("Third Company Task"));
            listPage.AddColumn("Company Management", "Title");

            MenuData selected = listPage.Select();
        }
    }
}
