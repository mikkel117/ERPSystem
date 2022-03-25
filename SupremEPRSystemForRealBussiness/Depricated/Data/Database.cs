using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupremEPRSystemForRealBussiness.src;

namespace SupremEPRSystemForRealBussiness.Data
{
    partial class Database
    {
        public static Database Instance { get; set; }
        public List<src.Customer> Customers { get; set; }
        static Database()
        {
            Instance = new Database();
        }


    }

}
