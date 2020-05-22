using TransportCompany.Order.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Enums;
using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Order.Domain.Services
{
    public interface IOrderService : IDomainService
    {
        PaymentAmount GetPaymentAmount(
            string startStreetHouseNumber, 
            string startCity, 
            string startState, 
            string destinationStreetHouseNumber, 
            string destinationCity,
            string destinationState,
            string country);
        Country GetExecutionCountry(string country);
        Invoice CreateCustomersInvoice(int customerId, string name, string surname, string phoneNumber, string email);
    }
}
