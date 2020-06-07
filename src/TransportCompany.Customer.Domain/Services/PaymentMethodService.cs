using System;
using System.Collections.Generic;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Customer.Domain.Model;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Customer.Domain.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IDictionary<PaymentMethodType, Func<PaymentMethodProperties, PaymentMethod>> _paymentMethodsDictionary;

        public PaymentMethodService()
        {
            _paymentMethodsDictionary = new Dictionary<PaymentMethodType, Func<PaymentMethodProperties, PaymentMethod>>
            {
                { PaymentMethodType.PayPal, (props)
                    => new PayPal(props.Email, props.Password, props.PhoneNumber, props.IsAlwaysLoggedIn) },
                { PaymentMethodType.DebitOrCreditCard, (props)
                    => new DebitOrCreditCard(props.CardNumber, props.ExpiryDate, props.CvvCode, props.Country) }
            };
        }
        
        public PaymentMethod CreatePaymentMethod(PaymentMethodType type,
                                                 string email,
                                                 string password,
                                                 string phoneNumber,
                                                 bool isAlwaysLoggedIn,
                                                 long cardNumber,
                                                 DateTime expiryDate,
                                                 int cvvCode,
                                                 Country country)
        {
            var properties = new PaymentMethodProperties(email, password, phoneNumber, isAlwaysLoggedIn, cardNumber,
                expiryDate, cvvCode, country);

            return _paymentMethodsDictionary[type](properties);
        }
    }
}
