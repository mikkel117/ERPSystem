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
        public static Database Instance { get; private set; }
        /*dummyData*/
        public List<Customer> Customers { get; set; }
        public List<Company> companys { get; set; }
        /*end of dummyData*/
        static Database()
        {
            Instance = new Database();
            /*makes a Instance of companys list with a Instance of the Company class*/
            Instance.companys = new List<Company>() { new Company("Test", "idkway", 10, 5, "aalborg", "Russia", "DDK") };
        }


    }

}
