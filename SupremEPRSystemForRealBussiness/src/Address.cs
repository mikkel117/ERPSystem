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
        private string streetName;
        private string city;
        private string country;
        private int zipCode;
        private string region;
        public string City { get { return city; } set { city = value; } }
        public string StreetName { get { return streetName; } set { streetName = value; } }
        public string Country { get { return country; } set { country = value; } }
        public int ZipCode { get { return zipCode; } set { zipCode = value; } }
        public string Region { get { return region; } set { region = value; } }

    }



}