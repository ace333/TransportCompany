using AutoMapper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransportCompany.Driver.Application.Dto;
using TransportCompany.Driver.Application.Query;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Dto;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Infrastructure.Model;
using TransportCompany.Shared.Infrastructure.Extensions;

namespace TransportCompany.Customer.Application.Query
{
    public sealed class DriverRidesQueryHandler : IQueryHandler<DriverRidesQuery, PaginatedList<DriverRidesQueryDto>>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverRidesQueryHandler(IDriverUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<PaginatedList<DriverRidesQueryDto>> Handle(DriverRidesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.RideRepository.GetAllCompletedRidesByDriverId(request.Id)
                .Select(x => new DriverRidesQueryDto
                {
                    Destination = _mapper.Map<AddressDto>(x.Stops
                        .OrderByDescending(y => y.UpdatedDate)
                        .FirstOrDefault().Address
                    ),
                    StartPoint = _mapper.Map<AddressDto>(x.Stops
                        .SingleOrDefault(y => y.PreviousPoint == null)
                        .Address
                    ),
                    CustomerDetails = _mapper.Map<CustomerDetailsDto>(x.CustomerDetails),
                    Income = _mapper.Map<MoneyDto>(x.Income),
                    Status = x.Status
                })
                .AsPaginatedList(request.GetPagingElements());
        }
    }
}
