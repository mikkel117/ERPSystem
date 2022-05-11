using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupremEPRSystemForRealBussiness.src;

namespace SupremEPRSystemForRealBussiness.Data
{
    partial class Database
    {
        /*adds a customer, address and contactInfo in the database*/
        public bool AddCustomer(Customer customer)
        {
            SqlDataReader dr;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $@"
            insert into Address (City, Country, Region, StreetName, ZipCode) 
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

        /*get all customers*/
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
        /*remove customer by id*/
        public bool RemoveCustomerById(int Id)
        {
            int? Addr = GetAddressId(Id);
            int? Contact = GetContactId(Id);
            if (Addr != null && Contact != null)
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"
            delete from Customer where CustomerId = @id

            delete from [Address] where AddressId = @AddrId

            delete from ContactInfo where ContactInfoId = @ContactId
            
            ";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@AddrId", Addr);
                cmd.Parameters.AddWithValue("@ContactId", Contact);
                cmd.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }
        }
        /*update customer*/
        public bool UpdateCustomer(Customer customer)
        {
            int? AddrID = GetAddressId(customer.ID);
            int? ContactId = GetContactId(customer.ID);
            if (AddrID != null && ContactId != null)
            {
                SqlDataReader dr;
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"
            UPDATE Customer set FirstName = @FirstName, LastName = @LastName where CustomerId = @id

            UPDATE [Address] set City = @City, ZipCode = @zipCode, StreetName = @StreetName, Region = @Region 
            where AddressId = @AddrId

            Update ContactInfo set PhoneNum = @PhoneNum, Email = @Email 
            where ContactInfoId = @ContactId
            ";
                cmd.Parameters.AddWithValue("@id", customer.ID);
                cmd.Parameters.AddWithValue("@AddrId", AddrID);
                cmd.Parameters.AddWithValue("@ContactId", ContactId);
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
            else
            {
                return false;
            }
        }
        /*finds the address id */
        int? GetAddressId(int id)
        {
            SqlDataReader dr;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select AddressId from Customer where CustomerId = @id";
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();
            int? AddressId = null;
            if (dr.Read())
            {
                AddressId = dr.GetInt32(0);
            }
            dr.Close();
            return AddressId;
        }

        /*finds the contact id*/
        int? GetContactId(int id)
        {
            SqlDataReader dr;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select ContactInfoId  from Customer where CustomerId = @id";
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();
            int? ContactId = null;
            if (dr.Read())
            {
                ContactId = dr.GetInt32(0);
            }
            dr.Close();
            return ContactId;
        }


        /*get a customer by id*/
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

        public bool UpdateLastOrderDate(int Id, string date)
        {
            DateTime dt = DateTime.ParseExact(date, "dd-MM-yyyy",
                                  CultureInfo.InvariantCulture);
            dt.ToString("yyyyMMdd");
            SqlDataReader dr;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"update Customer set LastOrderDate = @Date
            where CustomerId = @id";
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Parameters.AddWithValue("@Date", dt);
            cmd.ExecuteNonQuery();
            return false;
        }
    }
}
