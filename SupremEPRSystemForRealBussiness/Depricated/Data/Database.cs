using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupremEPRSystemForRealBussiness.src;
using System.Data.SqlClient;

namespace SupremEPRSystemForRealBussiness.Data
{
    partial class Database
    {
        private static SqlConnection connection = null;
        public static Database Instance { get; set; }
        static Database()
        {
            string connectionString = @"Server=docker.data.techcollege.dk;Database=H1PD021122_Gruppe1;User Id=H1PD021122_Gruppe1;Password=H1PD021122_Gruppe1;";
            connection = new SqlConnection(connectionString);
            connection.Open();
            Instance = new Database();
        }



    }

}
