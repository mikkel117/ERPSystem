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
            listPage.AddColumn("ProductName", "ProductName");
            listPage.AddColumn("Price", "SalesPrice");
            listPage.AddColumn("Stock", "Stock");
            Product selected = listPage.Select();
            Clear(this);
            Console.WriteLine("Product | Price | stock");
            Console.WriteLine($"{selected.ProductName} | {selected.SalesPrice} | {selected.Stock}");
            Console.Write("Amount: ");
            bool success = false;
            int input = 0;
            while (!success)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if(input <= selected.Stock)
                    {
                        if(input > 0)
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
                    Console.WriteLine("The Amount has to be a whole number");
                }
            }
            orderLine = new OrderLine(selected.ProductID, selected.ProductName, selected.SalesPrice,input);
            Console.WriteLine("order line has been created!");



        }
    }
}
