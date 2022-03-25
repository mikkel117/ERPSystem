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

            methodSelection(selected.Title);
        }

        private void methodSelection(string title)
        {
            Company companyObj = new Company();

            var methodList = new Dictionary<string, Delegate>();
            methodList["Company Configurations"] = new Func<string>(companyObj.companyConfig);
            methodList["Company Details"] = new Func<string>(companyObj.companyDetails);

            Console.WriteLine(methodList[title].DynamicInvoke());
        }
    }
}
