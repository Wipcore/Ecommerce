﻿using Kooboo.Commerce.Rules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Shipping
{
    public class ShippingMethod
    {
        [Param]
        public int Id { get; set; }

        [Required, StringLength(50)]
        [Param]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public bool IsEnabled { get; set; }

        [Required, StringLength(100)]
        public string ShippingRateProviderName { get; set; }

        public string ShippingRateProviderData { get; set; }

        public void Enable()
        {
            if (!IsEnabled)
            {
                IsEnabled = true;
            }
        }

        public void Disable()
        {
            if (IsEnabled)
            {
                IsEnabled = false;
            }
        }
    }
}
