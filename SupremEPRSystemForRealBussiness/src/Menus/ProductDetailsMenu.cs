using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using TECHCOOL.UI;


namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class ProductDetailsMenu : Screen
    {
        public ProductDetailsMenu(Product product)
        {
            //set the product from this class to product you get when its called
            this.product = product;
            Draw();
        }
        private Product product;
        public override string Title { get; set; } = "Product deltails";

        protected override void Draw()
        {
            Clear(this);
            WriteLine($"product number: {product.ProductID}");
            WriteLine($"product name: {product.ProductName}");
            WriteLine($"Description: {product.Description}");
            WriteLine($"Sales prise: {product.SalesPrice}");
            WriteLine($"Purchase price: {product.BuyPrice}");
            WriteLine($"Location: {product.Location}");
            WriteLine($"Stock: {product.Stock}");
            WriteLine($"Unit: IDK"); // TODO find out what they mean by unit
            WriteLine($"Advance in percent: {product.ProfitPercentage}");
            WriteLine($"Advance in kr: {product.ProfitKR}");
        }
    }
}
