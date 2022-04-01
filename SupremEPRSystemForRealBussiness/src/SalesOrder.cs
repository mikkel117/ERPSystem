using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremEPRSystemForRealBussiness.src
{
    public class SalesOrder
    {
        private double totalPrice { get; set; }

        private string tax { get; set; }

        private int totalItems { get; set; }

        private string paymentMethod { get; set; }

        private string deliveryOption { get; set; }

        private string timeStamp { get; set; }

        private string orderStatus { get; set; }

        public List<OrderLines> OrderLines { get; set; }

        public Customer Customer { get; set; }

        private int orderID { get; set; }
    }
}
