﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kooboo.Commerce.Brands
{
    public class BrandCustomField
    {
        [Key, Column(Order=0)]
        public int BrandId { get; set; }
        [Key, Column(Order = 1)]
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
