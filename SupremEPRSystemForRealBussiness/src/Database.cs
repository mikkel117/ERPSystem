using System.Runtime.InteropServices;
using System.Data.SQLite;


namespace ERP 
{
    partial class Database 
    {
        private static volatile Database? _instance;
        private static readonly object SyncRoot = new();

        private const string ConnPath = "Data Source=:memory:";
        private static SQLiteConnection? _dbConnection;

        private Database()
        {
            db_connect();
        }

        public static Database Instance 
        {
            get 
            {
                if (_instance != null)
                {
                    return _instance;
                }
                lock (SyncRoot) 
                {
                    if (_instance == null) 
                    {
                        _instance = new Database();
                    }
                }
                return _instance;
            }
        }

        private static void db_connect() 
        {
            try 
            {
                _dbConnection = new SQLiteConnection(ConnPath);
                _dbConnection.Open();
            }
            catch (SQLiteException e) 
            {
                _dbConnection = null;
                Console.WriteLine(e.Message);
            }
        }


        private bool ExecuteQuery(string query, bool getOutput=false) 
        {
            var cmd = new SQLiteCommand();
            cmd.Connection = _dbConnection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            try 
            {
                if (_dbConnection is not {State: System.Data.ConnectionState.Open})
                {
                    Console.WriteLine("DB Connection is currently closed..");
                    return false;
                }

                if (getOutput)
                {
                    var reader = cmd.ExecuteReader();
                    int fields = reader.FieldCount;
                    string column = "";
                    while (reader.Read())
                    {
                        for (int i = 0; i < fields; i++)
                        {
                            column += $"{reader.GetString(i)}\t";
                        }
                        column = column.Remove(column.Length - 1);
                        
                        Console.WriteLine(column);
                    }
                    return true;
                }
                cmd.ExecuteScalar();
                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void TableQuery(string tableName, Dictionary<string, string> columns) 
        {
            string query = $"CREATE TABLE IF NOT EXISTS {tableName} (";
            foreach (var column in columns) 
            {
                query += $"{column.Key} {column.Value}, ";
            }
            query = query.Remove(query.Length - 2);
            query += ");";

            //Console.WriteLine(query);
            
            ExecuteQuery(query);
        }

        public void InsertQuery(string tableName, Dictionary<string, string> columns) 
        {
            string query = $"INSERT INTO {tableName} (";
            foreach (var column in columns) 
            {
                query += $"{column.Key}, ";
            }
            query = query.Remove(query.Length - 2);
            query += ") ";
            query += $"VALUES (";
            foreach (var column in columns) 
            {
                query += $"'{column.Value}', ";
            }
            query = query.Remove(query.Length - 2);
            query += ");";

            //Console.WriteLine(query);
            
            ExecuteQuery(query);
        }

        public void SearchQuery(string tableName, string selector="*") 
        {
            string query = $"SELECT {selector} FROM {tableName}";
        
            ExecuteQuery(query, getOutput:true);
        }
        
        public void RemoveQuery(string tableName, string selector="Col_0", string identifier="Some String") 
        {
            ExecuteQuery($"DELETE FROM {tableName} WHERE {selector} = '{identifier}'");
        }

        public static void test_singleton() 
        {
            var db0 = Database.Instance;
            var db1 = Database.Instance;

            var dbObj0 = GCHandle.Alloc(db0, GCHandleType.WeakTrackResurrection);
            var dbObj1 = GCHandle.Alloc(db1, GCHandleType.WeakTrackResurrection);

            Console.WriteLine($"db0 instance: {GCHandle.ToIntPtr(dbObj0).ToInt64()}");
            Console.WriteLine($"db1 instance: {GCHandle.ToIntPtr(dbObj1).ToInt64()}");
        }

        ~Database()
        {
            if (_dbConnection == null)
            {
                return;
            }
            _dbConnection.Close();
            _instance = null;
        }
    }
}
