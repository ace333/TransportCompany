using System;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Customer.Domain.Model
{
    public class PaymentMethodProperties
    {
        public PaymentMethodProperties(string email,
                                       string password,
                                       string phoneNumber,
                                       bool isAlwaysLoggedIn,
                                       long cardNumber,
                                       DateTime expiryDate,
                                       int cvvCode,
                                       Country country)
        {
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            IsAlwaysLoggedIn = isAlwaysLoggedIn;
            CardNumber = cardNumber;
            ExpiryDate = expiryDate;
            CvvCode = cvvCode;
            Country = country;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAlwaysLoggedIn { get; set; }
        public long CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CvvCode { get; set; }
        public Country Country { get; set; }
    }
}
