using SupremEPRSystemForRealBussiness.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus.CustomerMenu
{
    internal class CustomerDetails : Screen
    {
        public override string Title { get; set; } = "Customer details";
        private Customer customer;
        public CustomerDetails(Customer c)
        {
            customer = c;
        }

        protected override void Draw()
        {
            Clear(this);
            ListPage<Customer> listPage = new ListPage<Customer>();
            listPage.Add(customer);
            Console.WriteLine("Press F5 to delete this customer");
            Console.WriteLine("Press F2 to Edit customer");
            listPage.AddKey(ConsoleKey.F2, editedCustomer);
            listPage.AddKey(ConsoleKey.F5, deleteCustomer);
            Console.WriteLine("Customer Details");
            Console.WriteLine();
            if (customer != null)
            {
                Console.WriteLine(CustomerString(customer, "FullName"));
                Console.WriteLine(CustomerString(customer, "Contact"));
                Console.WriteLine(CustomerString(customer, "Address"));
            }
            Customer select = listPage.Select();


        }


        private string CustomerString(Customer selected, string info)
        {
            StringBuilder customerString = new();
            switch (info)
            {
                case ("Contact"):
                    customerString.AppendLine("              ContactInfo");
                    customerString.AppendLine("==========================================");
                    customerString.AppendLine($"Phone-number: {selected.ContactInfo.Phone}");
                    customerString.AppendLine($"Email: {selected?.ContactInfo.Email}");
                    customerString.AppendLine("==========================================");
                    break;
                case ("FullName"):
                    customerString.AppendLine("              Name");
                    customerString.AppendLine("==========================================");
                    customerString.AppendLine($"Full Name: {selected.FirstName} {selected.LastName}");
                    customerString.AppendLine("==========================================");
                    break;
                case ("Address"):
                    customerString.AppendLine("              Address");
                    customerString.AppendLine("==========================================");
                    customerString.AppendLine($"Street: {selected.Address.StreetName}");
                    customerString.AppendLine($"City: {selected.Address.City}");
                    customerString.AppendLine($"Country: {selected.Address.Country}");
                    customerString.AppendLine($"region: {selected.Address.Region}");
                    customerString.AppendLine("==========================================");
                    break;
            }
            Debug.WriteLine("hey");
            return customerString.ToString();
        }

        void editedCustomer(Customer c)
        {
            CreateCustomer edited = new(c);
            Screen.Display(edited);
        }

        void deleteCustomer(Customer customer)
        {
            Database.Instance.removeCustomer(customer);
            /*listPage.Remove(customer);*/
            Quit();
        }

        /*Console.Clear();
            Console.WriteLine("Press F5 to delete this customer");
            Console.WriteLine("Press F2 to Edit customer");
            Console.WriteLine("Customer Details");
            Console.WriteLine();
            Console.WriteLine(CustomerString(selected, "FullName"));
            Console.WriteLine(CustomerString(selected, "Contact"));
            Console.WriteLine(CustomerString(selected, "Address"));
            ConsoleKey button = Console.ReadKey().Key;
            switch (button)
            {
                case (ConsoleKey.F5):
                    Console.Clear();
                    deleteCustomer(selected);
                    break;
                case (ConsoleKey.F2):
                    Console.Clear();
                    editedCustomer(selected);
                    break;
            }
    Quit();*/
    }
}
