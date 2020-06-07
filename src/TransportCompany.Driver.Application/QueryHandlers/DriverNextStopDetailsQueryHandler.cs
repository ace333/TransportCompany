using AutoMapper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransportCompany.Driver.Application.Dto;
using TransportCompany.Driver.Application.Query;
using TransportCompany.Driver.Domain.Services;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Dto;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Driver.Application.QueryHandlers
{
    public class DriverNextStopDetailsQueryHandler : IQueryHandler<DriverNextStopDetailsQuery, DriverNextStopDetailsQueryDto>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IRideService _rideService;
        private readonly IMapper _mapper;

        public DriverNextStopDetailsQueryHandler(IDriverUnitOfWork unitOfWork, 
            IRideService rideService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _rideService = rideService;
            _mapper = mapper;
        }

        public async Task<DriverNextStopDetailsQueryDto> Handle(DriverNextStopDetailsQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(request.DriverId);
            Fail.IfNull(driver, request.DriverId);

            var ride = driver.Rides.SingleOrDefault(x => x.Id == request.Id);
            Fail.IfNull(ride, request.Id);

            var stop = _rideService.GetNextStop(ride);

            return new DriverNextStopDetailsQueryDto(stop.Id, _mapper.Map<AddressDto>(stop.Address));
        }
    }
}
