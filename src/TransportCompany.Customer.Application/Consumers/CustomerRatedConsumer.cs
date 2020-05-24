using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Customer.Domain.Services;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Utils;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Customer.Application.Consumers
{
    public class CustomerRatedConsumer : IConsumer<ICustomerRated>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;
        private readonly ICustomerService _customerService;

        public CustomerRatedConsumer(ICustomerUnitOfWork unitOfWork, ICustomerService customerService)
        {
            _unitOfWork = unitOfWork;
            _customerService = customerService;
        }

        public async Task Consume(ConsumeContext<ICustomerRated> context)
        {
            var message = context.Message;
            var customer = await _unitOfWork.CustomerRepository.FindAsync(message.CustomerId);
            Fail.IfNull(customer, message.CustomerId);

            _customerService.RecalculateCustomerGrade(customer, message.Grade);
            await _unitOfWork.CommitAsync();
        }
    }
}
