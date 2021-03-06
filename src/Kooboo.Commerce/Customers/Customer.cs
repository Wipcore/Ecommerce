﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Locations;
using Kooboo.Commerce.Rules;
using Kooboo.Commerce.ComponentModel;
using Kooboo.Commerce.Events;
using Kooboo.Commerce.Events.Customers;

namespace Kooboo.Commerce.Customers
{
    public class Customer : INotifyCreated, INotifyUpdated, INotifyDeleted
    {
        public Customer()
        {
            Addresses = new List<Address>();
            CustomFields = new List<CustomerCustomField>();
        }

        [Param]
        public int Id { get; set; }

        public string AccountId { get; set; }

        [Param]
        public int SavingPoints { get; set; }

        [Param]
        public string FirstName { get; set; }

        [Param]
        public string MiddleName { get; set; }

        [Param]
        public string LastName { get; set; }

        [Param]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
            }
        }

        [Param]
        public string Email { get; set; }

        [Param]
        public Gender Gender { get; set; }

        [Param]
        public string Phone { get; set; }

        public int? CountryId { get; set; }

        public int? ShippingAddressId { get; set; }

        public int? BillingAddressId { get; set; }

        [Param]
        public string City { get; set; }

        [Reference]
        public virtual Country Country { get; set; }

        public virtual List<Address> Addresses { get; set; }

        public virtual Address ShippingAddress
        {
            get
            {
                if (Addresses != null && ShippingAddressId.HasValue)
                {
                    return Addresses.FirstOrDefault(o => o.Id == ShippingAddressId.Value);
                }
                return null;
            }
        }

        public virtual Address BillingAddress
        {
            get
            {
                if (Addresses != null && BillingAddressId.HasValue)
                {
                    return Addresses.FirstOrDefault(o => o.Id == BillingAddressId.Value);
                }
                return null;
            }
        }

        public virtual ICollection<CustomerCustomField> CustomFields { get; set; }

        void INotifyCreated.NotifyCreated()
        {
            Event.Raise(new CustomerCreated(this));
        }

        void INotifyUpdated.NotifyUpdated()
        {
            Event.Raise(new CustomerUpdated(this));
        }

        void INotifyDeleted.NotifyDeleted()
        {
            Event.Raise(new CustomerDeleted(this));
        }
    }
}