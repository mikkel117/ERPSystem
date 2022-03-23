using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremEPRSystemForRealBussiness.src
{
    class empolyee
    {
        public class Employee : Person
        {
            public Employee(string firstName, string lastName, ContactInfo contactInfo, Address address, string gender) : base(firstName, lastName, contactInfo, address, gender)
            {
            }

            private string workPhone { get; set; }

            private double salery { get; set; }

            private int employeeID { get; set; }

            private string position { get; set; }

            private string department { get; set; }
        }
    }
}

