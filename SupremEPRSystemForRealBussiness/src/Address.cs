using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Address
    {
        public Address(string streetName, string city, string country, int zipCode, string region)
        {
            StreetName = streetName;
            City = city;
            Country = country;
            ZipCode = zipCode;
            Region = region;
        }
        private string City { get; set; }
        private string StreetName { get; set; }
        private string Floor { get; set; }
        private string Country { get; set; }
        private int ZipCode { get; set; }
        private string Region { get; set; }

    }



}