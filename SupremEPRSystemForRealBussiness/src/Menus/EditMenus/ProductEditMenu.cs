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
            /*Product product = new Product("edit", "edit", 10, 10, "edit", 90, "edit");*/
            Form<Product> editor = new Form<Product>();
            editor.TextBox("product name", "ProductName");
            editor.TextBox("location", "Location");
            editor.DoubleBox("sales price", "SalesPrice");
            editor.DoubleBox("buy price", "BuyPrice");
            editor.TextBox("supplier", "Supplier");
            editor.IntBox("stock", "Stock");
            editor.TextBox("description", "Description");
            editor.Edit(product);

            Clear(this);
            Console.WriteLine($"product name: {product.ProductName}");
        }
    }
}
