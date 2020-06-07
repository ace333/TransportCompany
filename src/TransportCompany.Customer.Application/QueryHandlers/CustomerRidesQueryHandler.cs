using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Application.Query;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Dto;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Infrastructure.Extensions;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.Application.QueryHandlers
{
    public class CustomerRidesQueryHandler: IQueryHandler<CustomerRidesQuery, PaginatedList<CustomerRidesQueryDto>>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerRidesQueryHandler(ICustomerUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CustomerRidesQueryDto>> Handle(CustomerRidesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RideRepository.GetFinishedRidesByCustomerId(request.Id)
                .Select(x => new CustomerRidesQueryDto
                {
                    Id = x.Id,
                    FinishedDate = x.FinishedDate,
                    CarModel = x.DriverDetails.CarModel,
                    Status = x.Status,
                    Price = _mapper.Map<MoneyDto>(x.Price)
                })
                .AsPaginatedList(request.GetPagingElements());
        }
    }
}
