using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    class ListofCustomers : Screen
    {
        public override string Title { get; set; } = "Customers List";

        protected override void Draw()
        {
            Clear(this);
            ListPage<string> listPage = new ListPage<string>();
            if (Data.Database.Instance.Customers != null)
            {
                foreach (Customer customer in Data.Database.Instance.Customers)
                {
                    listPage.Add($"ID {customer.ID} | Name {customer.FirstName} {customer.LastName}");
                }
                listPage.AddColumn("Customers list", "Title");

                string selected = listPage.Select();
                Console.WriteLine(selected);
            }
            else
            {
                Console.WriteLine("You got no customers so you probbly going out of bussiness soon soooo yeah thats not good");
            }

        }
    }
}
