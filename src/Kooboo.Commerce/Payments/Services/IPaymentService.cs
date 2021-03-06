﻿using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.Commerce.Data;
using Kooboo.Commerce.Events;
using Kooboo.Commerce.Events.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Payments.Services
{
    public interface IPaymentService
    {
        Payment GetById(int id);

        IQueryable<Payment> Query();

        void Create(Payment payment);

        void AcceptProcessResult(Payment payment, ProcessPaymentResult result);

        void ChangeStatus(Payment payment, PaymentStatus newStatus);
    }

    [Dependency(typeof(IPaymentService))]
    public class PaymentService : IPaymentService
    {
        private IRepository<Payment> _repository;

        public PaymentService(IRepository<Payment> repository)
        {
            _repository = repository;
        }

        public Payment GetById(int id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Payment> Query()
        {
            return _repository.Query();
        }

        public void Create(Payment payment)
        {
            _repository.Insert(payment);
            Event.Raise(new PaymentCreated(payment));
        }

        public void AcceptProcessResult(Payment payment, ProcessPaymentResult result)
        {
            if (result.PaymentStatus == PaymentStatus.Success)
            {
                ChangeStatus(payment, PaymentStatus.Success);
            }
        }

        public void ChangeStatus(Payment payment, PaymentStatus newStatus)
        {
            if (payment.Status != newStatus)
            {
                var oldStatus = payment.Status;
                payment.Status = newStatus;

                _repository.Database.SaveChanges();

                Event.Raise(new PaymentStatusChanged(payment, oldStatus, newStatus));
            }
        }
    }
}
