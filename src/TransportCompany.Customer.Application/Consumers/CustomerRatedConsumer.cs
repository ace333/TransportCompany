using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Customer.Domain.Events.Consumed;
using TransportCompany.Customer.Domain.Services;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.Consumers
{
    public class CustomerRatedConsumer : IConsumer<CustomerRated>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;
        private readonly ICustomerService _customerService;

        public CustomerRatedConsumer(ICustomerUnitOfWork unitOfWork, ICustomerService customerService)
        {
            _unitOfWork = unitOfWork;
            _customerService = customerService;
        }

        public async Task Consume(ConsumeContext<CustomerRated> context)
        {
            var message = context.Message;
            var customer = await _unitOfWork.CustomerRepository.FindAsync(message.CustomerId);
            Fail.IfNull(customer, message.CustomerId);

            _customerService.RecalculateCustomerGrade(customer, message.Grade);
            await _unitOfWork.CommitAsync();
        }
    }
}
