
namespace ERP 
{
    class Program 
    {
        public static void Main(string[] args)
        {
            ListObjects();
        }

        public static void AddDummyCustomers()
        {
            
        }

        public static void ListObjects()
        {
            var db = Database.Instance;
            
            var newCustomerTable = new Dictionary<string, string>() 
            {
                {"FirstName", "TEXT"},
                {"LastName",  "TEXT"},
                {"PersonId",  "TEXT"},
                {"Country",   "TEXT"},
                {"Address1",  "TEXT"},
                {"Address2",  "TEXT"},
                {"PhoneNum",  "TEXT"},
                {"Gender",    "TEXT"},
                {"Email",     "TEXT"}
            };
            db.TableQuery("Persons", newCustomerTable);

            List<Person> persons = new List<Person>();
            
            persons.Add( new Person
            {
                FirstName = "Lars",
                LastName  = "Rosenkilde",
                PersonId  = "0001",
                Country   = "DK",
                Address1  = "Hemmeligadresse 2",
                Address2  = "",
                PhoneNum  = "+45 12345678",
                Gender    = "Male",
                Email     = "dummy@gmail.com"
            });
            persons.Add( new Person
            {
                FirstName = "Svend",
                LastName  = "Eriksen",
                PersonId  = "0002",
                Country   = "UK",
                Address1  = "Enadresse 22",
                Address2  = "Arbejdsadresse 24",
                PhoneNum  = "+43 88888888",
                Gender    = "Female",
                Email     = "another@gmail.com"
            });
            
            foreach (var person in persons)
            {
                var personDict = new Dictionary<string, string>()
                {
                    {"FirstName", person.FirstName ?? "Not set"},
                    {"LastName",  person.LastName  ?? "Not set"},
                    {"PersonId",  person.PersonId  ?? "Not set"},
                    {"Country",   person.Country   ?? "Not set"},
                    {"Address1",  person.Address1  ?? "Not set"},
                    {"Address2",  person.Address2  ?? "Not set"},
                    {"PhoneNum",  person.PhoneNum  ?? "Not set"},
                    {"Gender",    person.Gender    ?? "Not set"},
                    {"Email",     person.Email     ?? "Not set"},
                };
                
                db.InsertQuery("Persons", personDict);
            }
            
            db.SearchQuery("Persons");
            db.RemoveQuery("Persons", "PersonId", "0001");
            db.SearchQuery("Persons");
        }
    }
}
