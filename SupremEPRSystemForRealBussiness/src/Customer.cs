﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupremEPRSystemForRealBussiness.src
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

        private int employeeID
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