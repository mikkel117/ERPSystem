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

        public ProductEditMenu(Product product)
        {
            this.product = product;
            Draw();
        }

        protected override void Draw()
        {
            Clear(this);
            Form<Product> editor = new Form<Product>();
            editor.TextBox("product number", "ProductID");
            editor.TextBox("product name", "ProductName");
            editor.TextBox("description", "Description");
            editor.DoubleBox("sales price", "SalesPrice");
            editor.DoubleBox("buy price", "BuyPrice");
            editor.TextBox("location", "Location");
            editor.IntBox("stock", "Stock");
            editor.TextBox("unit", "Unit");
            editor.Edit(product);
        }
    }
}
