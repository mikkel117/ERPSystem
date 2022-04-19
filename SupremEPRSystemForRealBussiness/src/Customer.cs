using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Customer : Person
    {
        public Customer(string firstName, string lastName, ContactInfo contactInfo, Address address, string gender) : base(firstName, lastName, contactInfo, address, gender)
        {
        }

        private string ShippingAddress { get; set; }
        private string LastOrderDate { get; set; }
    }
}