using System;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Customer.Domain.Entities.PaymentMethods
{
    public class DebitOrCreditCard : PaymentMethod
    {
        public int CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CvvCode { get; set; }
        public Country Country { get; set; }
    }
}
