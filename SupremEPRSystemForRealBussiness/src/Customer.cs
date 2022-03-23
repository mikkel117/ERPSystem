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

        private string shippingAddress1 { get; set; }

        private string country { get; set; }

        private int zipCode { get; set; }

        private string city { get; set; }

        private string region { get; set; }

        private string lastOrderDate { get; set; }
    }
}