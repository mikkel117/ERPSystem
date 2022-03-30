using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupremEPRSystemForRealBussiness.src;

namespace SupremEPRSystemForRealBussiness.Data
{
    partial class Database
    {
        public static Database Instance { get; private set; }
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        static Database()
        {
            Instance = new Database();
            Instance.Products = new List<Product>();
            /*Instance.Products = new List<Product>() { new Product("Iphone", "4R10H", 102093311, 99, 95, "big mac", 10, "big mac's new iphone the only coset 99,95kr") };*/
        }

        private SqlConnection ConnectToDataBase()
        {
            SqlConnection connection = null;
            string DataSource = @"MIKK642F";
            string DatabaseName = "test";
            string UserID = "bb";
            string Password = "1234";

            string connectionString = "Data Source = " + DataSource + "; Initial Catalog = " + DatabaseName
                + "; User ID=" + UserID + "; Password=" + Password;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("connected");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There's an error connecting to the database!\n" + ex.Message);
            }
            return connection;
        }

        public void GetAllProducts()
        {
            SqlConnection Connect = ConnectToDataBase();
            try
            {
                SqlCommand command = new SqlCommand("Select * from [test].[dbo].[Products]", Connect);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ProductId = reader.GetInt32(0);
                        string ProductName = reader.GetString(1);
                        string Location = reader.GetString(2);
                        double SalesPrice = reader.GetDouble(3);
                        double BuyPrice = reader.GetDouble(4);
                        string Supplier = reader.GetString(5);
                        int Stock = reader.GetInt32(6);
                        string Description = reader.GetString(7);
                        Products.Add(new Product(ProductName, Location, ProductId, SalesPrice, BuyPrice, Supplier, Stock, Description));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There's an error connecting to the database!\n" + ex.Message);
            }
            Connect.Close();
        }
    }

}
