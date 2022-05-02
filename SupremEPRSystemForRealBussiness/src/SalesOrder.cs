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
        public string Tax { get; set; }
        public int TotalItems { get; set; }
        public string PaymentMethod { get; set; }
        public Address DeliveryAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderLine> OrderLines = new();
        public Customer Customer { get; set; }
        public int Orderid {get; set;}

        public SalesOrder()
        {
            Orderid = orders++;
            TimeStamp = DateTime.Now;
        }
    }
}
