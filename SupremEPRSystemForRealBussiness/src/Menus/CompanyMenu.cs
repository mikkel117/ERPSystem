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
        public override string Title { get; set; } = "[ Company Menu ]";

        protected override void Draw()
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            listPage.Add(new MenuData("Company Configurations"));
            listPage.Add(new MenuData("Company Details"));

            listPage.AddColumn("Menu Selection", "Title");
            
            MenuData selected = listPage.Select();
        }
    }
}
