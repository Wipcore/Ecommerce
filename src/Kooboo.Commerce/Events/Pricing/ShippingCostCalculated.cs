﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Events.Pricing
{
    [Event(Order = 500)]
    public class ShippingCostCalculated : BusinessEvent, IPricingEvent
    {
    }
}
