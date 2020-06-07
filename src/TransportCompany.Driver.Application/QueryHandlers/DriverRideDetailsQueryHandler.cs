using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransportCompany.Driver.Application.Dto;
using TransportCompany.Driver.Application.Query;
using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Driver.Domain.Extensions;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Dto;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.Query
{
    public sealed class DriverRideDetailsQueryHandler : IQueryHandler<DriverRideDetailsQuery, DriverRideDetailsQueryDto>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverRideDetailsQueryHandler(IDriverUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DriverRideDetailsQueryDto> Handle(DriverRideDetailsQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(request.DriverId);
            Fail.IfNull(driver, request.DriverId);

            var ride = driver.Rides.SingleOrDefault(x => x.Id == request.Id);
            Fail.IfNull(ride, request.Id);

            var stops = ride.Stops
                .OrderFromStart()
                .Select(x => _mapper.Map<AddressDto>(x.Address));

            return new DriverRideDetailsQueryDto(
                stops.ToList(),
                _mapper.Map<MoneyDto>(ride.Income),
                _mapper.Map<CustomerDetailsDto>(ride.CustomerDetails),
                ride.Status);
        }
    }
}
