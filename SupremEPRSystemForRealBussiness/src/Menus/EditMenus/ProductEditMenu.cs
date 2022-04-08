using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus.EditMenus
{
    internal class ProductEditMenu : Screen
    {
        public override string Title { get; set; } = "Edit Product";
        private Product product { get; set; }
        private Customer customer = new Customer("lars", "hansen", new ContactInfo("7777777", "lars@hasen.dk"), new Address("somewere", "NotEvilTown", "NotEvilIsland", 8910, "NotKilledByEvilRapingRabbit"), "male");

        public ProductEditMenu(Product product)
        {
            this.product = product;
            Draw();
        }

        protected override void Draw()
        {
            Clear(this);
            Form<Product> editor = new Form<Product>();
            Form<Customer> menu = new Form<Customer>();
            editor.TextBox("product number", "ProductNumber");
            editor.TextBox("product name", "ProductName");
            editor.TextBox("description", "Description");
            editor.DoubleBox("sales price", "SalesPrice");
            editor.DoubleBox("buy price", "BuyPrice");
            editor.TextBox("location", "Location");
            editor.IntBox("stock", "Stock");
            editor.TextBox("unit", "Unit");
            menu.TextBox("name", "firstName");
            editor.Edit(product);
            menu.Edit(customer);
        }
    }
}
