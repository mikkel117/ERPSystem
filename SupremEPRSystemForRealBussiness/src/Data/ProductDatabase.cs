using SupremEPRSystemForRealBussiness.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremEPRSystemForRealBussiness.Data
{
    partial class Database
    {
        private List<Product> products = new List<Product>();

        //adds new product to the product list
        public void InsertProduct(Product product)
        {
            products.Add(product);
        }

        //gives all products in the list
        public List<Product> SelectProducts()
        {
            return products;
        }

        public Product GetProductByID(int id)
        {
            foreach(Product p in products)
            {
                if(p.ProductID == id)
                {
                    return p;
                    break;
                }
            }
            return null;
        }

        //Get 1 product with the product id
        public Product GetProduct(Product product)
        {
            foreach (Product p in products)
            {
                if (p.ProductID == product.ProductID)
                {
                    return p;
                }
            }
            return null;
        }

        public bool RemoveProduct(Product product)
        {
            Product remove = GetProduct(product);
            products.Remove(remove);
            if (remove == null)
            {
                return false;
            }
            return true;
        }

        public void UpdateProduct(Product product)
        {
            src.Menus.EditMenus.ProductEditMenu productEditMenu = new(product);
            // updates the product profit in profit percentage and profit in KR
            double profitKRTemp = product.SalesPrice - product.BuyPrice;
            double profitPercentageTemp = profitKRTemp / product.SalesPrice * 100;
            profitPercentageTemp = (double)System.Math.Round(profitPercentageTemp, 2);
            product.ProfitPercentage = Convert.ToString(profitPercentageTemp + " %");
            product.ProfitKR = Convert.ToString(profitKRTemp + " kr");
        }
    }
}
