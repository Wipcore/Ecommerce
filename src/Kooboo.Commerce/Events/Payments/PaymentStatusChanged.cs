﻿using Kooboo.Commerce.Payments;
using Kooboo.Commerce.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Events.Payments
{
    [Event(Order = 200)]
    public class PaymentStatusChanged : BusinessEvent, IPaymentEvent
    {
        [Param]
        public int PaymentId { get; set; }

        [Param]
        public PaymentStatus OldStatus { get; set; }

        [Param]
        public PaymentStatus NewStatus { get; set; }

        public PaymentStatusChanged() { }

        public PaymentStatusChanged(Payment payment, PaymentStatus oldStatus, PaymentStatus newStatus)
        {
            PaymentId = payment.Id;
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }
    }
}
