using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupremEPRSystemForRealBussiness
{
    public class Customer : Person
    {
        private string shippingAddress1
        {
            get => default;
            set
            {
            }
        }

        private string shippingAddress2
        {
            get => default;
            set
            {
            }
        }

        private string country
        {
            get => default;
            set
            {
            }
        }

        private int zipCode
        {
            get => default;
            set
            {
            }
        }

        private string city
        {
            get => default;
            set
            {
            }
        }

        private string region
        {
            get => default;
            set
            {
            }
        }

        private string lastOrderDate
        {
            get => default;
            set
            {
            }
        }
    }

    public class SalesOrder
    {

        private double totalPrice
        {
            get => default;
            set
            {
            }
        }

        private string tax
        {
            get => default;
            set
            {
            }
        }

        private int totalItems
        {
            get => default;
            set
            {
            }
        }

        private string paymentMethod
        {
            get => default;
            set
            {
            }
        }

        private string deliveryOption
        {
            get => default;
            set
            {
            }
        }

        private string timeStamp
        {
            get => default;
            set
            {
            }
        }

        private string orderStatus
        {
            get => default;
            set
            {
            }
        }

        public List<OrderLines> OrderLines
        {
            get => default;
            set
            {
            }
        }

        public Customer Customer
        {
            get => default;
            set
            {
            }
        }

        private int orderID
        {
            get => default;
            set
            {
            }
        }
    }

    public class OrderLines
    {

        private int quantity
        {
            get => default;
            set
            {
            }
        }

        private Product Product
        {
            get => default;
            set
            {
            }
        }

        private int ItemID
        {
            get => default;
            set
            {
            }
        }

        private double unitPrice
        {
            get => default;
            set
            {
            }
        }
    }

    public class Employee : Person
    {
        private string workPhone
        {
            get => default;
            set
            {
            }
        }

        private double salery
        {
            get => default;
            set
            {
            }
        }

        private int id
        {
            get => default;
            set
            {
            }
        }

        private string position
        {
            get => default;
            set
            {
            }
        }

        private string department
        {
            get => default;
            set
            {
            }
        }
    }
}