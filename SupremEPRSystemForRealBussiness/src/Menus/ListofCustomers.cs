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
        public override string Title { get; set; } = "Customers List";
 

        protected override void Draw()
        {
            Clear(this);
            ListPage<Customer> listPage = new ListPage<Customer>();
            //Checks if the database has any sutomers to show if not it gives a message that says its havent found any 
            //if it does find some it will show the Name, lastname and the id of the customer if you press enter on one you get the full infomation 
            if (Database.Instance.SelectCustomer().Count > 0)
            {
                //The list of customers are created here 
                Console.WriteLine("Prees F2 to lookup customerID ");
                listPage.AddKey(ConsoleKey.F2, Lookupcustomer);
                listPage.AddColumn("Name", "FirstName", 10);
                listPage.AddColumn("LastName","LastName",10);
                listPage.AddColumn("ID ", "ID",5);
                listPage.Add(Database.Instance.SelectCustomer());
                Customer selected = listPage.Select();
                //list of customers ends here
                //selected customer details start here showing all know infomation about the customer 
                if(selected != null)
                    CustomerDetalis(selected);
            }
            else
            {
                //An error message if no customers were found 
                Console.WriteLine("No Customers Found (That could be a Problem)");
            }

        }
        void CustomerDetalis(Customer selected)
        {
            Console.Clear();
            Console.WriteLine("Customer Details");
            Console.WriteLine();
            Console.WriteLine($@"Name: {selected.FirstName} {selected.LastName}
=======================================");
            Console.WriteLine($@"ContactInfo:
    Phone-Number: {selected.ContactInfo.Phone}
    Email: {selected.ContactInfo.Email}
=======================================");
            Console.WriteLine($@"Address:
    Street {selected.Address.StreetName}
    City {selected.Address.City}
    Country {selected.Address.Country}
    Region {selected.Address.Region}");
            Console.ReadLine();
            Draw();
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
            }catch (Exception ex) 
            {
                Console.Clear();
                Console.WriteLine("The id you typed is invailed has to be a whole number");
                Lookupcustomer(customer);
            }
            foreach (Customer c in Database.Instance.SelectCustomer())
            {
                if(c.ID == input)
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
                Draw();
            }
        }

    }
}
