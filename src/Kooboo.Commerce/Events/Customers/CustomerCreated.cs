﻿using Kooboo.Commerce.Customers;
using Kooboo.Commerce.Rules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Events.Customers
{
    [Event(Order = 100)]
    public class CustomerCreated : BusinessEvent, ICustomerEvent
    {
        [Reference(typeof(Customer))]
        public int CustomerId { get; set; }

        protected CustomerCreated() { }

        public CustomerCreated(Customer customer)
        {
            CustomerId = customer.Id;
        }
    }
}