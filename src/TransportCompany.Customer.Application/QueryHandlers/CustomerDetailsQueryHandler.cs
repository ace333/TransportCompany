using System.Threading;
using System.Threading.Tasks;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Application.Query;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;

namespace TransportCompany.Customer.Application.QueryHandlers
{
    public class CustomerDetailsQueryHandler : IQueryHandler<CustomerDetailsQuery, CustomerDetailsQueryDto>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public CustomerDetailsQueryHandler(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDetailsQueryDto> Handle(CustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.FindAsync(request.Id);

            return new CustomerDetailsQueryDto(
                customer.PersonalInfo.Name,
                customer.PersonalInfo.Surname,
                customer.PersonalInfo.PhoneNumber,
                customer.PersonalInfo.Email,
                customer.PersonalInfo.Nationality,
                customer.SystemInfo.Grade);
        }
    }
}
