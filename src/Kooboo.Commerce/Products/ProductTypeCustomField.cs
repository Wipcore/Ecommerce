﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.Commerce.EAV;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kooboo.Commerce.Products
{
    public class ProductTypeCustomField
    {
        [Key, Column(Order = 0)]
        public int ProductTypeId { get; set; }
        [Key, Column(Order = 1)]
        public int CustomFieldId { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual CustomField CustomField { get; set; }

        public ProductTypeCustomField() { }

        public ProductTypeCustomField(ProductType productType, CustomField customField)
        {
            ProductType = productType;
            CustomField = customField;
        }
    }
}
