using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Application.Query;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.QueryHandlers
{
    public class CustomerRideDetailsQueryHandler : IQueryHandler<CustomerRideDetailsQuery, CustomerRideDetailsQueryDto>
    {
        private readonly ICustomerUnitOfWork _customerUnitOfWork;
        private readonly IMapper _mapper;

        public CustomerRideDetailsQueryHandler(ICustomerUnitOfWork customerUnitOfWork,
            IMapper mapper)
        {
            _customerUnitOfWork = customerUnitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerRideDetailsQueryDto> Handle(CustomerRideDetailsQuery request, CancellationToken cancellationToken)
        {
            var ride = await _customerUnitOfWork.RideRepository.FindAsync(request.Id);
            Fail.IfNull(ride, request.Id);
            
            var addresses = ride.Routes.SelectMany(x => x.GetAddresses)
                .Distinct()
                .Select(x => _mapper.Map<AddressDto>(x));

            var moneyDto = _mapper.Map<MoneyDto>(ride.Price);
            var driverDetailsDto = _mapper.Map<DriverDetailsDto>(ride.DriverDetails);

            return new CustomerRideDetailsQueryDto(
                addresses.ToList(), 
                moneyDto, 
                ride.FinishedDate, 
                driverDetailsDto);
        }
    }
}
