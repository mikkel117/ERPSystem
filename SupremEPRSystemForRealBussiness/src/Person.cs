using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Person
    {
        private string firstName { get; set; }

        private string lastName { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public Address Address { get; set; }

        private string gender { get; set; }

        public Person(string firstName, string lastName, ContactInfo contactInfo, Address address, string gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            ContactInfo = contactInfo;
            Address = address;
            this.gender = gender;
        }
    }
}