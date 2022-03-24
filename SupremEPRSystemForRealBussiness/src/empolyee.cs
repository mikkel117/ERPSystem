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
            public Employee(string firstName, string lastName, ContactInfo contactInfo, Address address, string gender, string workPhone, double salery, int employeeID, string position, string department) : base(firstName, lastName, contactInfo, address, gender)
            {
                WorkPhone = workPhone;
                Salery = salery;
                EmployeeID = employeeID;
                Position = position;
                Department = department;
            }

            private string WorkPhone { get; set; }

            private double Salery { get; set; }

            private int EmployeeID { get; set; }

            private string Position { get; set; }

            private string Department { get; set; }
        }
    }
}

