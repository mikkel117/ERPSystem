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
            GetCustomerById(7);
            /*Customer test = GetCustomerById();*/
            /*List<Customer> test = GetCustomer();*/
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

        public bool AddCustomer(Customer customer)
        {
            int? AddressId = DoesAddressIdExit(customer);
            SqlDataReader dr;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $@"insert into Address (City, Country, Region, StreetName, ZipCode) 
            values (@City, @Country, @Region, @StreetName, @ZipCode)
            insert into ContactInfo (Email, PhoneNum) values (@Email, @PhoneNum)

            insert into Customer (FirstName, LastName, LastOrderDate, AddressId, ContactInfoId) values(@FirstName, @LastName, '19000101',
            (select top 1 AddressId from [Address] order by AddressId desc),
            (select top 1 ContactInfoId from ContactInfo order by ContactInfoId desc))";
            cmd.Parameters.AddWithValue("@City", customer.Address.City);
            cmd.Parameters.AddWithValue("@Country", customer.Address.Country);
            cmd.Parameters.AddWithValue("@Region", customer.Address.Region);
            cmd.Parameters.AddWithValue("@StreetName", customer.Address.StreetName);
            cmd.Parameters.AddWithValue("@ZipCode", customer.Address.ZipCode);
            cmd.Parameters.AddWithValue("@Email", customer.ContactInfo.Email);
            cmd.Parameters.AddWithValue("@PhoneNum", customer.ContactInfo.Phone);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.ExecuteNonQuery();
            return true;
        }

        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new();
            SqlDataReader dr;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT c.CustomerId, c.FirstName, c.LastName, c.LastOrderDate, 
            ad.City, ad.Country, ad.Region, ad.StreetName, ad.ZipCode, 
            ci.Email, ci.PhoneNum FROM Customer c
            inner join Address ad on c.AddressId = ad.AddressId
            inner join ContactInfo ci on ci.ContactInfoId = c.ContactInfoId";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var CustomerId = dr.GetInt32(0);
                var FirstName = dr.GetString(1);
                var LastName = dr.GetString(2);
                var LastOrderDate = dr.GetDateTime(3);
                var City = dr.GetString(4);
                var Country = dr.GetString(5);
                var Region = dr.GetString(6);
                var StreetName = dr.GetString(7);
                var ZipCode = dr.GetInt32(8);
                var Email = dr.GetString(9);
                var Phone = dr.GetString(10);
                customers.Add(new Customer(FirstName, LastName, CustomerId, new ContactInfo(Phone, Email), new Address(StreetName, City, Country, ZipCode, Region), LastOrderDate.ToString()));
            }
            dr.Close();
            return customers;
        }

        public bool RemoveCustomerById(int Id)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"
            delete from Address where AddressId = ()
            delete from Customer where CustomerId = @id;
            
            ";
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public int? DoesAddressIdExit(Customer customer)
        {
            SqlDataReader dr;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select AddressID from [Address] where City = @City 
            and Country = @Country and Region = @Region and StreetName = @StreetName and ZipCode = @ZipCode";
            cmd.Parameters.AddWithValue("@City", customer.Address.City);
            cmd.Parameters.AddWithValue("@Country", customer.Address.Country);
            cmd.Parameters.AddWithValue("@Region", customer.Address.Region);
            cmd.Parameters.AddWithValue("@StreetName", customer.Address.StreetName);
            cmd.Parameters.AddWithValue("@ZipCode", customer.Address.ZipCode);
            dr = cmd.ExecuteReader();
            int? AddressId = null;
            if (dr.Read())
            {
                AddressId = dr.GetInt32(0);

            }
            return AddressId;
        }

        public bool UpdateCustomer(Customer customer)
        {
            SqlDataReader dr;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"
            UPDATE Customer set FirstName = @FirstName, LastName = @LastName where CustomerId = @id
            UPDATE [Address] set City = @City, ZipCode = @zipCode, StreetName = @StreetName, Region = @Region 
            from Customer 
            where Customer.AddressId = @id
            Update [ContactInfoId] set PhoneNum = @PhoneNum, Email = @Email 
            where (select ContactInfoId from Customer where CustomerId = @id)
            ";
            cmd.Parameters.AddWithValue("@id", customer.ID);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@City", customer.Address.City);
            cmd.Parameters.AddWithValue("@ZipCode", customer.Address.ZipCode);
            cmd.Parameters.AddWithValue("@StreetName", customer.Address.StreetName);
            cmd.Parameters.AddWithValue("@Region", customer.Address.Region);
            cmd.Parameters.AddWithValue("@PhoneNum", customer.ContactInfo.Phone);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.ExecuteNonQuery();
            return true;
        }



        public Customer? GetCustomerById(int? Id)
        {
            SqlDataReader dr;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT c.CustomerId, c.FirstName, c.LastName, c.LastOrderDate, 
            ad.City, ad.Country, ad.Region, ad.StreetName, ad.ZipCode, 
            ci.Email, ci.PhoneNum
            FROM Customer c
            inner join Address ad on c.AddressId = ad.AddressId
            inner join ContactInfo ci on ci.ContactInfoId = c.ContactInfoId
            WHERE CustomerId = @id";
            cmd.Parameters.AddWithValue("@id", Id);
            dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read())
                {
                    var CustomerId = dr.GetInt32(0);
                    var FirstName = dr.GetString(1);
                    var LastName = dr.GetString(2);
                    var LastOrderDate = dr.GetDateTime(3);
                    var City = dr.GetString(4);
                    var Country = dr.GetString(5);
                    var Region = dr.GetString(6);
                    var StreetName = dr.GetString(7);
                    var ZipCode = dr.GetInt32(8);
                    var Email = dr.GetString(9);
                    var Phone = dr.GetString(10);
                    Customer customer = new(FirstName, LastName, CustomerId, new ContactInfo(Phone, Email), new Address(StreetName, City, Country, ZipCode, Region), LastOrderDate.ToString());
                    dr.Close();
                    return customer;
                }
            }
            catch (SqlException sex)
            {
                Console.WriteLine(sex.ToString());
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
            }
            dr.Close();
            return null;
        }
    }
}
