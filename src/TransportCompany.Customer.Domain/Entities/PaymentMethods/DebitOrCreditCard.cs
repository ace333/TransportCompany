using System;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Customer.Domain.Entities.PaymentMethods
{
    public class DebitOrCreditCard : PaymentMethod
    {
        protected DebitOrCreditCard() { }

        public DebitOrCreditCard(long cardNumber, DateTime expiryDate, int cvvCode, Country country)
        {
            CardNumber = cardNumber;
            ExpiryDate = expiryDate;
            CvvCode = cvvCode;
            Country = country;
            IsPreffered = true;
        }

        public long CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CvvCode { get; set; }
        public Country Country { get; set; }
    }
}
