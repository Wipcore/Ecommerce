﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Kooboo.Commerce.Categories;

namespace Kooboo.Commerce.Data.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            //HasRequired(o => o.Catalog);
            HasMany(o => o.Children);
            HasOptional(o => o.Parent);
        }
    }
}
