using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    class CustomerEditedMenu : Screen
    {
        public override string Title { get; set; } = "Edited Customer";
        public Customer customer { get; set; }
        public CustomerEditedMenu(Customer Customer)
        {
            customer = Customer;
        }
        protected override void Draw()
        {
            
            Form<Customer> form = new();
            form.TextBox("Name", "FirstName");
            form.TextBox("LastName", "LastName");
            form.Edit(customer);
            Clear(this);
        }

    }
}
