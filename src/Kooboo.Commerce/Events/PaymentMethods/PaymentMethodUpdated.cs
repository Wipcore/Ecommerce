﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Events.PaymentMethods
{
    [Event(Order = 200)]
    public class PaymentMethodUpdated : DomainEvent, IPaymentMethodEvent
    {
    }
}
