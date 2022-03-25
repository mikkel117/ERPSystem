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

        private string phone;
        private string email;
        public string Phone { get { return phone; } set { phone = value; } }

        public string Email { get { return email; } set { email = value; } }

    }
}
