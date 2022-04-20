using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    public class CreateOrder : Screen
    {
        public override string Title { get; set; } = " Sales Menu ";
        protected override void Draw()
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            listPage.Add(new MenuData("exsiting customer"));
            listPage.Add(new MenuData("new customer"));
            listPage.AddColumn("Options", "Title");

            MenuData selected = listPage.Select();
            if (selected.Title == "exsiting customer")
               createNewOrder(true);
            else
            {
            }
        }
        void createNewOrder(bool exits)
        {
            Quit();
            Console.Clear();
            if (exits)
            {
                Customer customer = null;
                Console.WriteLine("vaild search infomation Customer ID,Email,Phone-Number");
                string input = Console.ReadLine();
                foreach (Customer c in Data.Database.Instance.SelectCustomer())
                {
                    if (input == c.ContactInfo.Phone || input == c.ContactInfo.Email)
                    {
                        customer = c;
                        break;
                    }
                    else
                    {
                        try
                        {
                            if(Convert.ToInt32(input) == c.ID)
                            {
                                customer = c;
                                break;
                            }
                        }
                        catch (Exception) { }
                    }
                }
                if(customer != null)
                {
                    SalesOrder salesOrder = new SalesOrder();
                    Console.Clear();
                    Console.WriteLine("Customer found!!!!!! LETS GOOOO");
                    Console.WriteLine($"FullName: {customer.Fullname}");
                    Console.WriteLine($"Address: {customer.Address.StreetName} {customer.Address.City}");
                    Console.WriteLine($"Want to use this address for the order? Y/N");
                    input = Console.ReadLine();
                    if (input.ToUpper().Contains("Y"))
                    {
                       salesOrder.DeliveryAddress = customer.Address;
                       salesOrder.Customer = customer;  
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("NO customer found do you want to create a new customer?");
                }

            }
        }
    }
}
