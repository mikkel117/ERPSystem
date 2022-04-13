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
        List<Customer> customers = new List<Customer>();

        public List<Customer> SelectCustomer()
        {
                return customers;
        }

        public void InsertCustomer(Customer customer)
        {
            customers.Add(customer);
        }
        public bool removeCustomer(Customer customer)
        {
            if (customers.Remove(customer))
            {
                return true;
            }
            else { return false; }  
        }
    }
}
