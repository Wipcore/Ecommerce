﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.API.Payments
{
    public class PaymentMethod : ItemResource
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string UniqueId { get; set; }

        public PriceChangeMode AdditionalFeeChargeMode { get; set; }

        public decimal AdditionalFeeAmount { get; set; }

        public float AdditionalFeePercent { get; set; }

        public string PaymentProcessorName { get; set; }

        public IList<PaymentProcessorParameterDescriptor> PaymentProcessorParameterDescriptors { get; set; }

        public PaymentMethod()
        {
            PaymentProcessorParameterDescriptors = new List<PaymentProcessorParameterDescriptor>();
        }

        public decimal GetPaymentMethodFee(decimal total)
        {
            if (AdditionalFeeChargeMode == PriceChangeMode.ByAmount)
            {
                return AdditionalFeeAmount;
            }

            return Math.Round((decimal)AdditionalFeePercent * total, 2);
        }
    }
}
