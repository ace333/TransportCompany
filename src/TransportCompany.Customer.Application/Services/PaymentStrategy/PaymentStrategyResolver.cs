using System;
using System.Collections.Generic;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Customer.Domain.Enums;

namespace TransportCompany.Customer.Application.Services.PaymentStrategy
{
    public class PaymentStrategyResolver : IPaymentStrategyResolver
    {
        private readonly IDictionary<PaymentMethodType, Func<PaymentMethod, PaymentStrategy>>
            _paymentStrategyDictionary;

        public PaymentStrategyResolver()
        {
            _paymentStrategyDictionary = new Dictionary<PaymentMethodType, Func<PaymentMethod, PaymentStrategy>>
            {
                { PaymentMethodType.DebitOrCreditCard, (paymentMethod) => new DebitOrCreditCardPaymentStrategy(paymentMethod) },
                { PaymentMethodType.PayPal, (paymentMethod) => new PayPalPaymentStrategy(paymentMethod) }
            };
        }

        public PaymentStrategy Resolve(PaymentMethod paymentMethod)
            => _paymentStrategyDictionary[paymentMethod.Type](paymentMethod);
    }
}
