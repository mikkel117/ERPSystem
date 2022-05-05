using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    public class CreateOrderLines : Screen
    {
        public OrderLine orderLine { get; private set; }
        public override string Title { get; set; } = "Selecte product to add to order";
        public OrderLine test()
        {
            Draw();
            return orderLine;
        }
        protected override void Draw()
        {
            Clear(this);
            ListPage<Product> listPage = new ListPage<Product>();
            listPage.Add(Data.Database.Instance.SelectProducts());
            listPage.AddKey(ConsoleKey.Escape, back);
            listPage.AddColumn("ProductName", "ProductName");
            listPage.AddColumn("Price", "SalesPrice");
            listPage.AddColumn("Stock", "Stock");
            Product selected = listPage.Select();
            Clear(this);
            Console.WriteLine("Type: 'Exit' to exit this menu");
            Console.WriteLine("Product | Price | stock");
            Console.WriteLine($"{selected.ProductName} | {selected.SalesPrice} | {selected.Stock}");
            Console.Write("Amount: ");
            bool success = false;
            string input = Console.ReadLine();
            int number = 0;
            while (!success)
            {
                try
                {
                    number = Convert.ToInt32(input);
                    if(number <= selected.Stock)
                    {
                        if(number > 0)
                        {
                            success = true;
                        }
                        else
                        {
                            Console.WriteLine("Amount has to be more than 0");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Can't do that becuse that many isn't in stock");
                    }
                   
                }
                
                catch (Exception ex)
                {
                    if(input.ToUpper() == "EXIT")
                    {
                        Quit();
                        Console.Clear();
                        Draw();
                    }
                    else
                    {
                        Console.WriteLine("The Amount has to be a whole number");
                    }
                    
                }
            }
            orderLine = new OrderLine(selected.ProductID, selected.ProductName, selected.SalesPrice,number);
            Console.WriteLine("order line has been created!");




        }
        void back(Product _)
        {
            Quit();
            Console.Clear();
            listorders listorders = new();
            Screen.Display(listorders);
        }
    }
}
