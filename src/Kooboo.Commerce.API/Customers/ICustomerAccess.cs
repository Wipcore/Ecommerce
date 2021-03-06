﻿using Kooboo.Commerce.API.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.API.Customers
{
    /// <summary>
    /// customer data access apis
    /// </summary>
    public interface ICustomerAccess
    {
        int Create(Customer customer);

        int AddAddress(int customerId, Address address);    
    }
}
