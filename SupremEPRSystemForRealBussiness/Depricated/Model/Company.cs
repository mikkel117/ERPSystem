using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremEPRSystemForRealBussiness.Model
{
    internal class Company
    {
        private string companyName { get; set; }
        private string street { get; set; }
        private string country { get; set; }
        private int zipCode { get; set; }

        private string city
        {
            get => default;
            set
            {
            }
        }
    }
}
