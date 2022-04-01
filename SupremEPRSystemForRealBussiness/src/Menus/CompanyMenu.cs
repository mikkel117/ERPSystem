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
        public override string Title { get; set; } = "Company menu";

        protected override void Draw()
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            listPage.Add(new MenuData("firmaopsætninger"));
            listPage.Add(new MenuData("firma info"));
            listPage.Add(new MenuData("Third cumpany Task"));
            listPage.AddColumn("Todo", "Title");

            MenuData selected = listPage.Select();
        }
    }
}
