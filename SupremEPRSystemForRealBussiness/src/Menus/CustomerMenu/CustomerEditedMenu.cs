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
            Clear(this);
            Form<Customer> form = new();
            Form<Address> addrees = new();
            form.TextBox("Name", "FirstName");
            form.TextBox("LastName", "LastName");
            addrees.TextBox("Street", "StreetName");
            form.Edit(customer);
            Clear(this);
            addrees.Edit(customer.Address);

            
        }

    }
}
