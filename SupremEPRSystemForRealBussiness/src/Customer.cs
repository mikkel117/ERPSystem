using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SupremEPRSystemForRealBussiness.Data;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Customer : Person
    {
        static int count = 0;
        public Customer() : base(" ", " ", new ContactInfo(" ", " "), new Address(" ", " ", " ", 0," " )," ")
        {
            count++;
            ID = count;
        }
        public Customer(string firstName, string lastName, ContactInfo contactInfo, Address address, string gender) : base(firstName, lastName, contactInfo, address, gender)
        {
            ID = count++;
            Fullname = $"{firstName} {lastName}";
        }
        public int ID { get; set; }
        public string Fullname { get; set; }    
        public string ShippingAddress1 { get; set; }
        public DateTime LastOrderDate { get; set; }




    }
}