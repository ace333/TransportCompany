using System;
using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Customer.Application.Command
{
    public class AddPaymentMethodCommand : IdCommand, ICommand
    {
        public PaymentMethodType Type { get; set; }
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
