using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public Address Address { get; set; }

        public string Gender { get; set; }

        public Person()
        {

        }
        public Person(string firstName, string lastName, ContactInfo contactInfo, Address address, string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactInfo = contactInfo;
            Address = address;
            Gender = gender;
        }
    }
}