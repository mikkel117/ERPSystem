using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremEPRSystemForRealBussiness.src
{
    public class SalesOrder
    {
        static int orders = 0;
        public double totalPrice { get; set; }
        public double price { get; set;}
        public string Tax { get; set; }
        public int TotalItems { get; set; }
        public string PaymentMethod { get; set; }
        public Address DeliveryAddress { get; set; }
        public string street { set { }  get { return Customer.Address.StreetName; } }
        public List<int> orderlineids = new();
        public string TimeStamp { get; set; }
        public string OrderStatus { get; set; }
        public string country { set { } get { return Customer.Address.Country; } }  
        public List<OrderLine> OrderLines = new();
        public Customer Customer { get; set; }
        public int CustomerId { get { return Customer.ID; } }
        public string Name { get { return Customer.Fullname;} }
        public int Orderid {get; set;}

        public SalesOrder()
        {
          
            Orderid = orders++;
            TimeStamp = DateTime.Now.ToShortDateString();
        }
    }
}
