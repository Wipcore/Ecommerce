﻿using Kooboo.Commerce.Customers;
using Kooboo.Commerce.Orders;
using Kooboo.Commerce.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Kooboo.Commerce.Promotions
{
    /// <summary>
    /// 定义一种促销策略。
    /// </summary>
    public interface IPromotionPolicy
    {
        /// <summary>
        /// 策略名称。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 执行促销策略。
        /// </summary>
        /// <param name="context"></param>
        void Execute(PromotionContext context);

        /// <summary>
        /// 获取促销策略配置的编辑器。
        /// </summary>
        PromotionPolicyEditor GetEditor(Promotion promotion);
    }
}
