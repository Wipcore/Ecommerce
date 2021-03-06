﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.API.Orders
{
    /// <summary>
    /// order status
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// order just created
        /// </summary>
        Created = 0,
        /// <summary>
        /// user has paid the order
        /// </summary>
        Paid = 1,
        /// <summary>
        /// order is in processing
        /// </summary>
        Processing = 2,
        /// <summary>
        /// order is canceled, maybe need to refund.
        /// </summary>
        Cancelled = 3
    }
}
