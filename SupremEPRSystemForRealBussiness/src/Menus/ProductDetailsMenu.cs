using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using SupremEPRSystemForRealBussiness.Data;
using TECHCOOL.UI;


namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class ProductDetailsMenu : Screen
    {
        public ProductDetailsMenu(Product product)
        {
            //set the product from this class to product you get when its called
            this.product = product;
            if (product != null)
            {
                Draw();
            }
        }
        private Product product;
        public override string Title { get; set; } = "Product deltails";

        protected override void Draw()
        {
            Clear(this);
            ListPage<Product> listPage = new ListPage<Product>();
            listPage.Add(product);
            listPage.AddKey(ConsoleKey.F1, AddProduct);
            listPage.AddKey(ConsoleKey.F2, UpdateProduct);
            listPage.AddKey(ConsoleKey.F5, RemoveProduct);
            WriteLine("=====================================================");
            WriteLine("F1: to Add new product");
            WriteLine("F2: to Update this product");
            WriteLine("F5: to Delete this product ");
            WriteLine("=====================================================");
            WriteLine($"product number: {product.ProductID}");
            WriteLine($"product name: {product.ProductName}");
            WriteLine($"Description: {product.Description}");
            WriteLine($"Sales prise: {product.SalesPrice}");
            WriteLine($"Purchase price: {product.BuyPrice}");
            WriteLine($"Location: {product.Location}");
            WriteLine($"Stock: {product.Stock}");
            WriteLine($"Unit: {product.Unit}");
            WriteLine($"Advance in percent: {product.ProfitPercentage}");
            WriteLine($"Advance in kr: {product.ProfitKR}");
            Product select = listPage.Select();
        }

        private void UpdateProduct(Product _)
        {
            Database.Instance.UpdateProduct(product);
        }

        private void AddProduct(Product _)
        {
            Clear(this);
            WriteLine("test");
        }

        private void RemoveProduct(Product _)
        {
            bool isRemoved = Database.Instance.RemoveProduct(product);
            if (isRemoved == true)
            {
                Clear(this);
                Quit();
            }
        }
    }
}
