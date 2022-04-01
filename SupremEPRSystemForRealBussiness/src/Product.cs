
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Product
    {
        public string ProductName { get; set; }

        public string Location { get; set; } //change location from array to string.

        public int ProductID { get; set; }

        public double SalesPrice { get; set; }

        public double BuyPrice { get; set; }

        public string Supplier { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; }

        public Product(string productName, string location, int productID, double salesPrice, double buyPrice, string supplier, int stock, string description)
        {
            ProductName = productName;
            Location = location;
            SalesPrice = salesPrice;
            BuyPrice = buyPrice;
            Supplier = supplier;
            Stock = stock;
            Description = description;
        }
    }
}

