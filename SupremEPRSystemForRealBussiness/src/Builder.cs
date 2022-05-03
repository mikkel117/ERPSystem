using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremEPRSystemForRealBussiness.src
{
    public class Builder
    {
        static public string CustomerString(Customer selected, string info)
        {
            StringBuilder customerString = new();
            switch (info)
            {
                case ("Contact"):
                    customerString.AppendLine("              ContactInfo");
                    customerString.AppendLine("==========================================");
                    customerString.AppendLine($"Phone-number: {selected.ContactInfo.Phone}");
                    customerString.AppendLine($"Email: {selected?.ContactInfo.Email}");
                    customerString.AppendLine("==========================================");
                    break;
                case ("FullName"):
                    customerString.AppendLine("              Info");
                    customerString.AppendLine("==========================================");
                    customerString.AppendLine($"Full Name: {selected.FirstName} {selected.LastName}");
                    customerString.AppendLine($"LastOrderDate: {selected.LastOrderDate}");
                    customerString.AppendLine("==========================================");
                    break;
                case ("Address"):
                    customerString.AppendLine("              Address");
                    customerString.AppendLine("==========================================");
                    customerString.AppendLine($"Street: {selected.Address.StreetName}");
                    customerString.AppendLine($"City: {selected.Address.City}");
                    customerString.AppendLine($"Country: {selected.Address.Country}");
                    customerString.AppendLine($"region: {selected.Address.Region}");
                    customerString.AppendLine("==========================================");
                    break;
            }
            return customerString.ToString();
        }
        public static string saleorders(SalesOrder s)
        {
            StringBuilder Saleorderstring = new();
            Saleorderstring.AppendLine("              OrderDetails");
            Saleorderstring.AppendLine("==========================================");
            Saleorderstring.AppendLine($"Ordernummber: {s.Orderid}");
            Saleorderstring.AppendLine($"Statues: {s.OrderStatus}");
            Saleorderstring.AppendLine($"Order placed: {s.TimeStamp}");
            foreach(OrderLine o in s.OrderLines)
            {
                Saleorderstring.AppendLine($"Name: {o.Name}|Price: {o.Price}|Amount {o.Amount}| LinePrice: {o.totalprice}");
            }
            Saleorderstring.AppendLine("==========================================");
            return Saleorderstring.ToString();
        }
    }

}
