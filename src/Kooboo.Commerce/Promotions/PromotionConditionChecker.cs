﻿using Kooboo.Commerce.Customers;
using Kooboo.Commerce.Orders;
using Kooboo.Commerce.Rules;
using Kooboo.Commerce.Rules.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Promotions
{
    /// <summary>
    /// A checker to check if a promotion can be used for the current context.
    /// </summary>
    public class PromotionConditionChecker
    {
        public CheckPromotionConditionResult CheckConditions(Promotion promotion, PriceCalculationContext context)
        {
            var result = new CheckPromotionConditionResult();

            if (String.IsNullOrWhiteSpace(promotion.ConditionsExpression))
            {
                result.Success = true;
                foreach (var item in context.Items)
                {
                    result.MatchedItems.Add(item);
                }

                return result;
            }

            var expression = Expression.Parse(promotion.ConditionsExpression);
            var ruleEngine = new RuleEngine();

            foreach (var item in context.Items)
            {
                var contextModel = new PromotionConditionContextModel
                {
                    Item = item,
                    Customer = context.Customer
                };

                if (ruleEngine.CheckCondition(expression, contextModel))
                {
                    result.Success = true;
                    result.MatchedItems.Add(item);
                }
            }

            return result;
        }
    }
}