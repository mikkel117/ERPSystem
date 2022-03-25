using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    class CreateCustomer : Screen
    {
        public override string Title { get; set; } = "Add Customer Menu ";
        new Customer Customer = new Customer();

        
        protected override void Draw()
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            listPage.Add(new MenuData("Name"));
            listPage.Add(new MenuData("Address"));
            listPage.Add(new MenuData("Contact Info"));
            listPage.Add(new MenuData("Check Info"));
            listPage.AddColumn("Needed infomation", "Title");
            MenuData selected = listPage.Select();
            switch (selected.Title)
            {
                case ("Name"):
                    Console.Write("Name: ");
                    Customer.FirstName = Console.ReadLine();
                    Console.Write("LastName: ");
                    Customer.LastName = Console.ReadLine(); 
                    break;

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
                case ("Contact Info"):
                    Console.Write("PhoneNumber: ");
                    string phone = Console.ReadLine();
                    Console.Write("Email");
                    string email = Console.ReadLine();
                    Customer.ContactInfo = new ContactInfo(phone, email);
                    break;
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
                    Data.Database.Instance.Customers.Add(Customer);
                    break;
            }
        }



    }
}


