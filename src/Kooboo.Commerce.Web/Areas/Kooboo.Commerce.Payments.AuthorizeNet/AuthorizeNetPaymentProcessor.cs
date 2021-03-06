﻿using AuthorizeNet;
using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.Commerce.Payments.Services;
using Kooboo.Commerce.Settings.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kooboo.Commerce.Payments.AuthorizeNet
{
    [Dependency(typeof(IPaymentProcessor), Key = "AuthorizeNet")]
    public class AuthorizeNetPaymentProcessor : IPaymentProcessor
    {
        private IPaymentMethodService _paymentMethodService;

        public string Name
        {
            get { return Strings.ProcessorName; }
        }

        public AuthorizeNetPaymentProcessor(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        public ProcessPaymentResult Process(ProcessPaymentRequest request)
        {
            var method = _paymentMethodService.GetById(request.Payment.PaymentMethod.Id);
            var settings = AuthorizeNetConfig.Deserialize(method.PaymentProcessorData);

            var authRequest = CreateGatewayRequest(settings, request);
            var gateway = new Gateway(settings.LoginId, settings.TransactionKey, settings.SandboxMode);
            var response = gateway.Send(authRequest, request.Payment.Description);

            var result = new ProcessPaymentResult();

            if (response.Approved)
            {
                result.PaymentStatus = PaymentStatus.Success;
            }
            else
            {
                result.PaymentStatus = PaymentStatus.Failed;
                result.Message = response.ResponseCode + ": " + response.Message;
            }

            result.ThirdPartyTransactionId = response.TransactionID;

            return result;
        }

        private GatewayRequest CreateGatewayRequest(AuthorizeNetConfig settings, ProcessPaymentRequest paymentRequest)
        {
            var request = new CardPresentAuthorizeAndCaptureRequest(
                    paymentRequest.Amount,
                    paymentRequest.Parameters[AuthorizeNetConstants.CreditCardNumber],
                    paymentRequest.Parameters[AuthorizeNetConstants.CreditCardExpireMonth],
                    paymentRequest.Parameters[AuthorizeNetConstants.CreditCardExpireYear]
            );

            request.AddCardCode(paymentRequest.Parameters[AuthorizeNetConstants.CreditCardCvv2]);

            return request;
        }

        public PaymentProcessorEditor GetEditor(PaymentMethod paymentMethod)
        {
            return new PaymentProcessorEditor("~/Areas/" + Strings.AreaName + "/Views/Config.cshtml");
        }
    }
}