﻿using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.Commerce.API.HAL;
using Kooboo.Commerce.API.Payments;
using Kooboo.Commerce.Payments.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.API.LocalProvider.Payments
{
    [Dependency(typeof(IPaymentMethodQuery))]
    public class LocalPaymentMethodQuery : LocalCommerceQuery<PaymentMethod, Kooboo.Commerce.Payments.PaymentMethod>, IPaymentMethodQuery
    {
        private IPaymentMethodService _paymentMethodService;
        private Kooboo.Commerce.Payments.IPaymentProcessorProvider _processorFactory;

        public LocalPaymentMethodQuery(
            IHalWrapper halWrapper,
            IPaymentMethodService paymentMethodService, 
            Kooboo.Commerce.Payments.IPaymentProcessorProvider processorFactory,
            IMapper<PaymentMethod, Kooboo.Commerce.Payments.PaymentMethod> mapper)
            : base(halWrapper, mapper)
        {
            _paymentMethodService = paymentMethodService;
            _processorFactory = processorFactory;
        }

        public IPaymentMethodQuery ById(int id)
        {
            EnsureQuery();
            _query = _query.Where(x => x.Id == id);
            return this;
        }

        public IPaymentMethodQuery ByUserKey(string userKey)
        {
            EnsureQuery();
            _query = _query.Where(x => x.UserKey == userKey);
            return this;
        }

        public IPaymentMethodQuery ByName(string name)
        {
            EnsureQuery();
            _query = _query.Where(x => x.Name == name);
            return this;
        }

        /// <summary>
        /// create entity query
        /// </summary>
        /// <returns>queryable object</returns>
        protected override IQueryable<Commerce.Payments.PaymentMethod> CreateQuery()
        {
            return _paymentMethodService.Query().Where(x => x.IsEnabled);
        }

        /// <summary>
        /// use the default order when pagination the query
        /// </summary>
        /// <param name="query">pagination query</param>
        /// <returns>ordered query</returns>
        protected override IQueryable<Commerce.Payments.PaymentMethod> OrderByDefault(IQueryable<Commerce.Payments.PaymentMethod> query)
        {
            return query.OrderBy(x => x.Name);
        }

        /// <summary>
        /// map the entity to object
        /// </summary>
        /// <param name="obj">entity</param>
        /// <returns>object</returns>
        protected override PaymentMethod Map(Commerce.Payments.PaymentMethod obj)
        {
            return _mapper.MapTo(obj);
        }
    }
}
