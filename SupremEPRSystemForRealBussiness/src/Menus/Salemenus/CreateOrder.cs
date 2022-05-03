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
                createNewOrder(false);
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
                        test(salesOrder);

                    }
                    else
                    {
                        bool done = false;
                        do
                        {

                            Console.Clear();
                            Console.WriteLine("What infomation needs to be changed");
                            Console.WriteLine("1. Street");
                            Console.WriteLine("2. City");
                            Console.WriteLine("3. Country");
                            try
                            {
                                int sel = Convert.ToInt32(Console.ReadLine());
                                switch(sel)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.Write("street: ");
                                        salesOrder.Customer.Address.StreetName = Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.Write("City name: ");
                                        salesOrder.Customer.Address.City = Console.ReadLine();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        Console.Write("Country: ");
                                        salesOrder.Customer.Address.Country = Console.ReadLine();
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine("You must use a number to define what infomation needs to be changed");
                                Console.ReadLine();
                            }
                        } while (!done);


                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("NO customer found do you want to create a new customer?");
                }

            }
        }

        public void test(SalesOrder salesOrder)
        {
            bool done = false;
            while (!done)
            {
                Console.Clear();
                OrderLine orderline = OrderLines();
                salesOrder.OrderLines.Add(orderline);



                Console.Clear();
                Console.WriteLine("F1 to finsh SalesOrder");
                Console.WriteLine("Enter to add product to salesOrder");
                Console.WriteLine("====================================");
                Console.WriteLine("Customer details:");
                Console.WriteLine($"ID: {salesOrder.Customer.ID}");
                Console.WriteLine($"Name: {salesOrder.Customer.Fullname}");
                Console.WriteLine($"Phone: {salesOrder.Customer.ContactInfo.Phone}");
                Console.WriteLine("====================================");
                Console.WriteLine("Shipping Address:");
                Console.WriteLine($"Address: {salesOrder.Customer.Address.StreetName}");
                Console.WriteLine($"zipcode: {salesOrder.Customer.Address.ZipCode}");
                Console.WriteLine($"city: {salesOrder.Customer.Address.City}");
                Console.WriteLine("====================================");
                double totalprice = 0;
                foreach (OrderLine c in salesOrder.OrderLines)
                {
                    Console.WriteLine($"Id: {c.Id}|Name: {c.Name}|Amount: {c.Amount}|Price: {c.Price} Kr.|line Total {c.totalprice} Kr.");
                    totalprice = +c.totalprice;
                }
                Console.WriteLine($"Total price: {totalprice}Kr");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.F1:
                        Data.Database.Instance.salesOrders.Add(salesOrder);
                        Customer customer = Data.Database.Instance.customergetbyid(salesOrder.Customer.ID);
                        customer.LastOrderDate = salesOrder.TimeStamp;
                        salesOrder.price = totalprice + "kr";
                        salesOrder.OrderStatus = "Payment Pending";
                        done = true;
                        foreach (OrderLine c in salesOrder.OrderLines)
                        {
                            Product p = Data.Database.Instance.GetProductByID(c.Id);
                            p.Stock = p.Stock - c.Amount;
                        }
                        Console.WriteLine("Order has been placed");
                        break;
                    default:
                        break;

                }
            }
        }

       OrderLine OrderLines()
       {
            CreateOrderLines createOrderLines = new CreateOrderLines();
            OrderLine something = createOrderLines.test();
            
            return something;
       }
    }
}
