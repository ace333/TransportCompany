using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Application.Query;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Infrastructure.Extensions;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.Application.QueryHandlers
{
    public sealed class CustomersQueryHandler: IQueryHandler<CustomersQuery, PaginatedList<CustomersQueryDto>>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public CustomersQueryHandler(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PaginatedList<CustomersQueryDto>> Handle(CustomersQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.CustomerRepository.GetAll()
                .Select(x => new CustomersQueryDto()
                {
                    Id = x.Id,
                    Name = x.PersonalInfo.Name,
                    Surname = x.PersonalInfo.Surname,
                    Email = x.PersonalInfo.Email,
                    Nationality = x.PersonalInfo.Nationality,
                    PhoneNumber = x.PersonalInfo.PhoneNumber
                })
                .AsPaginatedList(request.GetPagingElements());
        }
    }
}
