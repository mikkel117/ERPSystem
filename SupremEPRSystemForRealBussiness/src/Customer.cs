using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Customer : Person
    {
        static int count = 0;
        public Customer() : base(" ", " ", new ContactInfo(" ", " "), new Address(" ", " ", " ", 0, " "), " ")
        {
            count++;
            ID = count;
        }
        public Customer(string firstName, string lastName, ContactInfo contactInfo, Address address, string gender) : base(firstName, lastName, contactInfo, address, gender)
        {
            ID = count++;
        }
        public int ID { get; set; }
        public string ShippingAddress1 { get; set; }
        public string LastOrderDate { get; set; }

    }
}