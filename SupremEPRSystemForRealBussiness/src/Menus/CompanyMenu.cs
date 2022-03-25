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
        private List<Company> company = Database.Instance.companys.ToList();

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
                case ("firma info"):
                    CompanyList(selected.Title);
                    break;
                case ("redigere"):
                    CompanyList(selected.Title);
                    break;
            }
        }

        private void CompanySetups()
        {
            /*a foreach loop that prints companyName, Country and Currency*/
            foreach (var item in company)
            {
                Console.WriteLine($"Firmanavn: {item.CompanyName}");
                Console.WriteLine($"Land: {item.Country}");
                Console.WriteLine($"Valuta: {item.Currency}\n");
            }
        }
        /*a list that shows the title of every company that you can chose */
        private void CompanyList(string CompanyName)
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            foreach (var item in company)
            {
                listPage.Add(new MenuData(item.CompanyName));
            }
            listPage.AddColumn("firma liste", "Title");

            MenuData selected = listPage.Select();
            /*checks if you have chosen "firma info" if yes it will go to CompanyInfo*/
            if (CompanyName == "firma info")
            {
                CompanyInfo(selected.Title);
            }
            else
            {
                EditCompany(selected.Title);
            }
        }
        /*shows every info of the chosen company*/
        private void CompanyInfo(string CompanyName)
        {
            int index = company.FindIndex(a => a.CompanyName == CompanyName);
            Console.WriteLine($"firmanavn: {company[index].CompanyName}");
            Console.WriteLine($"vej: {company[index].Way}");
            Console.WriteLine($"Husnummer: {company[index].HouseNum}");
            Console.WriteLine($"Postnummer: {company[index].ZipCode}");
            Console.WriteLine($"By: {company[index].City}");
            Console.WriteLine($"Land: {company[index].Country}");
            Console.WriteLine($"Valuta: {company[index].Currency}");
        }

        private void EditCompany(string CompanyName)
        {
            Clear(this);
            MenuData menu = new MenuData("new test");
            Form<MenuData> editor = new Form<MenuData>();
            editor.TextBox("test name", "Title");
            editor.IntBox("text int", "Priority");

            editor.Edit(menu);
            Clear(this);
            Console.WriteLine($"Todo {menu.Title} {menu.Priority}");

        }


    }
}
