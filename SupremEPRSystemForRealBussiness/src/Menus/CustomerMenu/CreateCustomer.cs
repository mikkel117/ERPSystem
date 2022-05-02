using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    class CreateCustomer : Screen //TODO: rename CreateCustomer to CreateCustomerMenu
    {
        public override string Title { get; set; } = "Add Customer Menu ";
        bool isEdite = false;
        bool isDone = false;
        public CreateCustomer(Customer customer)
        {
            Customer = customer;
            isEdite = true;
            Title = "Edited Customer menu";
        }
        public CreateCustomer()
        {
            Customer = new();
        }

        Customer Customer = new();

        public Customer Test()
        {
            while (!isDone)
            {
                Draw();
            }
            return Customer;
        }

        protected override void Draw()
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            //required infomation 
            listPage.Add(new MenuData("Name"));
            listPage.Add(new MenuData("Address"));
            listPage.Add(new MenuData("Contact Info"));
            listPage.Add(new MenuData("Check Info"));
            listPage.AddColumn("infomation", "Title");
            MenuData selected = listPage.Select();
            if (selected != null)
            {


                switch (selected.Title) //TODO: Make a new method for this switch
                {
                    //sets up the name and lastname to the customer 
                    case ("Name"):
                        Console.Write("Name: ");
                        Customer.FirstName = Console.ReadLine();
                        Console.Write("LastName: ");
                        Customer.LastName = Console.ReadLine();
                        break;
                    //sets up the name and lastname to the customer 
                    case ("Address"):
                        Console.Write("StreetName: ");
                        string streetName = Console.ReadLine();
                        Console.Write("City: ");
                        string city = Console.ReadLine();
                        Console.Write("Country: ");
                        string country = Console.ReadLine();
                        Console.Write("ZipCode: ");
                        int zipCode = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Region: ");
                        string region = Console.ReadLine();
                        Customer.Address = new Address(streetName, city, country, zipCode, region);
                        break;
                    //sets up the name and lastname to the customer 
                    case ("Contact Info"):
                        Console.Write("PhoneNumber: ");
                        string phone = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Customer.ContactInfo = new ContactInfo(phone, email);
                        break;
                    //outputs all infomation on the customer for the operatore to confirm and adding the customer to the database
                    case ("Check Info"):
                        Console.WriteLine($"ID {Customer.ID}");
                        Console.WriteLine($"Name: {Customer.FirstName}");
                        Console.WriteLine($"LastName: {Customer.LastName}\n");
                        Console.WriteLine($"address:");
                        Console.WriteLine($"StreetName: {Customer.Address.StreetName}");
                        Console.WriteLine($"City: {Customer.Address.City}");
                        Console.WriteLine($"Country: {Customer.Address.Country}");
                        Console.WriteLine($"region: {Customer.Address.Region}\n");
                        Console.WriteLine($"Contact Info");
                        Console.WriteLine($"PhoneNumber { Customer.ContactInfo.Phone}");
                        Console.WriteLine($"Email {Customer.ContactInfo.Email}");
                        Console.WriteLine("Press Enter to confirm the infomation is correct");
                        Console.ReadLine();
                        if (!isEdite)
                        {
                            Data.Database.Instance.InsertCustomer(Customer);
                        }
                        Customer.Fullname = $"{Customer.FirstName} {Customer.LastName}";
                        Customer.PhoneNumber = Customer.ContactInfo.Phone;
                        Customer.Email = Customer.ContactInfo.Email;
                        Clear(this);
                        isDone = true;
                        Quit();
                        break;
                }
            }
        }



    }
}


