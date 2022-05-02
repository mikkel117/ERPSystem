using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupremEPRSystemForRealBussiness.src;

namespace SupremEPRSystemForRealBussiness.Data
{
    partial class Database
    {
        public List<SalesOrder> salesOrders = new List<SalesOrder>();

        public void InsertSalesOrder(SalesOrder salesOrder)
        {
            salesOrders.Add(salesOrder);
        }

        public List<SalesOrder> SelectSalesOrder()
        {
            return salesOrders;
        }

        public SalesOrder GetSalesOrder(SalesOrder salesOrder)
        {
            foreach (SalesOrder s in salesOrders)
            {
                if (s.Orderid == salesOrder.Orderid)
                {
                    return s;
                }
            }
            return null;
        }

        public bool RemoveSalesOrder(SalesOrder salesOrder)
        {
            SalesOrder remove = GetSalesOrder(salesOrder);
            salesOrders.Remove(remove);
            if (remove == null)
            {
                return false;
            }
            return true;
        }

        public void UpdateSalesOrder(SalesOrder salesOrder)
        {
            throw new AbandonedMutexException();
        }
    }
}
