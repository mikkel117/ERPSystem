using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;
using SupremEPRSystemForRealBussiness.Data;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    class ListofCustomers : Screen
    {
        //Customer selected;
        public override string Title { get; set; } = "Customers List";
        ListPage<Customer> listPage = new ListPage<Customer>();

        protected override void Draw()
        {
            Console.Clear();
            //Checks if the database has any cutomers to show if not it gives a message that says its havent found any 
            //if it does find some it will show the Name, lastname and the id of the customer if you press enter on one you get the full infomation 
            //The list of customers are created here 
            Console.WriteLine("Press F5 to delete customer");
            Console.WriteLine("Prees F3 to lookup customerID ");
            Console.WriteLine("Prees F2 to Edit customer");
            Console.WriteLine("Prees F1 to create new customer");
            listPage.AddKey(ConsoleKey.F1, createCustomers);
            listPage.AddKey(ConsoleKey.F2, editedCustomer);
            listPage.AddKey(ConsoleKey.F3, Lookupcustomer);
            listPage.AddKey(ConsoleKey.F5, deleteCustomer);
            listPage.AddColumn("customer Number ", "ID", 20);
            listPage.AddColumn("fullname", "Fullname", 20);
            listPage.AddColumn("phone number", "PhoneNumber", 20);
            listPage.AddColumn("email", "Email", 20);
            listPage.Add(Database.Instance.SelectCustomer());
            Customer selected = null;
            try
            {
                selected = listPage.Select();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("No Customers Found (That could be a Problem)");
            }


            //list of customers ends here
            //selected customer details start here showing all know infomation about the customer 
            if (selected != null)
                CustomerDetalis(selected);
        }
        void CustomerDetalis(Customer selected)
        {
            Console.Clear();
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
            Quit();
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
            return customerString.ToString();

        }

        void Lookupcustomer(Customer customer)
        {
            int? input = null;
            bool found = false;
            try
            {
                Console.Clear();
                Console.WriteLine("Search for a customer by id");
                Console.Write("Pleas enter ID: ");
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("The id you typed is invailed has to be a whole number");
                Lookupcustomer(customer);
            }
            foreach (Customer c in Database.Instance.SelectCustomer())
            {
                if (c.ID == input)
                {
                    found = true;
                    customer = c;
                }
            }
            if (found == true)
            {

                ListPage<Customer> listPage = new ListPage<Customer>();
                Clear(this);
                listPage.AddKey(ConsoleKey.F2, Lookupcustomer);
                listPage.AddColumn("Name", "FirstName", 10);
                listPage.AddColumn(" ", "LastName", 10);
                listPage.AddColumn("ID ", "ID", 5);
                listPage.Add(customer);
                CustomerDetalis(listPage.Select());
                Console.Clear();
            }
            else
            {
                Console.WriteLine("The ID haven´t been assigned to a customer ");
                Console.ReadLine();
                Console.Clear();
                Quit();
            }

        }
        void deleteCustomer(Customer customer)
        {
            Database.Instance.removeCustomer(customer);
            listPage.Remove(customer);
            Quit();
        }

        void editedCustomer(Customer c)
        {
            CreateCustomer edited = new(c);
            Screen.Display(edited);
        }
        void createCustomers(Customer _)
        {
            CreateCustomer createCustomer = new CreateCustomer();
            Screen.Display(createCustomer);
        }

    }
}
