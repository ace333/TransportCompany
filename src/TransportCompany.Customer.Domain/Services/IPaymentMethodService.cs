using System;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Shared.Domain.Enums;
using TransportCompany.Shared.Domain.Services;

namespace TransportCompany.Customer.Domain.Services
{
    public interface IPaymentMethodService : IDomainService
    {
        PaymentMethod CreatePaymentMethod(PaymentMethodType type, string email, string password, string phoneNumber, bool isAlwaysLoggedIn,
            long cardNumber, DateTime expiryDate, int cvvCode, Country country);
    }
}
