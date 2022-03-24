using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Person
    {
        private string FirstName { get; set; }

        private string LastName { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public Address Address { get; set; }

        private string Gender { get; set; }

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