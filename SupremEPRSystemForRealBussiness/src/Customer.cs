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
        public Customer() : base(" ", " ", new ContactInfo(" ", " "), new Address(" ", " ", " ", 0, " "))
        {
        }
        public Customer(string firstName, string lastName, int id, ContactInfo contactInfo, Address address, string? lastOrderDate) : base(firstName, lastName, contactInfo, address)
        {
            ID = id;
            Fullname = $"{firstName} {lastName}";
            PhoneNumber = contactInfo.Phone;
            Email = contactInfo.Email;
            LastOrderDate = lastOrderDate;

        }
        public int ID { get; set; }
        public string LastOrderDate { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }




    }
}