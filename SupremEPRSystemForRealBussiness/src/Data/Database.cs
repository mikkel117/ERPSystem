
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupremEPRSystemForRealBussiness.src;

namespace SupremEPRSystemForRealBussiness.Data
{
    partial class Database
    {
        public static Database Instance { get; private set; }
        public List<src.Customer> Customers { get; set; }
        static Database()
        {
            Instance = new Database();
            Instance.Customers.Add(new Customer("Bob", "Larsen", new ContactInfo("+4512357815", "Bobsmail@homemail.com"), new Address("techystreet 6","techtown","nerdLand",5502,"nerdzone"),"male"));
        }


    }

}