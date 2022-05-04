using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
            Debug.WriteLine(connection.State.ToString());
            Customer test = GetCustomerById();
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

        public Customer? GetCustomerById(int Id = 6)
        {
            SqlDataReader dr;
            SqlCommand scmd = connection.CreateCommand();
            scmd.CommandText = "SELECT CustomerId, FirstName, LastName, AddressId, ContactInfoId, LastOrderDate FROM Customer WHERE CustomerId = @id";
            scmd.Parameters.AddWithValue("@id", Id);
            dr = scmd.ExecuteReader();
            if (dr.Read())
            {
                var CustomerId = dr.GetInt32(0);
                var FirstName = dr.GetString(1);
                var LastName = dr.GetString(2);
                var ContactId = dr.GetInt32(3);
                var AddressId = dr.GetInt32(4);
                var LastOrderDate = dr.GetDateTime(5);
            }
            return null;
        }
    }
}
