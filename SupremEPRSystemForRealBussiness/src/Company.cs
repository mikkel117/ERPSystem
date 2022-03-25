using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Company
    {
        public string CompanyName { get; set; }
        public string Way { get; set; }
        public int HouseNum { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }

        public Company(string companyName, string way, int houseNum, int zipCode, string city, string country,
            string currency)
        {
            CompanyName = companyName;
            Way = way;
            HouseNum = houseNum;
            ZipCode = zipCode;
            City = city;
            Country = country;
            Currency = currency;
        }
    }
}