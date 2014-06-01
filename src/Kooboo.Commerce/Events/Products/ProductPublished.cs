﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Events.Products
{
    [Event(Order = 300)]
    public class ProductPublished : DomainEvent, IProductEvent
    {
        public int ProductId { get; set; }
    }
}
