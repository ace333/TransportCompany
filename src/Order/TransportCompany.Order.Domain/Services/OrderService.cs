using System;
using System.Linq;
using System.Runtime.Serialization;
using TransportCompany.Order.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Enums;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Order.Domain.Services
{
    public class OrderService : IOrderService
    {
        public Invoice CreateCustomersInvoice(int customerId, string name, string surname, string phoneNumber, string email)
        {
            // Method should be able to create a *.pdf invoice file with customer details and payment amount
            // For a demo purposes the file would be just empty byte array
            return new Invoice(customerId, new byte[0]);
        }

        public Country GetExecutionCountry(string country)
        {
            var enumName = typeof(Country).GetMembers()
                .SingleOrDefault(x => x.GetCustomAttributes(typeof(EnumMemberAttribute), false)
                    .Cast<EnumMemberAttribute>()
                    .Any(y => y.Value == country))
                .Name;

            return (Country)Enum.Parse(typeof(Country), enumName);
        }

        public PaymentAmount GetPaymentAmount(string startStreetHouseNumber, 
            string startCity, 
            string startState, 
            string destinationStreetHouseNumber, 
            string destinationCity, 
            string destinationState, 
            string country)
        {
            // Method should be able to calculate the distance between addresses in the user order.
            // Distance should be multiplied by the const value of price / km.
            // For a demo purposes the const price of 15 PLN and 23% of tax would be used.
            return new PaymentAmount("PLN", 15M, 23);
        }
    }
}
