using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremEPRSystemForRealBussiness.src
{
    public class SalesOrder
    {
        public double totalPrice { get; set; }
        public string Tax { get; set; }
        public int TotalItems { get; set; }
        public string PaymentMethod { get; set; }
        public Address DeliveryAddress { get; set; }
        public string TimeStamp { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderLines> OrderLines { get; set; }
        public Customer Customer { get; set; }
        public int OrderID { get; set; }
    }
}
