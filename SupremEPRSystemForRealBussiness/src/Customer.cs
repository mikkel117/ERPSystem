using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Customer : Person
    {
        public Customer(string firstName, string lastName, ContactInfo contactInfo, Address address, string gender, string shippingAddress1, string country, int zipCode, string city, string region, string lastOrderDate) : base(firstName, lastName, contactInfo, address, gender)
        {
            ShippingAddress1 = shippingAddress1;
            Country = country;
            ZipCode = zipCode;
            City = city;
            Region = region;
            LastOrderDate = lastOrderDate;
        }

        private string ShippingAddress1 { get; set; }

        private string Country { get; set; }

        private int ZipCode { get; set; }

        private string City { get; set; }

        private string Region { get; set; }

        private string LastOrderDate { get; set; }
    }
}