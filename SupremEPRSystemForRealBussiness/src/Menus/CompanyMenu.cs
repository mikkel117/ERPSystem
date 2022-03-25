using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;
using SupremEPRSystemForRealBussiness.src;
using SupremEPRSystemForRealBussiness.Data;

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
            listPage.Add(new MenuData("redigere"));
            listPage.AddColumn("Todo", "Title");

            MenuData selected = listPage.Select();

            /*a switch that looks at what you selecte*/
            switch (selected.Title)
            {
                case ("firmaopsætninger"):
                    CompanySetups();
                    break;


            }
        }

        private void CompanySetups()
        {
            /*a foreach loop that prints companyName, Country and Currency*/
            foreach (var item in Database.Instance.companys)
            {
                Console.WriteLine($"Firmanavn: {item.CompanyName}");
                Console.WriteLine($"Land: {item.Country}");
                Console.WriteLine($"Valuta: {item.Currency}\n");
            }
        }

        private void CompanyInfo()
        {

        }


    }
}
