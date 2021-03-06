using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;
using SupremEPRSystemForRealBussiness.Data;
using SupremEPRSystemForRealBussiness.src;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    class ListofCustomers : Screen
    {
        //Customer selected;
        public override string Title { get; set; } = "Customers List";
        ListPage<Customer> listPage;

        protected override void Draw()
        {
            Clear(this);
            listPage = new ListPage<Customer>();
            //Checks if the database has any cutomers to show if not it gives a message that says its havent found any 
            //if it does find some it will show the Name, lastname and the id of the customer if you press enter on one you get the full infomation 
            //The list of customers are created here 
            listPage.AddKey(ConsoleKey.F1, createCustomers);
            listPage.AddKey(ConsoleKey.F2, Lookupcustomer);
            Console.WriteLine("Prees F1 to create new customer");
            Console.WriteLine("Prees F2 to lookup customerID ");
            listPage.AddColumn("customer Number ", "ID", 20);
            listPage.AddColumn("fullname", "Fullname", 20);
            listPage.AddColumn("phone number", "PhoneNumber", 20);
            listPage.AddColumn("email", "Email", 20);
            listPage.Add(Database.Instance.GetCustomer());
            Customer selected = null;
            try
            {
                selected = listPage.Select();
                if (selected != null)
                    CustomerDetalis(selected);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                /*Console.WriteLine("No Customers Found (That could be a Problem)");*/
                createCustomers(new Customer()); /*need to be looked at later*/
            }

            //list of customers ends here
            //selected customer details start here showing all know infomation about the customer 
            /*if (selected != null)
                CustomerDetalis(selected);*/
        }
        void CustomerDetalis(Customer selected)
        {
            Console.Clear();
            Console.WriteLine("Customer Details");
            Console.WriteLine("Press F2 to Edit customer");
            Console.WriteLine("Press F5 to delete this customer");
            Console.WriteLine();
            Console.WriteLine(CustomerString(selected, "FullName"));
            Console.WriteLine(CustomerString(selected, "Contact"));
            Console.WriteLine(CustomerString(selected, "Address"));
            Console.WriteLine(CustomerString(selected, "LastOrder"));
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
                case ("LastOrder"):
                    if (selected.LastOrderDate != "01-01-1900 00:00:00")
                    {
                        customerString.AppendLine("              LastOrder");
                        customerString.AppendLine("==========================================");
                        customerString.AppendLine($"last Order Date: {selected.LastOrderDate}");
                        customerString.AppendLine("==========================================");
                    }
                    break;
            }
            return customerString.ToString();

        }

        void Lookupcustomer(Customer _)
        {
            Customer? c;
            int? input = null;
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
                Lookupcustomer(_);
            }
            c = Database.Instance.GetCustomerById(input);
            if (c != null)
            {
                ListPage<Customer> listPage = new ListPage<Customer>();
                Clear(this);
                listPage.AddKey(ConsoleKey.F2, Lookupcustomer);
                listPage.AddColumn("Name", "FirstName", 10);
                listPage.AddColumn("LastName", "LastName", 10);
                listPage.AddColumn("ID ", "ID", 5);
                listPage.Add(c);
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
            Database.Instance.RemoveCustomerById(customer.ID);
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
            Customer returnedCustomer = createCustomer.ReturnNewCustomer();
            if (returnedCustomer != null)
            {
                listPage.Add(returnedCustomer);
            }
        }

    }
}
