using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Product
    {
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string Location { get; set; }
        public double SalesPrice { get; set; }
        public double BuyPrice { get; set; }
        public string Supplier { get; set; }
        public int Stock { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public int ProductID { get; set; }
        public string ProfitPercentage { get; set; }
        public string ProfitKR { get; set; }
        static int IDPluse = 0;

        public Product(string productNumber, string productName, string location, double salesPrice, double buyPrice, string supplier, int stock, string unit, string description)
        {
            ProductNumber = productNumber;
            ProductName = productName;
            Location = location;
            SalesPrice = salesPrice;
            BuyPrice = buyPrice;
            Supplier = supplier;
            Stock = stock;
            Description = description;
            ProductID = IDPluse++;
            Unit = unit;
            ProfitPercentage = Convert.ToString(salesPrice / buyPrice * 100 + " %");
            ProfitKR = Convert.ToString(salesPrice - buyPrice + "kr");
        }
    }
}