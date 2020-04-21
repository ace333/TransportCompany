using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Application.Query;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Infrastructure.Extensions;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.Application.QueryHandlers
{
    public class CustomerRidesQueryHandler: IQueryHandler<CustomerRidesQuery, PaginatedList<CustomerRidesQueryDto>>
    {
        private readonly ICustomerUnitOfWork _customerUnitOfWork;
        private readonly IMapper _mapper;

        public CustomerRidesQueryHandler(ICustomerUnitOfWork customerUnitOfWork, IMapper mapper)
        {
            _customerUnitOfWork = customerUnitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CustomerRidesQueryDto>> Handle(CustomerRidesQuery request, CancellationToken cancellationToken)
        {
            return await _customerUnitOfWork.RideRepository.GetRidesByCustomerId(request.Id)
                .Select(x => new CustomerRidesQueryDto
                {
                    FinishedDate = x.FinishedDate,
                    DriverDetails = _mapper.Map<DriverDetailsDto>(x.DriverDetails),
                    Routes = _mapper.Map<List<AddressDto>>(x.Routes),
                    Price = _mapper.Map<MoneyDto>(x.Price)
                })
                .AsPaginatedList(request.GetPagingElements());
        }
    }
}
