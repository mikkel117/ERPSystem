
namespace ERP 
{
    class Program 
    {
        public static void Main(string[] args)
        {
            AddDummyCustomers();
            AddDummyEmployees();
        }

        public static void AddDummyCustomers()
        {
            var db = Database.Instance;
            
            var newCustomerTable = new Dictionary<string, string>() 
            {
                {"FirstName",   "TEXT"},
                {"LastName",    "TEXT"},
                {"PersonId",    "TEXT"},
                {"Country",     "TEXT"},
                {"ZipCode",     "TEXT"},
                {"Address1",    "TEXT"},
                {"Address2",    "TEXT"},
                {"PhoneNum",    "TEXT"},
                {"Gender",      "TEXT"},
                {"Email",       "TEXT"},
                {"LatestOrder", "TEXT"}
            };
            db.TableQuery("Customers", newCustomerTable);

            List<Customer> customers = new List<Customer>();
            
            customers.Add( new Customer
            {
                FirstName = "Lars",
                LastName  = "Rosenkilde",
                PersonId  = "0001",
                Country   = "DK",
                ZipCode   = "9000",
                Address1  = "Hemmeligadresse 2",
                Address2  = "",
                PhoneNum  = "+45 12345678",
                Gender    = "Male",
                Email     = "dummy@gmail.com",
                LatestOrder     = DateTime.UtcNow.ToString("MM-dd-yyyy")
            });
            customers.Add( new Customer
            {
                FirstName   = "Svend",
                LastName    = "Eriksen",
                PersonId    = "0002",
                Country     = "UK",
                ZipCode     = "2100",
                Address1    = "Enadresse 22",
                Address2    = "Arbejdsadresse 24",
                PhoneNum    = "+43 88888888",
                Gender      = "Female",
                Email       = "another@gmail.com",
                LatestOrder = DateTime.UtcNow.ToString("MM-dd-yyyy")
            });
            
            foreach (var customer in customers)
            {
                var customerDict = new Dictionary<string, string>()
                {
                    {"FirstName",   customer.FirstName   ?? "Not set"},
                    {"LastName",    customer.LastName    ?? "Not set"},
                    {"PersonId",    customer.PersonId    ?? "Not set"},
                    {"Country",     customer.Country     ?? "Not set"},
                    {"ZipCode",     customer.ZipCode     ?? "Not set"},
                    {"Address1",    customer.Address1    ?? "Not set"},
                    {"Address2",    customer.Address2    ?? "Not set"},
                    {"PhoneNum",    customer.PhoneNum    ?? "Not set"},
                    {"Gender",      customer.Gender      ?? "Not set"},
                    {"Email",       customer.Email       ?? "Not set"},
                    {"LatestOrder", customer.LatestOrder ?? "Not set"}
                };
                
                db.InsertQuery("Customers", customerDict);
            }
            
            db.SearchQuery("Customers");
            db.RemoveQuery("Customers", "PersonId", "0001");
            db.SearchQuery("Customers");
        }

        public static void AddDummyEmployees()
        {
            var db = Database.Instance;
            
            var newEmployeeTable = new Dictionary<string, string>() 
            {
                {"FirstName", "TEXT"},
                {"LastName",  "TEXT"},
                {"PersonId",  "TEXT"},
                {"Country",   "TEXT"},
                {"Address1",  "TEXT"},
                {"Address2",  "TEXT"},
                {"PhoneNum",  "TEXT"},
                {"Gender",    "TEXT"},
                {"Email",     "TEXT"},
                {"Position",  "TEXT"},
                {"Pay",       "TEXT"}
            };
            db.TableQuery("Employees", newEmployeeTable);

            List<Employee> employees = new List<Employee>();
            
            employees.Add( new Employee
            {
                FirstName = "Lars Rosenkilde",
                LastName  = "Vittrup",
                PersonId  = "0003",
                Country   = "DK",
                Address1  = "EngineerAddr 69",
                Address2  = "",
                PhoneNum  = "+45 98989898",
                Gender    = "Male",
                Email     = "back.dev@gmail.com",
                Position  = "back-end Developer",
                Pay       = "70.000"
            });
            employees.Add( new Employee
            {
                FirstName = "Anders",
                LastName  = "Abd",
                PersonId  = "0004",
                Country   = "US",
                Address1  = "FrontEnd 77",
                Address2  = "",
                PhoneNum  = "+43 12131416",
                Gender    = "Female",
                Email     = "front.dev@gmail.com",
                Position  = "front-end Developer",
                Pay       = "50.000"
            });
            
            foreach (var employee in employees)
            {
                var personDict = new Dictionary<string, string>()
                {
                    {"FirstName", employee.FirstName ?? "Not set"},
                    {"LastName",  employee.LastName  ?? "Not set"},
                    {"PersonId",  employee.PersonId  ?? "Not set"},
                    {"Country",   employee.Country   ?? "Not set"},
                    {"Address1",  employee.Address1  ?? "Not set"},
                    {"Address2",  employee.Address2  ?? "Not set"},
                    {"PhoneNum",  employee.PhoneNum  ?? "Not set"},
                    {"Gender",    employee.Gender    ?? "Not set"},
                    {"Email",     employee.Email     ?? "Not set"},
                    {"Position",  employee.Position  ?? "Not set"},
                    {"Pay",       employee.Pay       ?? "Not set"}
                };
                
                db.InsertQuery("Employees", personDict);
            }
            
            db.SearchQuery("Employees");
            db.RemoveQuery("Employees", "PersonId", "0004");
            db.SearchQuery("Employees");
        }
    }
}