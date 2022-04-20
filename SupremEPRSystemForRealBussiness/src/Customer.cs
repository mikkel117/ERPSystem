using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SupremEPRSystemForRealBussiness.Data;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Customer : Person
    {
        static int count = 0;
        public Customer() : base(" ", " ", new ContactInfo(" ", " "), new Address(" ", " ", " ", 0, " "), " ")
        {
            ID = count++;
        }
        public Customer(string firstName, string lastName, ContactInfo contactInfo, Address address, string gender) : base(firstName, lastName, contactInfo, address, gender)
        {
            ID = count++;
            Fullname = $"{firstName} {lastName}";
            PhoneNumber = contactInfo.Phone;
            Email = contactInfo.Email;

        }
        public int ID { get; set; }
        public string ShippingAddress1 { get; set; }
        public string LastOrderDate { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }




    }
}