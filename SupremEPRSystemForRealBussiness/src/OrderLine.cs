using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupremEPRSystemForRealBussiness.src.Menus;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src
{
    public class OrderLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductID { get; set; }
        public double Price { get; set; }
        public double totalprice { get; set; }
        public int Amount { get; set; }

        public OrderLine(int id, string name,double price,int amount)
        {
            Id = id;
            Name = name;
            Price = price;  
            Amount = amount;
            totalprice = amount * price;
        }
    }
}
