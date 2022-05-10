using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremEPRSystemForRealBussiness.src
{
    public class OrderLines
    {
        public int quantity { get; set; }

        public Product Product { get; set; }

        public int orderID { get; set; }

        public double unitPrice { get; set; }
    }
}
