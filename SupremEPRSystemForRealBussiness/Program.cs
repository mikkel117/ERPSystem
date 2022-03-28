using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupremEPRSystemForRealBussiness.src {
    public class Address {
        public Address(string streetName, string city, string country, int zipCode, string region) {
            City = city;
            StreetName = streetName;
            Country = country;
            ZipCode = zipCode;
            Region = region;
        }

        private string City {
            get { return City; }
            set { City = value ?? "Not entered.."; }
        }
        private string StreetName {
            get { return StreetName; }
            set { StreetName = value ?? "Not entered.."; }
        }
        private string Floor {
            get { return Floor; }
            set { Floor = value ?? "Not entered.."; }
        }
        private string Country {
            get { return Country; }
            set { Country = value ?? "Not entered.."; }
        }
        private int ZipCode {
            get { return ZipCode; }
            set { ZipCode = value; }
        }
        private string Region {
            get { return Region; }
            set { Region = value ?? "Not entered.."; }
        }

    }

}