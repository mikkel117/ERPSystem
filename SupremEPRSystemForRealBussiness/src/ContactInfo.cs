using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremEPRSystemForRealBussiness
{
    public class ContactInfo
    {
        public ContactInfo(string phone, string email)
        {
            Phone = phone;
            Email = email;
        }
        private string Phone { get; set; }

        private string Email { get; set; }

    }
}
