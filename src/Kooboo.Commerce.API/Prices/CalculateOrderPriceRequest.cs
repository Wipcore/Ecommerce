﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.API.Prices
{
    public class CalculateOrderPriceRequest
    {
        public int OrderId { get; set; }

        public int? PaymentMethodId { get; set; }
    }
}