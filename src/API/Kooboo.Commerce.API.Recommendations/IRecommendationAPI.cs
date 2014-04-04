﻿using Kooboo.Commerce.API.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.API.Recommendations
{
    public interface IRecommendationAPI
    {
        Product[] ForProduct(int productId);
    }
}